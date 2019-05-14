using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops

            ITrackable tBell1 = null;
            ITrackable tBell2 = null;
            double distance = 0;

            foreach (var location in locations)
            {
                var locA = location;
                GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                foreach (var destination in locations)
                {
                    var locB = destination;
                    GeoCoordinate corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tBell1 = locA;
                        tBell2 = locB;
                    }
                }

            }
                Console.WriteLine($"\n\nThe two furthest apart are:\n{tBell1.Name}\n{tBell2.Name}\nThey are {distance} miles apart.");

        }
    }
}