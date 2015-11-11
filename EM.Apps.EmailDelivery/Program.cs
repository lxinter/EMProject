using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using EM.Components.Business;
using EM.Components.Entities;
using System.Configuration;

namespace EM.Apps.EmailDelivery
{
    class Program
    {
        private static string _from = "";
        static void Main(string[] args)
        {
            Init();
            DateTime now = DateTime.Now;
            CampaignProvider provider = new CampaignProvider();
            var active = provider.GetActive();
            var current = active.Where(a => a.StartDate.Value < now && a.EndDate.Value > now);
            foreach (var c in current)
            {
                Send(c);
            }
            Console.ReadKey();
        }
        private static void Send(EM_Campaigns campaign)
        {
            Console.WriteLine("Starting process " + campaign.CampaignName);
            MailMessage message = new MailMessage();
            var email = campaign.EM_EmailInstances.FirstOrDefault<EM_EmailInstances>();
            message.Subject = email.SubjectLine;
           
            message.Body = email.EmailBody;
            message.From = new MailAddress(_from);
            message.ReplyToList.Add(new MailAddress(_from));
            message.IsBodyHtml = true;
            //var instances = email.EM_CampaignInstances;
            CampaignProvider provider = new CampaignProvider();
            var instances = provider.GetInstances(email.EmailInstanceID);
            foreach (var i in instances)
            {
                if (i.IsSent == false)
                {
                    string name = i.EM_Leads.FirstName;
                    message.To.Add(new MailAddress(i.EM_Leads.EmailAddress));
                    EmailHelper.Send(message);
                    provider.SetIsSent(i);
                }
            } Console.WriteLine("Finished processing " + campaign.CampaignName);
        }
        private static void Init()
        {
            _from = ConfigurationManager.AppSettings["from"];
        }
    }
}
