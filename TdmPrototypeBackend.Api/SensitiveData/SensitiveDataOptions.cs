using System.Security.Cryptography;
using System.Text;

namespace TdmPrototypeBackend.Api.SensitiveData;

public class SensitiveDataOptions
{
    public bool Include { get; set; }

    public Func<string, string> Getter { get; set; } = (input) => Sha256(input);

    static string Sha256(string input)
    {
        var crypt = new SHA256Managed();
        string hash = String.Empty;
        byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(input));
        foreach (byte theByte in crypto)
        {
            hash += theByte.ToString("x2");
        }
        return hash;
    }
}