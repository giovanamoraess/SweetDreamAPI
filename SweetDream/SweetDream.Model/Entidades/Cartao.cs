namespace SweetDream.Model.Entidades
{
    public class Cartao
    {
        public Bandeira bandeira { get; set; }
        public string numero { get; set; }
        public string CCV { get; set; }
        public string nome { get; set; }
        public string mesValidade { get; set; }
        public string anoValidade { get; set; }
    }
}