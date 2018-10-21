using System;
using System.Text;

public class Engine
{
    public void Run()
    {
        var addCollection = new AddCollection();
        var addRemoveCollection = new AddRemoveCollection();
        var myList = new MyList();

        var items = Console.ReadLine().Split();
        var addCollectionAddResult = new StringBuilder();
        var addRemoveCollectionAddResult = new StringBuilder();
        var myListAddResult = new StringBuilder();
        var addRemoveCollectionRemoveResult = new StringBuilder();
        var myListRemoveResult = new StringBuilder();

        foreach (var item in items)
        {
            addCollectionAddResult.Append(addCollection.Add(item));
            addCollectionAddResult.Append(" ");
            addRemoveCollectionAddResult.Append(addRemoveCollection.Add(item));
            addRemoveCollectionAddResult.Append(" ");
            myListAddResult.Append(myList.Add(item));
            myListAddResult.Append(" ");
        }

        int removes = int.Parse(Console.ReadLine());

        for (int i = 0; i < removes; i++)
        {
            addRemoveCollectionRemoveResult.Append(addRemoveCollection.Remove());
            addRemoveCollectionRemoveResult.Append(" ");
            myListRemoveResult.Append(myList.Remove());
            myListRemoveResult.Append(" ");
        }

        Console.WriteLine(addCollectionAddResult.ToString());
        Console.WriteLine(addRemoveCollectionAddResult.ToString());
        Console.WriteLine(myListAddResult.ToString());
        Console.WriteLine(addRemoveCollectionRemoveResult.ToString());
        Console.WriteLine(myListRemoveResult.ToString());
    }
}