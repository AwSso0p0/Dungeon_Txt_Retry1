using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Text_retry
{
    internal class Player
    {
        //레벨 이름 직업 체력 공격력 방어력 가진 돈
        public int Lv {  get; }
        public string Name { get; }
        public string Job { get; }
        public int Hp { get; }
        public int Atk { get; }
        public int Def { get; }
        public int PlayerGold { get; set; }


        public Player(int lv, string name, string job, int hp, int atk, int def, int playerGold)
        {
            Lv = lv;
            Name = name;
            Job = job;
            Hp = hp;
            Atk = atk;
            Def = def;
            PlayerGold = playerGold;
        }
    }
}
