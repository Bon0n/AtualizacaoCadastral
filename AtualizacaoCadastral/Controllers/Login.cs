using AtualizacaoCadastral.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AtualizacaoCadastral.Controllers
{
    public class Login : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public string MensagemLogin { get; set; }
        public Login(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            _contextAccessor.HttpContext.Session.SetString("username,", "");
            _contextAccessor.HttpContext.Session.SetInt32("id", 0);
            return View();
        }

        [Authorize]
        public IActionResult Logar(LoginModel login) 
        {
            string mensagemLogin = login.Logar();
            if(mensagemLogin == "Conectado!")
            {
                return RedirectToAction("Index", "Colaboradores");
            }
            _contextAccessor.HttpContext.Session.SetString("username,", login.Usuario);
            _contextAccessor.HttpContext.Session.SetInt32("id", 50);
            MensagemLogin = mensagemLogin;
            return RedirectToAction("LoginError", "Login");
        }

        public IActionResult LoginError() 
        {
            return View();
        }
    }
}
