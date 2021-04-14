using DatabaseFirstSimpleExample.Models;
using System;
using System.Linq;

namespace DatabaseFirstSimpleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DatabaseFirstSimpleExampleContext();

            const int postId = 1;

            var post = new Post()
            {
                PostId = postId,
                DatePublished = DateTime.Now,
                Title = "Title",
                Body = "Body"
            };

            var postFromDb = context.Posts.SingleOrDefault(q => q.PostId == postId);

            if (postFromDb == null)
            {
                context.Posts.Add(post);
                context.SaveChanges();
                postFromDb = context.Posts.Single(q => q.PostId == postId);
            }

            Console.WriteLine($"Id: {postFromDb.PostId}");
            Console.WriteLine($"Date published: {postFromDb.DatePublished}");
            Console.WriteLine($"Title: {postFromDb.Title}");
            Console.WriteLine($"Body: {postFromDb.Body}");
        }
    }
}
