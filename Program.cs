using System;
using System.Linq;

namespace Search_references_in_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            File file = new File();
            Console.WriteLine("Данные файла:");
            file.ShowRefList();
            Console.WriteLine();

            DB db = new DB();
            Console.WriteLine("Данные БД:");
            db.ShowDBList();
            Console.WriteLine();

            
            string[] array_file = file.references_list.Select(n => n.ToString()).ToArray();
            string[] array_db = db.db_list.Select(n => n.ToString()).ToArray();
            var new_array = array_file.Except(array_db);
            db.db_list.Clear();

            Console.WriteLine("Данные которые есть в файле, но отсутствуют в БД:");
            foreach (var item in new_array)
            {
                db.db_list.Add(item);
                Console.WriteLine(item);
            }

            db.InsertIntoDB();
        }
    }
}
