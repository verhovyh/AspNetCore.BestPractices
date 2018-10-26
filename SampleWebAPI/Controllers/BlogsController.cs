using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.BestPractices.ApplicationCore.Entities;
using AspNetCore.BestPractices.ApplicationCore.Interfaces;
using AspNetCore.BestPractices.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        public BlogsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            return _blogRepository.ListAll().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            return _blogRepository.GetById(id);
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
