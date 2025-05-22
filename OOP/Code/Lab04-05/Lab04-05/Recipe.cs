using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Collections;

namespace Lab04_05
{
    public class Recipe
    {


        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [MinLength(3, ErrorMessage = "Некорректная длина названия")]
        
        public string name {  get; set; }
        [Required(ErrorMessage = "Количество порций обязательно")]
        [Range(1, 50, ErrorMessage = "Неверное количество порций")]
        public int PortionAmount { get; set; }
        [Required(ErrorMessage = "Время приготовления обязательно")]
        [Range(1, 1440, ErrorMessage = "Неверное время приготовления" )]
        public int Time { get; set;}
        [Required(ErrorMessage = "Описание обязательно")]
        public string Description { get; set; }



        public class EnsureMinimumElementsAttribute : ValidationAttribute
        {
            private readonly int _minElements;

            public EnsureMinimumElementsAttribute(int minElements)
            {
                _minElements = minElements;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var list = value as IList;
                if (list == null || list.Count < _minElements)
                {
                    return new ValidationResult(ErrorMessage);
                }
                return ValidationResult.Success;
            }
        }


        [EnsureMinimumElements(1, ErrorMessage = "Список ингредиентов не может быть пустым")]
        public List<string> ingredients { get; set; }

        [EnsureMinimumElements(1, ErrorMessage = "Инструкция приготовления не может быть пустой")]
        public List<string> steps { get; set; }

    }
}
