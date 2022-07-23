using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_MS.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int SizeInUnit { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }
        public string BarcodeNum { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

        //ForeignKey
        public Storage Storage { get; set; }
        [ForeignKey("Storage")]
        public int StorageId { get; set; }


        public StorageType StorageType { get; set; }
        [ForeignKey("StorageType")]
        public int StorageTypeId { get; set; }


        public ProductType ProductType { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }

        public List<Transaction> Transaction { get; set; }

    }
}
