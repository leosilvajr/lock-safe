using LockSafe.Shared.Constantes;
using System.Security.Cryptography;
using System.Text;

namespace LockSafe.Application.Helpers
{
    public static class CriptografiaHelper
    {


        // Função para criptografar a senha
        public static string Criptografar(string senha)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetKey(); // Ajusta a chave para o tamanho adequado (32 bytes)
                aesAlg.IV = Encoding.UTF8.GetBytes(Key.ivBase);  // IV com 16 bytes

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(senha);
                    }
                    return Convert.ToBase64String(ms.ToArray()); // Retorna a senha criptografada em Base64
                }
            }
        }

        // Função para descriptografar a senha
        public static string Descriptografar(string senhaCriptografada)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetKey(); // Ajusta a chave para o tamanho adequado (32 bytes)
                aesAlg.IV = Encoding.UTF8.GetBytes(Key.ivBase);  // IV com 16 bytes

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(senhaCriptografada)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd(); // Retorna a senha descriptografada
                    }
                }
            }
        }

        // Ajuste da chave para o tamanho adequado (32 bytes)
        private static byte[] GetKey()
        {
            byte[] key = Encoding.UTF8.GetBytes(Key.chaveBase);
            if (key.Length < 32)
            {
                // Preenche com 0 até atingir 32 bytes
                Array.Resize(ref key, 32);
            }
            else if (key.Length > 32)
            {
                // Trunca para 32 bytes
                Array.Resize(ref key, 32);
            }
            return key;
        }
    }
}
