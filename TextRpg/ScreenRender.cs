using static TextRpg.GameManager;

namespace TextRpg
{
    public class ScreenRender
    {
        /// <summary>
        /// 게임화면 버퍼
        /// </summary>
        public char[,] m_frontbuffer;

        /// <summary>
        /// 게임UI 버퍼
        /// </summary>
        public char[,] m_frontbufferUI;
        char[,] m_map1;
        int deltaTime, lastTime;

        public ScreenRender()
        {
            Console.CursorVisible = false;
            m_frontbuffer = new char[35, 70];
            m_frontbufferUI = new char[15, 50];
            m_map1 = new char[33, 68];

            DrawBox();

            String[] tmp =
               {
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■■■■■■■■ㅤㅤㅤㅤㅤㅤㅤ■■■■■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ●ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ●ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■■■■□■■■ㅤㅤㅤㅤㅤㅤㅤ□ㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■■■■ㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ●ㅤㅤㅤㅤㅤㅤㅤㅤ■■■■■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ●ㅤㅤㅤㅤㅤ□ㅤㅤ■ㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤ■ㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ●ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤ■ㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■■■□■■■■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤ■ㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ●ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■■■■ㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤ■■■■■■■■ㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤ●ㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■■■■■■■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■■■■■■■■■■■■■■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ■■■■■■■■■■■■■■ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ",
            "ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ"
            };

            //string 타입 맵을 char 배열로 변환
            for (int i = 0; i < 33; i++)
            {
                char[] swap = tmp[i].ToCharArray();
                for (int j = 0; j < 68; j++)
                {
                    m_map1[i, j] = swap[j];
                }
            }

            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < 68; j++)
                {
                    //테두리를 제외하고 안쪽에 map1정보를 앞버퍼에 넣기
                    m_frontbuffer[i + 1, j + 1] = m_map1[i, j];
                }
            }
        }

        public void Render(int[] m_playerPos, GameManager.MapInfo mapNum, GameManager.UserInterfaceInfo uiNum)
        {
            //프레임 고정 (초당30프레임)
            while (true)
            {
                deltaTime = System.Environment.TickCount;
                if (deltaTime - lastTime < 30)
                {
                    continue;
                }

                lastTime = System.Environment.TickCount;
                break;
            }


            Console.SetCursorPosition(0, 0);

            DrawBox();
            DrawMap(mapNum);

            //플레이어 현재 위치를 가져와 앞버퍼에 넣기
            m_frontbuffer[m_playerPos[0], m_playerPos[1]] = '◈';

            //게임화면 버퍼 그리기
            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 70; j++)
                {
                    //플레이어만 초록색으로 그리기
                    if (m_frontbuffer[i, j] == '◈')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(m_frontbuffer[i, j]);
                        Console.ResetColor();

                        continue;
                    }
                    Console.Write(m_frontbuffer[i, j]);
                }
                Console.WriteLine();
            }


        }



        public void DrawMap(GameManager.MapInfo mapNum)
        {
            switch (mapNum)
            {
                case MapInfo.StartVillage:
                    for (int i = 0; i < 33; i++)
                    {
                        for (int j = 0; j < 68; j++)
                        {
                            //테두리를 제외하고 안쪽에 map1정보를 그린다
                            m_frontbuffer[i + 1, j + 1] = m_map1[i, j];
                        }
                    }
                    break;

                default:
                    for (int i = 0; i < 33; i++)
                    {
                        for (int j = 0; j < 68; j++)
                        {
                            //테두리를 제외하고 안쪽에 map1정보를 그린다
                            m_frontbuffer[i + 1, j + 1] = m_map1[i, j];
                        }
                    }
                    break;
            }



        }

        //게임이 진행되는 박스를 먼저 그린다.
        public void DrawBox()
        {

            for (int i = 1; i < 35; i++)
            {
                m_frontbuffer[i, 0] = '│';
                m_frontbuffer[i, 69] = '│';
            }

            for (int j = 1; j < 70; j++)
            {
                m_frontbuffer[0, j] = 'ㅡ';
                m_frontbuffer[34, j] = 'ㅡ';
            }

            m_frontbuffer[0, 0] = '┌';
            m_frontbuffer[0, 69] = '┐';
            m_frontbuffer[34, 0] = '└';
            m_frontbuffer[34, 69] = '┘';
        }

        public void ClearUI()
        {
            //빈공간으로 초기화
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    m_frontbufferUI[i, j] = 'ㅤ';
                }
            }

            for (int i = 1; i < 14; i++)
            {
                m_frontbufferUI[i, 0] = '│';
                m_frontbufferUI[i, 49] = '│';
            }

            for (int j = 1; j < 50; j++)
            {
                m_frontbufferUI[0, j] = 'ㅡ';
                m_frontbufferUI[14, j] = 'ㅡ';
            }

            m_frontbufferUI[0, 0] = '┌';
            m_frontbufferUI[0, 49] = '┐';
            m_frontbufferUI[14, 0] = '└';
            m_frontbufferUI[14, 49] = '┘';


        }

        public void DrawUI()
        {

            //게임UI 버퍼 그리기
            for (int i = 0; i < 15; i++)
            {
                int count = 0;
                for (int j = 0; j < 50; j++)
                {
                    
                    //글자 자리 맞추는 연산
                    String tmp = m_frontbufferUI[i, j].ToString();
                    if (m_frontbufferUI[i, j] != '\0' && System.Text.UTF8Encoding.UTF8.GetByteCount(tmp) < 3)
                    {
                        count++;
                        
                    }

                    //2바이트 이하인 글자수 개수만큼 공백으로 채우기
                    while (count > 0 && j > 48)
                    {
                        Console.Write(' ');
                      
                        count--;
                    }

                    //Ui 그리기
                    Console.Write(m_frontbufferUI[i, j]);
                }
               
                //줄 바꿈
                Console.WriteLine();
            }


            
        }

    }
}
