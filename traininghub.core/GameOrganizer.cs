using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using traininghub.dac.ef.Common;
using Traininghub.Data;

namespace traininghub.core
{
    public class GameOrganizer : IGameOrganizer, IUnitOfWork
    {
        private readonly IRepository<Game> gameRepo;
        private readonly IRepository<Challenge> challengeRepo;

        public GameOrganizer(
            IRepository<Game> gameRepo, 
            IRepository<Challenge> challengeRepo)
        {
            this.gameRepo = gameRepo;
            this.challengeRepo = challengeRepo;
        }

        public bool AcceptChallenge(int challengeId, int userId)
        {
            var challenge = this.challengeRepo.GetById(challengeId);
            var game = challenge.Game;
            if (game.OrganizerId == userId)
            {
                challenge.IsConfirmed = true;
                game.Status = Status.Full;
                this.challengeRepo.Attach(challenge);
                this.gameRepo.Attach(game);
                return true;
            } 

            return false;
        }

        public bool Cancel(int gameId, int userId)
        {
            var game = this.gameRepo.GetById(gameId);
            if (game.OrganizerId == userId)
            {
                game.Status = Status.Canceled;
                this.gameRepo.Attach(game);
            }
        }

        public int Create(Game game)
        {
            throw new NotImplementedException();
        }

        public bool IssueChallenge(int gameId, int userId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
