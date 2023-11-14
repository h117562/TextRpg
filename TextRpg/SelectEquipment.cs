using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    public class SelectEquipment
    {

        //해당되는 번호의 장비 장착
        public void Select(List<Weapon> weapons, InputClass m_input)
        {
            //숫자를 6번까지 밖에 못받으므로 번거롭긴 하지만 if문으로 처리함
            //switch 문으로 바꿀려면 inputclass를 고쳐야 함
            if(m_input.Num1_IsPressed())
            {

                if (weapons.Count() > 0)
                {

                    Off_Others(weapons, 0);
                    weapons[0].SwitchEquip();
                }
            }

            if (m_input.Num2_IsPressed())
            {

                if (weapons.Count() > 1)
                {

                    Off_Others(weapons, 1);
                    weapons[1].SwitchEquip();
                }
            }

            if (m_input.Num3_IsPressed())
            {

                if (weapons.Count() > 2)
                {

                    Off_Others(weapons, 2);
                    weapons[2].SwitchEquip();
                }
            }

            if (m_input.Num4_IsPressed())
            {

                if (weapons.Count() > 3)
                {

                    Off_Others(weapons, 3);
                    weapons[3].SwitchEquip();
                }
            }

            if (m_input.Num5_IsPressed())
            {

                if (weapons.Count() > 4)
                {

                    Off_Others(weapons, 4);
                    weapons[4].SwitchEquip();
                }
            }

            if (m_input.Num6_IsPressed())
            {

                if (weapons.Count() > 5)
                {

                    Off_Others(weapons, 5);
                    weapons[5].SwitchEquip();
                }
            }
        }

        //해당되는 번호의 장비 장착
        public void Select(List<Armor> armors, InputClass m_input)
        {
            //숫자를 6번까지 밖에 못받으므로 번거롭긴 하지만 if문으로 처리함
            //switch 문으로 바꿀려면 inputclass를 고쳐야 함
            if (m_input.Num1_IsPressed())
            {

                if (armors.Count() > 0)
                {

                    Off_Others(armors, 0);
                    armors[0].SwitchEquip();
                }
            }

            if (m_input.Num2_IsPressed())
            {

                if (armors.Count() > 1)
                {

                    Off_Others(armors, 1);
                    armors[1].SwitchEquip();
                }
            }

            if (m_input.Num3_IsPressed())
            {

                if (armors.Count() > 2)
                {

                    Off_Others(armors, 2);
                    armors[2].SwitchEquip();
                }
            }

            if (m_input.Num4_IsPressed())
            {

                if (armors.Count() > 3)
                {

                    Off_Others(armors, 3);
                    armors[3].SwitchEquip();
                }
            }

            if (m_input.Num5_IsPressed())
            {

                if (armors.Count() > 4)
                {

                    Off_Others(armors, 4);
                    armors[4].SwitchEquip();
                }
            }

            if (m_input.Num6_IsPressed())
            {

                if (armors.Count() > 5)
                {

                    Off_Others(armors, 5);
                    armors[5].SwitchEquip();
                }
            }
        }


        //해당 장비 이외에 다른 장비들 장착해제
        private void Off_Others(List<Weapon> weapons, int n)
        {
            for (int i = 0; i < weapons.Count(); i++)
            {
                //선택한 장비 제외
                if (n == i)
                    continue;


                if (weapons[i].m_equipCheck)
                {
                    weapons[i].SwitchEquip();
                }
            }
        }

        //해당 장비 이외에 다른 장비들 장착해제
        private void Off_Others(List<Armor> armors, int n)
        {
            for (int i = 0; i < armors.Count(); i++)
            {
                //선택한 장비 제외
                if (n == i)
                    continue;


                if (armors[i].m_equipCheck)
                {
                    armors[i].SwitchEquip();
                }
            }
        }
    }
}
