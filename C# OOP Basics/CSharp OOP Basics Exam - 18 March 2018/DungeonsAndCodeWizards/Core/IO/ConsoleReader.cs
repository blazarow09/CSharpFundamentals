using DungeonsAndCodeWizards.Core.IO.Contracts;
using System;

namespace DungeonsAndCodeWizards.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}