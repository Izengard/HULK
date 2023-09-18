namespace Logic;
public class Token
{
    public enum Types{
        INT,
        PLUS,
        MINUS,
        DIV,
        MUL,
        EOF,
        LPAREN,
        RPAREN
    }
    
    public Types Type {get;}
    public string Value {get; set;}

    public Token(Types type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}