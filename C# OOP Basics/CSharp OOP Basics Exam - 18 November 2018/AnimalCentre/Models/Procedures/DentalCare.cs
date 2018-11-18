using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughTime);
            }

            animal.ProcedureTime -= procedureTime;
            animal.Happiness += 12;
            animal.Energy += 10;

            this.procedureHistory.Add(animal);
        }
    }
}