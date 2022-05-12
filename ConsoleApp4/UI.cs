class UI
{
    public void DisplayMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    public void DisplayWarning(string msg)
    {
        var oldcolor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ForegroundColor = oldcolor;
    }
}
