using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figonx
{
    public class FigonxSendJPGToDiscordBot
    {
        public void SendJPGToDiscordBot(string process_disbot_name)
        {
            bool finded_success = Process.GetCurrentProcess().ProcessName.Contains("Figonx");
            if (finded_success)
            {
                Process.Start(process_disbot_name, String.Empty); //Project is FigonxDiscordBot.exe with SharpDX and Costura :D
            }
            else
            {
                throw new Exception("Figonx is Not Founded or is Not Successfully Launched!!!");
            }
        }
        public string GetCurrentJPGLocation()
        {
            //Finding All JPG And Sending To Discord Bot or Deleting JPG :D
            string jpg_loc = String.Empty;
            string current_folder = Environment.CurrentDirectory; //Current Directory to Find JPG Files and Sending to Current Discord Bot :D
            DirectoryInfo dir = new DirectoryInfo(current_folder); // DirectoryInformation about CurrentDirectory :D
            FileInfo[] file = dir.GetFiles("*.jpg", SearchOption.AllDirectories); //Searching JPG Files and AllDirectories in CurrentDirectory :D
            foreach (FileInfo send_jpg in file)
            {
                //FullName JPG Location :D
                jpg_loc = send_jpg.FullName;
            }
            //Returning Current JPG Location... 
            return jpg_loc;
        }
    }
}
