//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exercicio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Atuacao
    {
        public int id { get; set; }
        public int idAtor { get; set; }
        public int idFilme { get; set; }
    
        public virtual Ator Ator { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
