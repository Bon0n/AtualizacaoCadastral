using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace AtualizacaoCadastral.Data
{
    public class AttAdContext
    {
        private DirectoryEntry directoryEntry;
        public AttAdContext()
        {
            
        }
        public static DirectoryEntry CreateDirectoryEntry()
        {
            DirectoryEntry directoryEntry = new DirectoryEntry("networksecuritybr.local",username: "services.facilitador", "bed#DONe@Kp!");
            directoryEntry.AuthenticationType = AuthenticationTypes.Secure;
            return directoryEntry;
        }

        public static PrincipalContext CreatePrincipalContext()
        {
            PrincipalContext principalContext = new PrincipalContext
                (
                    ContextType.Domain, 
                    "networksecuritybr.local", 
                    "dc=networksecuritybr,dc=local", 
                    ContextOptions.Negotiate, 
                    "services.facilitador", 
                    "bed#DONe@Kp!"
                );
            return principalContext;
        }

        public static DirectorySearcher CreateDirectorySearcher()
        {
            DirectorySearcher directorySearcher = new DirectorySearcher();
            return directorySearcher;
        }
    }
}
