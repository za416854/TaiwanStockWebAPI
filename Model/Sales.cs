using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI
{ 
    public class Sales
    {
        [Column("sale_id")]
        public int SaleId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("price")]
        public int Price { get; set; }
    }
}
