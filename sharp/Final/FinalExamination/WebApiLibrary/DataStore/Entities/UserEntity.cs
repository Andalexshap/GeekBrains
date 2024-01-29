﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLibrary.DataStore.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        [NotMapped]
        public string RoleToString {
            get => Role.Role.ToString();
            set => RoleToString = value;
        }

        public virtual RoleEntity Role { get; set; }
    }
}