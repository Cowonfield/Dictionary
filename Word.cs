using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Word
    {
        
       public string Exampl { get; set; }
       public string Transl { get; set; }
       public Word( string word,string trans)
        {
            Exampl = word;
            Transl=trans;
         }

        
    }
}
