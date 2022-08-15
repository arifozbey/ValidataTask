using DomainLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ValidataTask.DAL;
using ValidataTask.Data;
using ValidataTask.Entity;
using ValidataTaskApplication.Commands;
using ValidataTaskApplication.Queries;

namespace ValidataTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
      public class ValidataController : Controller
    {

        /// <summary>
        /// Get by All record.
        /// return list.
        /// </summary>
        /// <param name="GetAll">GetAll List.</param>
        // GET: /Validata/GetAll
        [HttpGet, Route("GetAll")]
        public IEnumerable<ValidataDTO> GetAll() => new GetAllValidataQueryHandler().GetAll();

        /// <summary>
        /// Get by Record ID.
        /// ID string generated is "(System.Int32)".
        /// </summary>
        /// <param name="GetById">Number.</param>
        // GET: /Validata/GetById/5
        [HttpGet, Route("GetById")]
        public ValidataEntity GetById(int id) => new GetByIdValidataQueryHandler().GetById(id);


        /// <summary>
        /// Create by ValidataEntity.
        /// ValidataDTO generated is "ValidataEntity".
        /// </summary>
        /// <param name="Create">Entity.</param>
        // POST: /Validata/Create

        [HttpPost, Route("Create")]
        public ValidataDTO Create([FromBody] ValidataDTO request) => new CreateValidataCommandHandler().Create(request);



        /// <summary>
        ///  Edit ValidataEntity.
        /// ValidataDTO generated is "ValidataEntity".
        /// </summary>
        /// <param name="Edit">Number.</param>
        // POST: /Validata/Edit/5

        [HttpPost, Route("Edit")]
        public ValidataDTO Edit([FromBody] ValidataDTO request) => new UpdateValidataCommandHandler().Edit(request);

        /// <summary>
        /// Delete by ValidataEntity.
        /// ID string generated is "(System.Int32)".
        /// </summary>
        /// <param name="Delete">Number.</param>
        // POST: /Validata/Delete/5

        [HttpGet, Route("Delete")]
        public ValidataDTO Delete(int id) => new DeleteValidataCommandHandler().Delete(id);
        
    }
}
// (A short list of the assumptions that you made when designing/implementing the API.)
//Notes:

//unitofwork was used for save, edit, delete works, localdb was used as an example, the test system was made and all the requested features were made.Enabled to open with swagger interface with net ore 5

