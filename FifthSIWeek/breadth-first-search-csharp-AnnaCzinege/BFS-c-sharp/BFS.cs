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
        private List<UserNode> _users;

        public BFS(List<UserNode> users)
        {
            _users = users;
        }

        public int GetMinimumDistance(UserNode startNode, UserNode endNode)
        {
            Dictionary<UserNode, int> checkingNodes = new Dictionary<UserNode, int>();
            startNode.WasVisited = true;
            checkingNodes[startNode] = 0;
            queueOfUsers.Enqueue(startNode);

            while (queueOfUsers.Count > 0 && !checkingNodes.ContainsKey(endNode))
            {
                _currentNode = queueOfUsers.Dequeue();
                
                foreach (UserNode friend in _currentNode.Friends)
                {
                    if (!friend.WasVisited)
                    {
                        friend.WasVisited = true;
                        checkingNodes[friend] = checkingNodes[_currentNode] + 1;
                        queueOfUsers.Enqueue(friend);
                    }
                }
            }

            queueOfUsers.Clear();
            ReverseVisitedStatus();
            return checkingNodes[endNode];
        }

        public HashSet<UserNode> GetFriendsOfFriendsWithDistance(UserNode startNode, int distance)
        {
            HashSet<UserNode> friendsInDistance = new HashSet<UserNode>();
            int counter = 0;
            startNode.WasVisited = true;
            queueOfUsers.Enqueue(startNode);

            while (counter < distance)
            {
                _currentNode = queueOfUsers.Dequeue();
                foreach (UserNode friend in _currentNode.Friends)
                {
                    if (!friend.WasVisited)
                    {
                        friend.WasVisited = true;
                        friendsInDistance.Add(friend);
                        queueOfUsers.Enqueue(friend);
                    }

                }
                counter++;
            }

            queueOfUsers.Clear();
            ReverseVisitedStatus();
            return friendsInDistance;
        }

        public List<UserNode> GetShortestPaths(UserNode startNode, UserNode endNode)
        {
            List<UserNode> userNodes = new List<UserNode>();
            Dictionary<UserNode, int> checkingNodes = new Dictionary<UserNode, int>();
            Dictionary<UserNode, HashSet<UserNode>> checkingEdges = new Dictionary<UserNode, HashSet<UserNode>>();
            startNode.WasVisited = true;
            checkingNodes[startNode] = 0;
            checkingEdges[startNode] = startNode.Friends;
            queueOfUsers.Enqueue(startNode);

            while (queueOfUsers.Count > 0)
            {
                _currentNode = queueOfUsers.Dequeue();

                foreach (UserNode friend in _currentNode.Friends)
                {
                    if (!friend.WasVisited)
                    {
                        friend.WasVisited = true;
                        checkingNodes[friend] = checkingNodes[_currentNode] + 1;
                        checkingEdges[friend] = friend.Friends;
                        queueOfUsers.Enqueue(friend);
                    }
                }
            }

            int mindDist = checkingNodes[endNode];
            userNodes.Add(endNode);
            queueOfUsers.Enqueue(endNode);
            

            while (mindDist > 0)
            {
                _currentNode = queueOfUsers.Dequeue();
                int manyFriends = checkingNodes.Where(cn => cn.Value == mindDist - 1 && checkingEdges[_currentNode].Contains(cn.Key)).Count();
                foreach (var friend in checkingEdges[_currentNode])
                {
                    if (checkingNodes[friend] == mindDist - 1)
                    {
                        userNodes.Add(friend);
                        queueOfUsers.Enqueue(friend);
                    }
                }
                mindDist--;
                
                
            }

            queueOfUsers.Clear();
            ReverseVisitedStatus();

            userNodes.Reverse();
            return userNodes;
        }

        private void ReverseVisitedStatus()
        {
            foreach (var user in _users)
            {
                user.WasVisited = false;
            }
        }
    }
}
