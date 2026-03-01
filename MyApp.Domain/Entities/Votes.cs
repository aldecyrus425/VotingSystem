using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Votes
    {
        public int VoteId { get; set; }
        public int ElectionId { get; set; }  // (FK → Elections.ElectionId)
        public Elections Elections { get; set; }

        public int PositionId { get; set; } // (FK → Positions.PositionId)
        public Positions Positions { get; set; }

        public int CandidateId { get; set; } // (FK → Candidates.CandidateId)
        public Candidates Candidates { get; set; }

        public int VoterId { get; set; } // (FK → Users.UserId)
        public User User { get; set; }

        public DateTime VotedAt { get; set; }

        protected Votes() { }

        public Votes( int electionId, int positionId, int candidateId, int voterId)
        {
            if (electionId <= 0)
                throw new ArgumentException("Invalid election ID.");

            if (positionId <= 0)
                throw new ArgumentException("Invalid position ID.");

            if (candidateId <= 0)
                throw new ArgumentException("Invalid candidate ID.");

            if (voterId <= 0)
                throw new ArgumentException("Invalid voter ID.");

            ElectionId = electionId;
            PositionId = positionId;
            CandidateId = candidateId;
            VoterId = voterId;
            VotedAt = DateTime.UtcNow;
        }
    }
}
