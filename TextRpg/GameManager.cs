namespace TextRpg
{
    public class GameManager
    {
        //플레이어 정보
        struct PlayerStatus
        {
            public int level;
            public string name;
            public string job;
            public int power;
            public int defense;
            public int health;
            public int gold;
        }

        //장비 아이템 정보
        struct Equip
        {
            public string name;
            public string desc;
            public int defense;

            public bool m_equipCheck;

            public Equip(string x, string y, int z, bool f)
            {
                this.name = x;
                this.desc = y;
                this.defense = z;
                this.m_equipCheck = f;
            }
        }

        //무기 아이템 정보
        struct Weapon
        {
            public string name;
            public string desc;
            public int power;

            public bool m_equipCheck;

            public Weapon(string x, string y, int z, bool f)
            {
                this.name = x;
                this.desc = y;
                this.power = z;
                this.m_equipCheck = f;
            }
        }

        int[] m_playerPosition;

        ScreenRender m_screen;
        PlayerStatus m_playerStatus;
        ConsoleKeyInfo m_key;
        Equip[] m_equipMents;
        Weapon[] m_weapons;
        MapInfo m_mapInfo;
        UserInterfaceInfo m_uiInfo;
        bool m_focusUi = false;
        Thread t1;

        //키입력
        bool upArrow = false;
        bool downArrow = false;
        bool rightArrow = false;
        bool leftArrow = false;
        bool enterKey = false;
        bool escapeKey = false;
        bool num0Key = false;
        bool num1Key = false;
        bool num2Key = false;
        bool num3Key = false;
        bool num4Key = false;
        bool num5Key = false;
        bool num6Key = false;


        public GameManager()
        {
            m_screen = new ScreenRender();

            m_playerStatus = new PlayerStatus();

            m_playerStatus.health = 10;
            m_playerStatus.gold = 0;
            m_playerStatus.power = 5;
            m_playerStatus.level = 1;
            m_playerStatus.name = "김수한무거북이와두루미";
            m_playerStatus.defense = 0;
            m_playerStatus.job = "무직";

            m_equipMents = new Equip[5];
            m_weapons = new Weapon[5];

            m_equipMents[0] = new Equip("단단 묵직 모자", "단단한 모자다", 10, false);
            m_weapons[0] = new Weapon("트니트니 칼", "튼튼한 칼이다", 10, false);

            m_playerPosition = new int[2] { 30, 35 };
            m_mapInfo = MapInfo.StartVillage;
            m_uiInfo = UserInterfaceInfo.main;
            t1 = new Thread(KeyInput);
            t1.Start();
        }

        public void Render()
        {
            keyCheck();

            m_screen.Render(m_playerPosition, m_mapInfo, m_uiInfo);





            m_screen.ClearUI();
            InterfaceManageMent();
            m_screen.DrawUI();
            if (escapeKey)
            {
                t1.Abort();
            }
        }


        //키입력을 처리하는 함수
        public void keyCheck()
        {
            //이동방향에 공간이 있으면 이동
            if (upArrow)
            {
                if (m_screen.m_frontbuffer[m_playerPosition[0] - 1, m_playerPosition[1]] == 'ㅤ')
                {
                    m_playerPosition[0]--;
                }
                upArrow = false;
            }

            if (downArrow)
            {
                if (m_screen.m_frontbuffer[m_playerPosition[0] + 1, m_playerPosition[1]] == 'ㅤ')
                {
                    m_playerPosition[0]++;
                }
                downArrow = false;
            }

            if (rightArrow)
            {
                if (m_screen.m_frontbuffer[m_playerPosition[0], m_playerPosition[1] + 1] == 'ㅤ')
                {
                    m_playerPosition[1]++;
                }
                rightArrow = false;
            }

            if (leftArrow)
            {
                if (m_screen.m_frontbuffer[m_playerPosition[0], m_playerPosition[1] - 1] == 'ㅤ')
                {
                    m_playerPosition[1]--;
                }
                leftArrow = false;
            }
        }

        //키보드 입력을 받는 함수
        public void KeyInput()
        {
            ConsoleKeyInfo m_key;

            while (true)
            {
                m_key = Console.ReadKey(true);
                switch (m_key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        leftArrow = true;
                        break;
                    case ConsoleKey.RightArrow:
                        rightArrow = true;
                        break;
                    case ConsoleKey.DownArrow:
                        downArrow = true;
                        break;
                    case ConsoleKey.UpArrow:
                        upArrow = true;
                        break;
                    case ConsoleKey.Escape:
                        escapeKey = true;
                        break;
                    case ConsoleKey.Enter:
                        enterKey = true;
                        break;
                    case ConsoleKey.NumPad0:
                        num0Key = true;
                        break;
                    case ConsoleKey.NumPad1:
                        num1Key = true;
                        break;
                    case ConsoleKey.NumPad2:
                        num2Key = true;
                        break;
                    case ConsoleKey.NumPad3:
                        num3Key = true;
                        break;
                    case ConsoleKey.NumPad4:
                        num4Key = true;
                        break;
                    case ConsoleKey.NumPad5:
                        num5Key = true;
                        break;
                    case ConsoleKey.NumPad6:
                        num6Key = true;
                        break;
                }
            }

        }

        //UI관리를 위한 함수
        public void InterfaceManageMent()
        {
            String tmp = "";
            char[] swap = tmp.ToCharArray();
            switch (m_uiInfo)
            {
                case UserInterfaceInfo.main:

                    tmp = "태초마을에 오신것을 환영합니다.";
                    swap = tmp.ToCharArray();

                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[2, i + 5] = swap[i];
                    }


                    tmp = "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[3, i + 5] = swap[i];
                    }

                    tmp = "1. 상태보기";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[6, i + 7] = swap[i];
                    }

                    tmp = "2. 인벤토리";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[7, i + 7] = swap[i];
                    }

                    if (num1Key)
                    {
                        m_uiInfo = UserInterfaceInfo.status;
                        num1Key = false;
                    }

                    if (num2Key)
                    {
                        m_uiInfo = UserInterfaceInfo.inventory;
                        num2Key = false;
                    }

                    break;
                case UserInterfaceInfo.status:

                    tmp = "상태보기";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[2, i + 5] = swap[i];
                    }
                    tmp = "캐릭터의 정보가 표시됩니다.";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[3, i + 5] = swap[i];
                    }

                    tmp = "level: " + m_playerStatus.level.ToString();
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[5, i + 5] = swap[i];
                    }

                    tmp = m_playerStatus.name + "(" + m_playerStatus.job + ")";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[6, i + 5] = swap[i];
                    }

                    tmp = "공격력: " + m_playerStatus.power.ToString();
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[7, i + 5] = swap[i];
                    }

                    tmp = "방어력: " + m_playerStatus.defense.ToString();
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[8, i + 5] = swap[i];
                    }

                    tmp = "체력: " + m_playerStatus.health.ToString();
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[9, i + 5] = swap[i];
                    }

                    tmp = "Gold: " + m_playerStatus.gold.ToString() + " G";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[10, i + 5] = swap[i];
                    }

                    tmp = "0. 나가기";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[12, i + 5] = swap[i];
                    }


                    if (num0Key)
                    {
                        m_uiInfo = UserInterfaceInfo.main;
                        num0Key = false;
                    }
                    break;

                case UserInterfaceInfo.inventory:
                    tmp = "인벤토리";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[2, i + 5] = swap[i];
                    }
                    tmp = "보유 중인 아이템을 관리할 수 있습니다.";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[3, i + 5] = swap[i];
                    }

                    tmp = "[아이템 목록]";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[5, i + 5] = swap[i];
                    }

                    if (true)
                    {
                        int count = 0;
                        for (int i = 0; i < m_equipMents.Length; i++)
                        {
                            if (!String.IsNullOrEmpty(m_equipMents[i].name))
                            {
                                tmp = "- ";
                                if (m_equipMents[i].m_equipCheck)
                                    tmp += "[E]";
                                tmp += m_equipMents[i].name + "   | " + "방어력 : +" + m_equipMents[i].defense + "  | " + m_equipMents[i].desc;
                                swap = tmp.ToCharArray();
                                for (int x = 0; x < swap.Length; x++)
                                {
                                    m_screen.m_frontbufferUI[6 + i, x + 5] = swap[x];
                                }

                                count++;
                            }
                        }

                        for (int j = 0; j < m_weapons.Length; j++)
                        {
                            if (!String.IsNullOrEmpty(m_weapons[j].name))
                            {
                                tmp = "- ";
                                if (m_weapons[j].m_equipCheck)
                                    tmp += "[E]";
                                tmp += m_weapons[j].name + "   | " + "공격력 : +" + m_weapons[j].power + "  | " + m_weapons[j].desc;
                                swap = tmp.ToCharArray();
                                for (int x = 0; x < swap.Length; x++)
                                {
                                    m_screen.m_frontbufferUI[6 + count + j, x + 5] = swap[x];
                                }
                            }
                        }
                    }

                    tmp = "1. 장착 관리";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[12, i + 5] = swap[i];
                    }

                    tmp = "0. 나가기";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[13, i + 5] = swap[i];
                    }

                    if (num0Key)
                    {
                        m_uiInfo = UserInterfaceInfo.main;
                        num0Key = false;
                    }

                    if (num1Key)
                    {
                        m_uiInfo = UserInterfaceInfo.equipManage;
                        num1Key = false;
                    }

                    break;
                case UserInterfaceInfo.equipManage:

                    if (true)
                    {
                        int count = 0;
                        int count2 = 0;
                        for (int i = 0; i < m_equipMents.Length; i++)
                        {
                            if (!String.IsNullOrEmpty(m_equipMents[i].name))
                            {
                                tmp = "["+(count+1).ToString()+"]";
                                if (m_equipMents[i].m_equipCheck)
                                    tmp += "[E]";
                                tmp += m_equipMents[i].name + "   | " + "방어력 : +" + m_equipMents[i].defense + "  | " + m_equipMents[i].desc;
                                swap = tmp.ToCharArray();
                                for (int x = 0; x < swap.Length; x++)
                                {
                                    m_screen.m_frontbufferUI[3 + i, x + 5] = swap[x];
                                }

                                count++;
                            }
                        }

                        for (int j = 0; j < m_weapons.Length; j++)
                        {
                            if (!String.IsNullOrEmpty(m_weapons[j].name))
                            {
                                tmp = "[" + (count+j+1).ToString() + "]";
                                if (m_weapons[j].m_equipCheck)
                                    tmp += "[E]";
                                tmp += m_weapons[j].name + "   | " + "공격력 : +" + m_weapons[j].power + "  | " + m_weapons[j].desc;
                                swap = tmp.ToCharArray();
                                for (int x = 0; x < swap.Length; x++)
                                {
                                    m_screen.m_frontbufferUI[3 + count + j, x + 5] = swap[x];
                                }

                                count2++;
                            }
                        }
                    }


                    tmp = "0. 나가기";
                    swap = tmp.ToCharArray();
                    for (int i = 0; i < swap.Length; i++)
                    {
                        m_screen.m_frontbufferUI[13, i + 5] = swap[i];
                    }

                    if (num0Key)
                    {
                        m_uiInfo = UserInterfaceInfo.inventory;
                        num0Key = false;
                    }
                    break;
            }
        }

        //현재 어떤 맵에 있는지 분별하기 위한 함수
        public enum MapInfo
        {
            StartVillage = 0
        }

        public enum UserInterfaceInfo
        {
            main = 0,
            status = 1,
            inventory = 2,
            equipManage = 3
        }
    }
}
