using System;
using System.ComponentModel.DataAnnotations;


namespace P007_SuperShopWEB.MVC5.Data.Entities
{
    public class Product
    {
        // com o Id cria logo o registo n BD como chave primária
        public int Id { get; set; }

        // tenho de usar o dataAnnotation [Key] para gerar na BD a chave primária
        //[Key]
        //public int IdTest { get; set; }

        public string Name { get; set; }

        // não usa este formato em modo de edição
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        // Mostra Image como nome no Campo
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Last Purchase")]
        public DateTime LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime LastSale { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        // não usa este formato em modo de edição
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }
    }
}
