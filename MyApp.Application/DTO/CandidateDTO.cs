using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class CandidateDTO
    {
        public int CandidateId { get; set; }
        public ShowPositionDTO Positions { get; set; }
        public string DisplayName { get; set; }
        public string? PhotoUrl { get; set; }
        public string Description { get; set; }
    }

    public class ShowCandidateDTO
    {
        public int CandidateId { get; set; }
        public string DisplayName { get; set; }
    }

    public class AddCandidate
    {
        public int PositionID { get; set; }
        public string DisplayName { get; set; }
        public string? PhotoUrl { get; set; }
        public string Description { get; set; }
    }

    public class UpdateCandidate
    {
        public int CandidateId { get; set; }
        public int PositionID { get; set; }
        public string DisplayName { get; set; }
        public string? PhotoUrl { get; set; }
        public string Description { get; set; }
    }
}
