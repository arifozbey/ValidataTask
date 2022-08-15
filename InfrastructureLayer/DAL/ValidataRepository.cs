using DomainLayer.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidataTask.Data;
using ValidataTask.Entity;

namespace ValidataTask
{
    public class ValidataRepository : IValidataRepository, IDisposable
    {
        private ValidataContext context;

        public ValidataRepository(ValidataContext context)
        {
            this.context = context;
        }

        public IEnumerable<ValidataDTO> GetAllValidatas()
        {
            var listdata = context.Validata.OrderBy(x => x.Date).ToList();
            if (listdata==null)
            {
                return null;
            }
            var DTO = new List<ValidataDTO>();
            foreach (var item in listdata)
            {
                var returndata = context.Order.Where(x=>x.ItemName.Contains("Pizza")).ToList();
                var newDTO = new ValidataDTO();
                newDTO.Adress = item.Adress;
                newDTO.Date = item.Date;
                newDTO.LastName = item.LastName;
                newDTO.Name = item.Name;
                newDTO.Number = item.Number;
                newDTO.OrderId = item.OrderId;
                newDTO.PostalCode = item.PostalCode;

                if (returndata != null) 
                {
                    newDTO.Order = returndata;
                    DTO.Add(newDTO);
                } else {
                    DTO.Add(newDTO);
                };

            }
            return DTO;
        }

        public ValidataEntity GetValidataByID(int id)
        {
            var data = context.Validata.Find(id);
            if (data !=null)
            {
                data.Order = context.Order.FirstOrDefault(x=>x.Id==data.OrderId);
            }

            return data;
        }

        public ValidataEntity InsertValidata(ValidataDTO data)
        {
            //test data add 
            var removeorders = context.Order.ToList();
            context.Order.RemoveRange(removeorders);
            Save();

            if (data.Order == null || data.Name == "string")
            {
                var order1 = new OrderEntity() { Date = DateTime.Now.AddDays(1), ItemName = "Pizza1", price = 99, Product = "test", quantity = 10 };
                context.Order.Add(order1);

                var order2 = new OrderEntity() { Date = DateTime.Now.AddDays(5), ItemName = "Pizza2", price = 99, Product = "test", quantity = 10 };
                context.Order.Add(order2);
                Save();
            }
            else
            {
                foreach (var item in data.Order)
                {
                    context.Order.Add(item);
                    Save();
                }
            
            }
     
            var findorderid = context.Order.FirstOrDefault(x => x.ItemName.Contains("Pizza"));
            if (findorderid!=null)
            {
                var datadb = new ValidataEntity() { Date = DateTime.Now, Name = "Pizzas", Number = data.Number, Adress = "Testaddress", LastName = "Ozbey", OrderId = findorderid.Id, Order = findorderid };
                context.Validata.Add(datadb);
                return datadb;

            }


            ////Test data finish
            ///
            if (data.Other2 == null) { } //[TODO] Maybe code
            return null;
        }

        public ValidataEntity DeleteValidata(int Id)
        {
            ValidataEntity data = context.Validata.Find(Id);
            if (data!=null)
            {
                context.Validata.Remove(data);

            }
            return data;
        }

        public ValidataEntity UpdateValidata(ValidataDTO data)
        {
            ValidataEntity datadb = context.Validata.Find(data.Id);
            if (datadb!=null)
            {
                datadb.Name = "EDITED";
                context.Validata.Update(datadb);

                context.Entry(datadb).State = EntityState.Modified;

            }
           
            return datadb;
        }

        public void Save()
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                //TODO:Logging
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
