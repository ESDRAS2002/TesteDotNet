using TesteDotNet.Repository.Entities.Usuario;

namespace TesteDotNet.Business.DTOs
{
    public class UsuarioDTO
    {
        public string Usuario { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public long? Telefone { get; set; }
        public long Celular { get; set; }
        public bool IsWhatsApp { get; set; }

        public UsuarioDTO(Usuario usuario) //ENTIDADE DO BANCO DE DADOS
        {
            Usuario = usuario.usuario; //USUARIO (DTO) RECEBE O VALOR DO BANCO DE DADOS
            DataNascimento = usuario.dataNascimento.ToString("dd/mm/yyyy");// CONVERSÃO E FORMATAÇÃO DE (DATETIME PARA STRING)
            CPF = usuario.cpf;
            Email = usuario.email;
            Telefone = usuario.telefone;
            Celular = usuario.celular;
            IsWhatsApp = usuario.isWhatsApp;
        }
    }
}

//OBJETO DE TRANSFERENCIA DE DADOS, A CAMADA WEB PRECISA DELE PRA PUXAR DO REPOSITORY
