using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Ukol1()
    {
        Console.WriteLine("Zadej číslo");
        if(!int.TryParse(Console.ReadLine(), out int num))
        {
            return;
        }
        switch(num)
        {
            case 1:
                Console.WriteLine("Zadal jsi jedničku");
                break;
            case 2:
                Console.WriteLine("Zadal jsi dvojku");
                break;
            case 3:
                Console.WriteLine("Zadal jsi trojku");
                break;
            case 4:
                Console.WriteLine("Zadal jsi čtyřku");
                break;
            case 5:
                Console.WriteLine("Zadal jsi pětku");
                break;
            default:
                Console.WriteLine("Tohle číslo neznám");
                break;
        }
    }

    static void Casino()
    {
        Console.WriteLine("Vítej v casinu!\n ----------\n\n");
        int money = 1000;
        Random rnd = new Random();
        int spinCount = 0;
        while(money > 0)
        {
            spinCount++;
            Thread.Sleep(650);
            Console.WriteLine($"\nAktuálně máš {money} korun");
            Console.WriteLine("Zadej sázku");
            if(!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0)
            {
                Console.WriteLine("Neplatná hodnota");
                continue;
            }

            else if(bet > money)
            {
                Console.WriteLine("Lol broke ass bitch zadej sázku na kterou atually máš bez prodeje orgánů");
                continue;
            }

            Console.WriteLine("Zadej počet čísel v automatu, minimum je 5(psst... od sedmi máš bonus)");
            if(!int.TryParse(Console.ReadLine(), out int range) || bet < 5)
            {
                Console.WriteLine("Neplatná hodnota");
                continue;
            }
            
            money -= bet;
            int slot1, slot2, slot3;

            if (spinCount <= 3)
            {
                slot1 = slot2 = rnd.Next(1, range + 1);
                if (spinCount == 2)
                { 
                    slot3 = slot1;
                }
                else
                {
                    slot3 = rnd.Next(1, range + 1);
                }

            }
            else
            {
                slot1 = rnd.Next(1, range + 1);
                slot2 = rnd.Next(1, range + 1);
                slot3 = rnd.Next(1, range + 1);
            }

            Console.WriteLine("\n");

            for(int i = 0; i < 40; i++)
            {
                Console.Write("\r" + rnd.Next(1, range + 1) + " " + rnd.Next(1, range + 1) + " " + rnd.Next(1, range + 1));
                Thread.Sleep(100);
            }
            Console.Write("\r" + slot1 + " " + slot2 + " " + slot3);
            Thread.Sleep(500);
            

            if(slot1 == slot2 && slot2 == slot3)
            {
                int win = bet * 10;
                if(range < 8)
                {
                    win = (int)(win * ((double)range / 10 + 0.3));
                }
                Console.WriteLine($"\nJackpot! Výhral jsi {win} korun!");
                money += win;
            }
            else if (slot1 == slot2 || slot1 == slot3 || slot2 == slot3)
            {
                int win = bet * 2;
                if(range < 8)
                {
                    bet = (int)(win * ((double)range / 10 + 0.3));
                }
                else
                {
                    win += bet/10;
                }
                Console.WriteLine($"\nBig win! Výhral jsi {win} korun!");
                money += win;
            }
            else
            {
                Console.WriteLine("\nBohužel jsi prohrál, ale zkus to znovu, tentokrát to určitě vyjde!");
            }
        }
        Thread.Sleep(650);
        Console.WriteLine("Bohužel ti došly peníze, končíš");
        return;
    }

    static void caesar()
    {
        List<char> alphabet = new List<char> {
            ' ', ',', '.', 
            'a', 'b', 'c', 'd', 'e', 'f', 'g',
            'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
            'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
            'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        Console.WriteLine("Zadej text");
        string text = Console.ReadLine();
        Console.WriteLine("Zadej klíč(počet posunutí)");
        if(!int.TryParse(Console.ReadLine(), out int key))
        {
            Console.WriteLine("Neplatný klíč");
            return;
        }

        int letterCount = alphabet.Count;
        List<string> result = new List<string>();
        Console.WriteLine("Chceš [z]ašifrovat nebo [o]dšifrovat?");
        string operation = Console.ReadLine();

        foreach (char letter in text)
        {
            int idx = alphabet.IndexOf(letter);
            if (idx == -1)
            {
                Console.WriteLine($"Znak {letter} není v abecedě, bude ponechán tak jak je");
                result.Add(letter.ToString());
                continue;
            }

            if (operation.ToLower() == "z")
            {
                int newIndex = (idx + key) % letterCount;
                result.Add(alphabet[newIndex].ToString());
            } 
            else if (operation.ToLower() == "o")
            {
                int newIndex = (idx - key) % letterCount;
                if (newIndex < 0)
                    newIndex += letterCount;
                result.Add(alphabet[newIndex].ToString());
            }
            else
            {
                Console.WriteLine("Neplatná operace");
                return;
            }
        }

        if (operation.ToLower() == "o")
        {
            Console.WriteLine("Odšifrovaný text: " + string.Join("", result));
        }
        else if (operation.ToLower() == "z")
        {
            Console.WriteLine("Zašifrovaný text: " + string.Join("", result));
        }
        else
        {
            return;
        }
    }

    static void fuckUp()
    {
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            new Thread(() =>
            {
                while (true) { }
            }).Start();
        }
    }

    static void convertToBin()
    {
        List<int> bin = new List<int>();
        Console.WriteLine("Zadej celé číslo, které chceš převést");
        string inputStr = Console.ReadLine();
        if (!int.TryParse(inputStr, out int input))
        {
            Console.WriteLine("Neplatné číslo.");
            return;
        }
        int permInput = input;
        while (input > 0)
        {
            bin.Add(input % 2);
            input /= 2;
        }
        bin.Reverse();
        string result = string.Join("", bin);
        Console.WriteLine($"Číslo {permInput} převedené na binární kód je {result}");
    }

    static void convertFromBin()
    {
        Console.WriteLine("Zadej binární kód");
        string bin = Console.ReadLine();
        int result = 0;
        foreach (char digit in bin)
        {
            if (digit == '1')
            {
                result = result * 2 + 1;
            }
            else if (digit == '0')
            {
                result = result * 2;
            }
            else
            {
                Console.WriteLine("Neplatný binární kód.");
                return;
            }
        }
        Console.WriteLine($"Kód {bin} převedený na čísla je {result}");
    }

    static int Addition(List<int> valList)
    {
        int result = 0;
        foreach (int val in valList)
        {
            result += val;
        }
        return result;
    }

    static int Subtraction(List<int> valList)
    {
        int result = valList[0];
        for (int i = 1; i < valList.Count; i++)
        {
            result -= valList[i];
        }
        return result;
    }

    static int Multiplication(List<int> valList)
    {
        int result = valList[0];
        for (int i = 1; i < valList.Count; i++)
        {
            result *= valList[i];
        }
        return result;
    }

    static int Division(List<int> valList)
    {
        int result = valList[0];
        for (int i = 1; i < valList.Count; i++)
        {
            if (valList[i] == 0)
            {
                Console.WriteLine("Dělení nulou!");
                return 0;
            }
            result /= valList[i];
        }
        return result;
    }

    static void Modulo(List<int> valList)
    {
        Console.WriteLine("Pokud jsi zadal víc čísel, bude zjištěna dělitelnost prvního čísla druhým");
        if (valList.Count < 2 || valList[1] == 0)
        {
            Console.WriteLine("Neplatný vstup pro modulo.");
            return;
        }
        int result = valList[0] % valList[1];
        if (result == 0)
        {
            Console.WriteLine($"Číslo {valList[0]} je dělitelné {valList[1]}");
        }
        else
        {
            Console.WriteLine($"Číslo {valList[0]} není dělitelné {valList[1]}");
        }
    }

    static void Food()
    {
        Console.WriteLine("Jak se jmenuješ?");
        string name = Console.ReadLine();
        string favFood;
        Console.WriteLine("Jaké je tvé oblíbené jídlo?");
        favFood = Console.ReadLine();
        Console.WriteLine($"Jmenuješ se {name} a tvé oblíbené jídlo je {favFood}");
    }

    static void Age()
    {
        Console.WriteLine("Pornsite-grade age checker\n");
        Console.WriteLine("Zadej svůj věk");
        string ageInput = Console.ReadLine();
        if (!int.TryParse(ageInput, out int age))
        {
            Console.WriteLine("Neplatný věk.");
            return;
        }

        if (age < 13)
        {
            Console.WriteLine($"Jsi dítě, protože ti je {age} let");
        }
        else if (age <= 17)
        {
            Console.WriteLine($"Jsi teenager, protože ti je {age} let");
        }
        else if (age > 90)
        {
            Console.WriteLine($"Old ass co tu ještě děláš nech už svoje děti dědit doslova je ti {age} let");
        }
        else
        {
            Console.WriteLine($"Jsi dospělý, protože ti je {age} let, unc");
        }
    }

    static void Calc()
    {
        Console.WriteLine("Kolik chceš hodnot?");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int valCount) || valCount <= 0)
        {
            Console.WriteLine("Neplatný počet hodnot.");
            return;
        }

        List<int> valList = new List<int>();
        for (int i = 0; i < valCount; i++)
        {
            Console.WriteLine("Zadej hodnotu");
            string valInput = Console.ReadLine();
            if (!int.TryParse(valInput, out int val))
            {
                Console.WriteLine("Neplatné číslo, přeskočeno.");
                continue;
            }
            valList.Add(val);
        }

        if (valList.Count == 0)
        {
            Console.WriteLine("Žádná platná čísla.");
            return;
        }

        Console.WriteLine(string.Join(",", valList));

        Console.WriteLine("Jakou chceš provést operaci? [A]dd, [S]ubtract, [M]ultiply, [D]ivide, M[o]dulo");
        string operation = Console.ReadLine();
        int result;
        switch (operation.ToLower())
        {
            case "a":
                result = Addition(valList);
                Console.WriteLine($"Výsledek je {result}");
                break;

            case "s":
                result = Subtraction(valList);
                Console.WriteLine($"Výsledek je {result}");
                break;

            case "m":
                result = Multiplication(valList);
                Console.WriteLine($"Výsledek je {result}");
                break;

            case "d":
                result = Division(valList);
                Console.WriteLine($"Výsledek je {result}");
                break;

            case "o":
                Modulo(valList);
                break;

            default:
                Console.WriteLine("Zadej platnou operaci");
                break;
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Vyber nástroj: [C]alculator, [F]ood, [A]ge, [T]o binary, F[r]om binary, F[u]ckup, Cae[s]arova šifra, [G]ambling nebo zadej číslo úkolu");
            string option = Console.ReadLine();
            switch (option.ToLower())
            {
                case "c":
                    Calc();
                    break;
                case "f":
                    Food();
                    break;
                case "a":
                    Age();
                    break;
                case "t":
                    convertToBin();
                    break;
                case "r":
                    convertFromBin();
                    break;
                case "u":
                    fuckUp();
                    break;
                case "s":
                    caesar();
                    break;
                case "g":
                    Casino();
                    break;
                case "1":
                    Ukol1();
                    break;
                default:
                    Console.WriteLine("Neplatná volba");
                    break;
            }
        }
    }
}
