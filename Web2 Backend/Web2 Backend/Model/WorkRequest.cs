﻿using System;
namespace Web2_Backend.Model
{
    public class WorkRequest : Entity
    {
        public string Type { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Cause { get; set; }
        public string Note { get; set; }
        public bool Urgent { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }


    }
}
