using ConsoleApp1;

namespace TestProject1;

public class MyListTests
{
    [Fact]
    public void Add_AddsItemsToList()
    {
        var list = new MyList<int>();
        list.Add(10);
        list.Add(20);

        Assert.Equal(2, list.Count);
        Assert.Equal(10, list[0]);
        Assert.Equal(20, list[1]);
    }

    [Fact]
    public void Indexer_ThrowsException_WhenIndexOutOfRange()
    {
        var list = new MyList<string>();
        list.Add("test");

        Assert.Throws<IndexOutOfRangeException>(() => list[-1]);
        Assert.Throws<IndexOutOfRangeException>(() => list[1]);
    }

    [Fact]
    public void RemoveAt_RemovesCorrectItem()
    {
        var list = new MyList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.RemoveAt(1);

        Assert.Equal(2, list.Count);
        Assert.Equal(1, list[0]);
        Assert.Equal(3, list[1]);
    }

    [Fact]
    public void RemoveAt_ThrowsException_WhenIndexOutOfRange()
    {
        var list = new MyList<int>();
        list.Add(1);

        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(-1));
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(1));
    }

    [Fact]
    public void Enumerator_ReturnsAllElements()
    {
        var list = new MyList<string>();
        list.Add("a");
        list.Add("b");

        var result = new List<string>();
        foreach (var item in list) result.Add(item);

        Assert.Equal(new[] { "a", "b" }, result);
    }

    [Fact]
    public void Linq_SelectAndWhere_WorksCorrectly()
    {
        var list = new MyList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        var query = list.Where(x => x > 1).Select(x => x * 10).ToList();

        Assert.Equal(new[] { 20, 30 }, query);
    }

    [Fact]
    public void GetArray_ReturnsArrayWithCorrectElements()
    {
        var list = new MyList<int>();
        list.Add(5);
        list.Add(10);

        var array = list.GetArray();

        Assert.Equal(new[] { 5, 10 }, array);
    }
}