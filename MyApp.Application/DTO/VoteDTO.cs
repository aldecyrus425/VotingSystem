using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class VoteDTO
    {
        public int VoteId { get; set; }
        public ShowPositionDTO Position { get; set; }
        public ShowCandidateDTO Candidate { get; set; }
        public ShowUserDTO User { get; set; }
        public DateTime VotedAt { get; set; }

    }

    public class CastBallotDTO
    {
        public int ElectionId { get; set; }
        public List<VoteSelectionDTO> Votes { get; set; }
    }

    public class VoteSelectionDTO
    {
        public int PositionId { get; set; }
        public int CandidateId { get; set; }
    }


    public class VoteHistoryDTO
    {
        public int VoteId { get; set; }
        public string PositionName { get; set; }
        public string CandidateName { get; set; }
        public DateTime VotedAt { get; set; }
    }
}
