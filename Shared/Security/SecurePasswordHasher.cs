using System.Security.Cryptography;

namespace FacilitaCondo.Shared.Security
{
    public static class SecurePasswordHasher
    {
        private const int SaltSize = 16; // Tamanho do salt em bytes
        private const int HashSize = 20; // Tamanho do hash em bytes
        private const int Iterations = 10000; // Número de iterações do PBKDF2

        // Método para gerar um hash seguro de senha
        public static string Hash(string password)
        {
            // Gera um salt aleatório
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            // Cria um hash da senha usando PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Combina salt + hash em uma única string
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Converte para uma string Base64 para armazenamento
            string base64Hash = Convert.ToBase64String(hashBytes);

            // Retorna o hash senha-salt em formato string
            return base64Hash;
        }

        // Método para verificar se a senha fornecida corresponde ao hash
        public static bool Verify(string password, string hashedPassword)
        {
            // Converte o hash armazenado de volta em bytes
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Extrai salt do hash
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Calcula o hash da senha fornecida com o mesmo salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Compara os hashes
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false; // Senha incorreta
                }
            }
            return true; // Senha correta
        }
    }
}
