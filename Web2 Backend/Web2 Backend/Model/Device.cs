using System;
namespace Web2_Backend.Model
{
    public class Device : Entity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
