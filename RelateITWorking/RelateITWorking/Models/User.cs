using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace RelateITWorking.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
    }
}
