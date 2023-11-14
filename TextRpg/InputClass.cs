namespace TextRpg
{
    public class InputClass
    {
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

        Thread t1;
        bool stop = false;

        //키보드 입력을 받는 함수
        private void KeyInput()
        {
            ConsoleKeyInfo m_key;

            while (!stop)
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

        public bool Esc_IsPressed()
        {
            if (escapeKey == true)
            {
                escapeKey = false;
                return true;
            }

            return false;
        }

        public bool Enter_IsPressed()
        {
            if (enterKey == true)
            {
                enterKey = false;
                return true;
            }

            return false;
        }

        public bool Up_IsPressed()
        {
            if (upArrow == true)
            {
                upArrow = false;
                return true;
            }

            return false;
        }

        public bool Down_IsPressed()
        {
            if (downArrow == true)
            {
                downArrow = false;
                return true;
            }

            return false;
        }

        public bool Right_IsPressed()
        {
            if (rightArrow == true)
            {
                rightArrow = false;
                return true;
            }

            return false;
        }

        public bool Left_IsPressed()
        {
            if (leftArrow == true)
            {
                leftArrow = false;
                return true;
            }

            return false;
        }

        public bool Num0_IsPressed()
        {
            if (num0Key == true)
            {
                num0Key = false;
                return true;
            }

            return false;
        }

        public bool Num1_IsPressed()
        {
            if (num1Key == true)
            {
                num1Key = false;
                return true;
            }

            return false;
        }

        public bool Num2_IsPressed()
        {
            if (num2Key == true)
            {
                num2Key = false;
                return true;
            }

            return false;
        }

        public bool Num3_IsPressed()
        {
            if (num3Key == true)
            {
                num3Key = false;
                return true;
            }

            return false;
        }

        public bool Num4_IsPressed()
        {
            if (num4Key == true)
            {
                num4Key = false;
                return true;
            }

            return false;
        }

        public bool Num5_IsPressed()
        {
            if (num5Key == true)
            {
                num5Key = false;
                return true;
            }

            return false;
        }

        public bool Num6_IsPressed()
        {
            if (num6Key == true)
            {
                num6Key = false;
                return true;
            }

            return false;
        }

        public void ResetKey()
        {
            upArrow = false;
            downArrow = false;
            rightArrow = false;
            leftArrow = false;
            enterKey = false;
            escapeKey = false;
            num0Key = false;
            num1Key = false;
            num2Key = false;
            num3Key = false;
            num4Key = false;
            num5Key = false;
            num6Key = false;

            return;
        }

        public void Start()
        {
            t1 = new Thread(KeyInput);
            t1.Start();

            return;
        }

        public void ShutDown()
        {
            stop = true;

            return;
        }

    }
}
