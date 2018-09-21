namespace JaggedArrayModification
{
    using System;

    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            int[][] jagged = new int[size][];

            for (int row = 0; row < jagged.Length; row++)
            {
                var inputNumbers = Console.ReadLine()
                    .Split();

                jagged[row] = new int[inputNumbers.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = int.Parse(inputNumbers[col]);
                }
            }

            var commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commandArgs[0] != "END")
            {
                var command = commandArgs[0];
                var row = int.Parse(commandArgs[1]);
                var col = int.Parse(commandArgs[2]);
                var value = int.Parse(commandArgs[3]);

                if (row < 0 
                    || col < 0 
                    || row > jagged.Length -1 
                    || col > jagged.Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    switch (command)
                    {
                        case "Add":
                            jagged[row][col] += value;
                            break;
                        case "Subtract":
                            jagged[row][col] -= value;
                            break;
                    }
                }

                commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
