namespace ServerManagement.Models
{
    public class CitiesRepository
    {
        public static List<string> cities = new List<string>()
        {
            "Toronto",
            "Montreal",
            "Ottawa",
            "Calgary",
            "Halifax"
        };
        public static List<string> GetCities() => cities;
    }
}
