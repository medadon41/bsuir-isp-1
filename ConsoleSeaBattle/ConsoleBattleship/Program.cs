using System;

namespace ConsoleBattleship
{
    public class Player
    {
        public string name;
        public string[,] mainBoard = new string[12, 12]
        {
            {"   ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", " "},
            {"  1", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"  2", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"  3", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"  4", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"  5", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"  6", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"  7", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"  8", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"  9", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {" 10", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~", " "},
            {"   ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "}
        };
        public string[,] enemyBoard = new string[11, 11]
        {
            {"   ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"},
            {"  1", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {"  2", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {"  3", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {"  4", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {"  5", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {"  6", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {"  7", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {"  8", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {"  9", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",},
            {" 10", "~", "~", "~", "~", "~", "~", "~", "~", "~", "~",}
        };
        public int activeSquares = 20;
        public bool Convert(ref string turn)
        {
            if (turn == "" || turn.Length == 1) return false;
            switch (turn[0])
            {
                case 'A':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "1");
                    return true;
                case 'B':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "2");
                    return true;
                case 'C':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "3");
                    return true;
                case 'D':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "4");
                    return true;
                case 'E':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "5");
                    return true;
                case 'F':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "6");
                    return true;
                case 'G':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "7");
                    return true;
                case 'H':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "8");
                    return true;
                case 'I':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "9");
                    return true;
                case 'J':
                    turn = turn.Remove(0, 1);
                    turn = turn.Insert(0, "10");
                    return true;
                default:
                    return false;
            }
        }
        public int CheckAround(string[,] board, int x, int y, int type, bool isConnecting)
        {
            int result = 0;
            if (isConnecting)
            {
                if (int.TryParse(board[y - 1, x].Substring(0, 1), out type))
                {
                    if (int.Parse(board[y - 1, x]) != type)
                    {
                        result = 1;
                    }

                }
                if (int.TryParse(board[y, x - 1].Substring(0, 1), out type))
                {
                    if (int.Parse(board[y, x - 1]) != type)
                    {
                        result = 1;
                    }
                }
                if (int.TryParse(board[y + 1, x].Substring(0, 1), out type))
                {
                    if (int.Parse(board[y + 1, x]) != type)
                    {
                        result = 1;
                    }
                }
                if (int.TryParse(board[y, x + 1].Substring(0, 1), out type))
                {
                    if (int.Parse(board[y, x + 1]) != type)
                    {
                        result = 1;
                    }
                }
                if (
               int.TryParse(board[y, x].Substring(0, 1), out type) ||
               int.TryParse(board[y - 1, x - 1].Substring(0, 1), out type) ||
               int.TryParse(board[y + 1, x + 1].Substring(0, 1), out type) ||
               int.TryParse(board[y + 1, x - 1].Substring(0, 1), out type) ||
               int.TryParse(board[y - 1, x + 1].Substring(0, 1), out type)
               )
                {
                    result = 1;
                }
            }
            else
            {
                if (
           int.TryParse(board[y, x].Substring(0, 1), out type) ||
           int.TryParse(board[y - 1, x].Substring(0, 1), out type) ||
           int.TryParse(board[y, x - 1].Substring(0, 1), out type) ||
           int.TryParse(board[y + 1, x].Substring(0, 1), out type) ||
           int.TryParse(board[y, x + 1].Substring(0, 1), out type) ||
           int.TryParse(board[y - 1, x - 1].Substring(0, 1), out type) ||
           int.TryParse(board[y + 1, x + 1].Substring(0, 1), out type) ||
           int.TryParse(board[y + 1, x - 1].Substring(0, 1), out type) ||
           int.TryParse(board[y - 1, x + 1].Substring(0, 1), out type)
           )
                {
                    result = 1;
                }
            }
            return result;
        }
        public void ShowBoard(string[,] board)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(board[i, j] + ' ');
                }
                Console.Write('\n');
            }
        }

        public void CountCords(string cords, ref int cordX, ref int cordY)
        {
            if (cords.StartsWith("10"))
            {
                cordX = 10;
                cordY = (int)Char.GetNumericValue(cords[2]);
                if (cords.EndsWith("10"))
                    cordY = 10;
            }
            else if (cords.EndsWith("10"))
            {
                cordX = (int)Char.GetNumericValue(cords[0]);
                cordY = 10;
            }
            else
            {
                cordX = (int)Char.GetNumericValue(cords[0]);
                cordY = (int)Char.GetNumericValue(cords[1]);
            }
        }

        public void CreateShip(int type, string type_name)
        {
            string turn;
            bool isConnecting = false;
            for (int k = 5 - type; k > 0; k--)
            {
                Console.Clear();
                this.ShowBoard(this.mainBoard);
                Console.Write($"{this.name}, choose where to put a {type_name} ({type}-square) ({k} left): ");
                for (int i = 0; i < type; i++)
                {
                PartRetry:
                    turn = Console.ReadLine();

                    if (!(this.Convert(ref turn)))
                    {
                        Console.WriteLine("Invalid coordinates! Please use the correct format (ex.: F5).");
                        goto PartRetry;
                    }

                    int turnX = 0;
                    int turnY = 0;

                    this.CountCords(turn, ref turnX, ref turnY);


                    if (this.mainBoard[turnY - 1, turnX] == type.ToString() ||
                        this.mainBoard[turnY, turnX - 1] == type.ToString() ||
                        this.mainBoard[turnY + 1, turnX] == type.ToString() ||
                        this.mainBoard[turnY, turnX + 1] == type.ToString() ||
                        i == 0)
                    {
                        if (i > 0) { isConnecting = true; } else if (type == 1) { isConnecting = false; }
                        switch (this.CheckAround(this.mainBoard, turnX, turnY, 3, isConnecting))
                        {
                            case 1:
                                {
                                    Console.WriteLine("Invalid coordinates! Ships must be 1 square away from each other.");
                                    goto PartRetry;
                                }
                            default:
                                {
                                    this.mainBoard[turnY, turnX] = type.ToString();
                                    break;
                                }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates! Destroyer's squares should be connected with each other");
                        goto PartRetry;
                    }

                }
            }
        }
        public bool IdentShot(ref string shot, ref Player enemyPlayer)
        {
            this.Convert(ref shot);
            int shotX = 0;
            int shotY = 0;
            this.CountCords(shot, ref shotX, ref shotY);

            Console.WriteLine($"Y: {shotY} X: {shotX}");

            if(int.TryParse(enemyPlayer.mainBoard[shotY, shotX].Substring(0, 1), out int _test))
            {
                this.enemyBoard[shotY, shotX] = enemyPlayer.mainBoard[shotY, shotX];
                enemyPlayer.mainBoard[shotY, shotX] = "X"; 
                enemyPlayer.activeSquares -= 1;
                return true;
            } else
            {
                this.enemyBoard[shotY, shotX] = "*";
                enemyPlayer.mainBoard[shotY, shotX] = "*";
                return false;
            }
        }

    }
    class Program
    {
        static void Main()
        {
            var Player1 = new Player();
            var Player2 = new Player();

            Console.Write("The first player, enter your nickname: ");
            Player1.name = Console.ReadLine();
            Console.Write("The second player, enter your nickname: ");
            Player2.name = Console.ReadLine();

        InputRetry1:
            Console.Write(Player1.name + ", are you ready? Make sure your opponent can't see your ships ('+' if ready) ");
            switch (Console.ReadLine())
            {
                case "+": Console.Clear(); break;
                default: goto InputRetry1;
            };

            //First player's ship placement


            Player1.CreateShip(1, "Torpedo Boat");

            Player1.CreateShip(2, "Cruiser");

            Player1.CreateShip(3, "Destroyer");

            Player1.CreateShip(4, "Battleship");

            Console.Clear();

            //Second player's ship placement

        InputRetry2:
            Console.Write(Player2.name + ", are you ready? Make sure your opponent can't see your ships ('+' if ready) ");
            switch (Console.ReadLine())
            {
                case "+": Console.Clear(); break;
                default: goto InputRetry2;
            };

            Player2.CreateShip(1, "Torpedo Boat");

            Player2.CreateShip(2, "Cruiser");

            Player2.CreateShip(3, "Destroyer");

            Player2.CreateShip(4, "Battleship");

            Console.Clear();

            int whosTurn = 0;
            Player[] Players = new Player[2] { Player1, Player2 };
            string shot;
            int isWin = 1;
            while (isWin != 0)
            { 
            InputRetry3:
                Console.WriteLine(Players[whosTurn].name + ", are you ready? Make sure your opponent can't see your ships ('+' if ready) ");
                switch (Console.ReadLine())
                {
                    case "+": Console.Clear(); break;
                    default: goto InputRetry3;
                };
            AddShot:
                Console.Clear();
                Console.WriteLine("Your sea:");
                Players[whosTurn].ShowBoard(Players[whosTurn].mainBoard);
                Console.WriteLine("Enemy sea:");
                Players[whosTurn].ShowBoard(Players[whosTurn].enemyBoard);
            ShotRetry:
                Console.Write($"{Players[whosTurn].name}, your turn! Choose where you gonna shoot: ");
                shot = Console.ReadLine();
                if (!(Players[whosTurn].Convert(ref shot)))
                {
                    Console.WriteLine("Invalid coordinates! Please use the correct format (ex.: F5).");
                    goto ShotRetry;
                }
                if (Players[whosTurn].IdentShot(ref shot, ref Players[1 - whosTurn]))
                {
                    Console.Clear();
                    if (Player1.activeSquares == 0 || Player2.activeSquares == 0)
                    {
                        isWin = 0;
                    }
                    Console.WriteLine("You've hitted a ship! Additional turn.");
                    goto AddShot;
                }
                else
                {
                    whosTurn = 1 - whosTurn;
                    Console.Clear();
                }

            }
            Console.Clear();
            Console.WriteLine($"============ {Player1.name} sea ============");
            Player1.ShowBoard(Player1.mainBoard);
            Console.WriteLine($"============ {Player2.name} sea ============");
            Player2.ShowBoard(Player2.mainBoard);
            Console.WriteLine("=============================================");
            if (Player1.activeSquares == 0)
            {
                Console.WriteLine($"{Player1.name}'s ships are destroyed! {Player2.name} WINS THE BATTLE!!!");
            } 
            else if (Player2.activeSquares == 0)
            {
                Console.WriteLine($"{Player2.name}'s ships are destroyed! {Player1.name} WINS THE BATTLE!!!");
            }
            Console.WriteLine("=============================================");
            Console.WriteLine("\nConsole Sea Battle v. 1.0 (23.02.21), created by medadon41 :^)");

            Console.ReadKey();

        }

    }


}


