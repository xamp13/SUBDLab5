using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUBDLab5.Interface;
using SUBDLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace SUBDLab5.Services
{
    public class UsernameService : ILogic<Username>
    {
        private static NewsPortalDatabase db = Program.db;

        public void Create(Username model)
        {
            var username = db.Usernames.FirstOrDefault(c => c.Nickname == model.Nickname);
            if (username != null)
            {
                throw new Exception("Такой пользователь уже есть");
            }
            db.Usernames.Add(model);
            db.SaveChanges();
        }

        public void Delete(Username model)
        {
            var username = db.Usernames.FirstOrDefault(c => c.Id == model.Id);
            if (username == null)
            {
                throw new Exception("Такого пользователя нет");
            }
            db.Usernames.Remove(username);
            db.SaveChanges();
        }

        public void Update(Username model)
        {
            var username = db.Usernames.FirstOrDefault(c => c.Id == model.Id);
            if (username == null)
            {
                throw new Exception("Такого пользователя нет");
            }
            username.Nickname = model.Nickname;
            username.Password = model.Password;
            username.Email = model.Email;
            db.SaveChanges();
        }

        public List<Username> Read()
        {
            return db.Usernames.ToList();
        }

        public Username Get(int Id)
        {
            return db.Usernames.FirstOrDefault(c => c.Id == Id);
        }
    }
}
