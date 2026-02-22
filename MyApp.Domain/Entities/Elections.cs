using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Elections
    {
        public int ElectionId { get; private set; }
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool isActive { get; private set; }
        public int CreatedBy { get; private set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; private set; }

        protected Elections() { }

        public Elections( string title, DateTime startDate, DateTime endDate, bool isActive, int createdBy)
        {

            if(string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("Title is required.");

            if (startDate > endDate)
                throw new ArgumentException("Start date cannot be after end date.");

            if (endDate < startDate)
                throw new ArgumentException("End date cannot be before start date.");

            if (startDate < DateTime.UtcNow)
                throw new ArgumentException("Start date cannot be in the past.");

            if (createdBy <= 0)
                throw new ArgumentException("Invalid created by.");


            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            this.isActive = isActive;
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
        }

        public void ActivateElection()
        {
            if (DateTime.UtcNow < StartDate)
                throw new InvalidOperationException("Election has not started yet.");

            if (DateTime.UtcNow > EndDate)
                throw new InvalidOperationException("Election already ended.");

            if (isActive)
                throw new InvalidOperationException("Election is already active.");

            isActive = true;
        }



    }
}
