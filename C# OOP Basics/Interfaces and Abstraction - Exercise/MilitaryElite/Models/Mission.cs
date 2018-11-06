using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }

        public string State { get; private set; }

        public void CompleteMission()
        {
            string state = MissionStatus.Finished.ToString();

            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}