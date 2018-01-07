using System;
using System.Collections.Generic;
using System.Text;
using Traininghub.Data;

namespace traininghub.core
{
    public interface IGameOrganizer
    {
        int Create(Game game);
        bool AcceptChallenge(int challengeId, int userId);
        bool IssueChallenge(int gameId, int userId);
        bool Cancel(int gameId, int userId);
    }
}
