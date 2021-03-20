using System;
using System.Collections.Generic;
using System.IO;

namespace Search_references_in_DB
{
    class File
    {
        public List<string> references_list = new List<string>();
        public File()
        {
            using (var file = new StreamReader("Internet search system.txt"))
            {
                while(!file.EndOfStream)
                {
                    references_list.Add(file.ReadLine());
                }
            }
        }

        public void ShowRefList()
        {
            foreach (var item in references_list)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
