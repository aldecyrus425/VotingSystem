using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Persistence;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class VoteServices : IVotesServices
    {
        private readonly IVotesRepository _voteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _transaction;

        public VoteServices(IVotesRepository voteRepository, IUserRepository userRepository, IUnitOfWork transaction)
        {
            _voteRepository = voteRepository;
            _userRepository = userRepository;
            _transaction = transaction;
        }

        public async Task<ResponseDTO<string>> castVotesAsync(CastBallotDTO dto, int userID)
        {
            

            try
            {
                var user = await _userRepository.findUserByIDAsync(userID);
                if(user == null)
                {
                    return new ResponseDTO<string>
                    {
                        Success = false,
                        Message = "Voter not found."
                    };
                }
                if (user.isVoted)
                {
                    return new ResponseDTO<string>
                    {
                        Success = false,
                        Message = "User voted already."
                    };
                }

                await _transaction.BeginTransactionAsync();

                foreach (var selection in dto.Votes)
                {
                    var vote = new Votes(dto.ElectionId, selection.PositionId, selection.CandidateId, userID);

                    await _voteRepository.addVoteAsync(vote);
                }

                user.MarkAsVoted();

                await _voteRepository.saveChangesAsync();
                await _transaction.CommitAsync();

                return new ResponseDTO<string>
                {
                    Success = true,
                    Message = "Vote cast successfully.",

                };
            }
            catch (ArgumentException ex)
            {
                await _transaction.RollbackAsync();

                return new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

            catch(Exception ex)
            {
                await _transaction.RollbackAsync();

                return new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public Task<ResponseDTO<int>> countVotePerCandidateAsync(int candidate)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<IEnumerable<VoteDTO>>> getAllVotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResponseDTO<VoteHistoryDTO>>> getVoteHisotryAsync(int userID)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<VoteDTO>> getVotesAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
