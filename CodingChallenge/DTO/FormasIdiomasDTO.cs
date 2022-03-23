#nullable disable

namespace CodingChallenge.DTO
{
    public partial class FormasIdiomasDTO
    {
        public int Id { get; set; }
        public int IdForma { get; set; }
        public string Forma { get; set; }
        public int IdIdioma { get; set; }
        public string Idioma { get; set; }
        public string Singular { get; set; }
        public string Plural { get; set; }
    }
}
