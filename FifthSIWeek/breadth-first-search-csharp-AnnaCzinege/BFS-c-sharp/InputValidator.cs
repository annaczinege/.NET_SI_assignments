using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    public class InputValidator
    {
        public int ValidateInputForMinDistanceAndShortestPath(string nextId, HashSet<int> ids)
        {
            int id;
            do
            {
                Console.WriteLine($"\nEnter {nextId} Id for minimum distance: ");
                id = Convert.ToInt32(Console.ReadLine());
            } while (!ids.Contains(id));

            return id;
        }

        public int ValidateInputForFriendsInDistance(HashSet<int> ids)
        {
            int id;
            do
            {
                Console.WriteLine("\nEnter an Id for listing friends of friends in given distance: ");
                id = Convert.ToInt32(Console.ReadLine());
            } while (!ids.Contains(id));

            return id;
        }

        public int ValidateDistanceInput()
        {
            Regex regex = new Regex(@"^[0-9]+$");
            string distance;
            do
            {
                Console.WriteLine("\nEnter a number for distance: ");
                distance = Console.ReadLine();
            } while (!regex.IsMatch(distance));

            return Convert.ToInt32(distance);
        }
    }
}
