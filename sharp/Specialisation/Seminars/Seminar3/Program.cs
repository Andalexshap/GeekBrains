using Seminar3;

internal class Program
{
    private static void Main(string[] args)
    {
        //Task1();
        //Task2();
        //Task3();
        //Task4();
        //Task5();
        //Task6();
    }

    public static void Task1()
    {
        /*
         * Задача 1: Фильтрация и проекция данных с использованием LINQ
         * Предоставьте студентам некоторую коллекцию объектов (например, 
         * список студентов) и попросите их решить следующие задачи:
         * Найти всех студентов, чей возраст меньше 25 лет.
         * Вывести имена всех студентов в алфавитном порядке.
         * Выбрать студентов, обучающихся на факультете инженерии.
         * Посчитать средний возраст студентов.
         */

        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Age = 22, Faculty = "Engineering" },
            new Student { Name = "Bob", Age = 25, Faculty = "Science" },
            new Student { Name = "Charlie", Age = 19, Faculty = "Engineering" },
            new Student { Name = "David", Age = 30, Faculty = "Arts" },
            new Student { Name = "Eve", Age = 21, Faculty = "Science" },
            // Добавьте других студентов по вашему усмотрению
        };

        var findAge = students.Where(x => x.Age < 25);
        var sortName = students.OrderBy(x => x.Name).Select(x => x.Name);
        var findEngeners = students.Where(x => x.Faculty.Equals("Engineering"));
        var averageEge = students.Average(x => x.Age);

        findAge.ToList().ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
        sortName.ToList().ForEach(x => Console.WriteLine($"{x}, "));
        findEngeners.ToList().ForEach(x => Console.WriteLine($"{x.Name} - {x.Faculty}"));
        Console.WriteLine(averageEge);
    }

    public static void Task2()
    {
        /*
         * Отсортировать заказы по сумме в убывающем порядке.
         * Сгруппировать заказы по клиентам и вывести количество заказов для каждого клиента.
         * Найти клиента с наибольшей суммой заказов.
         * Вывести список клиентов и общую сумму их заказов.
         * Попросите студентов использовать LINQ для сортировки и группировки данных.
        */

        List<Order> orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 1), TotalAmount = 150.0 },
            new Order { OrderID = 2, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 75.5 },
            new Order { OrderID = 3, CustomerName = "Charlie", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 220.0 },
            new Order { OrderID = 4, CustomerName = "David", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 100.0 },
            new Order { OrderID = 5, CustomerName = "Eve", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 85.5 },
            // Добавьте другие заказы по вашему усмотрению
        };
        //Отсортировать заказы по сумме в убывающем порядке.
        var sortedOrdersByAmount = orders.OrderByDescending(x => x.TotalAmount);
        //Сгруппировать заказы по клиентам и вывести количество заказов для каждого клиента.
        var groupingByUser = orders.GroupBy(x => x.CustomerName).Select(x => new
        {
            Name = x.Key,
            Count = x.Count()
        });
        //Найти клиента с наибольшей суммой заказов.
        var maxOrderAmount = orders.GroupBy(x => x.CustomerName).Select(x => new
        {
            Name = x.Key,
            Sum = x.Sum(s => s.TotalAmount)
        }).OrderBy(x => x.Sum).First().Name;
        //Вывести список клиентов и общую сумму их заказов.
        var clientTA = orders.GroupBy(x => x.CustomerName).Select(x => new
        {
            Name = x.Key,
            Sum = x.Sum(s => s.TotalAmount)
        });

        sortedOrdersByAmount.ToList().ForEach(x => Console.WriteLine($"{x.CustomerName} - {x.TotalAmount}"));
        groupingByUser.ToList().ForEach(x => Console.WriteLine($"{x.Name}, {x.Count} "));
        Console.WriteLine($"{maxOrderAmount}");
        clientTA.ToList().ForEach(x => Console.WriteLine($"{x.Name}, {x.Sum} "));

    }

    public static void Task3()
    {
        /*
         * В этой задаче у вас есть список строк, и ваша задача – отсортировать этот список 
         * в порядке возрастания длины строк, используя лямбда-выражение. 
         * Ниже приведены начальные данные и возможное решение:
         */

        List<string> strings = new List<string>
        {
            "Apple",
            "Banana",
            "Cherry",
            "Date",
            "Fig",
            "Grapes"
        };

        strings.OrderBy(x => x.Length).ToList().ForEach(x => Console.Write(x + " "));
    }

    public static void Task4()
    {
        var numbers = Enumerable.Range(0, 100).Select((x, i) => x = i).OrderByDescending(x => x).ToList();
        numbers.Sort();
        numbers.ForEach(x => Console.WriteLine(x + " "));
    }

    public static void Task5()
    {
        /*
         * Мы хотим выбрать все строки, содержащие определенную подстроку, 
         * с использованием лямбда-выражения. 
         * Вот начальные данные и решение задачи:
         */
        List<string> words = new List<string>
        {
            "apple",
            "banana",
            "cherry",
            "date",
            "grape",
            "kiwi",
            "lemon",
        };

        string searchTerm = "an";

        words.Where(x => x.Contains(searchTerm)).ToList().ForEach(x => Console.WriteLine(x + " "));
    }
    public static void Task6()
    {
        /*
         * у нас есть список чисел, и мы хотим 
         * умножить каждое число в списке на 2, 
         * используя анонимный метод
         */

        Enumerable.Range(0, 10).Select((x, i) => x = i)
            .Select(x => x * 2).ToList()
            .ForEach(Console.WriteLine);

    }

    public static void Task7()
    {
        /*
         Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
        Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части 
        два числа равных по сумме первому.
        Поиск общих элементов в двух коллекциях
        */

        HashSet<int> hashSet = new HashSet<int> { 1, 2, 3, 4, 5 };
        List<int> list = new List<int> { 3, 4, 5, 6, 7 };

        var result = hashSet.Intersect(list);

    }
}
