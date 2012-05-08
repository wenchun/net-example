using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;

namespace NorthwindModel
{
    [MetadataType(typeof(OrderMetadata))]
    public partial class Order
    {
        public class OrderMetadata
        {
            [Editable(false)]
            public object OrderID { get; set; }

            [Display(Name = "訂購日期")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            public object OrderDate { get; set; }

            [DisplayFormat(DataFormatString="{0:N}")]
            public object Freight;

        }
    }
}