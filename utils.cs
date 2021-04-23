using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace BrainStorm.CortexAccess
{
    public class Utils
    {
        public static Int64 GetEpochTimeNow()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            Int64 timeSinceEpoch = (Int64)t.TotalMilliseconds;
            return timeSinceEpoch;

        }
        public static string GenerateUuidProfileName(string prefix)
        {
            return prefix + "-" + GetEpochTimeNow();
        }


        public static void SendEmail(string subject, string message = "", string senderAddress = "jett2.718hays@gmail.com", string recipientAddress = "jettblufabrications@gmail.com")
        {
            var pWord = Properties.Settings.Default.EmailPassword;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                message += "\nThis message is made possible by Brainstorm, a more efficient mind controlled keyboard.";
                mail.From = new MailAddress(senderAddress);
                mail.To.Add(recipientAddress);
                mail.Subject = subject;
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(senderAddress, pWord);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                UserMessage("Email sent with a smile.", Globals.MessageTypes.Status);
            }
            catch (Exception ex)
            {
                UserMessage("Email not sent. Hint: check 'less secure access' setting on your Gmail account. P.S.: File was most likely saved.", Globals.MessageTypes.Status);
            }
        }

        public static void UserMessage(string message, Globals.MessageTypes messageType = Globals.MessageTypes.None, bool throwError = false, bool saveMessage = false, int errorCode = 0)
        {
            var msg = string.Empty;

            switch (messageType)
            {
                case Globals.MessageTypes.None:
                    break;
                case Globals.MessageTypes.Error:
                    msg = $"Error: {message}, Code = {errorCode}";
                    MessageBox.Show(msg);
                    break;
                case Globals.MessageTypes.Status:
                    msg = $"Status: {message}, Code = {errorCode}";
                    MessageBox.Show(msg);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
            }

            if (!throwError) return;
            throw new ApplicationException(msg);
        }
        public static bool ProcessMessageBoxYesNo(string msg, string title)
        {
            var dialogResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo);
            return dialogResult == DialogResult.Yes;
        }

    }
}