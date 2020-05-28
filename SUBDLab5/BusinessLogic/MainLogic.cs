using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using SUBDLab5.Models;
using SUBDLab5.Services;

namespace SUBDLab5.BusinessLogic
{
    class MainLogic
    {
        private readonly AuthorService authorService;
        private readonly CategoryService categoryService;
        private readonly CommentService commentService;
        private readonly NewsService newsService;
        private readonly UsernameService usernameService;
        private readonly SubscriptionService subscriptionService;

        public MainLogic(AuthorService authorService, CategoryService categoryService, CommentService commentService, NewsService newsService, UsernameService usernameService, SubscriptionService subscriptionService)
        {
            this.usernameService = usernameService;
            this.newsService = newsService;
            this.commentService = commentService;
            this.categoryService = categoryService;
            this.authorService = authorService;
            this.subscriptionService = subscriptionService;
        }

        public MainLogic(AuthorService authorService, CategoryService categoryService, CommentService commentService, NewsService newsService, SubscriptionService subscriptionService, UsernameService usernameService)
        {
            this.authorService = authorService;
            this.categoryService = categoryService;
            this.commentService = commentService;
            this.newsService = newsService;
            this.subscriptionService = subscriptionService;
            this.usernameService = usernameService;
        }

        public void CreateAuthor(string Name)
        {
            Author author = new Author()
            {
                Name = Name
            };
            authorService.Create(author);
        }

        public void CreateCategory(string Name)
        {
            Category category = new Category()
            {
                Name = Name
            };
            categoryService.Create(category);
        }

        public void CreateComment(string CommentText, int NewsId, int UsernameId)
        {
            Comment comment = new Comment()
            {
                Comment_Text = CommentText,
                NewsId = NewsId,
                UsernameId = UsernameId
            };
            commentService.Create(comment);
        }

        public void CreateNews(string Title, DateTime date, int AuthorId, int CategoryId)
        {
            News news = new News()
            {
                Title = Title,
                Date_of_News = date,
                AuthorId = AuthorId,
                CategoryId = CategoryId
            };
            newsService.Create(news);
        }

        public void CreateUsername(string Name, string Password, string Email)
        {
            Username username = new Username()
            {
                Nickname = Name,
                Password = Password,
                Email = Email
            };
            usernameService.Create(username);
        }

        public void CreateSubscription(int UsernameId, int CategoryId)
        {
            Subscription subscription = new Subscription()
            {
                UsernameId = UsernameId,
                CategoryId = CategoryId
            };
            subscriptionService.Create(subscription);
        }

        public void DeleteAuthor(int Id, string Name)
        {
            Author author = new Author()
            {
                Id = Id,
                Name = Name
            };
            authorService.Delete(author);
        }

        public void UpdateAuthor(int Id, string Name)
        {
            var list = authorService.Get(Id);
            Author author = new Author()
            {
                Id = list.Id,
                Name = Name
            };
            authorService.Update(author);
        }

        public void DeleteCategory(int Id, string Name)
        {
            Category category = new Category()
            {
                Id = Id,
                Name = Name
            };
            categoryService.Delete(category);
        }

        public void UpdateCategory(int Id, string Name)
        {
            Category category = new Category()
            {
                Id = Id,
                Name = Name
            };
            categoryService.Update(category);
        }

        public void DeleteComment(int Id, string CommentText, int UsernameId, int NewsId)
        {
            Comment comment = new Comment()
            {
                Id = Id,
                Comment_Text = CommentText,
                UsernameId = UsernameId,
                NewsId = NewsId
            };
            commentService.Delete(comment);
        }

        public void UpdateComment(int Id, string CommentText, int UsernameId, int NewsId)
        {
            Comment comment = new Comment()
            {
                Id = Id,
                Comment_Text = CommentText,
                UsernameId = UsernameId,
                NewsId = NewsId
            };
            commentService.Update(comment);
        }

        public void DeleteNews(int Id, string Title, DateTime date, int AuthorId, int CategoryId)
        {
            News news = new News()
            {
                Id = Id,
                Title = Title,
                Date_of_News = date,
                AuthorId = AuthorId,
                CategoryId = CategoryId
            };
            newsService.Delete(news);
        }

        public void UpdateNews(int Id, string Title, DateTime date, int AuthorId, int CategoryId)
        {
            News news = new News()
            {
                Id = Id,
                Title = Title,
                Date_of_News = date,
                AuthorId = AuthorId,
                CategoryId = CategoryId
            };
            newsService.Update(news);
        }

        public void DeleteUsername(int Id, string Name, string Password, string Email)
        {
            Username username = new Username()
            {
                Id = Id,
                Nickname = Name,
                Password = Password,
                Email = Email
            };
            usernameService.Delete(username);
        }

        public void UpdateUsername(int Id, string Name, string Password, string Email)
        {
            Username username = new Username()
            {
                Id = Id,
                Nickname = Name,
                Password = Password,
                Email = Email
            };
            usernameService.Update(username);
        }

        public void DeleteSubscription(int Id, int UsernameId, int CategoryId)
        {
            Subscription subscription = new Subscription()
            {
                Id = Id,
                UsernameId = UsernameId,
                CategoryId = CategoryId
            };
            subscriptionService.Delete(subscription);
        }

        public void UpdateSubscription(int Id, int UsernameId, int CategoryId)
        {
            Subscription subscription = new Subscription()
            {
                Id = Id,
                UsernameId = UsernameId,
                CategoryId = CategoryId
            };
            subscriptionService.Update(subscription);
        }

        public void ReadAuthor()
        {
            var list = authorService.Read();
            foreach (var p in list)
            {
                Console.WriteLine(p.Id + " " + p.Name);
            }
        }

        public void ReadCategory()
        {
            var list = categoryService.Read();
            foreach (var p in list)
            {
                Console.WriteLine(p.Name);
            }
        }

        public void ReadComment()
        {
            foreach (var p in commentService.Read())
            {
                Console.WriteLine(p.Comment_Text);
            }
        }

        public void ReadNews()
        {
            foreach (var p in newsService.Read())
            {
                Console.WriteLine(p.Title + " " + p.Date_of_News);
            }
        }

        public void ReadUsername()
        {
            foreach (var p in usernameService.Read())
            {
                Console.WriteLine(p.Nickname + " " + p.Password + " " + p.Email);
            }
        }


        public void OrderUsername()
        {
            categoryService.OrderUserName();
        }

        public void UsernameComment()
        {
            categoryService.zap_2();
        }

        public void UserNewsComment()
        {
            categoryService.Zapros_3();
        }

        public void AuthorNews()
        {
            authorService.Zapros_4();
        }
    }
}
