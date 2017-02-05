﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TaxManager.Models;
using TaxManager.Models.Enums;

namespace TaxManager
{
    /// <summary>
    /// The main service class that is responsible for managing municipality taxes
    /// </summary>
    public class TaxManagerService : ITaxManagerService
    {
        

        public bool InsertMunicipalityTax(string municipalityName, TaxType taxType, decimal taxValue, DateTime startDate, DateTime endDate)
        {
            try
            {
                var municipalityTax = new MunicipalityTax
                {
                    MunicipalityId = 1,
                    TaxTypeId = (int)taxType,
                    TaxValue = taxValue,
                    PeriodStartDate = startDate,
                    PeriodEndDate = endDate
                };

                using (var taxDbContext = new TaxManagerDBEntities())
                {
                    taxDbContext.MunicipalityTax.Add(municipalityTax);
                }
            }
            catch (Exception e)
            {
                // TODO: log the exception
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns municipalityId by a given municipality name (case insensitive)
        /// </summary>
        /// <param name="municipalityName"></param>
        /// <returns></returns>
        private int GetMunicipalityId(string municipalityName)
        {
            var municipalityId = -1;

            using (var taxDbContext = new TaxManagerDBEntities())
            {
                var municipality =
                    taxDbContext.Municipality.FirstOrDefault(
                        x => string.Equals(x.MunicipalityName, municipalityName, StringComparison.CurrentCultureIgnoreCase));

                //if (municipality != null)
                //{
                //    municipalityId = municipality.Id;
                //}

                municipalityId = municipality?.Id ?? -1;
            }

            return municipalityId;
        }
    }
}
