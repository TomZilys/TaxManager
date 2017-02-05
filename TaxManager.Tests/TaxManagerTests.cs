using System;
using System.Collections.Generic;
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
        [TestMethod]
        public void TestGetMunicipalityId()
        {
            var service = new TaxManagerService();
            service.InsertMunicipalityTax("testingmunicipality", TaxType.Daily, (decimal)0.08, DateTime.Today, DateTime.Today);
        }
    }
}
