namespace RobotsWantedLeague.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RobotsWantedLeague.Models;

    public class RobotsService : IRobotsService
    {
        private readonly List<Robot> robots;
        private int idGenerator = 0;

        public List<Robot> Robots => robots;

        public RobotsService()
        {
            robots = new List<Robot>();
        }

        private int GenerateId()
        {
            idGenerator = idGenerator + 1;
            return idGenerator;
        }

        public Robot CreateRobot(string name, int weight, int height, string country, string continent)
        {
            var robot = new Robot(GenerateId(), name, weight, height, country, continent);
            robots.Add(robot);
            return robot;
        }

        private int GetIndexOfRobotById(int id)
        {
            int idx = 0;
            foreach (Robot robot in robots)
            {
                if (robot.Id == id)
                {
                    return idx;
                }
                idx++;
            }
            return -1;
        }

        public Robot? GetRobotById(int id)
        {
            int indexToDelete = GetIndexOfRobotById(id);
            if (indexToDelete == -1)
            {
                return null;
            }
            return robots[indexToDelete];
        }

        public bool DeleteRobotById(int id)
        {
            int indexToDelete = GetIndexOfRobotById(id);
            if (indexToDelete == -1)
            {
                return false;
            }
            robots.RemoveAt(indexToDelete);
            return true;
        }

        public IEnumerable<Robot> SearchRobots(string searchTerm)
        {
          searchTerm = searchTerm?.ToLower();

          return Robots.Where(robot =>

           robot.Country.ToLower().Contains(searchTerm) || robot.Region.ToLower().Contains(searchTerm)).ToList();
        }

        public IEnumerable<Robot> SearchRobotsByCountry(string country)
        {
            return robots.Where(robot => robot.Country == country);
        }

        public IEnumerable<Robot> SearchRobotsByRegion(string Continent)
        {
            return robots.Where(robot => robot.Continent == Continent);
        }
    }
}