using Fashe._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashe._1.ViewModels
{
    public class VmUser
    {
        public List<CustomUser> CustomUsers { get; set; }
        public Dictionary<string, string> UserRoles { get; set; }
    }
}
