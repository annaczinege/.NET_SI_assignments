using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _useList;

        public MockUserRepository()
        {
            _useList = new List<User>()
            {
                new User { Id = 1, FirstName = "Mary", LastName = "Jane", Posts = new List<Post>() {new Post { Id = 1, UserId = 1, Content = "MJ1"}, new Post { Id = 2, UserId = 1, Content = "MJ2"} }},
                new User { Id = 2, FirstName = "Harry", LastName = "Potter", Posts = new List<Post>() {new Post { Id = 3, UserId = 2, Content="HP1"}, new Post { Id = 4, UserId = 2, Content="HP2"} }},
                new User { Id = 3, FirstName = "Eric", LastName = "Cartman", Posts = new List<Post>() {new Post { Id = 5, UserId = 3, Content="EC1"}, new Post { Id = 6, UserId = 3, Content="EC2"} }}
            };
        }
        public User Add(User user)
        {
            _useList.Add(user);
            return user;
        }

        public User Delete(int id)
        {
            User user = _useList.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                _useList.Remove(user);
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _useList;
        }

        public User GetUser(int id)
        {
            return _useList.FirstOrDefault(user => user.Id == id);
        }

        public User Update(User userChanges)
        {
            User user = _useList.FirstOrDefault(user => user.Id == userChanges.Id);
            if (user != null)
            {
                user.FirstName = userChanges.FirstName;
                user.LastName = userChanges.LastName;
                user.Posts = userChanges.Posts;
            }
            return user;
        }
    }
}
