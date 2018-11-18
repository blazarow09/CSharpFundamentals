using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        var lapsNumber = int.Parse(Console.ReadLine());
        var trackLenght = int.Parse(Console.ReadLine());
        this.raceTower.SetTrackInfo(lapsNumber, trackLenght);

        var input = Console.ReadLine();

        while (true)
        {
            var inputParts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = inputParts[0];
            inputParts.Remove(inputParts[0]);

            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(inputParts);
                    break;
                case "LeaderBoard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    var result = this.raceTower.CompleteLaps(inputParts);

                    if (result != string.Empty)
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(inputParts);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(inputParts);
                    break;
            }

            if (this.raceTower.hasWiner)
            {
                Console.WriteLine($"{this.raceTower.winner.Name} wins the race for {this.raceTower.winner.TotalTime:F3} seconds.");
                return;
            }

            input = Console.ReadLine();
        }
    }
}