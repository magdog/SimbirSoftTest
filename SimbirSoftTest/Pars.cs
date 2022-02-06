using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftTest
{
    public class Pars
    {
        public void Parss()
        {
            IntroductPathPage introductPathPage = new IntroductPathPage();
            string address = introductPathPage.RedPathPage();
            DowloadStringHTML dowloadStringHTML = new DowloadStringHTML(address);
            dowloadStringHTML.SaveHTMLPages();
            ParsPage parsPage = new ParsPage(address);
            parsPage.Work();
        }
    }
}
