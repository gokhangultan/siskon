using System;

namespace VehicleAPI.Models
{
    public class VehicleModel
    {
        public int VehicleID { get; set; }
        public string Name { get; set; }
        public int ModelID { get; set; }
        public bool Active { get; set; }
    }

    public class VehicleDetailModel : VehicleModel
    {

    }

    public class VehicleFilterModel
    {
        public int? VehicleID { get; set; }
        public string Name { get; set; }
        public int? ModelID { get; set; }
        public bool? Active { get; set; }
    }
}