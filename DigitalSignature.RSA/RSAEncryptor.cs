using System.Text;

namespace DigitalSignature.RSA
{
    using System.Numerics;

    public class RSAEncryptor
    {
        private KeysProvider keysProvider;

        public RSAEncryptor(KeysProvider keysProvider)
        {
            this.keysProvider = keysProvider;
        }

        public BigInteger Encrypt(string message, BigInteger e, BigInteger n)
        {
            var bytes = Encoding.Unicode.GetBytes(message);
            var messageNum = new BigInteger(bytes);

            var c = BigInteger.ModPow(messageNum, e, n);

            return c;
        }
    }
}
