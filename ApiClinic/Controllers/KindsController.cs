using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Repositories;

namespace ApiClinic.Controllers
{

    [Route("api/[controller]")]
    public class KindsController : Controller
    {
        IRepository<Kind> repository;
        public KindsController(IRepository<Kind> repository)
        {
            this.repository = repository;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Kind> Get()
        {
            return this.repository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Kind Get(int id)
        {
            return this.repository.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public Kind Post([FromBody]Kind value)
        {
            this.repository.Add(value);
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Kind Put(int id, [FromBody]Kind value)
        {
            this.repository.Update(value);
            return value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.repository.Remove(this.repository.GetById(id));
        }
    }
}
