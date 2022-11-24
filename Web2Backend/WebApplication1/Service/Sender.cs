using MimeKit;
using WebApplication1.Interfaces;
namespace WebApplication1.Service
{
    public class Sender : ISender//za email
    {
        private readonly Configuration _config;

        public Sender(Configuration config)
        {
            this._config = config;
        }
        public void Send(Message message)
        {
            var m = CreateEmailMessage(message);
            SendMesage(m);
        }
        #region fje
        private MimeMessage CreateEmailMessage(Message message)
        {
            var m = new MimeMessage();
            m.From.Add(new MailboxAddress(_config.From, _config.From));
            m.To.AddRange(message.To);
            m.Subject = message.Subject;
            m.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return m;
        }
        private void SendMesage(MimeMessage message)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.CheckCertificateRevocation = false;
                    client.Connect(_config.SmtpServer, _config.Port, MailKit.Security.SecureSocketOptions.Auto);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_config.Username, _config.Password);
                    client.Send(message);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
        #endregion
    }
}
