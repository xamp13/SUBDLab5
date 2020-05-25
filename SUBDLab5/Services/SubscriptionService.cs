using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUBDLab5.Interface;
using SUBDLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace SUBDLab5.Services
{
    public class SubscriptionService : ILogic<Subscription>
    {
        private static NewsPortalDatabase db = Program.db;

        public void Create(Subscription model)
        {
            var subscription = db.Subscriptions.FirstOrDefault(c => c.Id == model.Id);
            if (subscription != null)
            {
                throw new Exception("Такая подписка уже есть");
            }
            db.Subscriptions.Add(model);
            db.SaveChanges();
        }

        public void Delete(Subscription model)
        {
            var subscription = db.Subscriptions.FirstOrDefault(c => c.Id == model.Id);
            if (subscription == null)
            {
                throw new Exception("Такой подписки нет");
            }
            db.Subscriptions.Remove(subscription);
            db.SaveChanges();
        }

        public void Update(Subscription model)
        {
            var subscription = db.Subscriptions.FirstOrDefault(c => c.Id == model.Id);
            if (subscription == null)
            {
                throw new Exception("Такой подписки нет");
            }
            subscription.Id = model.Id;
            db.SaveChanges();
        }

        public List<Subscription> Read()
        {
            return db.Subscriptions.ToList();
        }

        public Subscription Get(int Id)
        {
            return db.Subscriptions.FirstOrDefault(c => c.Id == Id);
        }
    }
}