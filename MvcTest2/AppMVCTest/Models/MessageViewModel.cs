using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using AppMVCTest.Models.Data;
using Microsoft.AspNet.Identity;

namespace AppMVCTest.Models
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and not more than {1} characters long.", MinimumLength = 4)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please fill in the Text field")]
        [Display(Name = "Text")]
        public string MsgText { get; set; }

        public int MsgId { get; set; }

        public readonly List<MessageToView> AllMessages = new List<MessageToView>();

        public MessageViewModel()
        {
            AllMessages = GetMessages();
        }

        public MessageViewModel(string sessName)
        {
            UserName = sessName;
            AllMessages = GetMessages();
        }

        public void AddNewMessage(UserModel user)
        {
            if(user != null)
            {
                MsgId = AppDbModel.SetNewMsg(new Messages
                {
                    MsgText = MsgText,
                    PostTime = DateTime.UtcNow,
                    NameId = user.UserId
                });
            }
        }

        

        private List<MessageToView> GetMessages()
        {
            return AppDbModel.GetAllMsg();
        }
    }
}