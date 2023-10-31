using System.Collections.Generic;
using RobotsWantedLeague.Models;
using System.Linq;

namespace RobotsWantedLeague.Services
{
    public class NotEmptyRobotsService : IRobotsService
    {
        private readonly IRobotsService underlyingRobotsService;

        public List<Robot> Robots => underlyingRobotsService.Robots;

        public NotEmptyRobotsService()
        {
            this.underlyingRobotsService = new RobotsService();
            this.underlyingRobotsService.CreateRobot("Alice", 1050, 2, "Bhutan", "Asia");
            this.underlyingRobotsService.CreateRobot("Bob", 5001, 5, "Vanuatu", "Oceania");
            this.underlyingRobotsService.CreateRobot("Xu", 890, 1, "Taiwan", "Asia");
        }

        public Robot CreateRobot(string name, int weight, int height, string country, string continent)
        {
            return underlyingRobotsService.CreateRobot(name, weight, height, country, continent);
        }

        public Robot? GetRobotById(int id)
        {
            return underlyingRobotsService.GetRobotById(id);
        }

        public bool DeleteRobotById(int id)
        {
            return underlyingRobotsService.DeleteRobotById(id);
        }

        public IEnumerable<Robot> SearchRobots(string searchTerm)
        {
            
            searchTerm = searchTerm?.ToLower(); 
            return Robots.Where(robot =>
                robot.Country.ToLower().Contains(searchTerm) ||
                robot.Continent.ToLower().Contains(searchTerm)); 
        }

        public IEnumerable<Robot> SearchRobotsByCountry(string country)
        {
            return Robots.Where(robot => robot.Country.Equals(country, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Robot> SearchRobotsByRegion(string Continent)
        {
            return Robots.Where(robot => robot.Continent.Equals(Continent, StringComparison.OrdinalIgnoreCase));
        }
    }
}
