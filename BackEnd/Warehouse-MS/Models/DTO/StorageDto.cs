namespace Warehouse_MS.Models.DTO
{
    public class StorageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SizeInUnit { get; set; }
        public string LocationInWarehouse { get; set; }
        public string Description { get; set; }
        public int WarehouseId { get; set; }
        public int StorageTypeId { get; set; }
    }
}
