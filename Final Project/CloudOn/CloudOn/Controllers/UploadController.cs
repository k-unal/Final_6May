using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudOn.Models;
using CloudOn.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
      
        private readonly cloudOnContext _U;
        public UploadController(cloudOnContext UPL)
        {
            _U = UPL;
        }
        // GET: api/Upload
        [HttpGet]
        public IActionResult Get2()
        {
            var up = _U.Folders.ToList();
            return Ok(up);
        }


        // GET: api/Upload/5

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _U.Folders.Where(obj => obj.CreatedBy == id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        // POST: api/Upload
        [HttpPost]
        public void Post([FromBody] Upload value)
        {
             Folders obj1 = new Folders();
            obj1.FName = value.FName;
            obj1.CreatedAt = value.CreatedAt;
            obj1.CreatedBy = value.CreatedBy;
            _U.Folders.Add(obj1);
            _U.SaveChanges();
        }

        // PUT: api/Upload/5
        /* [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

         // DELETE: api/ApiWithActions/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
