using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace vm_dev_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly DataContext _cont;
        public ProjectsController(DataContext cont) 
        {
            _cont = cont;
        }


        [HttpGet]
        public async Task<ActionResult<List<Projects>>> Get()
        {

            return Ok(await _cont.Projects.ToListAsync());
        }


    }
}
