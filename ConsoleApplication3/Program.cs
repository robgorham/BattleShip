﻿using System;
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
            int[,] screen = new int[8, 8];
            const int totalShips = 4;
            int shipCnt = 0;
            int hits = 0;


            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)

                {
                    battleship[x, y] = false;
                    screen[x, y] = 0;
                }
            }


            for(int x = 0; x <totalShips; x++) //paint battleships
            {
                int shipLngth = rnd.Next(6)+1;
                int dir = rnd.Next(2);
                int xStart = rnd.Next(8);
                int yStart = rnd.Next(8);
                Console.WriteLine("sl" + shipLngth + " dir" + dir + " x" + xStart + " y" + yStart);
                switch (dir) //paint ships
                {
                    case 0: //means we're going down
                        if((yStart + shipLngth )> 7)
                        {
                            Console.WriteLine("breaky");
                            x--;
                            break;
                        }
                        for(int i = yStart;i < yStart+shipLngth;i++)//put ship in array
                        {
                            battleship[i, yStart] = true;
                        }
                        break;
                    case 1: //means we're going down
                        if ((xStart + shipLngth) > 7)
                        {
                            Console.WriteLine("breakx");
                            x--;
                            break;
                        }
                        for (int i = xStart; i < xStart + shipLngth; i++)//put ship in array
                        {
                            battleship[xStart, i] = true;                           
                        }
                        break;


                }
            }


            //Making a game loop after "lose"
            bool keepgoing = true;
            while (keepgoing)
            {
                keepgoing = true;
                /**
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
                }**/
                Console.Clear();
                Console.WriteLine("  0 1 2 3 4 5 6 7");
                for (int x = 0; x < 8; x++)
                {
                    Console.WriteLine();
                    Console.Write(x + " ");
                   
                    for (int y = 0; y < 8; y++)

                    {  
                        
                       switch(screen[x,y])
                        {
                            case 0:
                                Console.Write("^ ");//water
                                break;
                            case 1:
                                Console.Write("X ");//hit
                                break;
                            case 2:
                                Console.Write("O ");
                                break;
                        };
                    }
                    Console.WriteLine();
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
                    screen[xSpace, ySpace] = 1;
                    if (++hits == shipCnt) keepgoing = false;

                }
                else
                {
                    Console.WriteLine("you lose");
                    screen[xSpace, ySpace] = 2;
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

    