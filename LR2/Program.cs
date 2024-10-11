class Program
{
    public static List<Num> IntsOne = new List<Num>();
    public static List<Num> IntsTwo = new List<Num>();
    static void Main()
    {
        PrintLine("Введите 9 цифр в строчке, больше 0 и мельше 10", ConsoleColor.Magenta);

        PrintLine("Введите первую строчку цифр", ConsoleColor.Yellow);
        IntsOne = GetNumsList();

        PrintLine("Введите вторую строчку цифр", ConsoleColor.Yellow);
        IntsTwo = GetNumsList();

        Console.WriteLine();

        SetParsNumber(GetTypePar());

        GetNumbers();

        SetParsNumber(GetTypePar());

        GetNumbers();

        Order();

        GetNumbers();

        Console.ReadLine();
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

    public static TypePar GetTypePar()
    {
        PrintLine("Введите пара по вертикали (V) или по горизонтали (H)", ConsoleColor.Yellow);
        string[] comand = new string[] {"H","V" };

        string comm = Console.ReadLine();

        switch (comm)
        {
            case "H": return TypePar.Horizontal;
            case "V": return TypePar.Vertical;
            default:
                PrintLine("Неверный тип, попробуйте еще раз", ConsoleColor.Red);
                return GetTypePar();
        }
    }

    public static void GetNumbers()
    {
        Console.WriteLine();
        foreach (var item in IntsOne)
        {
            Print(item.Value.ToString(), item.GetColorIsFree());
        }

        Console.WriteLine();

        foreach (var item in IntsTwo)
        {
            Print(item.Value.ToString(), item.GetColorIsFree());
        }
    }

    public static void SetParsNumber(TypePar typePar)
    {
        switch (typePar)
        {
            case TypePar.Horizontal:
                HorizontalMode();
                break;

            case TypePar.Vertical:
                VerticalMode();
                break;
        }
    }

    public static void HorizontalMode()
    {
        Console.WriteLine("Режим игры по горизонтали");
    }

    public static void VerticalMode()
    {
        Console.Clear();
        Console.WriteLine("Режим игры по вертикали");

        GetNumbers();
        Console.WriteLine();

        Console.WriteLine($"Введите номер калонны пары");
        int columb = GetNumberConsole();

        if (IntsOne[columb].Value == IntsTwo[columb].Value && IntsOne[columb].IsFree && IntsTwo[columb].IsFree)
        {
            IntsOne[columb].IsFree = false;
            IntsTwo[columb].IsFree = false;
        }
        else VerticalMode();
    }

    public static void Order()
    {
        var intsOne = IntsOne.Where(x => !x.IsFree);
        var intsTwo = IntsTwo.Where(x => !x.IsFree);

        foreach (var item in intsOne.ToList())
        {
            IntsOne.Remove(item);
        }
        foreach (var item in intsTwo.ToList())
        {
            IntsTwo.Remove(item);
        }
    }
}