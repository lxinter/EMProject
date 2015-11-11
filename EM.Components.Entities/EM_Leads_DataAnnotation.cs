using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EM.Components.Entities
{

    [MetadataType(typeof(EM_LeadsMetadata))]
    public partial class EM_Leads
    {
    }
    public class EM_LeadsMetadata
    {
        [DisplayName("First Name")]
        [Required()]
        public object FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required()]
        public object LastName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9azA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Not a valid email")]
        public object EmailAddress { get; set; }
    }

}
