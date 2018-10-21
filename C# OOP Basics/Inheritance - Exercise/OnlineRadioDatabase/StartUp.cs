using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var songs = new List<Song>();

            for (int i = 0; i < count; i++)
            {
                try
                {
                    var tokens = Console.ReadLine()
                   .Split(";", StringSplitOptions.RemoveEmptyEntries);
                    var artist = tokens[0];
                    var songName = tokens[1];
                    var lengthTokens = tokens[2].Split(":");

                    var song = new Song(artist,
                        songName,
                        int.Parse(lengthTokens[0]),
                        int.Parse(lengthTokens[1]));

                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("Invalid song length.");
                }
            }

            var totalSeconds = songs.Sum(p => p.Seconds);
            var totalMinutes = songs.Sum(p => p.Minutes) + totalSeconds / 60;

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {totalMinutes / 60}h {totalMinutes % 60}m {totalSeconds % 60}s");
        }
    }
}