using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DigitalSignature.Data.Entities;

namespace DigitalSignature.ECDSACustom
{
    public class ECDSASigner
    {
        private CurveProvider curveProvider;

        private KeysProvider keysProvider;

        public ECDSASigner(CurveProvider curveProvider, KeysProvider keysProvider)
        {
            this.curveProvider = curveProvider;
            this.keysProvider = keysProvider;
        }

        public ECDSASignature GetSignature(string message)
        {
            var q = curveProvider.GetCurrentGPoint.Q;
            var shaService = SHA1.Create();

            var hash = shaService.ComputeHash(Encoding.Unicode.GetBytes(message));
            var hashNumber = new BigInteger(hash);

            var z = new BigInteger(hash.Take(q.ToByteArray().Length).ToArray());

            var rand = RNGCryptoServiceProvider.Create();
            while (true)
            {
                var kBytes = new byte[q.ToByteArray().Length];
                rand.GetNonZeroBytes(kBytes);

                var k = BigInteger.Remainder(new BigInteger(kBytes), q - 2) + 1;
                if (k.Sign == -1) k *= -1;
                var Q = new ECDSAPublicKey
                {
                    X = k * curveProvider.GetCurrentGPoint.Gx,
                    Y = k * curveProvider.GetCurrentGPoint.Gy
                };

                var r = BigInteger.Remainder(Q.X, q);
                if (r == 0)
                {
                    continue;
                }
                var s = (ExtendedEuclidFindInverseModularNumber(k%q, q) *
                        BigInteger.Remainder((z + r*keysProvider.GetPrivateKey()), q)) % q;

                return new ECDSASignature {R = r, S = s};
            }
            


        }

        private BigInteger ExtendedEuclidFindInverseModularNumber(BigInteger a, BigInteger modulo)
        {
            BigInteger b = modulo, x = BigInteger.Zero, d = 1;
            while (a.CompareTo(BigInteger.Zero) == 1)//a>0
            {
                BigInteger q = b / a;
                BigInteger y = a;
                a = b % a;
                b = y;
                y = d;
                d = x - (q * d);
                x = y;
            }
            x = x % modulo;
            if (x.CompareTo(BigInteger.Zero) == -1)//x<0
            {
                x = (x + modulo) % modulo;
            }
            return x;
        }
    }
}
