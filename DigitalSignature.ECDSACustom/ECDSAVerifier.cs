using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using DigitalSignature.Data.Entities;

namespace DigitalSignature.ECDSACustom
{
    public class ECDSAVerifier
    {
        private CurveProvider curveProvider;

        public ECDSAVerifier(CurveProvider curveProvider)
        {
            this.curveProvider = curveProvider;
        }

        public ECDSACheckModel CheckSign(string message, ECDSASignature signature, ECDSAPublicKey qPublicKey)
        {
            var q = curveProvider.GetCurrentGPoint.Q;
            var shaService = SHA1.Create();

            var hash = shaService.ComputeHash(Encoding.Unicode.GetBytes(message));
            var hashNumber = new BigInteger(hash);

            var z = new BigInteger(hash.Take(q.ToByteArray().Length).ToArray());
            
            if (signature.R < 1 || signature.R > curveProvider.GetCurrentGPoint.Q - 1)
            {
                return new ECDSACheckModel
                {
                    MessageHash = hashNumber,
                    Sign = signature,
                    SignOk = false
                };
            }
            if (signature.S < 1 || signature.S > curveProvider.GetCurrentGPoint.Q - 1)
            {
                return new ECDSACheckModel
                {
                    MessageHash = hashNumber,
                    Sign = signature,
                    SignOk = false
                };
            }         

            var w = ExtendedEuclidFindInverseModularNumber(signature.S%q, q);

            var u1 = (z*w)%q;
            var u2 = (signature.R*w)%q;

            var curvePoint = new ECDSAPublicKey
            {
                X = u1*curveProvider.GetCurrentGPoint.Gx + u2*qPublicKey.X,
                Y = u1*curveProvider.GetCurrentGPoint.Gy + u2*qPublicKey.Y
            };

            return new ECDSACheckModel
            {
                MessageHash = hashNumber,
                Sign = signature,
                SignOk = signature.R == curvePoint.X%q
            };
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
