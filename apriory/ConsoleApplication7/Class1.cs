using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication7
{
    public class content
    {
        public int count;
        public string str;
        public content(int _C, string _str)
        {
            count = _C;
            str = _str;
        }
        public content()
        { }

    }
  public class Class1
    {
       
      public List<content> list;

       public Class1()
       {
      
          list =new List<content>();
       }

        
       public Class1(string b)
       {
         
       }
      public bool search(string a, string b)
      {
          bool flag = false;
          for (int i = 0; i < b.Length; i++)
          {
              flag = false;
              for (int j = 0; j <a.Length; j++)
              {
                  if (a[j] == b[i])
                  {
                      flag = true;
                      break;
                  }
              }
              if (flag==false)
              break;

          }

          return flag;
      
                  
      }
      public string join1(string a, string b)
      {
          string bb = "";
        string[]s= a.Split(';');
        string[] s1 = b.Split(';');
          
      bool flag = false;
      for (int i = 0; i < s.Length; i++)
      {
          flag = false;
          for (int j = 0; j < s1.Length;j++)
          {
              if (s[i] == s1[j])
              {
                  flag = true;
                  break;
              }


          }
          if (flag == false)
              bb+= s[i]+";";
      }
          for(int i=0;i<s1.Length;i++)
          {
          bb+= s1[i] + ";";
          }
             bb= bb.Substring(0, bb.Length - 1);


      
         
      return bb;

      }
      public bool Equal(string str1, string str2)
      {
          bool flag = false;

          string[] s1 = str1.Split(';');
          string[] s2 = str2.Split(';');
          if (s1.Length != s2.Length)
              return false;
          else
          {
              for (int i = 0; i < s1.Length; i++)
              {
                  flag = false;
                  for (int j = 0; j < s2.Length; j++)
                  {
                      if (s1[i] == s2[j])
                      {
                          flag = true;
                          break;
                      }
                  }
                  if (flag == false)
                      return false;
              }
              return true;
          }
      }
      public List<content> join2(int degree,List<string> ff,int min_sup)
      {
          List<string> ll = new List<string>();
          List<string> final_ll = new List<string>();
          int q = 0;

          for (int i = 0; i <list.Count; i++)
          {
              for (int j = i+1; j <list.Count; j++)
              {
                    ll.Add(join1(list[i].str, list[j].str));
              }
          }

       
          for (int yy = 0; yy <ll.Count; yy++)
          {

              string[] s = ll[yy].Split(';');
              if (s.Length == degree)
                  final_ll.Add(ll[yy]);
            
          }
          for (int i = 0; i < final_ll.Count;i++ )
          {
           
              for(int j=i+1;j<final_ll.Count;j++)
              {
                  if (Equal(final_ll[i],final_ll[j]))
                  {
                      final_ll.Remove(final_ll[j]);
                      j--;
                  }
              }
            
          }
           
             list.Clear();
              for (int i = 0; i < final_ll.Count; i++)
              {
                 
                 list.Add(new content());
                 list[final_ll.IndexOf(final_ll[i])].count++;
                 list[final_ll.IndexOf(final_ll[i])].str = final_ll[i];

              }
          for (int yy = 0; yy < list.Count; yy++)
          {
              if (list[yy].str == null)
              {
                  list.RemoveAt(yy);
                  yy--;
              }
          }
         
              for (int i = 0; i < list.Count; i++)
              {
                  for (int j = 0; j < ff.Count; j++)
                  {
                      if (search(ff[j], list[i].str)==true)
                      {
                          list[i].count =++q;
                      }

                  }
                  q = 0;
              }

          for (int i = 0; i <list.Count;i++ )
          {
              if (list[i].count < min_sup)
              {
                  list.Remove(list[i]);
                  i--;
              }


          }



              return list;
      }









       public static List<string> filecsv(string filepath)
            {

                var column2 = new List<string>();
                using (var rd = new StreamReader(filepath))
                {
                    while (!rd.EndOfStream)
                    {
                        var splits = rd.ReadLine().Split(',');
                        column2.Add(splits[1]);
                    }
                }
                List<string>source = column2.ToList<string>();
                return source;
            }
        

    }
}
