using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.Remoting.Messaging;
using DigitalSignature.ECDSACustom;

namespace DigitalSignature.TestConsoleApp
{
    using System.IO;

    using DigitalSignature.Data;
    using DigitalSignature.RSA;

    class Program
    {
        static void Main(string[] args)
        {
            //var a1 = BigInteger.Parse("64210519e59c80e70fa7e9ab72243049feb8deecc146b9b1", NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            var curveProvider = new CurveProvider();
            var keysProvider = new ECDSACustom.KeysProvider(curveProvider);
            var signer = new ECDSASigner(curveProvider, keysProvider);
            var verifier = new ECDSAVerifier(curveProvider);
            //var message = "Hello world";
            //var keysRepo = new InMemoryKeysRepository();
            //var keysProvider = new KeysProvider(keysRepo);
            //var decryptor = new RSADecryptor(keysProvider);
            //var encryptor = new RSAEncryptor(keysProvider);
            //var signer = new RSASigner(keysProvider);

            //var encryptedValue = encryptor.Encrypt(
            //    message,
            //    keysProvider.GetPublicKey().E,
            //    keysProvider.GetPublicKey().N);

            //var decryptedMessage = decryptor.Decrypt(encryptedValue);

            ////var sign = signer.GetSignature(message);
            ////Console.WriteLine(decryptor.CheckSign(keysProvider.GetPublicKey().E, keysProvider.GetPublicKey().N, message, sign));

            //Console.WriteLine(decryptedMessage);
            
            var message = "Hello world";
            var sign = signer.GetSignature(message);
            Console.WriteLine(sign.R);
            Console.WriteLine(sign.S);
            Console.WriteLine(verifier.CheckSign(message, sign, keysProvider.GetPublicKey()));
            
            Console.ReadLine();

        }
    }
}
