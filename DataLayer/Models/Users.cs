﻿namespace DataLayer.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{UserId}, {UserName}, {Password}";
        }
    }
}
