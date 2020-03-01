using System;
using System.Collections.Generic;
using System.Text;
/*
    VAR -> [a-zA-Z]+
    DIGIT -> 0|([1-9][0-9]*)
    ASSIGN_OP -> =
    OP -> +|-|*|/
 */
 
namespace Lex
{
    public class Lexem
    {
        public String regexp { get; }
        public String name { get; }
        

        public Lexem(String regexp, String name)
        {
            this.regexp = regexp;
            this.name = name;
        }

        public static readonly Lexem VAR = new Lexem(@"^([a-zA-Z]+)$", "VAR");
        public static readonly Lexem DIGIT = new Lexem(@"^(0|[1-9][0-9]*)$", "DIGIT");
        public static readonly Lexem ASSIGN_OP = new Lexem(@"^=$", "ASSIGN_OP");
        public static readonly Lexem OP = new Lexem(@"^(\+|-|\*|\/)$", "OP");
        public static readonly int Count = 4;

        public static IEnumerable<Lexem> Values
        {
            get
            {
                yield return VAR;
                yield return DIGIT;
                yield return ASSIGN_OP;
                yield return OP;
            }
        }

        public override string ToString() => name;
    }
}

