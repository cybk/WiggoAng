using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Models
{
    [Table("VehicleFeatures")]
    public class VehicleFuture
    {
        public int VehicleId { get; set; }

        public int FeatureId { get; set; }

        public Vehicle Vehicle { get; set; }

        public Feature Feature { get; set; }
    }
}