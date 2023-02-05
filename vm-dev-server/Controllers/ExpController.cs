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


        
        [HttpGet]
        public async Task<ActionResult<List<Experience>>> Get()
        {
            return Ok(await _context.Experiences.ToListAsync());
        }

        
    }
}
