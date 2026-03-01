using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IVotesServices
    {
        public Task<ResponseDTO<IEnumerable<VoteDTO>>> getAllVotesAsync();
        public Task<ResponseDTO<VoteDTO>> getVotesAsync(int id);
        public Task<ResponseDTO<string>> castVotesAsync(CastBallotDTO dto, int userID);
        public Task<ResponseDTO<int>> countVotePerCandidateAsync(int candidate);
        public Task<IEnumerable<ResponseDTO<VoteHistoryDTO>>> getVoteHisotryAsync(int userID);

    }
}
