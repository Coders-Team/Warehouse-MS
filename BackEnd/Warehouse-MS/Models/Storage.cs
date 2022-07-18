using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_MS.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SizeInUnit { get; set; }
        public string LocationInWarehouse { get; set; }
        public string Description { get; set; }

        public Warehouse Warehouse { get; set; }
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }

        public StorageType StorageType { get; set; }
        [ForeignKey("StorageType")]
        public int StorageTypeId { get; set; }

    }
}
