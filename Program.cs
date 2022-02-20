using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter direction: 1-en to ru; 2-ru to en");
            int choice = Convert.ToInt32(Console.ReadLine());
               // Console.WriteLine("Enter path to file");
          //  string path = Console.ReadLine();
            Dictionary ex = new Dictionary(choice);
            User_menu first = new User_menu(choice);
            first.Menu(ex);

        }
    }
}
