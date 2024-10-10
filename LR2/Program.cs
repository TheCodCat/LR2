class Program
{
    public static List<Num> intsOne = new List<Num>();
    public static List<Num> intsTwo = new List<Num>();
    static void Main()
    {
        while (true)
        {
            PrintLine("Введите 9 цифр в строчке, больше 0 и мельше 10", ConsoleColor.Magenta);

            PrintLine("Введите первую строчку цифр", ConsoleColor.Yellow);
            intsOne = GetNumsList();

            PrintLine("Введите вторую строчку цифр", ConsoleColor.Yellow);
            intsTwo = GetNumsList();

            foreach (var item in intsOne)
            {
                Print(item.Value.ToString(), ConsoleColor.Cyan);   
            }

            Console.WriteLine();

            foreach (var item in intsTwo)
            {
                Print(item.Value.ToString(), ConsoleColor.Cyan);
            }

            Console.WriteLine();

            PrintLine("Введите первую пару", ConsoleColor.Yellow);

        }
    }



    public static void PrintLine(string text,ConsoleColor newcolor)
    {
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = newcolor;
        Console.WriteLine(text);
        Console.ForegroundColor = color;
    }

    public static void Print(string text, ConsoleColor newcolor)
    {
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = newcolor;
        Console.Write(text);
        Console.ForegroundColor = color;
    }

    public static List<int> GetNumbersList(int count = 3)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < count; i++)
        {
            list.Add(GetNumberConsole());
        }
        return list;
    }

    public static int GetNumberConsole()
    {
        if (int.TryParse(Console.ReadLine(), out int num) && num.ToString().Length == 1) return num;
        else
        {
            PrintLine("Произошла опечатка, попробуйте снова", ConsoleColor.Red);
            return GetNumberConsole();
        }
    }

    public static List<Num> GetNumsList(int count = 3)
    {
        List<Num> list = new List<Num>();
        for (int i = 0; i < count; i++)
        {
            list.Add(GetNumConsole());
        }
        return list;
    }

    public static Num GetNumConsole()
    {
        if(int.TryParse(Console.ReadLine(),out int num) && num.ToString().Length == 1) return new Num(num);
        else
        {
            PrintLine("Произошла опечатка, попробуйте снова", ConsoleColor.Red);
            return GetNumConsole();
        }
    }
}