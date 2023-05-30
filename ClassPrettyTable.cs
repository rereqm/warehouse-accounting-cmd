using System;
using System.IO;

public class PrettyTable
{

  private int[] max_len_of_fields;
  private string[] name_of_fields;

  public PrettyTable(int[] max_len_of_fields, string[] name_of_fields)
  {
  this.max_len_of_fields = max_len_of_fields;
  this.name_of_fields = name_of_fields;
  }

  public void start ()
  {
    
    int j = 0;
    Console.Write("+");
    while (j < max_len_of_fields.Length)
    {
      Console.Write(new string ('-',max_len_of_fields[j]));
      j++;
      Console.Write("+");
    }
    Console.Write("\n");
    for(int i=0;i< max_len_of_fields.Length;i++)
    {
      Console.Write("|");
      Console.Write(name_of_fields[i]+ new string(' ',(max_len_of_fields[i]-name_of_fields[i].Length)));
    }
    Console.Write("|\n");



    j = 0;
    Console.Write("+");
    while (j < max_len_of_fields.Length)
    {
      Console.Write(new string ('-',max_len_of_fields[j]));
      j++;
      Console.Write("+");
    }
    Console.Write("\n");
    
  }
  public void line(string line)
  {  
    int ind=0;
    for(int i=0;i< max_len_of_fields.Length;i++)
    {
      Console.Write("|");
      for (int j=0;j< max_len_of_fields[i];j++)
      {
          //Console.Write("---");
          //Console.Write(line.Length);
          //Console.Write(" ");
          //Console.Write(ind);
          //Console.Write(" ");
          //Console.Write(j);
          //Console.Write(" ");
          //Console.Write(i);
          //Console.Write("---");
          if (line[ind]=='~')
          {
            Console.Write(" ");
          }else
          {
            Console.Write(line[ind]);
          }
          ind++;


        }

    }
    Console.Write("|\n");
  }
  public void end ()
  {
    int j = 0;
    Console.Write("+");
    while (j < max_len_of_fields.Length)
    {
      Console.Write(new string ('-',max_len_of_fields[j]));
      j++;
      Console.Write("+");
    }
    Console.Write("\n");
  }


}