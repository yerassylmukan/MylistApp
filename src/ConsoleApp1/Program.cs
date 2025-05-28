using System.Text;

namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding =
            Encoding.UTF8; // кодировка для корректного отображения символов (у меня не установлен плагин для русского языка в винде)

        var myList = new MyList<int>();
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        Console.WriteLine("Все элементы:");
        foreach (var t in myList)
            Console.WriteLine(t);

        Console.WriteLine("Получение элемента по индексу 1:");
        Console.WriteLine(myList[1]);

        myList.RemoveAt(1); // удаление элемента по индексу 1 (элемент 2).

        Console.WriteLine("После удаления:");
        foreach (var item in myList)
            Console.WriteLine(item);

        Console.WriteLine("LINQ Where:");
        var filtered = myList.Where(x => x > 1);
        foreach (var item in filtered)
            Console.WriteLine(item);

        Console.WriteLine("Расширяющий метод GetArray():");
        var array = myList.GetArray();
        foreach (var item in array)
            Console.WriteLine(item);
    }
}