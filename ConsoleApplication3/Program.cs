using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create a grid(an array with two dimensions) that is 8 by 8.

            //This grid will hold whether there is a ship in a given square or not.You can use a bool or an int for this.You will need to be able to display this grid, with
            //00000000
            //0000*000
            //00**0000
            //00000000
            //000**000
            //*0*00000
            //00000**0
            //00****00


            //Let the user try to "shoot" a ship by selecting two coordinates (the column and the row)

            //When users shoot an enemy, clear the ship in that cell

            //When all enemies are gone, make the "game" end.

            // Bonus:

            // If user picks a cell next to a ship, say "close!"

            Random rnd = new Random();
            bool[,] battleship = new bool[8, 8];
            bool[,] screen = new bool[8, 8];
            const int totalShips = 8;
            int shipCnt = 0;
            int hits = 0;


            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)

                {
                    if (totalShips > shipCnt)
                    {
                        battleship[x, y] = (rnd.Next(2) == 0);
                        if (battleship[x, y])
                        {
                            shipCnt++;
                        }
                    }
                    else
                    {
                        battleship[x, y] = false;
                    }
                    screen[x, y] = false;
                }
            }


            //Making a game loop after "lose"
            bool keepgoing = true;
            while (keepgoing)
            {
                keepgoing = true;
                for (int x = 0; x < 8; x++)
                {
                    Console.WriteLine();
                    for (int y = 0; y < 8; y++)

                    {
                        if (battleship[x, y] == true)
                        {
                            Console.Write("x");
                        }
                        else
                        {
                            Console.Write("o");
                        }

                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine("Please type an 'x' coordinate.");
                string answer = Console.ReadLine();
                int xSpace;
                while (!int.TryParse(answer, out xSpace) || ((xSpace < 0) || (xSpace >= 8)))
                {
                    Console.WriteLine("Not a number or out of range. Enter a number between 0-8. Try again!");
                    answer = Console.ReadLine();
                }

                Console.WriteLine("Please type a 'y' coordinate.");
                answer = Console.ReadLine();
                int ySpace;
                while (!int.TryParse(answer, out ySpace) || ((ySpace < 0) || (ySpace >= 8)))
                {
                    Console.WriteLine("Not a number or out of range. Enter a number between 0-7. Try again!");
                    answer = Console.ReadLine();
                }

                if (battleship[xSpace, ySpace] == true)
                {
                    Console.WriteLine("you hit my battleship, you win!!");
                    battleship[xSpace, ySpace] = false;
                    screen[xSpace, ySpace] = true;
                    if (++hits == shipCnt) keepgoing = false;

                }
                else
                {
                    Console.WriteLine("you lose");
                }
                Console.WriteLine("Do you want to keep going? \n[y]es\n[n]o");
                answer = Console.ReadLine();
                switch (answer.ToLower())
                {
                    case "y":
                        Console.WriteLine("Thanks, and here we go!");
                        break;
                    case "n":
                        Console.WriteLine("Thanks for playing!");
                        keepgoing = false;
                        break;
                }
            }

            Console.ReadLine();









        }
    }
}

    