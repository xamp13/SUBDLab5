using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUBDLab5.Interface;
using SUBDLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace SUBDLab5.Services
{
    public class CategoryService : ILogic<Category>
    {
        private static NewsPortalDatabase db = Program.db;

        public void Create(Category model)
        {
            var category = db.Categories.FirstOrDefault(c => c.Name == model.Name);
            if (category != null)
            {
                throw new Exception("Такая категория уже есть");
            }
            db.Categories.Add(model);
            db.SaveChanges();
        }

        public void Delete(Category model)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == model.Id);
            if (category == null)
            {
                throw new Exception("Такой категории нет");
            }
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public void Update(Category model)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == model.Id);
            if (category == null)
            {
                throw new Exception("Такой категории нет");
            }
            category.Name = model.Name;
            db.SaveChanges();
        }

        public List<Category> Read()
        {
            return db.Categories.ToList();
        }

        public Category Get(int Id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == Id);
        }

       public void OrderUserName()
        {
            var username = db.Usernames.OrderBy(c => c.Nickname);
            foreach (Username c in username)
            {
                Console.WriteLine(c.Nickname + " " + c.Password + " " + c.Email);
            }
        }

/*        public void Zapros_2()
        {
            var client = from p in db.Services
                         join c in db.Clients on p.ClientId equals c.Id
                         select new { c.Surname, c.Name, c.Adress, p.Name_Service };
            foreach (var c in client)
            {
                Console.WriteLine(c.Surname + " " + c.Name + " " + c.Adress + " " + c.Name_Service);
            }
        }*/

        public void zap_2()
        {
            var username = db.Comments
                .Join(db.Usernames,
                c => c.UsernameId,
                s => s.Id,
                (c, s) => new
                {
                    s.Nickname,
                    s.Email,
                    c.Comment_Text
                });
            foreach (var c in username)
            {
                Console.WriteLine(c.Nickname + " " + c.Email + " " + c.Comment_Text);
            }
        }
        public void Zapros_3()
        {
            var client = from p in db.Comments
                         join c in db.Usernames on p.UsernameId equals c.Id
                         join r in db.News on p.NewsId equals r.Id
                         select new { r.Title, r.Date_of_News, c.Nickname, p.Comment_Text};
            foreach (var c in client)
            {
                Console.WriteLine(c.Title + " " + c.Date_of_News + " " + c.Nickname + " " + c.Comment_Text);
            }
        }
    }
}