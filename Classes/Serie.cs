using System;

namespace DIOSeries
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Genero genero{ get; set;}
        private string titulo{get; set;}
        private string descricao{get; set;}
        private int ano{get; set;}
        
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.genero + Environment.NewLine;
            retorno += "Titulo: " + this.titulo + Environment.NewLine;
            retorno += "Descricao: " + this.descricao + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            return retorno;
        }
        public string GetTitulo()
        {
            return this.titulo;
        }
        public int GetId()
        {
            return this.id;
        }
    }
}