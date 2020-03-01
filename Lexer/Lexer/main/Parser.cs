using System;
using System.Collections.Generic;
using System.Text;
/*
    lang -> expr+
    expr -> VAR ASSIGN_OP value_expr
    value_expr -> value (OP value)*
    value -> VAR|DIGIT
 */

namespace Lex
{
    class Parser
    {
        private readonly List<Token> tokens;
        private int iterator;


        public Parser(List<Token> list)
        {
            this.tokens = list;
            iterator = 0;
        }

        public void lang()
        {
            while (true)
            {
                expr();
            }
        }

        private void expr()
        {
            var();
            assignOp();
            valueExpr();
        }

        private void value()
        {
            try
            {
                var();
            }
            catch (LangException e)
            {
                try
                {
                    iterator--;
                    digit();
                }
                catch (LangException ex)
                {
                    throw new LangException(e.Message + "\n" + ex.Message);
                }
            }

        }

        // ПЕРЕДЕЛАТЬ 
        private void valueExpr()
        {
            value();

            // ПЕРЕДЕЛАТЬ 
               // Может и не быть op + value (просто присваивание значения)
            while (true)
            {
                op();
                value();
            }
        }

        private void assignOp()
        {
            match(getNextToken(), Lexem.ASSIGN_OP);
        }

        private void op()
        {
            match(getNextToken(), Lexem.OP);
        }

        private void var()
        {
            match(getNextToken(), Lexem.VAR);
        }

        private void digit()
        {
            match(getNextToken(), Lexem.DIGIT);
        }

        private void match(Token currentToken, Lexem requiredLexem)
        {
            if(currentToken.lexem != requiredLexem)
            {
                throw new LangException(currentToken.lexem.ToString() + " expected, but " + requiredLexem.ToString() + " found");
            }

        }

        private Token getNextToken()
        {
            if (tokens.Count > iterator)
            {
                iterator++;
                return tokens[iterator-1];
            }
            else
            {
                throw new LangException("Out of Tokens");
            }
        }
    }
}
