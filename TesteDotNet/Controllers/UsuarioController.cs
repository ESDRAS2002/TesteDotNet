using Microsoft.AspNetCore.Mvc;
using TesteDotNet.Business.DTOs;
using TesteDotNet.Business.Services;
using TesteDotNet.Repository.Entities;

namespace TesteDotNet.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            var consulta = BuscarUsuarios();
            var consultaCpf = BuscarUsuarioPorCpfOuNome("89012345678", null);
            var consultaNome = BuscarUsuarioPorCpfOuNome(null, "Fernanda Lima");

            return View();
        }
        public ActionResult BuscarUsuarios()
        {
            List<UsuarioDTO>? usuarios = new(); // ABRIU UMA LISTA DE USUARIO DTO QUE PODE SER NULA, NEW() = RECEBER VALORES
            bool is_action = false;             //DEFINE VARIAVEL CONTROLER DO TIPO BOOLEANDO = VERDADEIRO OU FALSO
            string error = string.Empty;        //VARIAVEL VAI PEGAR O ERRO QUE VAI TRAZER DO C#
          
            try // SE DER CERTO
            {
                usuarios = _usuarioService.BuscarUsuarios(); // ELE VAI USUARIO SERVICE E BUSCA USUARIO
                is_action = true; // DEU CERTO
            }
            catch (Exception e) // SE DER ERRADO
            {
                error = e.Message;
            }
            return Json(new { usuarios, is_action, error }); // FRONTEND, JSON É UM FORMATO DE DADOS LEVE E DE FACIL LEITURA PARA TROCA DE INFORMAÇÕES ENTRE SISTEMAS PARA VIEW 
        }
        public ActionResult BuscarUsuarioPorCpfOuNome(string cpf, string nome)
        {
            bool is_action = false;
            string error = string.Empty;
            UsuarioDTO? usuarios = null;
            try
            {
                usuarios = _usuarioService.BuscarUsuarioPorCpfOuNome(cpf,nome);
                is_action = true;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return Json(new { usuarios, is_action, error });
        }
    }
}