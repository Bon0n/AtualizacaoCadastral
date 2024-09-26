using AtualizacaoCadastral.Data;
using AtualizacaoCadastral.Models;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace AtualizacaoCadastral.Controllers
{
    public class Colaboradores : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public Colaboradores(IHttpContextAccessor contextAccessor)
        {

            _contextAccessor = contextAccessor;

        }
        private DirectoryEntry directoryEntry = AttAdContext.CreateDirectoryEntry();
        public ActionResult Index()
        {
            string username = _contextAccessor.HttpContext.Session.GetString("username");
            if(string.IsNullOrWhiteSpace(username))
            {
                return RedirectToAction("Index", "Login");
            }
#pragma warning disable CA1416 // Validate platform compatibility
            PrincipalContext context = new PrincipalContext
            (
                ContextType.Domain,
                "networksecuritybr.local",
                "dc=networksecuritybr,dc=local",
                ContextOptions.Negotiate,
                "user",
                "senha"
            );
#pragma warning restore CA1416 // Validate platform compatibility
            var userPrincipal = new UserPrincipal(context);
            var searcher = new PrincipalSearcher(userPrincipal);

            var colaboradores = new List<ColaboradorModel>();
            ColaboradorModel colaborador;
            var query = searcher.FindAll();
            
            foreach(var result in query)
            {
                directoryEntry = result.GetUnderlyingObject() as DirectoryEntry;
                object nome;
                string usuario = "teste";
                string email = "teste";
                string departamento = "teste";
                object empresa;
                string cargo = "teste";
                System.Diagnostics.Debug.WriteLine(directoryEntry.Properties["givenName"].Value);

                nome = directoryEntry.Properties["givenName"].Value;
                empresa = directoryEntry.Properties["company"].Value;

                /*
                if (directoryEntry.Properties["givenName"].Value.Equals == null)
                {
                    nome = directoryEntry.Properties["givenName"].Value.ToString();
                }
                else
                {
                    nome = "Nome";
                }
                
                if (!string.IsNullOrWhiteSpace(directoryEntry.Properties["samAccountName"].Value.ToString()))
                {
                    usuario = directoryEntry.Properties["samAccountName"].Value.ToString();
                }
                else
                {
                    usuario = "Usuario";
                }
                if (!string.IsNullOrWhiteSpace(directoryEntry.Properties["emailAddress"].Value.ToString()))
                {
                    email = directoryEntry.Properties["emailAddress"].Value.ToString();
                }
                else
                {
                    email = "Email";
                }
                if (!string.IsNullOrWhiteSpace(directoryEntry.Properties["department"].Value.ToString()))
                {
                    departamento = directoryEntry.Properties["department"].Value.ToString();
                }
                else
                {
                    departamento = "Departamento";
                }
                if (!string.IsNullOrWhiteSpace(directoryEntry.Properties["company"].Value.ToString()))
                {
                    empresa = directoryEntry.Properties["company"].Value.ToString();
                }
                else
                {
                    empresa = "Empresa";
                }
                */
                colaborador = new ColaboradorModel
                (
                    directoryEntry.Properties["displayName"].Value,
                    directoryEntry.Properties["emailAddress"].Value,
                    directoryEntry.Properties["company"].Value,
                    directoryEntry.Properties["department"].Value,
                    directoryEntry.Properties["samAccountName"].Value,
                    ""
                );
                colaboradores.Add(colaborador);
            }
            return View(colaboradores);
        }

        public IActionResult Criar()
        {
            return View();
            
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Apagar()
        {
            return View();
        }
    }
}
