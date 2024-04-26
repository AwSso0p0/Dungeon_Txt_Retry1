using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Text_retry
{
    internal class Item
    {
        //이름 능력치추가해주는거 설명 가격

        public string Name { get; }
        public int Atk { get; }
        public int Def {  get; }
        public int Hp {  get; }
        public string Desc { get; }
        public int Gold { get; set; }

        public Item(string name, int atk, int def, int hp, string desc, int gold)
        {
            Name = name;
            Atk = atk;
            Def = def;
            Hp = hp;
            Desc = desc;
            Gold = gold;
        }
    }
}
