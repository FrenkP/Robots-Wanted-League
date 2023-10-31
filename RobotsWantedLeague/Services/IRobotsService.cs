namespace RobotsWantedLeague.Services
{
    using System.Collections.Generic;
    using RobotsWantedLeague.Models;

    public interface IRobotsService
    {
        List<Robot> Robots { get; }

        Robot CreateRobot(string name, int weight, int height, string country, string continent);

        Robot? GetRobotById(int id);

        bool DeleteRobotById(int id);

        IEnumerable<Robot> SearchRobots(string searchTerm);
        IEnumerable<Robot> SearchRobotsByCountry(string country);
        IEnumerable<Robot> SearchRobotsByRegion(string region);
    }
}