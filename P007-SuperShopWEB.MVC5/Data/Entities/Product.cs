using System;
using System.ComponentModel.DataAnnotations;


namespace P007_SuperShopWEB.MVC5.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        //[Key]
        //public int IdTest { get; set; } 
        // tenho de usar o dataAnnotation [Key] para gerar na BD a chave primária


        [Required]      // Obrigatório
        //Máximo 50 caracteres, a msg não aparece porque o java script não deixa preencher mais que 50 no formulário
        [MaxLength(50, ErrorMessage = "The field {0} can contains {1} characteres lenght")]
        public string Name { get; set; }


        // não usa este formato em modo de edição
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)] 
        public decimal Price { get; set; }


        [Display(Name = "Last Purchase")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy tt}", ApplyFormatInEditMode = false)]
        //tem ? = Datas opcionais
        public DateTime? LastPurchase { get; set; }


        [Display(Name = "Last Sale")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy tt}", ApplyFormatInEditMode = false)]
        //tem ? = Datas opcionais
        public DateTime? LastSale { get; set; }


        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }


        public User User { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://p007-supershopwebmvc5.azurewebsites.net/images/NoPhoto.png"
            : $"https://supershopmvc5.blob.core.windows.net/products/{ImageId}";

        //public string ImageFullPath => ImageId == Guid.Empty
        //    ? $"https://localhost:44313/images/NoPhoto.png"
        //    : $"https://localhost:44313/images/products/{ImageId}";

    }
}