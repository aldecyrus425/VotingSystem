using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class PositionsDTO
    {
        public int PositionId { get; set; }
        public int ElectionId { get; set; } // (FK → Elections.ElectionId)
        public Elections Elections { get; set; }
        public string Name { get; set; }
        public int MaxVoteAllowed { get; set; }
        public int MinVoteAllowed { get; set; }
    }

    public class  AddPositionDTO 
    {
        public int ElectionId { get; set; }
        public string Name { get; set; }
        public int MaxVoteAllowed { get; set; }
        public int MinVoteAllowed { get; set; }
    }

    public class UpdatePositionDTO
    {
        public int PositionId { get; set; }
        public int ElectionId { get; set; } 
        public string Name { get; set; }
        public int MaxVoteAllowed { get; set; }
        public int MinVoteAllowed { get; set; }
    }
}
