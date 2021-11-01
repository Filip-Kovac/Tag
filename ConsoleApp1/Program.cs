using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static string input = "K této knize se svět chová velice <capital>laskavě</capital>. Jen z různých edicí vydaných v " +
            "<red>Anglii</red> se už prodalo přes půldruhého miliónu výtisků. A v <hide>Chicagu</hide>" +
            " se mi už před mnoha lety dostalo ujištění - z úst jistého podnikavého piráta nyní v. v. - že víc než " +
            "<highlight>milión výtisků</highlight> se prodalo ve <green>Spojených státech</green>.";
        static string[] start_tag = { "capital", "red", "hide", "highlight", "green" };
        static string[] end_tag = { "/capital", "/red", "/hide", "/highlight", "/green" };
        static string word;
        static int i;
        static void Main(string[] args)
        {
            Program p = new Program();
            
            for (i = 0; i < input.Length; i++)
            {
                if (input[i] == '<')
                {
                    word = "";
                    i++;
                    for (; i < input.Length; i++)
                    {
                        if (input[i] == '>')
                        {
                            break;
                        }
                        else
                        {
                            word += input[i];
                            if (word == "highlight")
                            {
                                Console.Write("*** ");
                            }
                            if (word == "/highlight")
                            {
                                Console.Write(" ***");
                            }
                        }
                    }
                }
                else
                {
                    p.text_style();
                }
            }
        }
        public void text_style()
        {
            if (word == "capital")
            {
                Console.Write(char.ToUpper(input[i]));
            }
            else if (word == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(input[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (word == "hide")
            {
                Console.Write('*');
            }
            else if (word == "highlight")
            {
                Console.Write(char.ToUpper(input[i]));
            }
            else if (word == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(input[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(input[i]);
            }
        }
        //public delegate void CallBack(char ch);
    }
}
