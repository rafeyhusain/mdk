using System.Configuration;

namespace model
{
	internal class Config
	{
        internal static string MailTemplateRoot
        {
            get { return ConfigurationManager.AppSettings["MailTemplateRoot"]; }
        }

        internal static string SmtpHost
        {
            get { return ConfigurationManager.AppSettings["SmtpHost"]; }
        }

        internal static int SmtpPort
        {
            get { return int.Parse(ConfigurationManager.AppSettings["SmtpPort"]); }
        }

        internal static string SmtpUser
        {
            get { return ConfigurationManager.AppSettings["SmtpUser"]; }
        }

        internal static string SmtpPassword
        {
            get { return ConfigurationManager.AppSettings["SmtpPassword"]; }
        }
    }
}
