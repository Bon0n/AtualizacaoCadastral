using AtualizacaoCadastral.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtualizacaoCadastral.Controllers
{
    public class Login : Controller
    {
        public string MensagemLogin { get; private set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar(LoginModel login) 
        {
            string mensagemLogin = login.Logar();
            if(mensagemLogin == "Conectado!")
            {
                return RedirectToAction("Index", "Colaboradores");
            }
            MensagemLogin = mensagemLogin;
            return RedirectToAction("LoginError", "Login");
        }

        public IActionResult LoginError() 
        {
            return View();
        }
    }
}
