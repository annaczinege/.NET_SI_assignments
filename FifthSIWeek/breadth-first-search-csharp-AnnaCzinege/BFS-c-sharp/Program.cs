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
            BFS bFS = new BFS(users);

            // Get all userNodes
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("Done");

            // Get minimum distance
            int id1 = validator.ValidateInputForMinDistanceAndShortestPath("first", userIds);
            int id2 = validator.ValidateInputForMinDistanceAndShortestPath("second", userIds);

            UserNode startNode = users.Single(u => u.Id == id1);
            UserNode endNode = users.Single(u => u.Id == id2);
            
            int minDistance = bFS.GetMinimumDistance(startNode, endNode);
            Console.WriteLine($"\nThe minimum distance between {startNode} and {endNode} is {minDistance}.");

            // Get shortest path(s)
            List<UserNode> shortesPaths = bFS.GetShortestPaths(startNode, endNode);
            Console.WriteLine($"\nThe shortest path between {startNode} end {endNode} is: {String.Join(", ", shortesPaths)}");

            // Get friends of friends
            int idForFriendOfFriends = validator.ValidateInputForFriendsInDistance(userIds);
            int distance = validator.ValidateDistanceInput();

            UserNode startFriend = users.Single(u => u.Id == idForFriendOfFriends);

            HashSet<UserNode> friendsOfFriends = bFS.GetFriendsOfFriendsWithDistance(startFriend, distance);
            Console.WriteLine($"\nFriends of friends with distance {distance} about {startFriend} is: {String.Join(", ", friendsOfFriends)}");

            Console.ReadKey();
        }
    }
}
