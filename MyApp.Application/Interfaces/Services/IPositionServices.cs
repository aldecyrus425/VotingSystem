using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IPositionServices
    {
        public Task<ResponseDTO<IEnumerable<PositionsDTO>>> getAllPositionAsync();
        public Task<ResponseDTO<PositionsDTO>> getPositionsByIDAsync(int id);
        public Task<ResponseDTO<PositionsDTO>> addPositionAsync(AddPositionDTO dto);
        public Task<ResponseDTO<PositionsDTO>> updatePositionAsync(UpdatePositionDTO dto);
        public Task<ResponseDTO<PositionsDTO>> removePositionAsync(int id);
    }
}
