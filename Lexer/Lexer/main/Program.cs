using System;
using System.Collections.Generic;
using System.Text;

namespace Lex
{
    class Program
    {
        public static void Main(string[] args)
        {
            Lexer lexer = new Lexer("var = 10 + 5 while(var < 15){var = var+1 if(2>1){var = 22" +
                " while(12 > 1){asr =12} }} as = 10");

            lexer.returnTokens();
            Parser parser = new Parser(lexer.returnTokens());
            parser.lang();
            
            Console.ReadLine();

            
        }
    }
}
// var = 10 + 5 while(var < 15){var = var+1 if(var>14){test = 12}} as = 10