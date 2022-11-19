namespace CrudWebAPIAspCore.Models;
public class FilmeInputModel
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public int AnoLancamento {get; set; }
    public string Resumo { get; set; } = null!;
}