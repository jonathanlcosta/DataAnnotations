using System;
using BlogTeste.Models;
using BlogTeste.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace NovoBlog
{
    class Program
    {
        static void Main(string [] args)
        {
           using var context = new BlogDataContext();
           var user = new User
           {
                Name = "Jonathan Costa",
                Slug = "jonathancosta",
                Email = "jonathan@teste.com",
                Bio = "teste do aluno",
                Image = "https://teste.io",
                PasswordHash = "2233242",
           };

            // Create
           var category = new Category
           {
            Name = "Backend", 
            Slug = "backend"
           };

           var post = new Post
           {
            Author = user,
            Category = category,
            Body = "<p>Hello World</p>",
            Slug = "começando-com-ef",
            Summary = "Neste artigo vamos aprender sobre EF",
            Title = "Começando com EF",
            CreateDate = DateTime.Now,
            LastUpdateDate = DateTime.Now,
           };

        
            // READ
           context.Posts.Add(post);
           context.SaveChanges();
           var posts = context.Posts.AsNoTracking().Include(x => x.Author)
           .Include(x => x.Category).OrderByDescending(x => x.LastUpdateDate).ToList();
           foreach(var post1 in posts)
           Console.WriteLine($"{post1.Title} escrito por {post1.Author?.Name} em {post1.Category?.Name}");

        // UPDATE
        var post2 = context.Posts.Include(x => x.Author).Include(x => x.Category).OrderByDescending(x => x.LastUpdateDate).FirstOrDefault();
        post.Author.Name = "Teste";
        context.Posts.Update(post);
        context.SaveChanges();

        // REMOVE

        var post3 = context.Posts.Remove;
        context.Posts.Remove(post);
        context.SaveChanges();
        }

    }
}

