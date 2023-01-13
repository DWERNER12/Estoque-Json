using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueJson.Models
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }

        public Produto()
        {

        }
        public Produto(int codigo, string nomeProduto, int quantidade)
        {
            Codigo = codigo;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
        }
        
    }
}