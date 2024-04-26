using Dungeon_Text_retry;
using System.Diagnostics;

namespace Dungeon_Text_retry
{
    internal class GameManager
    {
        int hi;
        private Player player;
        public List<Item> itemList;
        private List<Item> storeItemList;


        //item리스트
        //player
        //각종Console를 관리해줄 녀석



        public GameManager()
        {
            EarlyGame();
        }

        public void EarlyGame() // 게임 초기 설정, 아이템 데이터
        {
            player = new Player(10, "LaBa", "God", 100, 5, 1,1500000);

            itemList = new List<Item>();

            storeItemList = new List<Item>();
            storeItemList.Add(new Item("무쇠갑옷", Item.ItemType.Armor, 0, 5, "아주 단단한 갑옷이다", 500));
            storeItemList.Add(new Item("낡은 검",Item.ItemType.Weapon, 10, 0, "좀 오래 되어 보이는 검이다", 1500));
            storeItemList.Add(new Item("여의주", Item.ItemType.Weapon, 15, 0, "구슬인 줄 알았는데?", 3000));
            storeItemList.Add(new Item("우스가르드소드", Item.ItemType.Weapon, 30, 0, "무기 마스터의 수련검", 50000));

        }
        public void StartGame() // 게임을 시작하게 되면
        {
            Console.Clear();
            ConsoleUtility.Intro();
            MainMenu();
        }

        public void MainMenu() // 메인이자 첫 번째 메뉴
        {
            Console.Clear();
            ConsoleUtility.YellowWriteLine("스파르타 마을에 오신것을 환영합니다!");
            Console.WriteLine("이곳에선 던전에 들어가기 전 준비를 할 수 있는 마을입니다");
            Console.WriteLine("");

            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");

            int select = ConsoleUtility.MenuSelect(1, 3);
            switch (select)
            {
                case 1:
                    Condition();
                    break;
                case 2:
                    Inventory();
                    break;
                case 3:
                    Shop();
                    break;
            }

        }

        private void Condition() // 상태창
        {
            //구현 할 것 : 레벨 표기, 이름표기, 직업, 체공방
            Console.Clear();
            ConsoleUtility.YellowWriteLine("[캐릭터 상태]");
            Console.WriteLine("");
            Console.WriteLine("이곳에서는 캐릭터의 상태를 확인할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("레  벨 : " + player.Lv);
            Console.WriteLine("이  름 : " + player.Name);
            Console.WriteLine("직  업 : " + player.Job);
                        
            //아이템 장착시 능력치 강화된 것 표현
            int plusAtk = itemList.Select(item => item.IsEquipped ? item.Atk : 0).Sum();
            int plusDef = itemList.Select(item => item.IsEquipped ? item.Def : 0).Sum();
            int plusHp = itemList.Select(item => item.IsEquipped ? item.Hp : 0).Sum();

            Console.WriteLine("공격력 : " + (player.Atk + plusAtk).ToString());
            Console.WriteLine("방어력 : " + (player.Def + plusDef).ToString());
            Console.WriteLine("체력 : " + (player.Hp + plusHp).ToString());


            Console.WriteLine("보유 골드 : " + player.PlayerGold);
            Console.WriteLine();

            Console.WriteLine("0. 나가기");

            int select = ConsoleUtility.MenuSelect(0, 0);
            switch (select)
            {
                case 0:
                    MainMenu();
                    break;
            }
        }

        private void Inventory() // 인벤토리
        {
            Console.Clear();
            ConsoleUtility.YellowWriteLine("[인벤토리]");
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            ConsoleUtility.YellowWriteLine("[아이템 목록]");
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].PrintItemStatDesc();
            }
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착 관리");

            int select = ConsoleUtility.MenuSelect(0, 1);
            switch (select)
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    EquipMenu();
                    break;
            }
        }


        private void EquipMenu()
        {
            Console.Clear();
            ConsoleUtility.YellowWriteLine("[인벤토리 - 장착 관리]");
            Console.WriteLine("보유중인 아이템을 장착하거나 해제할 수 있습니다.");
            ConsoleUtility.YellowWriteLine("[아이템 목록]");
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].PrintItemStatDesc(true, i + 1); //나가기가 0번 고정이라 +1 써넣어줌
            }

            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            int select = ConsoleUtility.MenuSelect(0, itemList.Count);

            switch (select)
            {
                case 0:
                    MainMenu();
                    break;
                default:
                    itemList[select - 1].ToggleEquipStatus();
                    EquipMenu();
                    break;
            }

        }

        private void Shop() // 상점
        {
            Console.Clear(); 
            ConsoleUtility.YellowWriteLine("[상점]");
            Console.WriteLine("없는거 빼고 다 있는 상점이다.");
            Console.WriteLine();
            ConsoleUtility.YellowWriteLine("[보유 골드]");
            ConsoleUtility.YellowWriteLine(player.PlayerGold.ToString() + " G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for(int i = 0; i < storeItemList.Count; i++)
            {
                storeItemList[i].PrintStoreItemDesc();
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 아이템 구매");
            switch (ConsoleUtility.MenuSelect(0, 1))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    PurchaseMenu();
                    break;
            }

        }

        private void PurchaseMenu(string? prompt = null)
        {
            if (prompt != null)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                Thread.Sleep(1000);//1초간 멈추고 다음에 진행
            }

            Console.Clear() ;

            ConsoleUtility.YellowWriteLine("[상점]");
            Console.WriteLine("없는거 빼고 다 있는 상점이다.");
            Console.WriteLine();
            ConsoleUtility.YellowWriteLine("[보유 골드]");
            ConsoleUtility.YellowWriteLine(player.PlayerGold.ToString() + " G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < storeItemList.Count; i++)
            {
                storeItemList[i].PrintStoreItemDesc(true, i + 1); // 0번은 나가기
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int select = ConsoleUtility.MenuSelect(0, storeItemList.Count);

            switch(select)
            {
                case 0:
                    MainMenu();
                    break; 
                default:
                    //1. 이미 구매한 경우
                    if (storeItemList[select - 1].IsPurchased == true) // -1한 이유는 인덱스맞추기 작업
                    {
                        PurchaseMenu("이미 구매한 아이템입니다") ;
                    }
                    //2. 돈이 충분해서 살 수 있는 경우
                    else if (player.PlayerGold >= storeItemList[select - 1].Price)
                    {
                        player.PlayerGold -= storeItemList[select - 1].Price;
                        storeItemList[select - 1].Purchase();
                        itemList.Add(storeItemList[select - 1]);
                        PurchaseMenu();
                    }
                    //3. 돈이 모자라는 경우 순서 중요
                    else
                    {
                        PurchaseMenu("Gold가 부족합니다.");
                    }
                    break;

            }

        }

    }
}
public class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartGame();
    }
}
