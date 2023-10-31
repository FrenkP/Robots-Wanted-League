using Microsoft.AspNetCore.Mvc;
using RobotsWantedLeague.Models;
using RobotsWantedLeague.Services;
using System.Collections.Generic;
using System.Linq;

namespace RobotsWantedLeague.Controllers
{
    public class AgentsController : Controller
    {
        private readonly IAgentsService agentsService;

        public AgentsController(IAgentsService agentsService)
        {
            this.agentsService = agentsService;
        }

        public IActionResult Index()
        {
            var agents = agentsService.GetAgents();
            return View(agents);
        }

        [HttpGet]
        public IActionResult AddAgent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAgent(Agent agent)
        {
            if (ModelState.IsValid)
            {
                agentsService.AddAgent(agent);
                return RedirectToAction("AgentDetails", new { id = agent.Id });
            }

            return View(agent);
        }

        public IActionResult AgentDetails(int id)
        {
            var agent = agentsService.GetAgentById(id);

            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }
    }
}
