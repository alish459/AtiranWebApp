//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebConnection.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class cust_act
    {
        public int rdf_ { get; set; }
        public int shmo { get; set; }
        public string date { get; set; }
        public decimal act_bes { get; set; }
        public decimal act_bed { get; set; }
        public string act_bedbes { get; set; }
        public string act_dis { get; set; }
        public int act_id { get; set; }
        public string user_id { get; set; }
        public decimal manafter { get; set; }
        public long ghno { get; set; }
        public string done_date { get; set; }
        public Nullable<System.DateTime> t_time { get; set; }
        public Nullable<int> HAct_id { get; set; }
        public bool ShowInReport { get; set; }
        public Nullable<int> DocNumber { get; set; }
        public string MoghayeratDiscription { get; set; }
        public Nullable<int> sysid { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<long> fk_id { get; set; }
        public Nullable<int> Rdf_ForDar { get; set; }
        public Nullable<decimal> GhestPriceTemp { get; set; }
        public Nullable<int> AccDocNumber { get; set; }
    
        public virtual CUSTOMERS CUSTOMERS { get; set; }
    }
}