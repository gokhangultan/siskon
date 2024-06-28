using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vehicle.DataAccessLayer.Entities;
using VehicleAPI.Utils;

namespace VehicleAPI.Models
{
    public class BrandModel
    {
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public bool Active { get; set; }
    }

    public class BrandDetailModel : BrandModel
    {
    }
    public class BrandFilterModel
    {
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public bool? Active { get; set; }
    }
    public class BrandLovModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}