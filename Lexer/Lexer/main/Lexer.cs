using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lex
{
    class Lexer 
    {
        private readonly String inputString;
        
        public Lexer(string inputString)
        {
            this.inputString = inputString;
        }

        public List<Token> returnTokens()
        {
            List<Token> result = new List<Token>();
            String currentString = String.Empty;
            

            // Совпадения 
            List<Token> matches = new List<Token>();
            List<Token> prevMatches = new List<Token>();


            for (int i=0; i < inputString.Length; i++)
            {
                prevMatches.Clear();
                prevMatches.AddRange(matches);
                matches.Clear();

                if(inputString[i] != ' ')
                    currentString += inputString[i];

                Console.WriteLine(currentString+ "\n");
                foreach(Lexem l in Lexem.Values)
                {
                    if (Regex.IsMatch(currentString, l.regexp))
                    {
                        Console.WriteLine(l.ToString() + " found");
                        matches.Add(new Token(l, currentString));
                    }
                    else
                        Console.WriteLine(l.ToString() + " isn't found");
                }

                if (matches.Count <= 0)
                {
                    if (prevMatches.Count == 1)
                    {
                        result.Add(prevMatches[0]);
                        currentString = String.Empty;
                        i--;
                        Console.WriteLine("\t\t\t\t" + prevMatches[0].lexem + "  (" + prevMatches[0].value + ")");
                    }
                    else
                        throw new LangException("Too much Lexem found");
                }

                // Если строка кончилась 
                if(i == inputString.Length-1 || inputString[i] == '\n' )
                {
                    if (matches.Count == 1)
                    {
                        result.Add(matches[0]);
                        currentString = String.Empty;
                        
                    }
                    else
                        throw new LangException("Too much Lexem found");
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("\n\n");
            foreach(var t in result)
            {
                Console.WriteLine(t.value+ "\t(" + t.lexem+")");
            }
            return result;
        }



        
    }
}
