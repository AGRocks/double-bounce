using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using traininghub.api.ViewModels;
using traininghub.core;
using traininghub.dac.ef.Common;
using Traininghub.Data;

namespace traininghub.api.Controllers
{
    [Route("api/challenges")]
    public class ChallengeController : Controller
    {
        private readonly IReadOnlyRepository<Challenge> chRepo;
        private readonly IGameOrganizer organizer;
        private readonly IMapper mapper;

        public ChallengeController(
            IReadOnlyRepository<Challenge> chRepo,
            IGameOrganizer gameOrganizer,
            IMapper mapper)
        {
            this.chRepo = chRepo;
            this.organizer = gameOrganizer;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("game/{gameId:int}")]
        public IEnumerable<ChallengeViewModel> GetChallengesForGame(int gameId)
        {
            return this.chRepo.Find(x => x.GameId == gameId)
                       .Select(x => this.mapper.Map<ChallengeViewModel>(x));
        }

        [HttpPut]
        [Route("accept/{challengeId:int}/{organizerId:int}")]
        public IActionResult Accept(int challengeId, int organizerId)
        {
            this.organizer.AcceptChallenge(challengeId, organizerId);
            this.organizer.Save();
            return Ok();
        }

        [HttpPut]        
        [Route("create/{gameId:int}/{userId:int}")]
        public IActionResult Create(int gameId, int userId)
        {
            this.organizer.IssueChallenge(gameId, userId);
            this.organizer.Save();
            return Ok();
        }
    }
}
