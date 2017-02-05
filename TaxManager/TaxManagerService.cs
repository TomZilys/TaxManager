using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using log4net;
using Newtonsoft.Json;
using TaxManager.Models;

namespace TaxManager
{
    /// <summary>
    /// The main service class that is responsible for managing municipality taxes
    /// </summary>
    public class TaxManagerService : ITaxManagerService
    {
        private ILog logger;
        public TaxManagerService()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.logger = LogManager.GetLogger(typeof(TaxManagerService));
            logger.Info("service started");
            var dataPath = ConfigurationManager.AppSettings["DataDirectory"];
            AppDomain.CurrentDomain.SetData("DataDirectory", dataPath);
        }

        /// <summary>
        /// Return specific municipality tax by municipality name and date
        /// </summary>
        /// <param name="municipalityName"></param>
        /// <param name="dateTime"></param>
        public decimal GetMunicipalityTax(string municipalityName, DateTime dateTime)
        {
            try
            {
                var municipalityId = GetMunicipalityId(municipalityName);

                using (var taxDbContext = new TaxManagerDBEntities())
                {
                    var tax = taxDbContext.MunicipalityTax
                        .Where(x => x.MunicipalityId == municipalityId &&
                                    x.PeriodStartDate <= dateTime &&
                                    x.PeriodEndDate > dateTime)
                        .OrderBy(y => y.TaxTypeId).FirstOrDefault();


                    if (tax != null)
                    {
                        return tax.TaxValue;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Error has occurred in GetMunicipalityTax", e);
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Inserts municipality tax
        /// </summary>
        /// <param name="municipalityName"></param>
        /// <param name="taxType"></param>
        /// <param name="taxValue"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool InsertMunicipalityTax(MunicipalityTaxDTO municipalityTaxDto)
        {
            logger.Info("performing inserrt");
            try
            {
                var municipalityTax = municipalityTaxDto.ToEntity();
                InsertMunicipalityTaxToDb(municipalityTax);
            }
            catch (Exception e)
            {
                logger.Error("Error has occurred in InsertMunicipalityTax", e);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Imports taxes from a JSON file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool InsertMunicipalityTaxesFromFile(string filePath)
        {
            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    var serializer = new JsonSerializer();
                    var taxList = (List<MunicipalityTaxDTO>)serializer.Deserialize(file, typeof(List<MunicipalityTaxDTO>));

                    foreach (var taxDto in taxList)
                    {
                        InsertMunicipalityTax(taxDto);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Error has occurred in InsertMunicipalityTaxesFromFile", e);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns municipalityId by a given municipality name (case insensitive)
        /// </summary>
        /// <param name="municipalityName"></param>
        /// <returns></returns>
        internal int GetMunicipalityId(string municipalityName)
        {
            var municipalityId = -1;

            using (var taxDbContext = new TaxManagerDBEntities())
            {
                var municipality =
                    taxDbContext.Municipality.FirstOrDefault(
                        x => string.Equals(x.MunicipalityName, municipalityName));

                municipalityId = municipality?.Id ?? -1;
            }

            return municipalityId;
        }

        /// <summary>
        /// Inserts Tax to DB
        /// </summary>
        /// <param name="municipalityTax"></param>
        private void InsertMunicipalityTaxToDb(MunicipalityTax municipalityTax)
        {
            using (var taxDbContext = new TaxManagerDBEntities())
            {
                taxDbContext.MunicipalityTax.Add(municipalityTax);
                taxDbContext.SaveChanges();
            }
        }
    }
}
