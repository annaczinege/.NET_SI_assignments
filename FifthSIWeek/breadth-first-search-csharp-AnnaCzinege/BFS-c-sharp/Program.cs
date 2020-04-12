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
            InputValidator validator = new InputValidator();
            BFS bFS = new BFS();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("Done");

            int id1 = validator.ValidateInputForMinimumDistance("first", userIds);
            int id2 = validator.ValidateInputForMinimumDistance("second", userIds);

            UserNode startNode = users.Single(u => u.Id == id1);
            UserNode endNode = users.Single(u => u.Id == id2);
            
            int minDistance = bFS.GetMinimumDistance(startNode, endNode);
            Console.WriteLine($"The minimum distance between {startNode} and {endNode} is {minDistance}.");

            bFS.ReverseVisitedStatus(users);

            int idForFriendOfFriends = validator.ValidateInputForFriendsInDistance(userIds);
            int distance = validator.ValidateDistanceInput();

            UserNode startFriend = users.Single(u => u.Id == idForFriendOfFriends);

            HashSet<UserNode> friendsOfFriends = bFS.GetFriendsOfFriendsWithDistance(startFriend, distance);
            Console.WriteLine($"Friends of friends with distance {distance} about {startFriend} is: {String.Join(", ", friendsOfFriends)}");

            bFS.ReverseVisitedStatus(users);
            Console.ReadKey();
        }
    }
}
