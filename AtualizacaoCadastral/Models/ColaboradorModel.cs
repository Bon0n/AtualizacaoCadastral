namespace AtualizacaoCadastral.Models
{
    public class ColaboradorModel
    {
        public int Id { get; private set; }
        public object Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public object Empresa { get; private set; }
        public string Gerente { get; private set; }
        public string EstadoCivil { get; private set; }
        public string EnderecoCompleto { get; private set; }
        public string Cor { get; private set; }
        public string GrauEscolaridade { get; private set; }
        public string EmailPessoal { get; private set; }
        public string TelefonePessoal { get; private set; }
        public string NomeContatoEmergencia { get; private set; }
        public string TelefoneContatoEmergencia { get; private set; }
        public string GrauParentescoContatoEmergencia { get; private set; }
        public string TipoSanguineo { get; private set; }
        public string Alergias { get; private set; }
        public string TratamentosSaude { get; private set; }
        public string UsoMedicamentos { get; private set; }
        public string NomeDependente { get; private set; }
        public string GrauParentescoDependente { get; private set; }
        public string DataNascimentoParentesco { get; private set; }
        public string CpfParentesco { get; private set; }
        public object EmailCorporativo { get; private set; }
        public object Departamento { get; private set; }
        public object Cargo { get; private set; }

        

        public ColaboradorModel()
        {
            
        }
        public ColaboradorModel(object nome, object email, object empresa, object departamento, object cargo, string estadoCivil)
        {
            Nome = nome;
            EmailCorporativo = email;
            Empresa = empresa;
            Departamento = departamento;
            Cargo = cargo;
            EstadoCivil = estadoCivil;
        }
        
    }
}
