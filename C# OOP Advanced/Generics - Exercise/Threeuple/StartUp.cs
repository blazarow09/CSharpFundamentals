using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var line = Console.ReadLine().Split();
        var fullName = line[0] + " " + line[1];
        var adress = line[2];
        var town = line[3];
        Threeuple<string, string, string> tuple = new Threeuple<string, string, string>(fullName, adress, town);

        line = Console.ReadLine().Split();
        fullName = line[0];
        var litersBeer = int.Parse(line[1]);
        var condition = line[2];
        if (condition.Contains("not")) condition = "False";
        else condition = "True";
        Threeuple<string, int, string> secondTuple = new Threeuple<string, int, string>(fullName, litersBeer, condition);

        line = Console.ReadLine().Split();
        fullName = line[0];
        var accBalance = double.Parse(line[1]);
        var bankName = line[2];
        Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(fullName, accBalance, bankName);

        Console.WriteLine(tuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }
}