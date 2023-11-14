namespace TextRpg
{
    //현재 어떤 맵에 있는지 분별하기 위한 함수
    public enum MapInfo
    {
        StartVillage = 0
    }

    //현재 focus 상태인 화면만 골라서 랜더링 하기 위해 나눴다 
    public enum UserInterfaceInfo
    {
        main = 0,
        status = 1,
        inventory = 2,
        armorManager = 3,
        weaponManager = 4
    }

    //플레이어 정보
    public struct PlayerStatus
    {
        public int level;
        public string name;
        public string job;
        public int power;
        public int defense;
        public int health;
        public int gold;

        public PlayerStatus()
        {
            level = 1;
            name = "김수한무거북이와두루미";
            job = "무직";
            health = 10;
            power = 5;
            defense = 0;
            gold = 999;
        }
    }

    //장비 아이템 정보
    public struct Armor
    {
        public string name;
        public string desc;
        public int defense;

        public bool m_equipCheck;

        public Armor(string name, string desc, int defense, bool equipcheck)
        {
            this.name = name;
            this.desc = desc;
            this.defense = defense;
            this.m_equipCheck = equipcheck;
        }

        public void SwitchEquip()
        {
            m_equipCheck = !m_equipCheck;
        }
    }

    //무기 아이템 정보
    public struct Weapon
    {
        public string name;
        public string desc;
        public int power;

        public bool m_equipCheck;

        public Weapon(string name, string desc, int power, bool equipcheck)
        {
            this.name = name;
            this.desc = desc;
            this.power = power;
            this.m_equipCheck = equipcheck;
        }

        public void SwitchEquip()
        {
            m_equipCheck = !m_equipCheck;
        }
    }



    public class GameManager
    {
        int[] m_playerPosition;

        RenderClass m_screen;
        InputClass m_inputClass;
        InterfaceClass m_interfaceClass;
        SelectEquipment selectEquipment;
        PlayerStatus m_playerStatus;
        List<Armor> m_armors = new List<Armor>();
        List<Weapon> m_weapons = new List<Weapon>();
        MapInfo m_mapInfo;
        UserInterfaceInfo m_uiInfo;



        public GameManager()
        {
            m_playerStatus = new PlayerStatus();
            m_armors.Add(new Armor("단단 묵직 모자", "단단한 모자다", 10, true));
            m_weapons.Add(new Weapon("트니트니 칼", "튼튼한 칼이다", 10, true));
            m_playerPosition = new int[2] { 20, 35 };
            m_mapInfo = MapInfo.StartVillage;
            m_uiInfo = UserInterfaceInfo.main;

            //랜더링 클래스 생성
            m_screen = new RenderClass();

            //Ui 클래스 생성
            m_interfaceClass = new InterfaceClass();
            selectEquipment = new SelectEquipment();

            //입력 클래스 생성
            m_inputClass = new InputClass();
            m_inputClass.Start();
        }

        public bool Render()
        {
            //방향키 입력을 받아 캐릭터 이동
            MovePlayer();

            //캐릭터 위치, 현재 맵 정보를 전달하여 랜더링 (UI는 따로 그림)
            m_screen.Render(m_playerPosition, m_mapInfo);

            //Ui창을 빈 버퍼로 만들고 새로 그리기
            m_screen.ClearUI();

            //인터페이스 정보를 상태에 따라 그리기
            InterfaceManageMent();

            //콘솔창에 Ui 그리기
            m_screen.DrawUI();

            //종료 키 입력시 자원 반환
            if (m_inputClass.Esc_IsPressed())
            {
                return false;
            }

            return true;
        }


        //자원 반환 함수
        public void Shutdown()
        {
            m_inputClass.ShutDown();
        }


        //눌린 방향키에 맞춰서 플레이어 좌표 이동
        private void MovePlayer()
        {
            //이동방향에 공간이 있으면 이동
            if (m_inputClass.Up_IsPressed())
            {
                if (m_screen.m_frontbuffer[m_playerPosition[0] - 1, m_playerPosition[1]] == 'ㅤ')
                {
                    m_playerPosition[0]--;
                }
            }

            if (m_inputClass.Down_IsPressed())
            {
                if (m_screen.m_frontbuffer[m_playerPosition[0] + 1, m_playerPosition[1]] == 'ㅤ')
                {
                    m_playerPosition[0]++;
                }
            }

            if (m_inputClass.Right_IsPressed())
            {
                if (m_screen.m_frontbuffer[m_playerPosition[0], m_playerPosition[1] + 1] == 'ㅤ')
                {
                    m_playerPosition[1]++;
                }
            }

            if (m_inputClass.Left_IsPressed())
            {
                if (m_screen.m_frontbuffer[m_playerPosition[0], m_playerPosition[1] - 1] == 'ㅤ')
                {
                    m_playerPosition[1]--;
                }
            }
        }


        //UI창 전환를 위한 함수
        private void InterfaceManageMent()
        {
            switch (m_uiInfo)
            {
                case UserInterfaceInfo.main:

                    //메인 Ui창 그리기
                    m_interfaceClass.DrawMain(m_screen.m_frontbufferUI);

                    if (m_inputClass.Num1_IsPressed())
                    {
                        m_uiInfo = UserInterfaceInfo.status;
                    }

                    if (m_inputClass.Num2_IsPressed())
                    {
                        m_uiInfo = UserInterfaceInfo.inventory;
                    }

                    break;
                case UserInterfaceInfo.status:

                    //플레이어 스테이터스 창 그리기
                    m_interfaceClass.DrawStatus(m_screen.m_frontbufferUI, m_playerStatus);

                    if (m_inputClass.Num0_IsPressed())
                    {
                        m_uiInfo = UserInterfaceInfo.main;
                    }
                    break;

                case UserInterfaceInfo.inventory:

                    //플레이어 인벤토리 그리기
                    m_interfaceClass.DrawInventory(m_screen.m_frontbufferUI, m_armors, m_weapons);

                    if (m_inputClass.Num0_IsPressed())
                    {
                        m_uiInfo = UserInterfaceInfo.main;
                    }

                    if (m_inputClass.Num1_IsPressed())
                    {
                        m_uiInfo = UserInterfaceInfo.armorManager;
                    }

                    if (m_inputClass.Num2_IsPressed())
                    {
                        m_uiInfo = UserInterfaceInfo.weaponManager;
                    }

                    break;
                case UserInterfaceInfo.armorManager:

                    //방어구 관리창 그리기
                    m_interfaceClass.DrawArmorManager(m_screen.m_frontbufferUI, m_armors);

                    selectEquipment.Select(m_armors, m_inputClass);

                    if (m_inputClass.Num0_IsPressed())
                    {
                        m_uiInfo = UserInterfaceInfo.inventory;
                    }
                    break;
                case UserInterfaceInfo.weaponManager:

                    //무기 관리창 그리기
                    m_interfaceClass.DrawWeaponManager(m_screen.m_frontbufferUI, m_weapons);

                    selectEquipment.Select(m_weapons, m_inputClass);
                    
                    if (m_inputClass.Num0_IsPressed())
                    {
                        m_uiInfo = UserInterfaceInfo.inventory;
                    }
                    break;
            }
        }
    }
}
