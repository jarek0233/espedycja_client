using System;

namespace TruckTelemetryClient
{
    // To musi pasować do Twojego API
    public class TelemetryPayload
    {
        public string ApiKey { get; set; }

        public double CoordinateX { get; set; }
        public double CoordinateZ { get; set; }
        public float SpeedKmh { get; set; }
        public float Heading { get; set; }

        public string TruckModel { get; set; }
        public string PlateNumber { get; set; }

        public bool HasTrailer { get; set; }
        public string CargoId { get; set; }
        public double CargoWeight { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }

        public double FuelAmount { get; set; }
        public double FuelAverage { get; set; }
        public float DamageTruck { get; set; }
        public float DamageTrailer { get; set; }
        public float DamageCargo { get; set; }
        // ========================================================
        // Tych dwóch linijek brakuje u Ciebie:
        public string SourceCompany { get; set; }      // <--- DODAJ TO
        public string DestinationCompany { get; set; } // <--- DODAJ TO
                                                       // ========================================================
        public double Odometer { get; set; }
    }
}