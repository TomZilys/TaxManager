using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxManager.Models;
using TaxManager.Models.Enums;
using TaxManager.Tests.TaxManagerService;

namespace TaxManager.Tests
{
    [TestClass]
    public class TaxManagerTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Setting the path of database
            var dataPath = ConfigurationManager.AppSettings["DataDirectory"];
            AppDomain.CurrentDomain.SetData("DataDirectory", dataPath);
        }

        [TestMethod]
        public void TestInsertMunicipalityTax()
        {
            var service = new TaxManager.TaxManagerService();

            var result = service.InsertMunicipalityTax(new MunicipalityTaxDTO
            {
                MunicipalityName = "testingmunicipality",
                TaxType = (int)TaxType.Daily,
                TaxValue = 0.08m,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            });
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestInsertMunicipalityTaxesFromFile()
        {
            var service = new TaxManager.TaxManagerService();
            var result = service.InsertMunicipalityTaxesFromFile(@"c:\import.json");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestHostedService()
        {
            var client = new TaxManagerServiceClient();
            var result = client.InsertMunicipalityTax(new MunicipalityTaxDTO
            {
                MunicipalityName = "testingmunicipality",
                TaxType = (int)TaxType.Daily,
                TaxValue = 0.07m,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetMunicipalityTax()
        {
            var service = new TaxManager.TaxManagerService();
            var result = service.GetMunicipalityTax("Vilnius", DateTime.Parse("2016-01-01"));
            Assert.IsTrue(result == 0.1m);

            result = service.GetMunicipalityTax("Vilnius", DateTime.Parse("2016-05-02"));
            Assert.IsTrue(result == 0.4m);

            result = service.GetMunicipalityTax("Vilnius", DateTime.Parse("2016-07-10"));
            Assert.IsTrue(result == 0.2m);

            result = service.GetMunicipalityTax("Vilnius", DateTime.Parse("2016-03-16"));
            Assert.IsTrue(result == 0.2m);
        }
    }
}
