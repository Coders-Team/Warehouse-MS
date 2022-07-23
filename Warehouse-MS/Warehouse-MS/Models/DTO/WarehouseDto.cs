using System.Collections.Generic;

namespace Warehouse_MS.Models.DTO
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SizeInUnit { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public List<StorageDto> Storages { get; set; }
    }
}
