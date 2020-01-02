using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/** https://www.codingame.com/ide/puzzle/winamax-battle
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        Queue<string> FirstPlayer = new Queue<string>();
        Queue<string> SecondPlayer = new Queue<string>();
        for (int i = 0; i < n; i++)
        {
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            FirstPlayer.Enqueue(cardp1);
        }
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            SecondPlayer.Enqueue(cardp2);
        }
        int step = 0;
        for (; ; )
        {
            string PAT = "";
            if (FirstPlayer.Count != 0 & SecondPlayer.Count != 0)
            {
                Queue<string> FirstPlayerCard = new Queue<string>();
                Queue<string> SecondPlayerCard = new Queue<string>();
                for (; ; )
                {
                    int firstMax = 0, secondMax = 0;
                    string[] cardArr = FirstPlayer.Peek().Split(new string[] { "D", "H", "C", "S" }, StringSplitOptions.RemoveEmptyEntries);
                    string cardText = cardArr[0];
                    if (cardText == "A" && firstMax < 14) firstMax = 14;
                    else if (cardText == "K" && firstMax < 13) firstMax = 13;
                    else if (cardText == "Q" && firstMax < 12) firstMax = 12;
                    else if (cardText == "J" && firstMax < 11) firstMax = 11;
                    else if (cardText != "A" && cardText != "K" && cardText != "Q" && cardText != "J" && int.Parse(cardText) > firstMax) firstMax = int.Parse(cardText);
                    FirstPlayerCard.Enqueue(FirstPlayer.Dequeue());

                    cardArr = SecondPlayer.Peek().Split(new string[] { "D", "H", "C", "S" }, StringSplitOptions.RemoveEmptyEntries);
                    cardText = cardArr[0];
                    if (cardText == "A" && secondMax < 14) secondMax = 14;
                    else if (cardText == "K" && secondMax < 13) secondMax = 13;
                    else if (cardText == "Q" && secondMax < 12) secondMax = 12;
                    else if (cardText == "J" && secondMax < 11) secondMax = 11;
                    else if (cardText != "A" && cardText != "K" && cardText != "Q" && cardText != "J" && int.Parse(cardText) > secondMax) secondMax = int.Parse(cardText);
                    SecondPlayerCard.Enqueue(SecondPlayer.Dequeue());

                    if (firstMax == secondMax && FirstPlayer.Count != 0 && SecondPlayer.Count != 0)
                    {
                        int c = 1;
                        while (c <= 3)
                        {
                            if (FirstPlayer.Count > 0) FirstPlayerCard.Enqueue(FirstPlayer.Dequeue());
                            else
                            {
                                PAT = "PAT";
                                break;
                            }
                            if (SecondPlayer.Count > 0) SecondPlayerCard.Enqueue(SecondPlayer.Dequeue());
                            else
                            {
                                PAT = "PAT";
                                break;
                            }
                            c++;
                        }
                        if (PAT != "PAT") continue;
                        else break;
                    }
                    else if (firstMax > secondMax)
                    {
                        while (FirstPlayerCard.Count > 0)
                        {
                            FirstPlayer.Enqueue(FirstPlayerCard.Dequeue());
                        }
                        while (SecondPlayerCard.Count > 0)
                        {
                            FirstPlayer.Enqueue(SecondPlayerCard.Dequeue());
                        }
                        step++;
                        break;
                    }
                    else if (secondMax > firstMax)
                    {
                        while (FirstPlayerCard.Count > 0)
                        {
                            SecondPlayer.Enqueue(FirstPlayerCard.Dequeue());
                        }
                        while (SecondPlayerCard.Count > 0)
                        {
                            SecondPlayer.Enqueue(SecondPlayerCard.Dequeue());
                        }
                        
                        step++;
                        break;
                    }
                    else break;
                }
            }
            else if (FirstPlayer.Count != 0 && SecondPlayer.Count == 0)
            {
                Console.WriteLine("1 " + step);
                break;
            }
            else if (FirstPlayer.Count == 0 && SecondPlayer.Count != 0)
            {
                Console.WriteLine("2 " + step);
                break;
            }
            else if (FirstPlayer.Count == 0 && SecondPlayer.Count == 0)
            {
                Console.WriteLine("PAT");
                break;
            }
            if (PAT == "PAT")
            {
                Console.WriteLine("PAT");
                break;
            }
        }
    }
}
