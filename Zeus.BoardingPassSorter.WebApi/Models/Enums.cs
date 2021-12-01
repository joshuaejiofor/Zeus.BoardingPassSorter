namespace Zeus.BoardingPassSorter.WebApi.Models
{
    // byte because it is tinyint in the DB to be used in DB mapping
    public enum TransportType : byte
    {
        None = 0,
        Train = 1,
        AirportBus = 2,
        Flight = 3,
    }
}
