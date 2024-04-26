using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Text_retry
{
    internal class ConsoleUtility // 전반적인 콘솔에 쓰여질 녀석들
    {
        public static void Intro()//인트로 화면 (게임 시작 첫 화면)
        {
            Console.WriteLine("반갑습니다! 게임을 시작하려면 아무 키나 눌러주세요");
            Console.ReadLine();
        }

        public static int MenuSelect(int min, int max) // 메뉴 선택을 구분해주는 함수
        { 
            while (true) // 메뉴 선택하기 전까지 웨일은 풀리지 않아 
            {
                YellowWriteLine("원하시는 메뉴를 선택해주세요!");
                if (int.TryParse(Console.ReadLine(), out int select) && select >= min && select <= max)
                {
                    return select;
                }
                RedWriteLine("올바르지 않은 접근입니다.");
            }
        }

        public static void YellowWriteLine(string Txt) // 노란색 WriteLine
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Txt);
            Console.ResetColor();
        }

        public static void RedWriteLine(string Txt) // 빨간색 WriteLine
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Txt);
            Console.ResetColor();
        }

        public static int GetPrintLength(string str) // 한글열 문자열을 구분해주기 위한 함수
                                                     // 그니까 총 문자열을 10으로 해주었을 때 컴퓨터는 한글을 2칸 분량임
                                                     // 근데 그냥 남은 문자 열만큼 더해주겠다 캐버리면 한글 3글자를 쓰면 6이 되어야 하는데
                                                     // 이 작업을 안해주면 3이 되어버림
                                                     // 그래서 이 함수를 만들어 주는 것임. 어쩌고저쩌고 코드에 넣어준다
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; // 한글과 같은 넓은 문자는 2칸 취급
                }
                else
                {
                    length += 1; // 나머지는 1칸 취급??
                }
            }
            return length;
        }

        public static string PadRightForMixedTest(string str, int totalLength)
        {
            int currentLength = GetPrintLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);
        }
    }
}
