using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace vm_dev_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpController : ControllerBase
    {

        private readonly DataContext _context;

        public ExpController(DataContext cont)
        {
            _context = cont;
        }


        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<Experience>>> Get()
        {
            var exp = new List<Experience>()
            {
                new Experience
                {
                    Id = 1,
                    Comp = "DepEd",
                    StDate = "April 1, 2022",
                    EdDate = "July 1, 2022",
                    Role_Name = "Frontend Developer"
                }
            };

            return Ok(await _context.Experiences.ToListAsync());
        }
    }
}
