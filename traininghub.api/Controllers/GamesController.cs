using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traininghub.Data;

namespace traininghub.api.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {

        public GamesController()
        {

        }

        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            throw new NotImplementedException();
        }
    }
}
