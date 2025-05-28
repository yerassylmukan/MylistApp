using System.Collections;

namespace ConsoleApp1;

public class MyList<T> : IEnumerable<T>
{
    private T[] _items; // массив для хранения элементов

    public MyList()
    {
        _items = new T[4]; // дефолтный размер
        Count = 0;
    }

    public T this[int index] // индексатор
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            
            return _items[index];
        }
    }

    public int Count { get; private set; } // свойство для получения количества элементов

    public void Add(T item) // добавление элемента в конец
    {
        if (Count == _items.Length)
            Resize(); 

        _items[Count++] = item;
    }

    public void RemoveAt(int index) // удаление по индексу
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();

        for (var i = index; i < Count - 1; i++) _items[i] = _items[i + 1];

        _items[--Count] = default!;
    }
    
    public IEnumerator<T> GetEnumerator() // реализация перечислителя для поддержки foreach
    {
        for (var i = 0; i < Count; i++)
            yield return _items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    private void Resize() // увеличение размера
    {
        var newArray = new T[_items.Length * 2];
        Array.Copy(_items, newArray, _items.Length);
        _items = newArray;
    }
}