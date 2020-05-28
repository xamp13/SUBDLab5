using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUBDLab5.Interface;
using SUBDLab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace SUBDLab5.Services
{
    public class NewsService : ILogic<News>
    {
        private static NewsPortalDatabase db = Program.db;

        public void Create(News model)
        {
            var news = db.News.FirstOrDefault(c => c.Title == model.Title);
            if (news != null)
            {
                throw new Exception("Такая новость уже есть");
            }
            db.News.Add(model);
            db.SaveChanges();
        }

        public void Update(News model)
        {
            var news = db.News.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такой новости нет");
            }
            news.Title = model.Title;
            news.Date_of_News = model.Date_of_News;
            db.SaveChanges();
        }

        public void Delete(News model)
        {
            var news = db.News.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такой новости нет");
            }
            db.News.Remove(news);
            db.SaveChanges();
        }

        public List<News> Read()
        {
            return db.News.ToList();
        }

        public void ReadStranichno(int strok, int skipstrok)
        {
            var news = from n in db.News.Skip(skipstrok).Take(strok)
                       select new
                       {
                           n.Id,
                           n.Title,
                           n.Date_of_News
                       };
            foreach (var c in news)
            {
                Console.WriteLine(c.Title + " " + c.Date_of_News);
            }
        }

            public News Get(int Id)
        {
            return db.News.FirstOrDefault(c => c.Id == Id);
        }
    }
}