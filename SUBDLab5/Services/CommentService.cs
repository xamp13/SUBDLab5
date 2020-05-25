using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUBDLab5.Interface;
using SUBDLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace SUBDLab5.Services
{
    public class CommentService : ILogic<Comment>
    {
        private static NewsPortalDatabase db = Program.db;

        public void Create(Comment model)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Comment_Text == model.Comment_Text);
            if (comment != null)
            {
                throw new Exception("Такой комментарий уже есть");
            }
            db.Comments.Add(model);
            db.SaveChanges();
        }

        public void Delete(Comment model)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == model.Id);
            if (comment == null)
            {
                throw new Exception("Такого комментария нет");
            }
            db.Comments.Remove(comment);
            db.SaveChanges();
        }

        public void Update(Comment model)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == model.Id);
            if (comment == null)
            {
                throw new Exception("Такого комментария нет");
            }
            comment.Comment_Text = model.Comment_Text;
            db.SaveChanges();
        }

        public List<Comment> Read()
        {
            return db.Comments.ToList();
        }

        public Comment Get(int Id)
        {
            return db.Comments.FirstOrDefault(c => c.Id == Id);
        }
    }
}