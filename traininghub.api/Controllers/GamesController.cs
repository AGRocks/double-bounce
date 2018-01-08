using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using traininghub.api.ViewModels;
using traininghub.core;
using traininghub.dac.ef.Common;
using Traininghub.Data;

namespace traininghub.api.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IReadOnlyRepository<Game> gamesRepo;
        private readonly IGameOrganizer organizer;
        private readonly IMapper mapper;

        public GamesController(
            IReadOnlyRepository<Game> gamesRepo, 
            IGameOrganizer gameOrganizer,
            IMapper mapper)
        {
            this.gamesRepo = gamesRepo;
            this.organizer = gameOrganizer;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("avaliable")]
        public IEnumerable<GameViewModel> GetAvaliableGames()
        {
            return this.gamesRepo
                       .Find(x => x.Status == Status.Active)
                       .Select(x => this.mapper.Map<GameViewModel>(x));
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<GameViewModel> GetAllGames()
        {
            return this.gamesRepo
                       .GetAll()
                       .Select(x => this.mapper.Map<GameViewModel>(x));
        }

        [HttpGet]
        [Route("byuser/{userId:int}")]
        public IEnumerable<GameViewModel> GetGamesByUserId(int userId)
        {
            return this.gamesRepo
                       .Find(x => x.OrganizerId == userId)
                       .Select(x => this.mapper.Map<GameViewModel>(x));
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] GameViewModel game)
        {
            var newGame = this.mapper.Map<Game>(game);
            this.organizer.CreateGame(newGame);
            this.organizer.Save();
            return Ok(newGame.Id);
        }

        [HttpDelete]
        public IActionResult CancelGame([FromBody] GameViewModel game)
        {
            this.organizer.CancelGame(game.Id, game.OrganizerId);
            this.organizer.Save();
            return Ok();
        }
    }
}
