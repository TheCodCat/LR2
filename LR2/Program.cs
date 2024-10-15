class Program
{
    public static List<Num> IntsOne = new List<Num>();
    public static List<Num> IntsTwo = new List<Num>();
    public static string[] command = { "V", "H", "R", "N", "L" };
    static void Main()
    {
        PrintLine("Введите 9 цифр в строчке, больше 0 и мельше 10", ConsoleColor.Magenta);

        PrintLine("Введите первую строчку цифр", ConsoleColor.Yellow);
        IntsOne = GetNumsList();

        PrintLine("Введите вторую строчку цифр", ConsoleColor.Yellow);
        IntsTwo = GetNumsList();

        Console.WriteLine();
        GetNumbersGUI();

        int count = IntsOne.Where(x => x.IsFree).Concat(IntsTwo.Where(y => y.IsFree)).Count();
        while (count > 0)
        {
            SetParsNumber(GetTypePar());

            GetNumbersGUI();

            count = IntsOne.Where(x => x.IsFree).Concat(IntsTwo.Where(y => y.IsFree)).Count();
        }
        PrintLine("Вы проиграли", ConsoleColor.Magenta);
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

    public static List<int> GetNumbersList(int count = 5)
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

    public static List<Num> GetNumsList(int count = 5)
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

    public static TypeMode GetTypePar()
    {
        PrintLine("Введите пара по вертикали (V) или по горизонтали (H),сброс вычеркнутых (R), Сдаться (L)", ConsoleColor.Yellow);

        string comm = Console.ReadLine() + string.Empty;
        var comt = command.SingleOrDefault(x => x.Contains(comm,StringComparison.CurrentCultureIgnoreCase));

        switch (comt)
        {
            case "H": return TypeMode.Horizontal;
            case "V": return TypeMode.Vertical;
            case "R": return TypeMode.Reset;
            case "L": return TypeMode.Lose;
            default:
                PrintLine("Неверный тип, попробуйте еще раз", ConsoleColor.Red);
                return GetTypePar();
        }
    }

    public static void GetNumbersGUI()
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

    public static void SetParsNumber(TypeMode typePar)
    {
        switch (typePar)
        {
            case TypeMode.Horizontal:
                HorizontalMode();
                break;

            case TypeMode.Vertical:
                VerticalMode();
                break;

            case TypeMode.Reset:
                Order();
                break;

            case TypeMode.Lose:
                Lose();
                break;
        }
    }

    public static void HorizontalMode()
    {
		Console.Clear();
		Console.WriteLine("Режим игры по горизонтали");
		GetNumbersGUI();
		Console.WriteLine();

		Console.WriteLine($"Продолжить \"N\" или \"R\" - назад");
        string commanda = Console.ReadLine() + string.Empty;

        var comt = command.SingleOrDefault(x => x.Contains(commanda, StringComparison.CurrentCultureIgnoreCase));

        switch (comt)
		{
			case "N":
				Console.WriteLine($"Введите номер строки");
				int Stroka = GetNumberConsole();

				Console.WriteLine();

				Console.WriteLine($"Введите номер первого числа");
				int Num1 = GetNumberConsole();

				Console.WriteLine($"Введите номер второго числа");
				int Num2 = GetNumberConsole();

				switch (Stroka)
				{
					case 0:
						if (IntsOne[Num1].Value == IntsOne[Num2].Value || IntsOne[Num1].Value + IntsOne[Num2].Value == 10)
						{
							IntsOne[Num1].IsFree = false;
							IntsOne[Num2].IsFree = false;
						}
						break;

					case 1:
						if (IntsTwo[Num1].Value == IntsTwo[Num2].Value || IntsTwo[Num1].Value + IntsTwo[Num2].Value == 10)
						{
							IntsTwo[Num1].IsFree = false;
							IntsTwo[Num2].IsFree = false;
						}
						break;

					default:
						HorizontalMode();
						break;
				}
				break;

			case "R":
				SetParsNumber(GetTypePar());
				break;

			default:
                HorizontalMode();
				break;
		}
	}

    public static void VerticalMode()
    {
        Console.Clear();
        Console.WriteLine("Режим игры по вертикали");
        GetNumbersGUI();
        Console.WriteLine();

        Console.WriteLine($"Продолжить \"N\" или \"R\" - назад");
        string commanda = Console.ReadLine() + string.Empty;

        var comt = command.SingleOrDefault(x => x.Contains(commanda, StringComparison.CurrentCultureIgnoreCase));
        switch (comt)
        {
            case "N":
				Console.WriteLine("Ввоедите номер калонны");
				int columb = GetNumberConsole();

                if (columb < IntsOne.Count && columb < IntsTwo.Count  && IsColumb(columb))
                {
                    IntsOne[columb].IsFree = false;
                    IntsTwo[columb].IsFree = false;
                }
                else VerticalMode();
                break;

			case "R":
				SetParsNumber(GetTypePar());
				break;

			default:
				VerticalMode();
				break;
        }

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

    public static void Lose()
    {
        IntsOne.Clear();
        IntsTwo.Clear();
    }

    public static bool IsColumb(in int columb)
    {
        if(IntsOne[columb].Value == IntsTwo[columb].Value && IntsOne[columb].IsFree && IntsTwo[columb].IsFree) return true;
        if(IntsOne[columb].Value + IntsTwo[columb].Value == 10 && IntsOne[columb].IsFree && IntsTwo[columb].IsFree) return true;

        return false;
    }

    public static List<Num> AddNumsList()
    {
        var newList = IntsOne.Where(x => x.IsFree).Concat(IntsTwo.Where(x => x.IsFree)).ToList();
        return newList;
    }
}