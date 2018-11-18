using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private Track track;
    private const double PitStopTime = 20;
    private Dictionary<string, Driver> drivers;
    private Dictionary<Driver, string> dnfDrivers;
    public bool hasWiner;
    public Driver winner;

    public RaceTower()
    {
        this.drivers = new Dictionary<string, Driver>();
        this.dnfDrivers = new Dictionary<Driver, string>();
        this.hasWiner = false;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Tyre tyre = TyreFactory.CreateTyre(commandArgs.Skip(4).ToList());
            Car car = CarFactory.CreateCar(commandArgs.Skip(2).Take(2).ToList(), tyre);
            Driver driver = DriverFactory.CreateDriver(commandArgs.Take(2).ToList(), car);
            this.drivers.Add(commandArgs[1], driver);
        }
        catch (System.ArgumentException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reason = commandArgs[0];
        Driver driver = this.drivers[commandArgs[1]];
        driver.TotalTime += PitStopTime;

        switch (reason)
        {
            case "ChangeTyres":
                Tyre newTyre = TyreFactory.CreateTyre(commandArgs.Skip(2).ToList());
                driver.Car.ChangeTyres(newTyre);
                break;

            case "Refuel":
                driver.Car.Refuel(double.Parse(commandArgs[2]));
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var completeLap = int.Parse(commandArgs[0]);

        if (this.track.TotalLaps - completeLap < 0)
        {
            return $"There is no time! On lap {this.track.CurrentLap}.";
        }
        else
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < completeLap; i++)
            {
                this.GetDriversTime();
                this.DriversTakeLap();
                this.RemoveDnfDrivers();
                this.track.CurrentLap++;

                List<Driver> standing = this.drivers.Values.OrderByDescending(d => d.TotalTime).ToList();

                this.Overtaking(standing, sb);
            }

            if (this.track.CurrentLap == this.track.TotalLaps)
            {
                this.hasWiner = true;
                this.winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
            }

            return sb.ToString().Trim();
        }
    }

    private void Overtaking(List<Driver> standings, StringBuilder sb)
    {
        for (int i = 0; i < standings.Count - 1; i++)
        {
            Driver frontDriver = standings[i];
            Driver behindDriver = standings[i + 1];

            double gap = Math.Abs(frontDriver.TotalTime - behindDriver.TotalTime);
            int interval = 2;
            bool isCrashed = this.CheckConditions(frontDriver, ref interval);

            if (gap <= interval)
            {
                if (isCrashed)
                {
                    this.dnfDrivers.Add(frontDriver, "Crashed");
                    this.drivers.Remove(frontDriver.Name);
                    continue;
                }

                frontDriver.TotalTime -= interval;
                behindDriver.TotalTime += interval;
                sb.AppendLine($"{frontDriver.Name} has overtaken {behindDriver.Name} on lap {this.track.CurrentLap}.");
            }
        }
    }

    private bool CheckConditions(Driver frontDriver, ref int interval)
    {
        bool isCrashed = false;

        if (frontDriver.GetType().Name == "AgressiveDriver" && frontDriver.Car.Tyre.GetType().Name == "UltrasoftTyre")
        {
            interval = 3;

            if (this.track.Weather == "Foggy")
            {
                isCrashed = true;
            }
        }

        if (frontDriver.GetType().Name == "EnduranceDriver" && frontDriver.Car.Tyre.GetType().Name == "HardTyre")
        {
            interval = 3;

            if (this.track.Weather == "Rainy")
            {
                isCrashed = true;
            }
        }

        return isCrashed;
    }

    private void RemoveDnfDrivers()
    {
        foreach (var dnfDriver in this.dnfDrivers.Keys)
        {
            if (this.drivers.ContainsKey(dnfDriver.Name))
            {
                this.drivers.Remove(dnfDriver.Name);
            }
        }
    }

    private void DriversTakeLap()
    {
        foreach (var driver in this.drivers.Values)
        {
            try
            {
                driver.ReduceFuelAmount(this.track.Length);
                driver.Car.Tyre.ReducedDegradation();
            }
            catch (ArgumentException ex)
            {
                this.dnfDrivers.Add(driver, ex.Message);
            }
        }
    }

    private void GetDriversTime()
    {
        foreach (var driver in this.drivers.Values)
        {
            driver.TotalTime += 60 / (this.track.Length / driver.Speed);
        }
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {this.track.CurrentLap}/{this.track.TotalLaps}");

        int position = 1;

        foreach (var driver in this.drivers.Values.OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{position} {driver.Name} {driver.TotalTime:f3}");
            position++;
        }

        foreach (KeyValuePair<Driver, string> driver in this.dnfDrivers.Reverse())
        {
            sb.AppendLine($"{position} {driver.Key.Name} {driver.Value}");
            position++;
        }

        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.track.Weather = commandArgs[0];
    }
}