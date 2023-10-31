using RobotsWantedLeague.Models;
using System.Collections.Generic;
using System.Linq;

namespace RobotsWantedLeague.Services
{
    public class AgentsService : IAgentsService
    {
        private readonly List<Agent> agents = new List<Agent>();

        public AgentsService()
        {
            // Agents par défaut
            agents.Add(new Agent { Id = 1, Name = "Agent 1", IdentificationNumber = "12345", Region = "Europe" });
            agents.Add(new Agent { Id = 2, Name = "Agent 2", IdentificationNumber = "67890", Region = "Amérique" });
        }

        public List<Agent> GetAgents()
        {
            return agents;
        }

        public void AddAgent(Agent agent)
        {
            // Génére nouveau identifiant pour l'agent
            agent.Id = agents.Count + 1;
            agents.Add(agent);
        }
        public Agent GetAgentById(int id)
        {
            return agents.FirstOrDefault(agent => agent.Id == id);
        }
    }
}
