using DomainLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidataTask.Entity;

namespace ValidataTask
{

    public interface IValidataRepository : IDisposable
    {
        IEnumerable<ValidataDTO> GetAllValidatas();
        ValidataEntity GetValidataByID(int Id);
        ValidataEntity InsertValidata(ValidataDTO data);
        ValidataEntity DeleteValidata(int Id);
        ValidataEntity UpdateValidata(ValidataDTO data);
        void Save();
    }

}

