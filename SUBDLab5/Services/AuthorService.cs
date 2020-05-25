using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUBDLab5.Interface;
using SUBDLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace SUBDLab5.Services
{
    public class AuthorService : ILogic<Author>
    {
        private static NewsPortalDatabase db = Program.db;

        public void Create(Author model)
        {
            var author = db.Authors.FirstOrDefault(c => c.Name == model.Name);
            if (author != null)
            {
                throw new Exception("Такой автор уже есть");
            }
            db.Authors.Add(model);
            db.SaveChanges();
        }

        public void Delete(Author model)
        {
            var author = db.Authors.FirstOrDefault(c => c.Id == model.Id);
            if (author == null)
            {
                throw new Exception("Такого автора нет");
            }
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public void Update(Author model)
        {
            var author = db.Authors.FirstOrDefault(c => c.Id == model.Id);
            if (author == null)
            {
                throw new Exception("Такого автора нет");
            }
            author.Name = model.Name;
            db.SaveChanges();
        }

        public List<Author> Read()
        {
            return db.Authors.ToList();
        }

        public Author Get(int Id)
        {
            return db.Authors.FirstOrDefault(c => c.Id == Id);
        }

/*        public void Zapros_4()
        {
            var authors = db.Authors
                .Include(s => s.Material)
                .ToList()
                .OrderByDescending(s => s.Material.Sum(m => m.Sum))
                .GroupBy(s => s.Name_Organization)
                .Take(10)
                .Select(s => new
                {
                    NameOrg = s.Key,
                    sum = s.ToList().Sum(s => s.Material.Sum(m => m.Sum))
                });
            foreach (var c in authors)
            {
                Console.WriteLine(c.NameOrg + " " + c.sum);
            }
        }*/
    }
}