//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EM.Components.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class EM_EmailInstances
    {
        public EM_EmailInstances()
        {
            this.EM_CampaignInstances = new HashSet<EM_CampaignInstances>();
        }
    
        public int EmailInstanceID { get; set; }
        public Nullable<int> CampaignID { get; set; }
        public string SubjectLine { get; set; }
        public string EmailBody { get; set; }
        public Nullable<byte> Step { get; set; }
        public Nullable<byte> PreviousStep { get; set; }
        public Nullable<bool> EnableTracking { get; set; }
        public Nullable<bool> IsDraft { get; set; }
        public Nullable<int> Timespan { get; set; }
        public Nullable<System.DateTime> AbsoluteDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual ICollection<EM_CampaignInstances> EM_CampaignInstances { get; set; }
        public virtual EM_Campaigns EM_Campaigns { get; set; }
    }
}
