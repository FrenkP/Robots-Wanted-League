using System;
using System.ComponentModel.DataAnnotations;

namespace RobotsWantedLeague.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Region { get; set; }
    }
}

