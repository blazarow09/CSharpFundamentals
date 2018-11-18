using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughTime);
            }

            animal.ProcedureTime -= procedureTime;
            animal.Energy -= 8;
            animal.IsVaccinated = true;

            this.procedureHistory.Add(animal);
        }
    }
}