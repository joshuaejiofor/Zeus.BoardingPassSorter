namespace Zeus.BoardingPassSorter.WebApi.Models
{
    public class BoardingCard
    {
        public string From { get; set; }
        public string To { get; set; }
        public TransportType TransportType { get; set; }
        public string VehicleNo { get; set; }
        public string GateNo { get; set; }
        public string SeatNo { get; set; }
        public string TicketCounter { get; set; }


        public int TravelSequence { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (BoardingCard)obj;

            return From == other.From &&
                To == other.To &&
                TransportType == other.TransportType &&
                VehicleNo == other.VehicleNo &&
                GateNo == other.GateNo &&
                SeatNo == other.SeatNo &&
                TicketCounter == other.TicketCounter;
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() ^ To.GetHashCode();
        }

        public override string ToString()
        {

            return TransportType switch
            {
                TransportType.Train => $"{TravelSequence}. Take {TransportType} {VehicleNo} from {From} to {To}. Sit in seat {SeatNo}.",
                TransportType.AirportBus => $"{TravelSequence}. Take the {TransportType} from {From} to {To}. No seat assignment.",
                TransportType.Flight => $@"{TravelSequence}. From {From}, take flight {VehicleNo} to {To}. Gate {GateNo}, seat {SeatNo}." + 
                    $"{((TicketCounter != null) ? $"{TravelSequence}. Baggage drop at ticket counter {TicketCounter}." : "Baggage will we automatically transferred from your last leg." )}",
                _ => ""
            };
        }
    }
}
