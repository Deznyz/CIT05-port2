﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserRatings
    {
        public int UserId { get; set; }
        public int UserRating {  get; set; }
        public string TitleId { get; set; }
        public Users Users { get; set; }
        public MovieTitles MovieTitles { get; set; }


        public override string ToString()
        {
            return $"{UserId}, {UserRating}, {TitleId}";
        }
    }
}
