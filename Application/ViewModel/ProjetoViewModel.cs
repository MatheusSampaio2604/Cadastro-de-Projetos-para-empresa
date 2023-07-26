using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ProjetoViewModel
    {
        public ProjetoViewModel ()
        {
            HoraAbertura = DateTime.Now;
        }

        public DateTime HoraAbertura { get; set; }
        public int Id { get; set; }
        
        [DisplayName("Código")]
        [Required(ErrorMessage = "Necessário!")]
        public string Codigo { get; set; }
        
        [DisplayName("Descrição do Projeto")]
        [Required(ErrorMessage = "Insira um nome!")]
        [StringLength(100, MinimumLength = 5)]
        public string Nome { get; set; }
                
        [Required(ErrorMessage = "Insira um Tema!")]
        [DisplayName("Tema")]
        public int Id_Tema { get; set; }
        
        [Required(ErrorMessage = "Insira um Objetivo!")]
        [DisplayName("Objetivo")]
        public int Id_Objetivo { get; set; }
        
        [Required(ErrorMessage = "Insira um Cliente!")]
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        
        [Required(ErrorMessage = "Insira um Responsavel!")]
        [DisplayName("LTP")]
        public int ResponsavelId { get; set; }
        
        [DisplayName("Apoio")]
        public int[]? ApoioId { get; set; }
        
        [Required(ErrorMessage = "Insira um Financiamento!")]
        [DisplayName("Financiamento")]
        public int Id_Financiamento { get; set; }
        
        //public IFormFile? Anexo { get; set; }
        public string? Anexo { get; set; }

        public string? NomeCliente { get; set; }
        public string? NomeResponsavel { get; set; }
        public string[]? NomeApoio { get; set; }

        public virtual ICollection<AnexosViewModel>? Anexos { get; set; }
        public virtual TemaViewModel? Tema { get; set; }
        public virtual ObjetivoViewModel? Objetivo { get; set; }
        public virtual GerenciaGeralViewModel? GerenciaGeral { get; set; }
        public virtual FinanciamentoViewModel? Financiamento { get; set; }
        [ForeignKey("ClienteId")]
        public virtual UsuarioProjetoViewModel? Cliente { get; set; }
        [ForeignKey("ResponsavelId")]
        public virtual UsuarioProjetoViewModel? Responsavel { get; set; }
        [ForeignKey("ApoioId")]
        public virtual ICollection<UsuarioProjetoViewModel>? Apoio { get; set; }
    }
}
