using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class ElectionServices : IElectionServices
    {
        private readonly IElectionRepository _electionRepository;

        public ElectionServices(IElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }

        public async Task<ResponseDTO<ElectionsDTO>> activateElectionAsync(int id)
        {
            try
            {
                var election = await _electionRepository.getElectionByIDAsync(id);
                if(election == null)
                {
                    return new ResponseDTO<ElectionsDTO>
                    {
                        Success = false,
                        Message = "Election not found."
                    };
                }

                election.ActivateElection();

                await _electionRepository.SaveChangesAsync();

                return new ResponseDTO<ElectionsDTO>
                {
                    Success = true,
                    Message = "Election activated successfully.",
                    Data = new ElectionsDTO
                    {
                        ElectionId = election.ElectionId,
                        Title = election.Title,
                        StartDate = election.StartDate,
                        EndDate = election.EndDate,
                        isActive = election.isActive,
                        CreatedBy = election.CreatedBy,
                        User = new ShowUserDTO
                        {
                            FirstName = election.User.FirstName,
                            MiddleName = election.User.MiddleName,
                            LastName = election.User.LastName,
                        },
                        CreatedAt = election.CreatedAt,
                        
                    }
                };

            }
            catch(InvalidOperationException ex)
            {
                return new ResponseDTO<ElectionsDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ElectionsDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public Task<ResponseDTO<ElectionsDTO>> addElectionAsync(AddElectionsDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<ElectionsDTO>> deleteElectionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<IEnumerable<ElectionsDTO>>> getAllElectionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<ElectionsDTO>> getElectionByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<ElectionsDTO>> updateElectionAsync(UpdateElectionsDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
