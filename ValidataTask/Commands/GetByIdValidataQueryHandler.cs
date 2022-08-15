using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidataTask.DAL;
using ValidataTask.Entity;

namespace ValidataTaskApplication.Commands
{
    public class GetByIdValidataQueryHandler : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ValidataEntity());

        public ValidataEntity GetById(int id)
        {
            var validata = unitOfWork.GetValidataByID(id);
            return validata;
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }

}
