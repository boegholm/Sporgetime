class Program
{
    

    public static void Main(string[] args)
    {
        UI ui = new UI();
        var app = new App(ui);
        app.Run();
    }
}