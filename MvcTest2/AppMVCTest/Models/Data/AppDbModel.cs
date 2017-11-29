using System;
using System.Collections.Generic;
using System.Linq;

namespace AppMVCTest.Models.Data
{
    public static class AppDbModel
    {
        public static List<Users> GetAllUsers()
        {
            using (var db = new AppDbContext())
            {
                return db.Users.ToList();
            }
        }

        public static Users FindUser(string name)
        {
            using (var db = new AppDbContext())
            {
                var user = db.Users.SingleOrDefault(p => p.Name == name);
                return user;
            }
        }

        public static List<MessageToView> GetAllMsg()
        {
            using (var db = new AppDbContext())
            {
                var list = db.Messages.OrderByDescending(p=>p.PostTime).Select(p => new MessageToView
                {
                    Id = p.Id,
                    MsgText = p.MsgText,
                    NameId = p.NameId,
                    PostTime = p.PostTime,
                    UserName = p.Users.Name
                }).ToList();
                return list;
            }
        }

        public static int SetNewMsg(Messages msg)
        {
            using (var db = new AppDbContext())
            {
                db.Messages.Add(msg);
                db.SaveChanges();
                return msg.Id;
            }
        }

        public static int SetNewUser(Users user)
        {
            using (var db = new AppDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user.Id;
            }
        }
    }

    public class MessageToView
    {
        public int Id { get; set; }
        public DateTime PostTime { get; set; }
        public string MsgText { get; set; }
        public int NameId { get; set; }
        public string UserName { get; set; }
    }
}