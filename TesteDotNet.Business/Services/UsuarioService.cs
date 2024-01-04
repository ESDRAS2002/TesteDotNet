using TesteDotNet.Business.DTOs;
using TesteDotNet.Repository.Context;
using TesteDotNet.Repository.Entities.Usuario;

namespace TesteDotNet.Business.Services
{
    public class UsuarioService
    {
        private readonly UsuarioContext _usuarioContext; // _ É UMA CLASSE DEPENDENDE QUE HERDOU READONLY = SÓ LEITURA

        public UsuarioService(UsuarioContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }

        public List<UsuarioDTO>? BuscarUsuarios()
        {
            List<Usuario>? usuarios = _usuarioContext.usuarios.ToList();
            if (!usuarios.Any()) throw new Exception("Não foram encontrados usuários"); // ANY = QUALQUER USUARIO PODE PASSAR, THROW ESTOURA O ERRO E VAI PRO CATCH
            List<UsuarioDTO>? usuariosDTO = new();

            foreach (var usuario in usuarios)
            {
                UsuarioDTO usuarioDTO = new(usuario);
                usuariosDTO.Add(usuarioDTO);
            }
            return usuariosDTO;
        }
        public UsuarioDTO? BuscarUsuarioPorCpfOuNome(string cpf, string nome)
        {
            Usuario? usuario = _usuarioContext.usuarios.Where(e => e.cpf == cpf || e.usuario == nome).FirstOrDefault(); // VAI ENTRAR NO BANCO E NA TABELA E COM ESSE CPF VAI TRAZER O PRIMEIRO
            if (usuario == null) throw new Exception("Usuário não encontrado.");
            UsuarioDTO? usuarioDTO = new(usuario); // RECEBENDO OS DADOS DO BANCO PRO DTO
            return usuarioDTO;
        }
    }

}    //EXPRESSÃO LAMBDA = (E)= ENTIDADE/USUARIO / => (E). PROCURAR E TRAZER A COLUNA QUE QUEREMOS