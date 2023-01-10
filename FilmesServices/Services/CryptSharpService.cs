using CryptSharp;

namespace Filmes.Services.Services
{
    public static class CryptSharpService
    {
        public static string CryptPassword(string senha)
        {
            return Crypter.MD5.Crypt(senha);
        }

        public static bool CheckIfCryptedPasswordMatch(string senha, string hash)
        {
            return Crypter.CheckPassword(senha, hash);
        }

    }
}
