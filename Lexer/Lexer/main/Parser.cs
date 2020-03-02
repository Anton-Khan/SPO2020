using System;
using System.Collections.Generic;
using System.Text;
/*
   new	
lang -> expr+
expr -> assign_expr|if_expr|while_expr
assign_expr -> VAR ASSIGN_OP value_expr
value_expr -> value (OP value)*
value -> VAR|DIGIT

if_expr -> IF_KW if_head if_body
if_head -> L_B logic_comp R_B
if_body -> L_SB expr+ R_SB

while_expr -> WHILE_KW while_head while_body
while_head -> L_B logic_comp R_B
while_head -> L_SB expr+ R_SB

logic_comp -> compare_var COMPARE_OP compare_var
compare_var -> value|value_expr

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
            try
            {
                assignExpr();
            }
            catch(LangException e)
            {
                try
                {
                    iterator--;
                    ifExpr();
                    Console.WriteLine("\tIF_EXPR");
                    
                }
                catch(LangException ex)
                {
                    try
                    {
                        iterator--;
                        whileExpr();
                        Console.WriteLine("\tWHILE_EXPR");
                    }
                    catch(LangException exp)
                    {
                        
                       throw new LangException("AsEXP_excp " + e.Message + "|\nIfEXP_excp " + ex.Message + "|\nWhileEXP_excp " + exp.Message + "-> " + iterator);
                    }
                }
            }
        }

        private void whileExpr()
        {
            whileKw();
            whileHead();
            whileBody();
        }

        private void whileHead()
        {
            leftB();
            logicComp();
            rightB();
        }

        private void whileBody()
        {
            squareBracketBody();
        }

        private void ifExpr()
        {
            ifKw();
            if_head();
            if_body();

        }

        private void if_head()
        {
            leftB();
            logicComp();
            rightB();
        }
        
        private void if_body()
        {
            squareBracketBody();
        }

        private void logicComp()
        {
            compareVar();
            compareOp();
            compareVar();
        }

        private void compareVar()
        {
            try
            {
                value();
            }catch(LangException e)
            {
                try
                {
                    iterator--;
                    valueExpr();
                }catch(LangException ex)
                {
                    throw new LangException(e.Message + "|\n" + ex.Message + "-> " + iterator);
                }

            }
        }

        private void assignExpr()
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
                    throw new LangException(e.Message + "|\n" + ex.Message + "-> " + iterator);
                }
            }

        }
        
        private void valueExpr()
        {
            value();
            while (true)
            {
                try
                {
                    op();
                    value();
                }
                catch (LangException e)
                { 
                    Console.WriteLine("\tASSIGN_EXPR");
                    throw new LangException(e.Message + "-> " + iterator);
                }
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

        private void ifKw()
        {
            match(getNextToken(), Lexem.IF_KW);
        }

        private void whileKw()
        {
            match(getNextToken(), Lexem.WHILE_KW);   
        }

        private void leftB()
        {
            match(getNextToken(), Lexem.L_B);
        }

        private void rightB()
        {
            match(getNextToken(), Lexem.R_B);
        }

        private void leftSb()
        {
            match(getNextToken(), Lexem.L_SB);
        }

        private void rightSb()
        {
            match(getNextToken(), Lexem.R_SB);
        }

        private void compareOp()
        {
            match(getNextToken(), Lexem.COMPARE_OP);
        }

        // Не уверен в этой функции, нужно тестировать (опять все на try/catch)
        private void squareBracketBody()
        {
            leftSb();
            try
            {
                while (true)
                {
                    expr();
                }
            }
            catch (LangException e)
            {
                try
                {
                    iterator--;
                    rightSb();                    
                }
                catch (LangException ex)
                {
                    throw new LangException(e.Message + "|\n" + ex.Message + "-> " + iterator);
                }
            }
        }

        private void match(Token currentToken, Lexem requiredLexem)
        {
            if(currentToken.lexem != requiredLexem)
            {
                throw new LangException(requiredLexem.ToString() + " expected, but " + currentToken.lexem +"("+ currentToken.value + ") found -> " + iterator );
            }
            Console.WriteLine(currentToken.lexem + " " + currentToken.value + " " + (iterator-1));
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
                iterator++;
                Console.WriteLine("END");
                throw new LangException("Out of Tokens -> " + iterator);
                
            }
        }

    }
}
