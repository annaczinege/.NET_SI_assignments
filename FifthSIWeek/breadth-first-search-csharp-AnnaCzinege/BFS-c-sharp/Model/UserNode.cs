using System;
using System.Collections.Generic;

namespace BFS_c_sharp.Model
{
    public class UserNode
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly HashSet<UserNode> _friends = new HashSet<UserNode>();

        public HashSet<UserNode> Friends
        {
            get { return _friends; }
        }

        public bool IsVisited { get; set; }


        public UserNode() { }

        public UserNode(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsVisited = false;
        }

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName + "(" + Friends.Count + ")";
        }
    }
}
