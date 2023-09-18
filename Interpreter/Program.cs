using Logic;
while (true)
{
    System.Console.Write("> ");
    var entry = Console.ReadLine();
    if (entry.ToLower() == "exit")
    {
        break;
    }
    Lexer lexer = new Lexer(entry);
    Parser parser = new Parser(lexer);
    int result = parser.Expr();
    System.Console.WriteLine(result);
}