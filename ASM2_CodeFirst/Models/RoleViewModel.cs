using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASM2_CodeFirst.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() { }
        public string Id { get; set; }
        public string Name { get; set; }
        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }
    }
}