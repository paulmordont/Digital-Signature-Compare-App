namespace DigitalSignature.RSA
{
    using System.IO;
    using System.Numerics;
    using System.Security.Cryptography;
    using System.Text;

    public class RSASigner
    {
        private KeysProvider keysProvider;

        public RSASigner(KeysProvider keysProvider)
        {
            this.keysProvider = keysProvider;
        }

        public BigInteger GetSignature(Stream stream)
        {
            var shaService = SHA512.Create();

            var hash = shaService.ComputeHash(stream);
            var hashNumber = new BigInteger(hash);
            var privateKey = keysProvider.GetPrivateKey();

            BigInteger sign = BigInteger.ModPow(hashNumber, privateKey.D, privateKey.N);

            return sign;
        }

        public BigInteger GetSignature(string message)
        {
            var shaService = SHA512.Create();

            var hash = shaService.ComputeHash(Encoding.Unicode.GetBytes(message));
            var hashNumber = new BigInteger(hash);
            var privateKey = keysProvider.GetPrivateKey();

            BigInteger sign = BigInteger.ModPow(hashNumber, privateKey.D, privateKey.N);

            return sign;
        }
    }
}
