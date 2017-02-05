using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxManager.Models
{
    public static class DtoConverter
    {
        public static MunicipalityTax ToEntity(this MunicipalityTaxDTO municipalityTaxDto)
        {
            if (municipalityTaxDto.MunicipalityId == null)
            {
                var service = new TaxManagerService();
                municipalityTaxDto.MunicipalityId = service.GetMunicipalityId(municipalityTaxDto.MunicipalityName);
            }

            return new MunicipalityTax
            {
                MunicipalityId = municipalityTaxDto.MunicipalityId.Value,
                TaxValue = municipalityTaxDto.TaxValue,
                TaxTypeId = municipalityTaxDto.TaxType,
                PeriodStartDate = municipalityTaxDto.StartDate,
                PeriodEndDate = municipalityTaxDto.EndDate
            };
        }
    }
}