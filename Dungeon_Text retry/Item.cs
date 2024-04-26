using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Text_retry
{
    internal class Item
    {
        public enum ItemType
        {
            Weapon,
            Armor
        }
        //무기인지방어구인지 이름 공방 설명 가격 장착 됐는지 안됐는지

        private ItemType Type;
        public string Name { get; }
        public int Atk { get; }
        public int Def {  get; }
        public int Hp { get; }
        public string Desc { get; }
        public int Price { get; }
        public bool IsEquipped { get; private set; }
        public bool IsPurchased { get; private set; }


        public Item(string name, ItemType type, int atk, int def, string desc, int price, bool isEquipped = false, bool isPurchased = false)
        {
            Name = name;
            Type = type;
            Atk = atk;
            Def = def;
            Desc = desc;
            Price = price;
            IsEquipped = isEquipped;
            IsPurchased = isPurchased;
        }

        //1. 인벤토리에서 내가 가진 아이템 볼 때 타입이랑
        //2. 내가 장착관리에서 아이템 낄지 말지 선택 할 때 타입 비슷
        internal void PrintItemStatDesc(bool withNumbers = false, int idx = 0)
        {
            Console.WriteLine();
            Console.Write("- ");
            if(withNumbers)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{idx} ");
                Console.ResetColor();

            }
            if (IsEquipped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(ConsoleUtility.PadRightForMixedTest(Name, 9));                
            }
            else Console.Write(ConsoleUtility.PadRightForMixedTest(Name, 12));

            Console.Write(" | ");
            
            if(Atk != 0) Console.Write($"공격력{(Atk >= 0 ? "+" : "")}{Atk}");
            if(Def != 0) Console.Write($"방어력{(Atk >= 0 ? "+" : "")}{Def}");
            if(Hp != 0 ) Console.Write($"체  력{(Atk >= 0 ? "+" : "")}{Hp}");
            

        }

        internal void ToggleEquipStatus()
        {
            IsEquipped = !IsEquipped;
        }

        internal void PrintStoreItemDesc(bool withNumbers = false, int idx = 0)
        {
            Console.Write("- ");
            if (withNumbers)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{idx} ");
                Console.ResetColor();
            }

            Console.Write(ConsoleUtility.PadRightForMixedTest(Name, 9));

            Console.Write(" | ");

            if (Atk != 0) Console.Write($"공격력{(Atk >= 0 ? "+" : "")}{Atk}");
            if (Def != 0) Console.Write($"방어력{(Atk >= 0 ? "+" : "")}{Def}");
            if (Hp != 0) Console.Write($"체  력{(Atk >= 0 ? "+" : "")}{Hp}");

            Console.Write(" | ");
            Console.Write(ConsoleUtility.PadRightForMixedTest(Desc, 12));
            Console.Write(" | ");

            if (IsPurchased)
            {
                Console.WriteLine("구매 완료");
            }
            else
            {
                ConsoleUtility.YellowWriteLine(Price.ToString() + "G");
            }

        }
        internal void Purchase()
        {
            IsPurchased = true;
        }
    }
}
