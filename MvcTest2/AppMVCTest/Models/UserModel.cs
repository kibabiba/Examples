using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppMVCTest.Models.Data;

namespace AppMVCTest.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsExist { get; set; }

        public UserModel(string name)
        {
            UserName = name;
            IsExist = IsUserExist();
        }

        private bool IsUserExist()
        {
            var user = AppDbModel.FindUser(UserName);
            if (user != null)
                UserId = user.Id;
            return user != null;
        }

        public void SaveNewUser()
        {
            UserId = AppDbModel.SetNewUser(new Users() {Name = UserName});
        }
    }
}