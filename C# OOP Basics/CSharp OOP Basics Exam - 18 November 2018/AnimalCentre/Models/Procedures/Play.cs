using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughTime);
            }

            animal.ProcedureTime -= procedureTime;
            animal.Energy -= 6;
            animal.Happiness += 12;

            this.procedureHistory.Add(animal);
        }
    }
}