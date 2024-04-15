namespace Pattern_of_life.Services
{
    public class CoordinateConverter
    {
        public static string DecimalDegreesToDMS(double decimalDegrees, bool isLatitude)
        {
            char direction = isLatitude ? (decimalDegrees >= 0 ? 'N' : 'S') : (decimalDegrees >= 0 ? 'E' : 'W');

            // Get the absolute value of the decimal degrees
            decimalDegrees = Math.Abs(decimalDegrees);

            // Calculate degrees, minutes, and seconds
            int degrees = (int)decimalDegrees;
            double decimalMinutes = (decimalDegrees - degrees) * 60;
            int minutes = (int)decimalMinutes;
            double seconds = (decimalMinutes - minutes) * 60;

            // Format the DMS string
            return string.Format("{0}° {1}' {2:0.##}\" {3}", degrees, minutes, seconds, direction);
        }
    }
}
