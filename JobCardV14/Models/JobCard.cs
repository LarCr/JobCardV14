//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobCardV14.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobCard
    {
        public int JobId { get; set; }
        public int CustId { get; set; }
        public int EngId { get; set; }
        public string JobDetails { get; set; }
        public string SiteContact { get; set; }
        public string PartsUsed { get; set; }
        public System.DateTime Date { get; set; }
        public string TimeOnSite { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Engineer Engineer { get; set; }
    }
}