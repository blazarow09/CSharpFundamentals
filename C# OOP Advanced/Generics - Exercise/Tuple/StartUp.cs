using System;
public class StartUp
{
    public static void Main(string[] args)
    {
        var line = Console.ReadLine().Split();
        var fullName = line[0] + " " + line[1];
        var adress = line[2];
        Tuple<string, string> tuple = new Tuple<string, string>(fullName, adress);
        line = Console.ReadLine().Split();
        fullName = line[0];
        var litersBeer = int.Parse(line[1]);
        Tuple<string, int> secondTuple = new Tuple<string, int>(fullName, litersBeer);
        line = Console.ReadLine().Split();
        var integer = int.Parse(line[0]);
        var doubleVal = double.Parse(line[1]);
        Tuple<int, double> thirdTuple = new Tuple<int, double>(integer, doubleVal);
        Console.WriteLine(tuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }
}