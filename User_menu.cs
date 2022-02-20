using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class User_menu:Dictionary
    {
        public User_menu(int dir) : base(dir) { }
        
        public void Menu(Dictionary examp)
        {
            bool job = true;
           while(job)
            {
                Console.WriteLine("Enter your choice:1-Add new word; 2-Dellete word; 3-edit word or translation; 4-search translation;" +
                " 5- save into file; 6-read from file; 7-show all dictionary; 0-exit;");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                      Console.WriteLine("Enter new word - ");
                        string str1 = Console.ReadLine();
                        Console.WriteLine("Translation - ");
                       string str2= Console.ReadLine();
                        Word b = new Word(str1, str2);
                        examp.Add(b);
                        break;
                    case 2:
                        Console.WriteLine("Enter  word for deletion");
                        string str = Console.ReadLine();
                      
                       try
                        {
                         
                              examp.Dell(examp.Get(str));
                               
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"File Exception {ex.Message}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter word for edition");
                         str =  Console.ReadLine();
                         examp.Edit(examp.Get(str));
                         break;
                    
                    case 4:
                        Console.WriteLine("Enter word");
                        string word = Console.ReadLine();
                        examp.Get_transl(word);
                        break;
                    case 5:
                        Console.WriteLine("Enter path for saving");
                        string path = Console.ReadLine();
                        examp.Save(path);
                        break;
                    case 6:
                        Console.WriteLine("Enter path for reading");
                         path = Console.ReadLine();
                        examp.Read_from_file(path);
                        break;
                    case 7:
                        examp.Print();
                        break;
                    case 0:
                        job = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            }
        }
    }
}
