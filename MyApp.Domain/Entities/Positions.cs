using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Positions
    {
        public int PositionId { get; private set; }
        public int ElectionId { get; private set; } // (FK → Elections.ElectionId)
        public Elections Elections { get; set; }
        public string Name { get; private set; }
        public int MaxVoteAllowed { get; private set; }
        public int MinVoteAllowed { get; private set; }

        protected Positions() { }

        public Positions( int electionId, string name, int maxVoteAllowed, int minVoteAllowed)
        {
            if (electionId <= 0)
                throw new ArgumentException("Invalid election ID.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            if (maxVoteAllowed <= 0)
                throw new ArgumentException("Invalid Max vote count.");

            if (minVoteAllowed <= 0 || maxVoteAllowed < minVoteAllowed)
                throw new ArgumentException("Invalid Min vote count.");

            ElectionId = electionId;
            Name = name;
            MaxVoteAllowed = maxVoteAllowed;
            MinVoteAllowed = minVoteAllowed;
        }

        public void UpdatePosition(int electionId, string name, int maxVoteAllowed, int minVoteAllowed)
        {
            if (electionId <= 0)
                throw new ArgumentException("Invalid election ID.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            if (maxVoteAllowed <= 0)
                throw new ArgumentException("Invalid Max vote count.");

            if (minVoteAllowed <= 0 || maxVoteAllowed < minVoteAllowed)
                throw new ArgumentException("Invalid Min vote count.");

            ElectionId = electionId;
            Name = name;
            MaxVoteAllowed = maxVoteAllowed;
            MinVoteAllowed = minVoteAllowed;
        }
    }
}
