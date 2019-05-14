namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");
            
            //catch null errors

            if (line == null)
            {
                //log
                return null;
            }

            var cells = line.Split(',');

            //catch array.Length<3 errors

            if (cells.Length != 3)
            {
                //log
                return null;
            }

            double latitude;
            double longittude;
            if(!double.TryParse(cells[0], out latitude) || !double.TryParse(cells[1], out longittude))
            {
                return null;
            }

            string locationName = cells[2].Trim();
  

            //catch invalid input

            if (latitude < -90 || latitude > 90 || longittude < -180 || longittude > 180 || locationName.Length < 1 || locationName.ToLower()[0] != 't' || !locationName.ToLower().Contains("taco bell"))
            {
                return null;
            }

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