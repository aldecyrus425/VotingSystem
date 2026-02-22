using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IElectionServices
    {
        public Task<ResponseDTO<IEnumerable<ElectionsDTO>>> getAllElectionsAsync();

        public Task<ResponseDTO<ElectionsDTO>> getElectionByIDAsync(int id);
        public Task<ResponseDTO<ElectionsDTO>> addElectionAsync(AddElectionsDTO dto);
        public Task<ResponseDTO<ElectionsDTO>> updateElectionAsync(UpdateElectionsDTO dto);
        public Task<ResponseDTO<ElectionsDTO>> deleteElectionAsync(int id);
        public Task<ResponseDTO<ElectionsDTO>> activateElectionAsync(int id);
    }
}
