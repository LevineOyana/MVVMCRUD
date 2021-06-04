using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WPFMVVM.Model
{
    public class Pessoa : BaseNotifyPropertyChanged, ICloneable
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetField(ref _id, value); }
        }

        private string _nome;
        [Required]
        public string Nome
        {
            get { return _nome; }
            set { SetField(ref _nome, value); }
        }

        private string _sobrenome;
        [Required]
        public string Sobrenome
        {
            get { return _sobrenome; }
            set { SetField(ref _sobrenome, value); }
        }

        private string _cpf;
        [Required, MaxLength(11)]
        public string CPF 
        { 
            get { return _cpf; }
            set { SetField(ref _cpf, value); }
        }

        private DateTime _datanascimento;
        [Required]
        public DateTime DataNascimento
        {
            get { return _datanascimento; }
            set { SetField(ref _datanascimento, value); }
        }

        private Genero _genero;
        public Genero Genero
        {
            get { return _genero; }
            set { SetField(ref _genero, value); }
        }

        private string _logradouro;
        [Required]
        public string Logradouro
        {
            get { return _logradouro; }
            set { SetField(ref _logradouro, value); }
        }

        private int _numero;
        [Required]
        public int Numero
        {
            get { return _numero; }
            set { SetField(ref _numero, value); }
        }

        private string _bairro;
        [Required]
        public string Bairro
        {
            get { return _bairro; }
            set { SetField(ref _bairro, value); }
        }

        private string _cidade;
        [Required]
        public string Cidade
        {
            get { return _cidade; }
            set { SetField(ref _cidade, value); }
        }

        private string _estado;
        [Required]
        public string Estado
        {
            get { return _estado; }
            set { SetField(ref _estado, value); }
        }

        private string _complemento;
        public string Complemento
        {
            get { return _complemento; }
            set { SetField(ref _complemento, value); }
        }

        private int _cep;
        [Required, MaxLength(8)]
        public int Cep
        {
            get { return _cep; }
            set { SetField(ref _cep, value); }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
