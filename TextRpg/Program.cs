
namespace TextRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(200, 50);

            GameManager gameManager = new GameManager();
            
            while (true)
            {
                gameManager.Render();
            }

        }
    }
}