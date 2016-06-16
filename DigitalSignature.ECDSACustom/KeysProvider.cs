using System.Numerics;
using System.Security.Cryptography;
using DigitalSignature.Data.Entities;

namespace DigitalSignature.ECDSACustom
{
    public class KeysProvider
    {
        private ECDSAPublicKey publicKey;

        private BigInteger xPrivate;

        private CurveProvider curveProvider;

        public KeysProvider(CurveProvider curveProvider)
        {
            this.curveProvider = curveProvider;
            GenerateAndSaveKeys();
        }

        public void GenerateAndSaveKeys()
        {
            var q = curveProvider.GetCurrentGPoint.Q;
            var rand = RNGCryptoServiceProvider.Create();
            var xBytes = new byte[q.ToByteArray().Length];
            rand.GetNonZeroBytes(xBytes);

            var x = BigInteger.Remainder(new BigInteger(xBytes), q - 2) + 1;
            if (x.Sign == -1) x *= -1;
            var Q = new ECDSAPublicKey
            {
                X = x*curveProvider.GetCurrentGPoint.Gx,
                Y = x*curveProvider.GetCurrentGPoint.Gy
            };

            this.publicKey = Q;
            this.xPrivate = x;
        }

        public ECDSAPublicKey GetPublicKey()
        {
            return publicKey;
        }

        public BigInteger GetPrivateKey()
        {
            return xPrivate;
        }

        public void Reset()
        {
            GenerateAndSaveKeys();
        }
    }
}
