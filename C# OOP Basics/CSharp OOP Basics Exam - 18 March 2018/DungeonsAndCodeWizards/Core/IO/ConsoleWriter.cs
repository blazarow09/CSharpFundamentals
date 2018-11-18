using DungeonsAndCodeWizards.Core.IO.Contracts;
using System;

namespace DungeonsAndCodeWizards.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}