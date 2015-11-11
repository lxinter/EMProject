using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.ComponentModel;

namespace EM.Components.Entities
{
    
    [MetadataType(typeof(EM_CampaignsMetadata))]
    public partial class EM_Campaigns
    {
    }
    public class EM_CampaignsMetadata
    {
        [DisplayName("Name")]
        [Required()]
        public object CampaignName { get; set; }
        [DisplayName("Description")]
        [Required()]
        public object CampaignDesc { get; set; }
    }
    [MetadataType(typeof(EM_Campaigns_DataAnnotation))]
    public class EM_Campaigns_DataAnnotation
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public object StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public object EndDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public object ApprovedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public object CreatedDate { get; set; }
    }
}