﻿namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            //catch array.Length<3 errors

            if (cells.Length < 3)
            {
                //log
                return null;
            }

            double latitude = double.Parse(cells[0]);
            double longittude = double.Parse(cells[1]);
            string locationName = cells[2];

            //instantiate TacoBell and Point
            TacoBell tacobell = new TacoBell();
            Point point = new Point(latitude, longittude);

            //set Name and Location
            tacobell.Name = locationName;
            tacobell.Location = point;
            // Do not fail if one record parsing fails, return null

            return tacobell;
        }
    }
}