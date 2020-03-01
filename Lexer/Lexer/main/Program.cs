using System;
using System.Collections.Generic;
using System.Text;

namespace Lex
{
    class Program
    {
        public static void Main(string[] args)
        {
            Lexer lexer = new Lexer("cat = 6+7 ");

            lexer.returnTokens();
            Parser parser = new Parser(lexer.returnTokens());
            parser.lang();
            Console.ReadLine();

            
        }
    }
}
