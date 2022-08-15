using DomainLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidataTask.Data;
using ValidataTask.Entity;

namespace ValidataTask.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ValidataEntity _entity;
        private IValidataRepository Repository = new ValidataRepository(new ValidataContext());

        public UnitOfWork(ValidataEntity Entity)
        {
            this._entity = Entity;
        }

        //public ValidataRepository ValidataRepository => this.validataRepository ?? (this.validataRepository = new ValidataRepository(context));

        public void InsertValidata(ValidataDTO data)
        {

            if (_entity != null)
            {
               var datareturn= Repository.InsertValidata(data);
                if (datareturn == null) { return; }

                Save();
            }

        }
        public IEnumerable<ValidataDTO> GetAllValidatas()
        {

            if (_entity != null)
            {
                return Repository.GetAllValidatas();
            }
            return null;

        }

        public ValidataEntity GetValidataByID(int id)
        {

            if (_entity != null)
            {
                return Repository.GetValidataByID(id);
            }
            return null;

        }


        public void UpdateValidata(ValidataDTO data)
        {
            if (_entity != null)
            {
               var datareturn= Repository.UpdateValidata(data);
                if (datareturn == null) { return; }

                Save();
            }
        }
        public void DeleteValidata(int id)
        {
            if (_entity != null)
            {
                var datareturn = Repository.DeleteValidata(id);
                if (datareturn == null) { return; }
                Save();
            }

        }
        public void Save()
        {
            
                Repository.Save();
            

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
