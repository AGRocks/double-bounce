using System;
using System.Collections.Generic;
using System.Text;
using traininghub.dac.ef.Common;
using Traininghub.Data;

namespace traininghub.core
{
    public interface IGameOrganizer : IUnitOfWork
    {
        void CreateGame(Game game);
        void CancelGame(int gameId, int userId);
        void AcceptChallenge(int challengeId, int userId);
        void IssueChallenge(int gameId, int userId);
    }
}
