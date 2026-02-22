using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class ElectionsDTO
    {
        public int ElectionId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedBy { get; set; }
        public ShowUserDTO User { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class AddElectionsDTO
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class UpdateElectionsDTO
    {
        public int ElectionId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class MakeActiveElectionDTO
    {
        public int ElectionId { get; set; }
        public bool isActive { get; set; }
    }
}
