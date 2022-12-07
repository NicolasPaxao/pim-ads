namespace web_api.Models
{
    public class ReturnClienteModel
    {
        public ClienteModel? Cliente { get; set; }
        public List<RetornaApolicesModel>? Apolices { get; set; }
    }  
}
