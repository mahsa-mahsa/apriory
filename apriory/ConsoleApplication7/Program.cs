using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 tt = new Class1();
            List<content> lis_komaki = new List<content>();
            int degree = 0;
            List<string> list_string = new List<string>();
            List<string> list_string2 = new List<string>();
            List<string> komaki = new List<string>();
            Console.WriteLine("enter you min_sup number:" + "\n");
            string v = Console.ReadLine();
            int min_sup = int.Parse(v);
            Console.WriteLine("enter file_path"+"\n");
           
            string path = Console.ReadLine();
           list_string=Class1.filecsv(path);
           komaki = list_string;

            foreach (string ff in list_string)
            {
                string[] yy = ff.Split(';');
                foreach (string jjj in yy)
                {
                    list_string2.Add(jjj);
                }
            }
         
            for (int i = 0; i < list_string2.Count; i++)
            {


                tt.list.Add(new content());
                tt.list[list_string2.IndexOf(list_string2[i])].count++;
                tt.list[list_string2.IndexOf(list_string2[i])].str = list_string2[i];
            }

            for (int yy = 0; yy < tt.list.Count; yy++)
            {
                if (tt.list[yy].str == null)
                {
                    tt.list.RemoveAt(yy);
                    yy--;
                }
            }

            for (int i = 0; i < tt.list.Count; i++)
            {
                if (tt.list[i].count <min_sup)
                {
                    tt.list.Remove(tt.list[i]);
                    i--;
                }


            }

            degree = tt.list.Count;


            for (int i = 1; i <= degree; i++)
            {


                if (tt.list.Count != 0)
                {

                    lis_komaki.Clear();
                    for (int jjj = 0; jjj < tt.list.Count; jjj++)
                    {
                        lis_komaki.Add(tt.list[jjj]);
                    }
                    tt.join2(i+1, list_string,min_sup);


                }

            }

            Console.WriteLine("frequent is" + "\n");
                    for (int iii = 0; iii < lis_komaki.Count; iii++)
                    {
                      Console.WriteLine( lis_komaki[iii].str  + " " + lis_komaki[iii].count + "\n");
                     
                        
                    }
                    
                
                Console.ReadKey();


            }




        }
    }
