using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface ICandidateServices
    {
        public Task<ResponseDTO<IEnumerable<CandidateDTO>>> getAllCandidateAsync();
        public Task<ResponseDTO<CandidateDTO>> getCandidateByIDAsync(int id);
        public Task<ResponseDTO<CandidateDTO>> addCandidateAsync(AddCandidate dto);
        public Task<ResponseDTO<CandidateDTO>> deleteCandidateAsync(int id);
        public Task<ResponseDTO<CandidateDTO>> updateCandidateAsync(UpdateCandidate dto);
    }
}
