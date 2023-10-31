using RobotsWantedLeague.Models;
using RobotsWantedLeague.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotsWantedLeague.Controllers
{
    public class RobotRequest
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
    }

    public class RobotsController : Controller
    {
        private readonly ILogger<RobotsController> _logger;
        private readonly IRobotsService robotsService;
        private readonly ICountriesService countriesService;

        public RobotsController(ILogger<RobotsController> logger, IRobotsService robotsService, ICountriesService countriesService)
        {
            _logger = logger;
            this.robotsService = robotsService;
            this.countriesService = countriesService;
        }

        public IActionResult Index()
        {
            return View(robotsService.Robots);
        }

        public IActionResult Robot(int id)
        {
            Robot robot = robotsService.GetRobotById(id);
            return View(robot);
        }

        [HttpGet]
        public IActionResult CreateRobot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRobot([FromBody] RobotRequest robot)
        {
            // Vérifie si le pays est valide avec le service CountriesService
            if (!countriesService.IsCountryValid(robot.Country))
            {
                // Msg d'erreur si le pays n'est pas valide
                ModelState.AddModelError("Country", "Le pays n'est pas valide.");
                return View(robot);
            }

            string continent = "YourContinentValue";

            Robot r = robotsService.CreateRobot(robot.Name, robot.Weight, robot.Height, robot.Country, continent);
            string htmxRedirectHeaderName = "HX-Redirect";
            string redirectURL = "/robots/robot?id=" + r.Id;
            Response.Headers.Add(htmxRedirectHeaderName, redirectURL);
            return Ok();
        }

        [HttpGet]
        public IActionResult UpdatePays(int id)
        {
            Robot robot = robotsService.GetRobotById(id);

            if (robot == null)
            {
                return NotFound();
            }

            return View(robot);
        }

        [HttpPost]
        public IActionResult UpdatePays(int id, string country)
        {
            // Récupérez le robot à partir de l'id
            Robot robot = robotsService.GetRobotById(id);

            if (robot == null)
            {
                return NotFound();
            }

            // Vérifiez si le pays est valide
            if (!countriesService.IsCountryValid(country))
            {
                // Msg d'erreur si le pays n'est pas valide
                ModelState.AddModelError("Country", "Le pays n'est pas valide.");
                return View(robot);
            }

            // Ajoutez l'ancien pays dans l'historique
            robot.HistoriquePays.Add(robot.Country);

            // Metz à jour pays du robot
            robot.Country = country;

            // Redirige utilisateur vers page des détails du robot
            return RedirectToAction("Robot", new { id = robot.Id });
        }

        public IActionResult Search(string searchTerm)
        {

            if (countriesService.IsCountryValid(searchTerm))
            {

                IEnumerable<Robot> searchResults = robotsService.SearchRobotsByCountry(searchTerm);
                return View("Search", searchResults);
            }
            else
            {
                
                IEnumerable<Robot> searchResults = robotsService.SearchRobotsByRegion(searchTerm);
                return View("Search", searchResults);
            }
        }
    }
}
