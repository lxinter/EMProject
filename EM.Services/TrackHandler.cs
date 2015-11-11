using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EM.Components.Business;

namespace EM.Services
{
    public class TrackHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            // get campaign instance Guid from URL
            try
            {
                string url = context.Request.RawUrl;
                string id = context.Request.QueryString["id"];
                CampaignProvider provider = new CampaignProvider();
                provider.TrackCampaignView(id);
            }
            catch
            {
                //should keep applicaiton running
            }
            // return image
            context.Response.ContentType = "image/jpeg";
            context.Response.TransmitFile(
            HttpContext.Current.Server.MapPath("/images/email-marketing.jpg"));
        }
    }
}