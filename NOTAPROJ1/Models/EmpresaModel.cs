using System.Collections.Generic;

public class EnderecoEmpresa
{
    public string CodigoPais { get; set; }
    public string DescricaoPais { get; set; }
    public string TipoLogradouro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string TipoBairro { get; set; }
    public string Bairro { get; set; }
    public string CodigoCidade { get; set; }
    public string DescricaoCidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
}

public class ConfigRPS
{
    public int Lote { get; set; }
    public List<NumeracaoRPS> Numeracao { get; set; }
}

public class NumeracaoRPS
{
    public int Numero { get; set; }
    public string Serie { get; set; }
    public int NumeracaoAtual { get; set; }
}

public class ConfigNFSe
{
    public ConfigRPS Rps { get; set; }
    public EmailConfig Email { get; set; }
    public bool Producao { get; set; }
    public bool EnvioLimitado { get; set; }
    public List<Integracao> Integracoes { get; set; }
}

public class ConfigDFe
{
    public bool PrimeiroNsu { get; set; }
}

public class ConfigNFe
{
    public ConfigDFe Dfe { get; set; }
    public EmailConfig Email { get; set; }
    public Integracao Integracoes { get; set; }
    public bool Producao { get; set; }
    public bool ImpressaoFcp { get; set; }
    public bool ImpressaoPartilha { get; set; }
    public string VersaoManual { get; set; }
    public string VersaoEsquema { get; set; }
    public List<NumeracaoDFe> Numeracao { get; set; }
}

public class ConfigNFCe
{
    public EmailConfig Email { get; set; }
    public Integracao Integracoes { get; set; }
    public bool Producao { get; set; }
    public string VersaoManual { get; set; }
    public string VersaoEsquema { get; set; }
    public List<NumeracaoDFe> Numeracao { get; set; }
}

public class EmailConfig
{
    public bool Envio { get; set; }
}

public class Integracao
{
    public bool Ativo { get; set; }
}

public class NumeracaoDFe
{
    public int Numero { get; set; }
}

public class EmpresaCadastro
{
    public EnderecoEmpresa Endereco { get; set; }
    public ConfigNFSe NFSe { get; set; }
    public ConfigNFe NFe { get; set; }
    public ConfigNFCe NFCe { get; set; }
    public bool IncentivoFiscal { get; set; }
    public bool IncentivadorCultural { get; set; }
    public string CPFCNPJ { get; set; }
    public string InscricaoMunicipal { get; set; }
    public string Certificado { get; set; }
    public string RazaoSocial { get; set; }
    public bool SimplesNacional { get; set; }
    public int RegimeTributario { get; set; }
    public int RegimeTributarioEspecial { get; set; }
}
