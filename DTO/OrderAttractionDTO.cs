﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderAttractionDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int GlobalPrice { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> IsApproval { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }

        public AttractionDTO Attraction;

        public UserDTO User;

        public string UserName;

        public bool IsWritten;
    }
}
