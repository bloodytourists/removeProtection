using System;
using System.Collections.Generic;

using Microsoft.InformationProtection;

namespace mipsdk
{
    public class Program
    {
        private static string clientId;
        private static string appName;
        private static string appVersion;

        static int Main(string[] args)
        {
           AppConfig config = new AppConfig();
           clientId = config.GetClientId();
           appName = config.GetAppName();
           appVersion = config.GetAppVersion();

           ApplicationInfo appInfo = new ApplicationInfo()
            {
                // ApplicationId should ideally be set to the same ClientId found in the Azure AD App Registration.
                // This ensures that the clientID in AAD matches the AppId reported in AIP Analytics.
                ApplicationId = clientId,
                ApplicationName = appName,
                ApplicationVersion = appVersion
            };

            Console.WriteLine("Enter full filepath you wish to decrypt (i.e c:\\temp\\myfile.docx): ");
            var inputFile = Console.ReadLine();
            Console.WriteLine("Enter different output filepath (i.e c:\\temp\\newfile.docx): ");
            var outputFile = Console.ReadLine();

            Action action2 = new Action(appInfo);

            action2.RemoveProtection(inputFile, outputFile);

            System.Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
            return 0;                  
        }        
    }
}
