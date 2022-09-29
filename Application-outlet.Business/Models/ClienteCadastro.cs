using System;
using System.Collections.Generic;

namespace Application_outlet.Business.Models
{
    public  class ClienteCadastro
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Nascimento { get; set; } = null!;
        public string Idade { get; set; }
        public string Cpf { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}
