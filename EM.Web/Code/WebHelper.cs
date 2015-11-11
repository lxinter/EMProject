using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EM.Web.Code
{
    public class WebHelper
    {
        public static bool Convert(bool? value)
        {
            if (value != null) return value.Value;
            else return false;
        }
        public const string TempDataCampaignID = "cid";
        public const string ViewDataCampaignName = "cname";
    }
}