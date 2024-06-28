using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.DataAccessLayer.Entities
{
    public class BrandEntity
    {
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public bool Active { get; set; }
    }
    public class BrandDetailEntity : BrandEntity
    {

    }
    public class BrandFilterEntity
    {
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public bool? Active { get; set; }
    }
    public class BrandLovEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
