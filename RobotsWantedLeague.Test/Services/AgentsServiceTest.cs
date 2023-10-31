using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotsWantedLeague.Models;
using RobotsWantedLeague.Services;
using System.Collections.Generic;

namespace RobotsWantedLeague.Test.Services
{
    [TestClass]
    public class AgentsServiceTest
    {
        [TestMethod]
        public void TestGetAgents_ReturnsAgentsList()
        {
            // Arrange
            IAgentsService agentsService = new AgentsService();

            // Act
            List<Agent> agents = agentsService.GetAgents();

            // Assert
            Assert.IsNotNull(agents);
            Assert.IsTrue(agents.Count > 0);
        }

        [TestMethod]
        public void TestAddAgent_AddsAgentToList()
        {
            // Arrange
            IAgentsService agentsService = new AgentsService();
            Agent newAgent = new Agent
            {
                Name = "Test Agent",
                IdentificationNumber = "123456",
                Region = "Test Region"
            };

            // Act
            agentsService.AddAgent(newAgent);
            List<Agent> agents = agentsService.GetAgents();

            // Assert
            Assert.IsNotNull(agents);
            Assert.IsTrue(agents.Count > 0);
            Assert.IsTrue(agents.Exists(agent => agent.Name == "Test Agent"));
        }

        [TestMethod]
        public void TestGetAgentById_ReturnsCorrectAgent()
        {
            // Arrange
            IAgentsService agentsService = new AgentsService();
            Agent newAgent = new Agent
            {
                Name = "Test Agent",
                IdentificationNumber = "123456",
                Region = "Test Region"
            };
            agentsService.AddAgent(newAgent);

            // Act
            Agent retrievedAgent = agentsService.GetAgentById(newAgent.Id);

            // Assert
            Assert.IsNotNull(retrievedAgent);
            Assert.AreEqual("Test Agent", retrievedAgent.Name);
            Assert.AreEqual("123456", retrievedAgent.IdentificationNumber);
            Assert.AreEqual("Test Region", retrievedAgent.Region);
        }

        
    }
}
