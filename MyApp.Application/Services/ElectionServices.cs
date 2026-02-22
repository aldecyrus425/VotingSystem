using MyApp.Application.DTO;
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

        public async Task<ResponseDTO<ElectionsDTO>> addElectionAsync(AddElectionsDTO dto)
        {
            try
            {
                var election = new Elections(dto.Title, dto.StartDate, dto.EndDate, dto.CreatedBy);
                var response = await _electionRepository.addElectionAsync(election);

                return new ResponseDTO<ElectionsDTO>
                {
                    Success = true,
                    Message = "Election added successfully.",
                    Data = new ElectionsDTO
                    {
                        ElectionId = response.ElectionId,
                        Title = response.Title,
                        StartDate = response.StartDate,
                        EndDate = response.EndDate,
                        isActive = response.isActive,
                        CreatedBy = response.CreatedBy,
                        User = new ShowUserDTO
                        {
                            FirstName = response.User.FirstName,
                            MiddleName = response.User.MiddleName,
                            LastName = response.User.LastName,
                        },
                        CreatedAt = response.CreatedAt,

                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<ElectionsDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<ElectionsDTO>> deleteElectionAsync(int id)
        {
            try
            {
                var response = await _electionRepository.deleteElectionAsync(id);
                if(!response)
                {
                    return new ResponseDTO<ElectionsDTO>
                    {
                        Success = false,
                        Message = "Election not found."
                    };
                }

                await _electionRepository.SaveChangesAsync();
                return new ResponseDTO<ElectionsDTO>
                {
                    Success = true,
                    Message = "Election deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ElectionsDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<IEnumerable<ElectionsDTO>>> getAllElectionsAsync()
        {
            try
            {
                var response = await _electionRepository.getAllElectionsAsync();

                var election = response.Select(e => new ElectionsDTO
                {
                    ElectionId = e.ElectionId,
                    Title = e.Title,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    isActive = e.isActive,
                    CreatedBy = e.CreatedBy,
                    User = new ShowUserDTO
                    {
                        FirstName = e.User.FirstName,
                        MiddleName = e.User.MiddleName,
                        LastName = e.User.LastName,
                    },
                    CreatedAt = e.CreatedAt,
                });

                return new ResponseDTO<IEnumerable<ElectionsDTO>>
                {
                    Success = true,
                    Message = "Elections List's",
                    Data = election
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<IEnumerable<ElectionsDTO>>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<ElectionsDTO>> getElectionByIDAsync(int id)
        {
            try
            {
                var response = await _electionRepository.getElectionByIDAsync(id);
                if(response == null)
                {
                    return new ResponseDTO<ElectionsDTO>
                    {
                        Success = false,
                        Message = "Election not found."
                    };
                }

                return new ResponseDTO<ElectionsDTO>
                {
                    Success = true,
                    Message = "Election information.",
                    Data = new ElectionsDTO
                    {
                        ElectionId = response.ElectionId,
                        Title = response.Title,
                        StartDate = response.StartDate,
                        EndDate = response.EndDate,
                        isActive = response.isActive,
                        CreatedBy = response.CreatedBy,
                        User = new ShowUserDTO
                        {
                            FirstName = response.User.FirstName,
                            MiddleName = response.User.MiddleName,
                            LastName = response.User.LastName,
                        },
                        CreatedAt = response.CreatedAt,
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ElectionsDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<ElectionsDTO>> updateElectionAsync(UpdateElectionsDTO dto)
        {
            try
            {
                var response = await _electionRepository.getElectionByIDAsync(dto.ElectionId);
                if (response == null)
                {
                    return new ResponseDTO<ElectionsDTO>
                    {
                        Success = false,
                        Message = "Election not found."
                    };
                }

                response.UpdateElection(dto.Title, dto.StartDate, dto.EndDate);

                await _electionRepository.SaveChangesAsync();

                return new ResponseDTO<ElectionsDTO>
                {
                    Success = true,
                    Message = "Election updated successfully.",
                    Data = new ElectionsDTO
                    {
                        ElectionId = response.ElectionId,
                        Title = response.Title,
                        StartDate = response.StartDate,
                        EndDate = response.EndDate,
                        isActive = response.isActive,
                        CreatedBy = response.CreatedBy,
                        User = new ShowUserDTO
                        {
                            FirstName = response.User.FirstName,
                            MiddleName = response.User.MiddleName,
                            LastName = response.User.LastName,
                        },
                        CreatedAt = response.CreatedAt,
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ElectionsDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}

