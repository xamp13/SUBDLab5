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

       /* public void OrderClientName()
        {
            var client = db.Clients.OrderBy(c => c.Surname);
            foreach (Client c in client)
            {
                Console.WriteLine(c.Surname + " " + c.Name + " " + c.Adress + " " + c.Phone_Numper);
            }
        }

        public void Zapros_2()
        {
            var client = from p in db.Services
                         join c in db.Clients on p.ClientId equals c.Id
                         select new { c.Surname, c.Name, c.Adress, p.Name_Service };
            foreach (var c in client)
            {
                Console.WriteLine(c.Surname + " " + c.Name + " " + c.Adress + " " + c.Name_Service);
            }
        }

        public void zap_2()
        {
            var client = db.Services
                .Join(db.Clients,
                c => c.ClientId,
                s => s.Id,
                (c, s) => new
                {
                    s.Surname,
                    s.Name,
                    s.Adress,
                    c.Name_Service
                });
            foreach (var c in client)
            {
                Console.WriteLine(c.Surname + " " + c.Name + " " + c.Adress + " " + c.Name_Service);
            }
        }
        public void Zapros_3()
        {
            var client = from p in db.Materials
                         join c in db.Orders on p.OrderId equals c.Id
                         join r in db.Clients on c.ClientId equals r.Id
                         select new { r.Surname, r.Name, c.Adress, p.Name_Material, p.Sum };
            foreach (var c in client)
            {
                Console.WriteLine(c.Surname + " " + c.Name + " " + c.Adress + " " + c.Name_Material + " " + c.Sum);
            }
        }*/
    }
}