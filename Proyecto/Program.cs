namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            ScreenGame ventana = new ScreenGame(500, 500);
            ventana.Run(30, 30);
        }
    }
}
