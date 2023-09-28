using System.DirectoryServices.AccountManagement;

namespace AtualizacaoCadastral.Models
{
    public class LoginModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string MensagemLogin { get; private set; }

        public string Logar()
        {
            try
            {
                PrincipalContext principalContext = new PrincipalContext
                (
                ContextType.Domain,
                "networksecuritybr.local",
                "dc=networksecuritybr,dc=local",
                ContextOptions.Negotiate,
                Usuario,
                Senha
                );
                if (principalContext.ConnectedServer == "vm-adds-01.networksecuritybr.local" || 
                    principalContext.ConnectedServer == "vm-adds-02.networksecuritybr.local")
                {
                    MensagemLogin = "Conectado!";
                    return "Conectado!";
                }
            } 
            catch
            {
                MensagemLogin = "Credenciais inválidas!";

                return "Credenciais inválidas!";
            }
            MensagemLogin = "Não foi possível realizar o login";

            return "Não foi possível realizar o login";
        }
    }
}
