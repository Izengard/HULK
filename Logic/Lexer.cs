using System;
namespace Logic;

public class Lexer
{
    string text;
    int pos = 0;
    char currentChar;
    
    public Lexer(string entry)
    {
        this.text = entry;
        currentChar = text[pos];
    }


    private void Advance(){
        this.pos++;
        if (this.pos > this.text.Length - 1){
            currentChar = '\0'; 
        }
        else    
            currentChar = text[pos];
    }

    private void SkipWhiteSpace(){
        while(currentChar != '\0' && char.IsWhiteSpace(currentChar)){
            Advance();
        }
    }

    private string GetInt(){
        var result = "";
        while(char.IsDigit(currentChar)){
            result += currentChar;
            Advance();
        }
        return result;
    }

    public Token GetToken()
    {
        if (this.pos > text.Length - 1)
        {
            this.currentChar = '\0';
        }
        
        while (currentChar != '\0')
        {

            if (char.IsWhiteSpace(currentChar))
                SkipWhiteSpace();
            
            else if (char.IsDigit(currentChar))
                return new Token(Token.Types.INT, GetInt());
            
            else if (currentChar == '+'){
                Advance();
                return new Token(Token.Types.PLUS, "+");
            }
            else if (currentChar == '-'){
                Advance();
                return new Token(Token.Types.MINUS, "-");
            }
            else if (currentChar == '/'){
                Advance();
                return new Token(Token.Types.DIV, "/");
            }
            else if (currentChar == '*'){
                Advance();
                return new Token(Token.Types.MUL, "*");
            }
            else if (currentChar == '('){
                Advance();
                return new Token(Token.Types.LPAREN, "(");
            }
            else if (currentChar == ')'){
                Advance();
                return new Token(Token.Types.RPAREN, ")");
            }
        }
        return new Token(Token.Types.EOF, "\0");

    }

}
