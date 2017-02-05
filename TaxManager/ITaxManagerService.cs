using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TaxManager.Models.Enums;

namespace TaxManager
{
    [ServiceContract]
    public interface ITaxManagerService
    {
        [OperationContract]
        bool InsertMunicipalityTax(string municipalityName, int taxType, decimal taxValue, DateTime startDate, DateTime endDate);
    }
}
