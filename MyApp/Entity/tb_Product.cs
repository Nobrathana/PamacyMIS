//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyApp.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Product
    {
        public string PRO_ID { get; set; }
        public string PRO_CODE { get; set; }
        public string PRO_NAME { get; set; }
        public Nullable<decimal> PRO_PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public string BRD_ID { get; set; }
        public string CAT_ID { get; set; }
        public string CREATE_BY { get; set; }
        public Nullable<System.DateTime> CREATE_AT { get; set; }
        public Nullable<bool> STATUS { get; set; }
    
        public virtual tb_Brand tb_Brand { get; set; }
        public virtual tb_Category tb_Category { get; set; }
    }
}