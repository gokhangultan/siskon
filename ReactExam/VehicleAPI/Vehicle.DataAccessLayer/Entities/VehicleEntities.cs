using System;

namespace Vehicle.DataAccessLayer.Entities
{
    public class VehicleEntity
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public bool IsActive { get; set; }

    }

    public class VehicleDetailEntity : VehicleEntity
    {

    }

    public class VehicleFilterEntity
    {
        public int? VehicleId { get; set; }
        public string Name { get; set; }
        public int? ModelId { get; set; }
        public bool? IsActive { get; set; }

    }
}
