using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxManager.Models.Enums;

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
            var service = new TaxManagerService();
            var result = service.InsertMunicipalityTax("testingmunicipality", (int)TaxType.Daily, (decimal)0.08, DateTime.Today, DateTime.Today);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestInsertMunicipalityTaxesFromFile()
        {
            var service = new TaxManagerService();
            service.InsertMunicipalityTaxesFromFile("");
        }
    }
}
