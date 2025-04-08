﻿using System.ComponentModel.DataAnnotations;

namespace LarDePaz_API.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}