using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioSmsUwp
{
    public class MessageSender
    {
        private readonly string _phonenumber;

        public MessageSender()
        {
            var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            _phonenumber = Environment.GetEnvironmentVariable("TWILIO_PHONE_NUMBER");

            TwilioClient.Init(accountSid, authToken);
        }
        public void SendSms(string toNumber, string body)
        {
            try
            {
                //Add the country code to the phone number if it is not there
                if (!toNumber.StartsWith("+1"))
                    toNumber = $"+1{toNumber}";

                var message = MessageResource.Create(
                    body: body,
                    @from: new PhoneNumber(_phonenumber),
                    to: new PhoneNumber(toNumber)
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}