using AtualizacaoCadastral.Data;
using AtualizacaoCadastral.Models;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace AtualizacaoCadastral.Controllers
{
    public class Colaboradores : Controller
    {
        private DirectoryEntry directoryEntry = AttAdContext.CreateDirectoryEntry();
        
        private DirectorySearcher directorySearcher = new DirectorySearcher();
        private PrincipalContext ad = new PrincipalContext(ContextType.Domain);
        public ActionResult Index()
        {
            var principalContext = AttAdContext.CreatePrincipalContext();
            var userPrincipal = new UserPrincipal(principalContext);

            var searcher = new PrincipalSearcher(userPrincipal);
            var colaboradores = new List<ColaboradorModel>();
            foreach(var result in searcher.FindAll())
            {
                directoryEntry = result.GetUnderlyingObject() as DirectoryEntry;
                var colaborador = new ColaboradorModel
                (
                    directoryEntry.Properties["givenName"].Value.ToString(),
                    directoryEntry.Properties["samAccountName"].Value.ToString(),
                    directoryEntry.Properties["emailAddress"].Value.ToString(),
                    directoryEntry.Properties["department"].Value.ToString(),
                    directoryEntry.Properties["company"].Value.ToString(),
                    "Teste"
                );
                colaboradores.Add(colaborador);
            }
            return View("test",colaboradores);
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
