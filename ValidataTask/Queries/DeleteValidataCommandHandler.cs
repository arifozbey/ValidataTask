using DomainLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ValidataTask.DAL;
using ValidataTask.Entity;

namespace ValidataTaskApplication.Queries
{
    public class DeleteValidataCommandHandler : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ValidataEntity());
        public ValidataDTO Delete(int id)
        {
            try
            {
                var validata = unitOfWork.GetValidataByID(id);
                unitOfWork.DeleteValidata(id);
                return new ValidataDTO() { Id= id };

            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            }
            return new ValidataDTO();
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
