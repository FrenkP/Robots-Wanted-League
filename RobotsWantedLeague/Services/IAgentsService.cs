using RobotsWantedLeague.Models;
using System.Collections.Generic;

namespace RobotsWantedLeague.Services
{
    public interface IAgentsService
    {
        List<Agent> GetAgents();
        void AddAgent(Agent agent);
        Agent GetAgentById(int id);
    }
}
