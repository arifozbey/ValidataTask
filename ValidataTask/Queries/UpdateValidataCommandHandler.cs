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
    public class UpdateValidataCommandHandler : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ValidataEntity());
        public ValidataDTO Edit(ValidataDTO request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.UpdateValidata(request);
                    return new ValidataDTO() { Id = request.Id };
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
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
