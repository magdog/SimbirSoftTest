using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftTest
{
    public class IntroductPathPage
    {
        public string RedPathPage()
        {
            Console.WriteLine("Введите путь страницы");
            string address = Console.ReadLine();
            return address;
        }
    }
}
