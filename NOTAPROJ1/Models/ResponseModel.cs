public class ResponseModel
{
    public Document[] documents { get; set; }
    public string message { get; set; }
    public string protocol { get; set; }
}

public class Document
{
    public string idIntegracao { get; set; }
    public string Emitente { get; set; }
    public string id { get; set; }
}