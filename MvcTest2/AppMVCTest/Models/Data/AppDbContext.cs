using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppMVCTest.Models.Data
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Index("UserNameIndex", IsUnique = true)]
        [StringLength(25)]
        public string Name { get; set; }

        public virtual DbSet<Messages> Messages { get; set; }
    }

    [Table("Messages")]
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime PostTime { get; set; }
        public string MsgText { get; set; }

        [ForeignKey("Users")]
        public int NameId { get; set; }
        public virtual Users Users { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("appDbConnection") { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }
    }
}