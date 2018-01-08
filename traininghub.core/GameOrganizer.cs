using System;
using System.Threading.Tasks;
using traininghub.dac.ef.Common;
using Traininghub.Data;

namespace traininghub.core
{
    public class GameOrganizer : IGameOrganizer
    {
        private readonly IRepository<Game> gameRepo;
        private readonly IRepository<Challenge> challengeRepo;
        private readonly IUnitOfWork unitOfWork;

        public GameOrganizer(
            IRepository<Game> gameRepo, 
            IRepository<Challenge> challengeRepo)
        {
            this.gameRepo = gameRepo;
            this.challengeRepo = challengeRepo;
            this.unitOfWork = gameRepo;
        }

        public void AcceptChallenge(int challengeId, int userId)
        {
            var challenge = this.challengeRepo.GetById(challengeId);
            var game = challenge.Game;
            if (game.OrganizerId == userId)
            {
                challenge.IsConfirmed = true;
                game.Status = Status.Full;
                this.challengeRepo.Attach(challenge);
                this.gameRepo.Attach(game);
            } 
        }

        public void CancelGame(int gameId, int userId)
        {
            var game = this.gameRepo.GetById(gameId);
            if (game.OrganizerId == userId)
            {
                game.Status = Status.Canceled;
                this.gameRepo.Attach(game);
            }
        }

        public void CreateGame(Game game)
        {
            this.gameRepo.Insert(game);
        }

        public void IssueChallenge(int gameId, int userId)
        {
            var game = this.gameRepo.GetById(gameId);
            if (game != null && game.Status == Status.Active)
            {
                var challenge = new Challenge
                {
                    ChallengeTime = DateTime.Now,
                    GameId = gameId,
                    IsConfirmed = false,
                    UserId = userId
                };

                this.challengeRepo.Insert(challenge);
            }
        }

        public void Save()
        {
            this.unitOfWork.Save();
        }

        public Task SaveAsync()
        {
            return this.unitOfWork.SaveAsync();
        }
    }
}
