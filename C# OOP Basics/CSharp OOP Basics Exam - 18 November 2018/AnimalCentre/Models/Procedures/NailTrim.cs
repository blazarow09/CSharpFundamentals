using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughTime);
            }

            animal.ProcedureTime -= procedureTime;
            animal.Happiness -= 7;

            this.procedureHistory.Add(animal);
        }
    }
}