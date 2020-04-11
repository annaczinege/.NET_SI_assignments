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

        public int GetMinimumDistance(UserNode startNode, UserNode endNode, List<UserNode> users)
        {
            int countDistance = 0;
            _currentNode = startNode;
            _currentNode.IsVisited = true;
            queueOfUsers.Enqueue(_currentNode);

            while (queueOfUsers.Count > 0)
            {
                _currentNode = queueOfUsers.Dequeue();
                if (_currentNode.Friends.Contains(endNode))
                {
                    countDistance++;
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
    }
}
