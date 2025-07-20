namespace BoshAPI.Entities
{
    public class TechsSpec
    {
        public int Id { get; set; }
        public decimal BatteryVoltage { get; set; }
        public decimal MaxTorque { get; set; }
        public decimal Weight { get; set; }
        public decimal ChuckSize {get; set;}
        public string NoLoadSpeed { get; set; }
        public decimal PowerInput { get; set; }
        public decimal DiscDiameter {get; set;}
        public decimal ImpactEnergy { get; set;}
        public decimal DrillDiameterConcrete { get; set;}
        public decimal StrokeLength { get; set;}
        public decimal OscillationAngle { get; set;}
        public string Speed { get; set;}
        public decimal BladeDiametar { get; set;}
        public decimal PlaningWidth { get; set; }
        public string MeasuringRange { get; set; }
        public string Bluetooth { get; set;}
        public string TemperatureRang { get; set;}


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
