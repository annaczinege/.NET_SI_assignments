using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace BlogTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_writes_to_database()
        {
            var options = new DbContextOptionsBuilder<BlogDBContext>()
                .UseInMemoryDatabase(databaseName: nameof(Add_writes_to_database))
                .Options;

            // Run the test against one instance of the context
            using (var context = new BlogDBContext(options))
            {
                var service = new SQLUserRepository(context);
                service.Add(new User { Id=4, FirstName="Willy", LastName="Wonka"});
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new BlogDBContext(options))
            {
                Assert.AreEqual("Willy", context.Users.Single(u => u.Id == 4).FirstName);
            }
        }
    }
}