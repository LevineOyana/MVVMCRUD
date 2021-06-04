using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WPFMVVM.Model
{
    public class Endereco : BaseNotifyPropertyChanged, ICloneable
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetField(ref _id, value); }
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

        private string _cep;
        [Required, MaxLength(8)]
        public string Cep
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
