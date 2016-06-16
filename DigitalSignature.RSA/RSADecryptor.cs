namespace DigitalSignature.RSA
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Security.Cryptography;
    using System.Text;

    public class RSADecryptor
    {
        private KeysProvider keysProvider;

        public RSADecryptor(KeysProvider keysProvider)
        {
            this.keysProvider = keysProvider;
        }

        public bool CheckSign(BigInteger e, BigInteger n, Stream message, BigInteger sign)
        {
            var shaService = SHA512.Create();

            var hash = shaService.ComputeHash(message);
            var hashNumber = new BigInteger(hash);

            var mTest = BigInteger.ModPow(sign, e, n);

            return mTest == hashNumber;
        }

        public CheckSignViewModel CheckSign(BigInteger e, BigInteger n, string message, BigInteger sign)
        {
            var shaService = SHA512.Create();

            var hash = shaService.ComputeHash(Encoding.Unicode.GetBytes(message));
            var hashNumber = new BigInteger(hash);

            var mTest = BigInteger.ModPow(sign, e, n);

            return new CheckSignViewModel
            {
                DecryptedSignHash = mTest,
                SentMessageHash = hashNumber,
                Sign = sign,
                SignOk = hashNumber == mTest
            };
        }

        public string Decrypt(BigInteger messageToDecrypt)
        {
            var privateKey = keysProvider.GetPrivateKey();
            var decryptedNum = BigInteger.ModPow(messageToDecrypt, privateKey.D, privateKey.N);
            return Encoding.Unicode.GetString(decryptedNum.ToByteArray().Concat(new byte[] { 0x00 }).ToArray());
        }
    }
}
