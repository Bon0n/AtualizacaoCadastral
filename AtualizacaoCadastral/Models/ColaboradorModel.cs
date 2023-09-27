namespace AtualizacaoCadastral.Models
{
    public class ColaboradorModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Empresa { get; private set; }
        public string Departamento { get; private set; }
        public string Cargo { get; private set; }

        public string EstadoCivil { get; private set; }

        public ColaboradorModel(string nome, string email, string empresa, string departamento, string cargo, string estadoCivil)
        {
            Nome = nome;
            Email = email;
            Empresa = empresa;
            Departamento = departamento;
            Cargo = cargo;
            EstadoCivil = estadoCivil;
        }
    }
}
