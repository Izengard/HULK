
using System;
namespace Logic;

public class Parser
{
    Lexer lexer;
    Token currentToken;
    public Parser(Lexer lexer)
    {
        this.lexer = lexer;
        this.currentToken = lexer.GetToken();
    }


    private void Eat(Token.Types type)
    {
        if (this.currentToken.Type.Equals(type))
            this.currentToken = lexer.GetToken();
        else
            new Exception("Error Parsing");
    }

    private int Factor()
    {
        if (currentToken.Type == Token.Types.INT)
        {
            // this.currentToken = lexer.GetToken();
            int result = int.Parse(currentToken.Value);
            Eat(Token.Types.INT);
            return result;
        }
        else if (currentToken.Type == Token.Types.LPAREN)
        {
            Eat(Token.Types.LPAREN);
            int result = Expr();
            Eat(Token.Types.RPAREN);
            return result;
        }
        throw new Exception("Parse Error");
    }

    private int Term()
    {
        int result = Factor();
        while (currentToken.Type == Token.Types.MUL || currentToken.Type == Token.Types.DIV)
        {
            if (currentToken.Type == Token.Types.MUL)
            {
                Eat(Token.Types.MUL);
                result *= Factor();
            }
            else if (currentToken.Type == Token.Types.DIV){
                Eat(Token.Types.DIV);
                result /= Factor();
            }
        }
        return result;
    }

    public int Expr()
    {
        int result = Term();

        while (currentToken.Type == Token.Types.PLUS || currentToken.Type == Token.Types.MINUS)
        {
            if (currentToken.Type == Token.Types.PLUS)
            {
                Eat(Token.Types.PLUS);
                result += Term();
            }
            else if (currentToken.Type == Token.Types.MINUS){
                Eat(Token.Types.MINUS);
                result -= Term();
            }
        }
        return result;
    }
}


