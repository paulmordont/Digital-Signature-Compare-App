using System.Numerics;
using DigitalSignature.Data.Entities;
using DigitalSignature.Data.Interfaces;
using DigitalSignature.Helpers;

namespace DigitalSignature.RSA
{
    using System;

    public class KeysProvider
    {
        private IKeysRepository keysRepository;

        public KeysProvider()
        {
            GenerateAndSaveKeys();
        }

        public KeysProvider(IKeysRepository keysRepository)
        {
            this.keysRepository = keysRepository;
            GenerateAndSaveKeys();
        }

        public void ResetKeys()
        {
            GenerateAndSaveKeys();
        }

        public PublicKey GetPublicKey()
        {
            return keysRepository.GetPublicKey();
        }

        public PrivateKey GetPrivateKey()
        {
            return keysRepository.GetPrivateKey();
        }

        public void GenerateAndSaveKeys()
        {
            var primeGen = new PrimeNumbersGenerator();
            var p = primeGen.GetPrimePositiveNumber(128);
            var q = primeGen.GetPrimePositiveNumber(128);

            var n = p*q;
         
            var f = this.EulerFunction(p, q);

            BigInteger e = 0;
            for (int i = 3; i < 100; i++)
            {
                var stpn = Math.Pow(2, i);
                e = (int)Math.Pow(2, stpn) + 1;
                if (BigInteger.GreatestCommonDivisor(f, e) == 1)
                {
                    break;
                }
            }

            BigInteger d = this.ExtendedEuclidFindInverseModularNumber(e % f, f);

            PublicKey publicKey = new PublicKey { E = e, N = n };
            PrivateKey privateKey = new PrivateKey { D = d, N = n };

            this.keysRepository.SetPublicKey(publicKey);
            this.keysRepository.SetPrivateKey(privateKey);
        }

        private BigInteger EulerFunction(BigInteger p, BigInteger q)
        {
            var f = (p - 1)*(q - 1);
            return (f.Sign == -1) ? f *= -1 : f;
        }

        private BigInteger ExtendedEuclidFindInverseModularNumber(BigInteger a, BigInteger modulo)
        {
            BigInteger b = modulo, x = BigInteger.Zero, d = 1;
            while (a.CompareTo(BigInteger.Zero) == 1)//a>0
            {
                BigInteger q = b/a;
                BigInteger y = a;
                a = b%a;
                b = y;
                y = d;
                d = x-(q*d);
                x = y;
            }
            x = x%modulo;
            if (x.CompareTo(BigInteger.Zero) == -1)//x<0
            {
                x = (x+modulo)%modulo;
            }
            return x;
        }

    }
}
