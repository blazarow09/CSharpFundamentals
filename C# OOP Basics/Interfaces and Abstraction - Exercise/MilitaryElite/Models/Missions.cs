using System;

public class Missions : IMissions
{
    private string state;

    public Missions(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName { get; }

    public string State
    {
        get
        {
            return this.state;
        }
        private set
        {
            if (value != "inProgress" && value != "Finished")
            {
                throw new ArgumentException();
            }
            this.state = value;
        }
    }

    private void CompleteMission()
    {
        this.State = "Finished";
    }

    public override string ToString()
    {
        return string.Format($"Code Name: {this.CodeName} State: {this.State}");
    }
}