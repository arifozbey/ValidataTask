using DomainLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidataTask.DAL;
using ValidataTask.Data;
using ValidataTask.Entity;

namespace ValidataTaskApplication.Commands
{

    public class GetAllValidataQueryHandler : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ValidataEntity());

        public IEnumerable<ValidataDTO> GetAll()
        {
            return unitOfWork.GetAllValidatas();
        }

    }
}


