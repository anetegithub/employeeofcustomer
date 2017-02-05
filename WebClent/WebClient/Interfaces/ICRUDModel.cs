using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Interfaces
{
    public interface ICRUDModel
    {
        int Id { get; set; }
        string UserId { get; set; }
        DateTime Created { get; set; }
        DateTime Changed { get; set; }
        bool Deleted { get; set; }
    }
}