using System;
using System.Collections.Generic;
using System.Text;
/*
     VAR -> ^([a-zA-Z]+)$
    DIGIT -> ^(0|[1-9][0-9]*)$
    ASSIGN_OP -> ^=$
    OP -> ^(\+|-|\*|\/)$

        new 
    IF_KW -> ^if$
    WHILE_KW -> ^while$
    L_B -> ^\($
    R_B -> ^\)$
    L_SB -> ^\{$
    R_SB -> ^\}$
    COMPARE_OP -> ^(>=|<=|>|<|!=|==)$

    count = 11
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
        public static readonly Lexem IF_KW = new Lexem(@"^if$", "IF_KW");
        public static readonly Lexem WHILE_KW = new Lexem(@"^while$", "WHILE_KW");
        public static readonly Lexem L_B = new Lexem(@"^\($", "L_B");
        public static readonly Lexem R_B = new Lexem(@"^\)$", "R_B");
        public static readonly Lexem L_SB = new Lexem(@"^\{$", "L_SB");
        public static readonly Lexem R_SB = new Lexem(@"^\}$", "R_SB");
        public static readonly Lexem COMPARE_OP = new Lexem(@"^(>=|<=|>|<|!=|==)$", "COMPARE_OP");
        public static readonly int Count = 11;

        public static IEnumerable<Lexem> Values
        {
            get
            {
                yield return IF_KW;
                yield return WHILE_KW;
                yield return VAR;
                yield return DIGIT;
                yield return ASSIGN_OP;
                yield return OP;
                yield return R_B;
                yield return L_B;
                yield return COMPARE_OP;
                yield return R_SB;
                yield return L_SB;
            }
        }

        public override string ToString() => name;
    }
}

