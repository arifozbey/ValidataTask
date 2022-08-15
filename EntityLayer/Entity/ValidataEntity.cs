using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ValidataTask.Entity
{
    public class ValidataEntity
    {
     
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int? OrderId { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }
        [MaxLength(250)]
        public string Adress { get; set; }
        public int? PostalCode { get; set; }
        public DateTime Date { get; set; }

        public  OrderEntity  Order { get; set; }
   
    }

    public class OrderEntity
    {
    
        [Key]
        public int Id { get; set; }
        public int quantity { get; set; }

        [MaxLength(250)]
        public string ItemName { get; set; }
        [MaxLength(250)]
        public string Product { get; set; }
      
        public int price { get; set; }
        public DateTime Date { get; set; }

    }
}
