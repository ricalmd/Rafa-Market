using Microsoft.Owin.Security.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rafa_Market.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [StringLength(30, ErrorMessage = "O {0} deverá ter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Tem que inserir o {0}")]
        [Display(Name = "Primeiro Nome")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "O {0} deverá ter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Tem que inserir o {0}")]
        [Display(Name = "Apelido")]
        public string LastName { get; set; }

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "Tem que inserir um valor para o {0}")]
        public decimal Salary { get; set; }

        [Display(Name = "Percentagem Bónus")]
        [Range(0,20,ErrorMessage = "O valor da {0} deverá ser entre {1} e {2}")]
        public float BonusPercent { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        [Required(ErrorMessage = "Tem que inserir uma {0}")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Início")]
        [Required(ErrorMessage = "Tem que inserir uma {0}")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string URL { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "Tem que selecionar um{0}")]
        [Display(Name = "Tipo de Documento")]
        public int DocumentTypeID { get; set; }

        [NotMapped]
        public int Age 
        { 
            get 
            { 
                var myAge =  DateTime.Now.Year - DateOfBirth.Year;
                if(DateOfBirth > DateTime.Now.AddYears(-myAge))
                {
                    myAge--;
                }

                return myAge;
            }
        }

        public virtual DocumentType DocumentType { get; set; }
    }
}