using Serilog;
using System;
using System.IO;
using System.Net;

namespace SimbirSoftTest
{
    public class DowloadStringHTML
    {    
        public string Text { get; private set; }
        public DowloadStringHTML(string text)
        {
            Text = text;
        }
        public void SaveHTMLPages()
        {          
                try
                {
                    using (WebClient client = new WebClient())
                    { 
                    string directory = Directory.GetCurrentDirectory();
                    Console.WriteLine(Text);
                    string html = client.DownloadString(Text);
                    File.WriteAllText(directory + @"\" + ".html", html);
                    Console.WriteLine("Файл сохранен");
                    }
                }
                catch (Exception e)
                {
                Log.Error(e, "Произошла ошибка");
                }
        }
    }
}
