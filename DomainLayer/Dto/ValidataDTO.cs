using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataTask.Entity;

namespace DomainLayer.Dto
{
    public class ValidataDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int? OrderId { get; set; }
        public string Name { get; set; }
        public string Other2 { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int? PostalCode { get; set; }
        public DateTime Date { get; set; }
        public List<OrderEntity> Order { get; set; }
    }
}
