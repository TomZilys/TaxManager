using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxManager.Models
{
    public class MunicipalityTaxDTO
    {
        public string MunicipalityName { get; set; }
        public int TaxType { get; set; }
        public decimal TaxValue { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
    }
}