namespace ConsoleApp1;

public static class MyListExtensions
{
    public static T[] GetArray<T>(this MyList<T> list) // экстеншон для преобразования коллекции в массив
    {
        var array = new T[list.Count];
        for (var i = 0; i < list.Count; i++)
            array[i] = list[i];
        
        return array;
    }
}