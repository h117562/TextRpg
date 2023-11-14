namespace TextRpg
{
    public class InterfaceClass
    {

        String tmp = "";
        char[] swap;

        public void DrawMain(char[,] m_buffer)
        {
            tmp = "태초마을에 오신것을 환영합니다.";
            swap = tmp.ToCharArray();

            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[2, i + 5] = swap[i];
            }


            tmp = "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[3, i + 5] = swap[i];
            }

            tmp = "1. 상태보기";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[6, i + 7] = swap[i];
            }

            tmp = "2. 인벤토리";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[7, i + 7] = swap[i];
            }
        }

        public void DrawStatus(char[,] m_buffer, PlayerStatus status)
        {
            tmp = "상태보기";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[2, i + 5] = swap[i];
            }
            tmp = "캐릭터의 정보가 표시됩니다.";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[3, i + 5] = swap[i];
            }

            tmp = "level: " + status.level.ToString();
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[5, i + 5] = swap[i];
            }

            tmp = status.name + "(" + status.job + ")";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[6, i + 5] = swap[i];
            }

            tmp = "공격력: " + status.power.ToString();
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[7, i + 5] = swap[i];
            }

            tmp = "방어력: " + status.defense.ToString();
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[8, i + 5] = swap[i];
            }

            tmp = "체력: " + status.health.ToString();
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[9, i + 5] = swap[i];
            }

            tmp = "Gold: " + status.gold.ToString() + " G";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[10, i + 5] = swap[i];
            }

            tmp = "0. 나가기";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[12, i + 5] = swap[i];
            }
        }

        public void DrawInventory(char[,] m_buffer, List<Armor> equips, List<Weapon> weapons)
        {
            tmp = "인벤토리";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[2, i + 5] = swap[i];
            }
            tmp = "보유 중인 아이템을 관리할 수 있습니다.";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[3, i + 5] = swap[i];
            }

            tmp = "[아이템 목록]";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[5, i + 5] = swap[i];
            }

            if (true)
            {
                int count = 0;
                for (int i = 0; i < equips.Count(); i++)
                {
                    if (!String.IsNullOrEmpty(equips[i].name))
                    {
                        tmp = "- ";
                        if (equips[i].m_equipCheck)
                            tmp += "[E]";
                        tmp += equips[i].name + "   | " + "방어력 : +" + equips[i].defense + "  | " + equips[i].desc;
                        swap = tmp.ToCharArray();
                        for (int x = 0; x < swap.Length; x++)
                        {
                            m_buffer[6 + i, x + 5] = swap[x];
                        }

                        count++;
                    }
                }

                for (int j = 0; j < weapons.Count(); j++)
                {
                    if (!String.IsNullOrEmpty(weapons[j].name))
                    {
                        tmp = "- ";
                        if (weapons[j].m_equipCheck)
                            tmp += "[E]";
                        tmp += weapons[j].name + "   | " + "공격력 : +" + weapons[j].power + "  | " + weapons[j].desc;
                        swap = tmp.ToCharArray();
                        for (int x = 0; x < swap.Length; x++)
                        {
                            m_buffer[6 + count + j, x + 5] = swap[x];
                        }
                    }
                }
            }

            tmp = "2. 장비 관리";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[11, i + 5] = swap[i];
            }

            tmp = "1. 방어구 관리";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[12, i + 5] = swap[i];
            }

            tmp = "0. 나가기";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[13, i + 5] = swap[i];
            }
        }

        public void DrawArmorManager(char[,] m_buffer, List<Armor> armors)
        {
        
            for (int i = 0; i < armors.Count(); i++)
            {
                if (!String.IsNullOrEmpty(armors[i].name))
                {
                    tmp = "[" + (i + 1).ToString() + "]";
                    if (armors[i].m_equipCheck)
                        tmp += "[E]";
                    tmp += armors[i].name + "   | " + "방어력 : +" + armors[i].defense + "  | " + armors[i].desc;
                    swap = tmp.ToCharArray();
                    for (int x = 0; x < swap.Length; x++)
                    {
                        m_buffer[3 + i, x + 5] = swap[x];
                    }
                }
            }

            tmp = "0. 나가기";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[13, i + 5] = swap[i];
            }
        }

        public void DrawWeaponManager(char[,] m_buffer, List<Weapon> weapons)
        {
            for (int i = 0; i < weapons.Count(); i++)
            {
                if (!String.IsNullOrEmpty(weapons[i].name))
                {
                    tmp = "[" + (i + 1).ToString() + "]";
                    if (weapons[i].m_equipCheck)
                        tmp += "[E]";
                    tmp += weapons[i].name + "   | " + "공격력 : +" + weapons[i].power + "  | " + weapons[i].desc;
                    swap = tmp.ToCharArray();
                    for (int x = 0; x < swap.Length; x++)
                    {
                        m_buffer[3 + i, x + 5] = swap[x];
                    }

                   
                }
            }

            tmp = "0. 나가기";
            swap = tmp.ToCharArray();
            for (int i = 0; i < swap.Length; i++)
            {
                m_buffer[13, i + 5] = swap[i];
            }
        }

    }
}
