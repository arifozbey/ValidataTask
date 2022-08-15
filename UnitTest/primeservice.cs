using DomainLayer.Dto;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataTask.Controllers;
using ValidataTask.Entity;

namespace UnitTest.Services
{
    public class PrimeService
    {
        public bool GetAll()
        {
            try
            {
                var test = new ValidataController().GetAll();
                return false;
            }
            catch (Exception e)
            {
                throw new NotImplementedException("Please create a test first.");
            }
        }

        public bool GetId(int data)
        {
            try
            {
                var test = new ValidataController().GetById(data);
                return false;
            }
            catch (Exception e)
            {
                throw new NotImplementedException("Please create a test first.");
            }
        }

        public bool Insert(ValidataDTO data)
        {
            try
            {
                var test = new ValidataController().Create(data);
                return false;
            }
            catch (Exception e)
            {
                throw new NotImplementedException("Please create a test first.");
            }
        }
        public bool Update(ValidataDTO data)
        {
            try
            {
                var test = new ValidataController().Edit(data);
                return false;
            }
            catch (Exception e)
            {
                throw new NotImplementedException("Please create a test first.");
            }
        }
        public bool Delete(int data)
        {
            try
            {
                var test = new ValidataController().Delete(data);
                return false;
            }
            catch (Exception e)
            {
                throw new NotImplementedException("Please create a test first.");
            }
        }
    }

    [TestFixture]
    public class TestService
    {
        private PrimeService _primeService = new PrimeService();

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void GetAll()
        {
            var result = _primeService.GetAll();

            Assert.IsFalse(result, "GetAll should not be success");
        }
        [Test]
        public void GetId()
        {
            var result = _primeService.GetId(2);

            Assert.IsFalse(result, "GetId should not be success");
        }

        [Test]
        public void Insert()
        {
            //test data add 
            var orders = new List<OrderEntity>();
            orders.Add(new OrderEntity() { Date = DateTime.Now, ItemName = "Pizza", price = 99, Product = "test", quantity = 10 });

            var data = new ValidataDTO() { Date = DateTime.Now, Name = "Pizzas", Number = 123, Adress = "Testaddress", LastName = "Ozbey", Order = orders };

            var result = _primeService.Insert(data);

            Assert.IsFalse(result, "Insert should not be success");
        }

        [Test]
        public void Update()
        {
            //Before start getall and find id, replace finded id
            var newtest = new ValidataDTO() { Date = DateTime.Now, Name = "ArifOzbey", Id = 0 };

            var result = _primeService.Update(newtest);

            Assert.IsFalse(result, "Update should not be success");
        }
        [Test]
        public void Delete()
        {
            var result = _primeService.Delete(1);

            Assert.IsFalse(result, "Delete should not be success");
        }

    }
}