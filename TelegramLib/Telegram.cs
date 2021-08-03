using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TelegramLib
{
    public class Telegram
    {
        private string NumberToSendMessage { get; set; }
        private string NumberToAuthenticate { get; set; }
        private string CodeToAuthenticate { get; set; }
        private string PasswordToAuthenticate { get; set; }
        private string NotRegisteredNumberToSignUp { get; set; }
        private string UserNameToSendMessage { get; set; }
        private string NumberToGetUserFull { get; set; }
        private string NumberToAddToChat { get; set; }
        private string ApiHash { get; set; }
        private int ApiId { get; set; }

        public Telegram()
        {

        }

        public void Init()
        {
            GatherTestConfiguration();
        }

        /*
        public virtual async Task AuthUser()
        {
            var client = NewClient();

            await client.ConnectAsync();

            var hash = await client.SendCodeRequestAsync(NumberToAuthenticate);
            var code = CodeToAuthenticate; // you can change code in debugger too

            if (String.IsNullOrWhiteSpace(code))
            {
                throw new Exception("CodeToAuthenticate is empty in the app.config file, fill it with the code you just got now by SMS/Telegram");
            }

            TLUser user = null;
            try
            {
                user = await client.MakeAuthAsync(NumberToAuthenticate, hash, code);
            }
            catch (CloudPasswordNeededException ex)
            {
                var password = await client.GetPasswordSetting();
                var password_str = PasswordToAuthenticate;

                user = await client.MakeAuthWithPasswordAsync(password, password_str);
            }
            catch (InvalidPhoneCodeException ex)
            {
                throw new Exception("CodeToAuthenticate is wrong in the app.config file, fill it with the code you just got now by SMS/Telegram",
                                    ex);
            }
        }

        public virtual async Task SendMessageTest()
        {
            NumberToSendMessage = ConfigurationManager.AppSettings[nameof(NumberToSendMessage)];
            if (string.IsNullOrWhiteSpace(NumberToSendMessage))
                throw new Exception($"Please fill the '{nameof(NumberToSendMessage)}' setting in app.config file first");

            // this is because the contacts in the address come without the "+" prefix
            var normalizedNumber = NumberToSendMessage.StartsWith("+") ?
                NumberToSendMessage.Substring(1, NumberToSendMessage.Length - 1) :
                NumberToSendMessage;

            var client = NewClient();

            await client.ConnectAsync();

            var result = await client.GetContactsAsync();

            var user = result.Users
                .OfType<TLUser>()
                .FirstOrDefault(x => x.Phone == normalizedNumber);

            if (user == null)
            {
                throw new System.Exception("Number was not found in Contacts List of user: " + NumberToSendMessage);
            }

            await client.SendTypingAsync(new TLInputPeerUser() { UserId = user.Id });
            Thread.Sleep(3000);
            await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, "TEST");
        }
        */

        public async Task Connect()
        {
            try
            {
                //var client = new TelegramClient(API_ID, API_HASH);
                //await client.ConnectAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private void GatherTestConfiguration()
        {
            ApiHash = ConfigurationManager.AppSettings[nameof(ApiHash)];

            var apiId = ConfigurationManager.AppSettings[nameof(ApiId)];
            ApiId = int.Parse(apiId);

            NumberToAuthenticate = ConfigurationManager.AppSettings[nameof(NumberToAuthenticate)];

            CodeToAuthenticate = ConfigurationManager.AppSettings[nameof(CodeToAuthenticate)];

            PasswordToAuthenticate = ConfigurationManager.AppSettings[nameof(PasswordToAuthenticate)];

            NotRegisteredNumberToSignUp = ConfigurationManager.AppSettings[nameof(NotRegisteredNumberToSignUp)];

            UserNameToSendMessage = ConfigurationManager.AppSettings[nameof(UserNameToSendMessage)];

            NumberToGetUserFull = ConfigurationManager.AppSettings[nameof(NumberToGetUserFull)];

            NumberToAddToChat = ConfigurationManager.AppSettings[nameof(NumberToAddToChat)];
        }

        private TelegramClient NewClient()
        {
            try
            {
                return new TelegramClient(ApiId, ApiHash);
            }
            catch (MissingApiConfigurationException ex)
            {
                throw new Exception($"Please add your API settings to the `app.config` file. (More info: {MissingApiConfigurationException.InfoUrl})",
                                    ex);
            }
        }


    }
}
