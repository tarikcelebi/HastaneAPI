using HastaneAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaneController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public HastaneController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
