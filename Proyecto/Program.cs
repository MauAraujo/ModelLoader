namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            ScreenGame ventana = new ScreenGame(800, 800);
            ventana.Run(30, 30);
        }
    }
}
