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
        [Route("byuser/{int:userId}")]
        public IEnumerable<GameViewModel> GetGamesByUserId(int userId)
        {
            return this.gamesRepo
                       .Find(x => x.UserId == userId)
                       .Select(x => this.mapper.Map<GameViewModel>(x));
        }

        [HttpPut]
        [Route("accept")]
        public IActionResult AcceptGame(int gameId, int userId)
        {
            var success = this.organizer.Accept(gameId, userId);
            if (success)
            {
                return Ok("Game challenge accepted!");
            }
            else
            {
                return BadRequest("Can't accept challenge. It's eigther canceled, or already taken by other player.");
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateGame(GameViewModel game)
        {
            var newGame = this.mapper.Map<Game>(game);
            var gameId = this.organizer.Create(newGame);

            if (gameId > 0)
            {
                return Ok(gameId);
            }
            else
            {
                return BadRequest("Error occured. Please try again.");
            }
        }
    }
}
