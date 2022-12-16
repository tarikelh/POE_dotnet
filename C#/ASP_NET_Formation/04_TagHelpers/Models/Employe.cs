﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace _04_TagHelpers.Models
{
    public class Employe
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public double Salary { get; set; }
        [DisplayName("Actif")]
        public bool IsActif { get; set; } = true;

        public string Email { get; set; } = String.Empty;
        [DisplayName("Departement Id")]
        public int DepartementId { get; set; }

        public EmployeType Type { get; set; } = EmployeType.STAGIAIRE;
    }


    public enum EmployeType
    {
        STAGIAIRE = 1,
        JUNIOR = 2,
        SENIOR  = 3
    }
}
