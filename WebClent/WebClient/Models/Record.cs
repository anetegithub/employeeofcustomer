using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebClient.Interfaces;

namespace WebClient.Models
{
    public abstract class Record : ICRUDModel
    {
        //[Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public bool Deleted { get; set; }
    }
}