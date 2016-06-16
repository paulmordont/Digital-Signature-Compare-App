using System;
using System.Windows.Forms;
using DigitalSignature.Data;
using DigitalSignature.ECDSACustom;
using DigitalSignature.RSA;
using KeysProvider = DigitalSignature.RSA.KeysProvider;

namespace DigitalSignature
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repo = new InMemoryKeysRepository();
            var keysProvider = new KeysProvider(repo);
            var signer = new RSASigner(keysProvider);
            var decryptor = new RSADecryptor(keysProvider);

            var curves = new CurveProvider();
            var keys2 = new ECDSACustom.KeysProvider(curves);
            var signer2 = new ECDSASigner(curves, keys2);
            var verifier = new ECDSAVerifier(curves);

            Application.Run(new DigitalSignatureMainWindow(decryptor, signer, keysProvider, keys2, curves, signer2, verifier));
        }
    }
}
