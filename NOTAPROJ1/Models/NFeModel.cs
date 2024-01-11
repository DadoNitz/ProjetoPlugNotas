using System.Collections.Generic;

public class Endereco
{
    public string tipoLogradouro { get; set; }
    public string logradouro { get; set; }
    public string numero { get; set; }
    public string bairro { get; set; }
    public string codigoCidade { get; set; }
    public string descricaoCidade { get; set; }
    public string estado { get; set; }
    public string cep { get; set; }
}

public class ValorUnitario
{
    public double comercial { get; set; }
    public double tributavel { get; set; }
}

public class BaseCalculo
{
    public int modalidadeDeterminacao { get; set; }
    public double valor { get; set; }
    public double quantidade { get; set; }
}

public class ICMS
{
    public string origem { get; set; }
    public string cst { get; set; }
    public BaseCalculo baseCalculo { get; set; }
    public double aliquota { get; set; }
    public double valor { get; set; }
}

public class PIS
{
    public string cst { get; set; }
    public BaseCalculo baseCalculo { get; set; }
    public double aliquota { get; set; }
    public double valor { get; set; }
}

public class COFINS
{
    public string cst { get; set; }
    public BaseCalculo baseCalculo { get; set; }
    public double aliquota { get; set; }
    public double valor { get; set; }
}

public class Tributos
{
    public ICMS icms { get; set; }
    public PIS pis { get; set; }
    public COFINS cofins { get; set; }
}

public class Item
{
    public string codigo { get; set; }
    public string descricao { get; set; }
    public string ncm { get; set; }
    public string cest { get; set; }
    public string cfop { get; set; }
    public ValorUnitario valorUnitario { get; set; }
    public double valor { get; set; }
    public Tributos tributos { get; set; }
}

public class Pagamento
{
    public bool aVista { get; set; }
    public string meio { get; set; }
    public double valor { get; set; }
}

public class ResponsavelTecnico
{
    public string cpfCnpj { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public Telefone telefone { get; set; }
}

public class Telefone
{
    public string ddd { get; set; }
    public string numero { get; set; }
}

public class Root
{
    public string idIntegracao { get; set; }
    public bool presencial { get; set; }
    public bool consumidorFinal { get; set; }
    public string natureza { get; set; }
    public Emitente emitente { get; set; }
    public Destinatario destinatario { get; set; }
    public List<Item> itens { get; set; }
    public List<Pagamento> pagamentos { get; set; }
    public ResponsavelTecnico responsavelTecnico { get; set; }
}

public class Emitente
{
    public string cpfCnpj { get; set; }
}

public class Destinatario
{
    public string cpfCnpj { get; set; }
    public string razaoSocial { get; set; }
    public string email { get; set; }
    public Endereco endereco { get; set; }
}
