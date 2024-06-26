using Project.Adopet.Console.Modelos;

namespace Project.Adopet.Console.Servicos.Arquivos;
public class PetsDoCsv : FileReaderCsv<Pet>
{
    public PetsDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

    public override Pet createLineFromCsv(string linha)
    {
        string[] propriedades = linha.Split(';');
        bool guidValido = Guid.TryParse(propriedades[0], out Guid petId);
        if (!guidValido) throw new ArgumentException("Invalid identifier.");

        bool tipoValido = int.TryParse(propriedades[2], out int tipoPet);
        if (!tipoValido) throw new ArgumentException("Invalid type.");

        TipoPet tipo = tipoPet == 1 ? TipoPet.Gato : TipoPet.Cachorro;

       return new Pet(petId, propriedades[1], tipo);
    }
}
