using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace SimbirSoftTest
{
    public class ParsPage
    {
        public IEnumerable<Stats> Stats;
        public string Site { get; private set; }
        public ParsPage(string sites)
        {
            Site = sites;
        }
        public void Work()
        {
            using (var db = new Context())
            {
                try
                {
                    Console.WriteLine("Words of - " + Site);
                    Console.WriteLine("//////////////////////////////");
                    string text = ReadTextFromSite(Site);
                    var result = Calc(text);
                    result.Remove("");
                    foreach (var pair in result)
                    {
                        Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                        Console.WriteLine("//////////////////////////////");
                        Stats stats = new Stats()
                        {
                            CreateDate = DateTime.Now,
                            Status = pair.Key,
                            Value = pair.Value
                        };
                        db.Set<Stats>().Add(stats);
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {                
                    Log.Error(e, "Произошла ошибка"); 
                }
            }
        }
        static Dictionary<string, int> Calc(string site)
        {
            var res = new Dictionary<string, int>();      
            try
            {
                foreach (var word in site.Split(' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t', '#', '&', '@').Skip(1))
                {
                    var count = 0;
                    res.TryGetValue(word, out count);
                    res[word] = count + 1;
                }
            }
            catch (Exception e) { Log.Error(e,"Произошла ошибка"); }
            return res;
        }
        public string ReadTextFromSite(string site)
        {
            HtmlWeb htmlWeb = new HtmlWeb();// Он по полученной html страницы скачивает документ и его полностью получает 
            try
            {
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(site);
                return document.DocumentNode.InnerText;
            }
            catch (Exception e)
            {
                Log.Error(e, "Произошла ошибка");
                return null;
            }
        }
    }
}
