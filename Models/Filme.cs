using System.ComponentModel.DataAnnotations;
namespace Api_Produto.Models
{
    public class Filme
    {
       [Key]
        public int id{get;set;}

        [MinLength(1, ErrorMessage ="O titulo do filme deve conter no minimo 1 caracter")]
        [MaxLength(80, ErrorMessage ="O titulo do filme deve conter no maximo 80 caracteres")]
        public string Titulo{get;set;}


        [MinLength(20, ErrorMessage ="A descrição deve conter no minimo 20 caracteres")]
        [MaxLength(160, ErrorMessage ="A descrição deve conter no máximo 160 caracteres")]
        public string Descricao{get;set;}

        [Required(ErrorMessage ="Classificação obrigatória")]
        public string Classificacao{get;set;}

        
        [Required(ErrorMessage ="Genero obrigatório")]
        public string Genero{get;set;}



    }
}