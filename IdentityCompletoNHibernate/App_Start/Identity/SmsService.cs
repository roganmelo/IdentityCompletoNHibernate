using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Threading.Tasks;
using Twilio;

namespace IdentityCompletoNHibernate.App_Start.Identity
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if (ConfigurationManager.AppSettings["Internet"] == "true")
            {
                // Utilizando TWILIO como SMS Provider.
                // https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

                const string accountSid = "SEU ID";
                const string authToken = "SEU TOKEN";

                var client = new TwilioRestClient(accountSid, authToken);

                client.SendMessage("814-350-7742", message.Destination, message.Body);
            }

            return Task.FromResult(0);
        }
    }
}