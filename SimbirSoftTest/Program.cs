using System;
using Serilog;
namespace SimbirSoftTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Console()
              .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();
            Console.WriteLine("Здравствуйте Нажми Enter для старта");
            Console.ReadKey();
            for (; ; )
            {
                Console.WriteLine("Для парсинка сайта нажмите 1. Для выхода из программы любую другую кнопку");
                string command = Console.ReadLine();
                try
                {
                    int comman = Convert.ToInt32(command);
                    if (comman == 1)
                    {
                        Pars pars = new Pars();
                        pars.Parss();
                    }
                    else
                    { Console.WriteLine("Спасибо за использование программы.Нажмите пробел для выхода"); 
                      Console.ReadKey(); 
                      break; 
                    }
                }
                catch(Exception e) { Console.WriteLine(@$"Программа завершилась с ошибкой: {e}"); }
            }        
        }
    }
}
