using System;
using System.ComponentModel.DataAnnotations;

namespace AbstractSweetShopServiceDAL.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateFrom { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateTo { get; set; }
    }
}
