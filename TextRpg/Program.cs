
namespace TextRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool result;
            Console.SetWindowSize(200, 50);

            GameManager gameManager = new GameManager();
            
            while (true)
            {
                result = gameManager.Render();
                if (!result)
                {
                    Console.Clear();
                    Console.WriteLine("  게임 종료");

                    break;
                }

            }
            //게임종료 됐을 때 모든 자원 반환
            gameManager.Shutdown();
        }
    }
}