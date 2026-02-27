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
    public class CandidateServices : ICandidateServices
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateServices(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }


        public async Task<ResponseDTO<CandidateDTO>> addCandidateAsync(AddCandidate dto)
        {
            try
            {
                var candidate = new Candidates(dto.PositionID, dto.DisplayName, dto.PhotoUrl, dto.Description);
                var response = await _candidateRepository.addCandidateAsync(candidate);

                return new ResponseDTO<CandidateDTO>
                {
                    Success = true,
                    Message = "Candidate added successfully.",
                    Data = new CandidateDTO
                    {
                        CandidateId = response.CandidateId,
                        Positions = new ShowPositionDTO
                        {
                            PositionId = response.Positions.PositionId,
                            Name = response.Positions.Name,
                        },
                        DisplayName = response.DisplayName,
                        PhotoUrl = response.PhotoUrl,
                        Description = response.Description

                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<CandidateDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<CandidateDTO>> deleteCandidateAsync(int id)
        {
            try
            {
                var response = await _candidateRepository.deleteCandidateAsync(id);
                if (!response)
                {
                    return new ResponseDTO<CandidateDTO>
                    {
                        Success = false,
                        Message = "Candidate not found."
                    };
                }

                await _candidateRepository.SaveChangesAsync();

                return new ResponseDTO<CandidateDTO>
                {
                    Success = true,
                    Message = "Candidate deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<CandidateDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<IEnumerable<CandidateDTO>>> getAllCandidateAsync()
        {
            try
            {
                var response = await _candidateRepository.getAllCandidatesAsync();
                var candidate = response.Select(c => new CandidateDTO
                {
                    CandidateId = c.CandidateId,
                    Positions = new ShowPositionDTO
                    {
                        PositionId = c.Positions.PositionId,
                        Name = c.Positions.Name
                    },
                    DisplayName = c.DisplayName,
                    PhotoUrl = c.PhotoUrl,
                    Description = c.Description
                });

                return new ResponseDTO<IEnumerable<CandidateDTO>>
                {
                    Success = true,
                    Message = "Candidate List's",
                    Data = candidate
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<IEnumerable<CandidateDTO>>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<CandidateDTO>> getCandidateByIDAsync(int id)
        {
            try
            {
                var response = await _candidateRepository.getCandidateByIDAsync(id);
                if (response == null)
                {
                    return new ResponseDTO<CandidateDTO>
                    {
                        Success = false,
                        Message = "Candidate not found."
                    };
                }

                return new ResponseDTO<CandidateDTO>
                {
                    Success = true,
                    Message = "Candidate Information",
                    Data = new CandidateDTO
                    {
                        CandidateId = response.CandidateId,
                        Positions = new ShowPositionDTO
                        {
                            PositionId = response.Positions.PositionId,
                            Name = response.Positions.Name,
                        },
                        DisplayName = response.DisplayName,
                        PhotoUrl = response.PhotoUrl,
                        Description = response.Description
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<CandidateDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseDTO<CandidateDTO>> updateCandidateAsync(UpdateCandidate dto)
        {
            try
            {
                var response = await _candidateRepository.getCandidateByIDAsync(dto.CandidateId);
                if(response == null)
                {
                    return new ResponseDTO<CandidateDTO>
                    {
                        Success = false,
                        Message = "Candidate not found."
                    };
                }

                response.UpdateCandidate(dto.PositionID, dto.DisplayName, dto.PhotoUrl, dto.Description);

                await _candidateRepository.SaveChangesAsync();

                return new ResponseDTO<CandidateDTO>
                {
                    Success = true,
                    Message = "Candidate updated successfully.",
                    Data = new CandidateDTO
                    {
                        CandidateId = response.CandidateId,
                        Positions = new ShowPositionDTO
                        {
                            PositionId = response.Positions.PositionId,
                            Name = response.Positions.Name,
                        },
                        DisplayName = response.DisplayName,
                        PhotoUrl = response.PhotoUrl,
                        Description = response.Description
                    }
                };


            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<CandidateDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
