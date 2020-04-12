using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    public class BFS
    {
        private UserNode _currentNode;
        private Queue<UserNode> queueOfUsers = new Queue<UserNode>();

        public BFS() { }

        public int GetMinimumDistance(UserNode startNode, UserNode endNode)
        {
            int countDistance = 0;
           startNode.IsVisited = true;
            queueOfUsers.Enqueue(startNode);

            while (queueOfUsers.Count > 0)
            {
                _currentNode = queueOfUsers.Dequeue();
                if (_currentNode.Friends.Contains(endNode))
                {
                    countDistance++;
                    queueOfUsers.Clear();
                    return countDistance;
                }
                else
                {
                    countDistance++;
                    foreach (UserNode friend in _currentNode.Friends)
                    {
                        if (!friend.IsVisited)
                        {
                            friend.IsVisited = true;
                            queueOfUsers.Enqueue(friend);
                        }
                    }
                }
            }

            return countDistance;
        }

        public HashSet<UserNode> GetFriendsOfFriendsWithDistance(UserNode startNode, int distance)
        {
            HashSet<UserNode> friendsInDistance = new HashSet<UserNode>();
            int counter = 0;
            startNode.IsVisited = true;
            queueOfUsers.Enqueue(startNode);

            while (counter < distance)
            {
                _currentNode = queueOfUsers.Dequeue();
                foreach (UserNode friend in _currentNode.Friends)
                {
                    if (!friend.IsVisited)
                    {
                        friend.IsVisited = true;
                        friendsInDistance.Add(friend);
                        queueOfUsers.Enqueue(friend);
                    }
                    
                }
                counter++;
            }

            queueOfUsers.Clear();
            return friendsInDistance;
        }
        
        public void ReverseVisitedStatus(List<UserNode> users)
        {
            foreach (var user in users)
            {
                user.IsVisited = false;
            }
        }
    }
}
