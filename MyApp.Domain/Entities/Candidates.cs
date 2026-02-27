using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Candidates
    {
        public int CandidateId { get; private set; }
        public int PositionId { get; private set; } // (FK → Positions.PositionId)
        public Positions Positions { get; set; }
        public string DisplayName { get; private set; }
        public string? PhotoUrl { get; private set; }
        public string Description { get; private set; }

        protected Candidates() { }

        public Candidates(int positionId, string displayName, string? photoUrl, string description)
        {
            if (positionId <= 0)
                throw new ArgumentException("Invalid position ID.");

            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException("Display name is required.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            PositionId = positionId;
            DisplayName = displayName;
            PhotoUrl = photoUrl;
            Description = description;
        }

        public void UpdateCandidate(int positionId, string displayName, string? photoUrl, string description)
        {
            if (positionId <= 0)
                throw new ArgumentException("Invalid position ID.");

            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException("Display name is required.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            PositionId = positionId;
            DisplayName = displayName;
            PhotoUrl = photoUrl;
            Description = description;
        }
    }
}
