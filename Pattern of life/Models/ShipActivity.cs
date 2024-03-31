namespace Pattern_of_life.Models
{
    public class ShipActivity
    {
        public int ID { get; set; }
        public DateTime DTG { get; set; }
        public double Longitude { get; set; } 
        public double Latitude { get; set; }  
        public double Course { get; set; }
        public int IMO { get; set; }
        public string POB { get; set; }        
        public string Remarks { get; set; }    
        public double Speed { get; set; }
        public string Name { get; set; }       

        // Foreign keys
        public int VesselTypeID { get; set; }
        public int FlagStateID { get; set; }
        public int ActivityNameID { get; set; }

        // Navigation properties
        public VesselType? VesselType { get; set; }
        public FlagState? FlagState { get; set; }
        public ActivityName? ActivityName { get; set; }
    }
}