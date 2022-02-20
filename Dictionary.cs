using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
namespace ConsoleApp22
{
    class Dictionary
    {
        public Dictionary<string, string> dict = new Dictionary<string, string>();
        
        
        public Dictionary(int direction)
        {
               string[] str= File.ReadAllLines($"../../Dictionary_en_ru.txt",System.Text.Encoding.UTF8);
                foreach (string line in str)
                {
                    string[] words = line.Split('-');
                    if (direction == 1)
                        dict.Add(words[0], words[1]);
                    else
                        dict.Add(words[1], words[0]);
                }
            
        }
        public void Add(Word new_word)
        {
            dict.Add(new_word.Exampl, new_word.Transl);
        }
        public void Dell(Word b)
        {
           dict.Remove(b.Exampl);
        }
        public Word Get(string user_word)
        {
            Word w = null;
            foreach (var word in dict)
                if (word.Key == user_word)
                {
                    w = new Word(word.Key, word.Value);
                }
            return w;
        }
        public Word Edit(Word b)
        {
            try
            {
                foreach (var word in dict)
                {
                    if (word.Key == b.Exampl)
                    {
                        dict.Remove(word.Key);
                        Console.WriteLine("Enter your choice: 1-to edit word; 2- to edit translation ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice < 0 || choice > 2)
                            Console.WriteLine("Wrong choice!");
                        else
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Enter new word");
                                    string str = Console.ReadLine();
                                    b.Exampl = str;
                                    break;
                                case 2:

                                    Console.WriteLine("Enter new translation");
                                    string str1 = Console.ReadLine();
                                    b.Transl = str1;
                                    break;
                            }
                        dict.Add(b.Exampl, b.Transl);
                        return b;
                    }

                }
            }

            catch { Console.WriteLine("We haven't this word "); }
            return null;
        }


        public void Print()
        {
            foreach (var copy in dict)
            {
                Console.WriteLine($"{copy.Key} - {copy.Value}\n");

            }
        }
     
        public void Get_transl(string word)
        {
          
            try
            {
                foreach (var ex in dict)
                    if (ex.Key == word)
                    {
                        Console.WriteLine($"{ex.Value}");
                        Console.WriteLine("If you want save rezult-press 'y'");
                        char rez = Convert.ToChar(Console.ReadLine());
                        if (rez == 'y')
                            Console.WriteLine("Enter path for saving");
                        string path = Console.ReadLine();
                        File.WriteAllText(path, $"{ex.Key}-{ex.Value}");
                     }
            }
             catch   
                {
                Console.WriteLine( "We have't this word in our dictionary!");
                }
            
           
        }
        public void Save(string path)
        {
            try
            {
                File.WriteAllLines(path, dict.Select(x => x.Key+"-"+x.Value));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"File Exception {ex.Message}");
            }
        }
        public void Read_from_file(string path)
        {
            try
            {
                Word b;
                string[] str = File.ReadAllLines(path);
                foreach (string copy in str)
                {
                    string[] word = copy.Split('-');
                    b = new Word(word[0], word[1]);
                    dict.Add(b.Exampl, b.Transl);
                    Console.WriteLine($" {copy}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File Exception {ex.Message}");
            }

        }
     
        }
}
