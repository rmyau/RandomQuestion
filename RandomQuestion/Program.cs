using System;
using System.IO;
using System.Collections.Generic;
namespace RandomQuestion
{
    class Program
    { static List <int> F  (string[] a)
        {
            List<int> b = new List <int>();
            string[] s1, s2;
            for (int i = 0; i < a.Length-1;i++)
            {
                s1 = a[i].Split(',');
                s2 = a[i + 1].Split(",");
                for (int j = 0; j < s1.Length; j++)
                    b.Add(Convert.ToInt32(s1[j]));
                    

                for (int j = Convert.ToInt32(s1[s1.Length - 1])+1; j < Convert.ToInt32(s2[0]); j++)
                    b.Add(j); 
                if (i + 1 == a.Length - 1)
                    for (int j = 0; j < s2.Length; j++)
                        b.Add(Convert.ToInt32(s2[j]));
                       
            }
            return b;
        }
        static void Main(string[] args)
        {
            FileInfo f = new FileInfo("qwest.txt");
            StreamReader file = f.OpenText();
            string[] text = (file.ReadToEnd()).Split("\n");
            Random rand = new Random();
            
            Console.WriteLine("Введите диапазон вопросов через тире и запятые");
            string[] qw = Console.ReadLine().Split("-");
            //Console.WriteLine("len qw - {0}", qw.Length);
            List<int> Qw = F(qw);
            //Console.WriteLine("count qw - {0}", Qw.Count);
            List <int> IsUse = new List<int>();
            for (int i = 0; i < Qw.Count; i++)
                IsUse.Add(0);
            //Console.WriteLine("count isuse - {0}", IsUse.Find(x => x == 0));
            // bool stop = false;

            while (IsUse.Find(x=>x==0)==0)
            {
                int r = rand.Next(0, text.Length);
                if (Qw.FindIndex(x => x == (r + 1)) != -1 && IsUse[Qw.FindIndex(x => x == (r + 1))] == 0)
                {
                    Console.WriteLine(text[r]);
                    IsUse[Qw.FindIndex(x => x == (r + 1))] = 1;
                }
            }

        }
    }
}
