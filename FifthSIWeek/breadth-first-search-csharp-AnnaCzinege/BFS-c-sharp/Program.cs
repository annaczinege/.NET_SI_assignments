using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();
            HashSet<int> userIds = generator.Ids;

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("Done");

            Console.WriteLine("\nEnter first Id for minimum distance: ");
            int id1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter second Id for minimum distance: ");
            int id2 = Convert.ToInt32(Console.ReadLine());

            UserNode userNode1 = users.Single(u => u.Id == id1);
            UserNode userNode2 = users.Single(u => u.Id == id2);

            BFS bFS = new BFS();
            int minDistance = bFS.GetMinimumDistance(userNode1, userNode2, users);
            Console.WriteLine($"The minimum distance between {userNode1} and {userNode2} is {minDistance}.");
            Console.ReadKey();

        }
    }
}
