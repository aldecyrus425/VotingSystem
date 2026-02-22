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
    public class PositionsServices : IPositionServices
    {
        private readonly IPositionRepository _positionRepo;

        public PositionsServices(IPositionRepository positionRepo)
        {
            positionRepo = _positionRepo;
        }

        public async Task<ResponseDTO<PositionsDTO>> addPositionAsync(AddPositionDTO dto)
        {
            try
            {
                var position = new Positions(dto.ElectionId, dto.Name, dto.MaxVoteAllowed, dto.MinVoteAllowed);
                var response = await _positionRepo.addPositionAsync(position);

                return new ResponseDTO<PositionsDTO>
                {
                    Success = true,
                    Message = "Position added successfully.",
                    Data = new PositionsDTO
                    {
                        PositionId = response.PositionId,
                        ElectionId = response.ElectionId,
                        Name = response.Name,
                        MaxVoteAllowed = response.MaxVoteAllowed,
                        MinVoteAllowed = response.MinVoteAllowed
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<PositionsDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<IEnumerable<PositionsDTO>>> getAllPositionAsync()
        {
            try
            {
                var response = await _positionRepo.getAllPositionAsync();

                var positions = response.Select(p => new PositionsDTO
                {
                    PositionId = p.PositionId,
                    ElectionId = p.ElectionId,
                    Elections = p.Elections,
                    Name = p.Name,
                    MaxVoteAllowed = p.MaxVoteAllowed,
                    MinVoteAllowed = p.MinVoteAllowed
                });

                return new ResponseDTO<IEnumerable<PositionsDTO>>
                {
                    Success = true,
                    Message = "Positions List's",
                    Data = positions
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<IEnumerable<PositionsDTO>>
                {
                    Success = false,
                    Message = ex.Message,
                };

            }
        }

        public async Task<ResponseDTO<PositionsDTO>> getPositionsByIDAsync(int id)
        {
            try
            {
                var response = await _positionRepo.getPositionByIDAsync(id);
                if(response == null)
                {
                    return new ResponseDTO<PositionsDTO>
                    {
                        Success = false,
                        Message = "Position not found."
                    };
                }

                return new ResponseDTO<PositionsDTO>
                {
                    Success = true,
                    Message = "Position Information.",
                    Data = new PositionsDTO
                    {
                        PositionId = response.PositionId,
                        ElectionId = response.ElectionId,
                        Elections = response.Elections,
                        Name = response.Name,
                        MaxVoteAllowed = response.MaxVoteAllowed,
                        MinVoteAllowed = response.MinVoteAllowed
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<PositionsDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<PositionsDTO>> removePositionAsync(int id)
        {
            try
            {
                var response = await _positionRepo.deletePositionAsync(id);
                if(!response)
                {
                    return new ResponseDTO<PositionsDTO>
                    {
                        Success = false,
                        Message = "Position not found."
                    };
                }

                await _positionRepo.saveChangesAsync();

                return new ResponseDTO<PositionsDTO>
                {
                    Success = true,
                    Message = "Position deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<PositionsDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<PositionsDTO>> updatePositionAsync(UpdatePositionDTO dto)
        {
            try
            {
                var response = await _positionRepo.getPositionByIDAsync(dto.PositionId);
                if(response == null)
                {
                    return new ResponseDTO<PositionsDTO>
                    {
                        Success = false,
                        Message = "Position not found."
                    };
                }

                response.UpdatePosition(dto.ElectionId, dto.Name, dto.MaxVoteAllowed, dto.MinVoteAllowed);

                await _positionRepo.saveChangesAsync();

                return new ResponseDTO<PositionsDTO>
                {
                    Success = true,
                    Message = "Position updated successfully.",
                    Data = new PositionsDTO
                    {
                        PositionId = response.PositionId,
                        ElectionId = response.ElectionId,
                        Elections = response.Elections,
                        Name = response.Name,
                        MaxVoteAllowed = response.MaxVoteAllowed,
                        MinVoteAllowed = response.MinVoteAllowed
                    }
                };
            }
            catch(ArgumentException ex)
            {
                return new ResponseDTO<PositionsDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
