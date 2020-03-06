using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Lex
{
    class Program
    {
        public static void Main(string[] args)
        {


            Lexer lexer = new Lexer("if(12 > 4 * 3){asd = 12 while(test > 5 * 25){test = test + 12}}");//getCode(@"C:\Users\Khan\source\repos\mirea\SPO2020\Lexer\Code.TXT"));

            Parser parser = new Parser(lexer.returnTokens());
            parser.lang();
            
            Console.ReadLine();

            
        }

        private static string getCode(string filePath)
        {
            try
            {
                StreamReader sr = new StreamReader(filePath);
                string result = string.Empty;
                while (!sr.EndOfStream)
                {
                    result += sr.ReadLine()+" ";
                }
                return result;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
// var = 10 + 5 while(var < 15){var = var+1 if(var>14){test = 12}} as = 10
// var = 10 test = 12 - 4 while(12 > 5){test = 1 test = test + 1 if(test > 2 ){test = 12 +1}}