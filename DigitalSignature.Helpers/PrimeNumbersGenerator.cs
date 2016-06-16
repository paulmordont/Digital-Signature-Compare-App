using System;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;

namespace DigitalSignature.Helpers
{
    public class PrimeNumbersGenerator
    {
        private byte[] primeNumbers = new byte[]
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
            31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
            73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
            127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
            233, 239, 241, 251
        };

        public BigInteger GetPrimePositiveNumber(int bytesCount)
        {
            bool notPrime = true;
            while (notPrime)
            {
                var bytes = new byte[bytesCount];
                var cryptoService = new RNGCryptoServiceProvider();
                cryptoService.GetNonZeroBytes(bytes);
                var number = new BigInteger(bytes);
                if (number.Sign == -1)
                {
                    number = BigInteger.Negate(number);
                }
                
                if (PossibilityForPrime(number))
                {
                    if (MillerRabinTest(number, 100, bytesCount))
                    {
                        return number;
                    }
                }
            }

            return BigInteger.Zero;
        }

        private bool PossibilityForPrime(BigInteger number)
        {
            foreach (var primeNumber in primeNumbers)
            {
                if (number % primeNumber == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool MillerRabinTest(BigInteger numberToTest, BigInteger roundCount, int bytesCount)
        {
            var m = numberToTest - 1;
            BigInteger t = 0;
            BigInteger a;
            int s = 0;
            //m - 1 = 2 ^ s * t
            bool tNotFound = true;
            while (tNotFound)
            {
                if (m % 2 == 0)
                {
                    s++;
                    m /= 2;
                }
                else
                {
                    t = m;
                    tNotFound = false;
                }
                
            } 

            for (BigInteger i = 0; i < roundCount; i++)
            {
                var bytes = new byte[bytesCount];
                var cryptoService = new RNGCryptoServiceProvider();
                cryptoService.GetNonZeroBytes(bytes);
                //a = random[2, m - 2]
                var temp = (new BigInteger(bytes))%(numberToTest - 2);
                a = (temp > 2) ? temp : 2;

                //x = a ^ t mod numberToTest
                var x = BigInteger.ModPow(a, t, numberToTest);
                if (x == 1 || x == numberToTest - 1)
                {
                    continue;
                }

                for (int j = 0; j < s - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, numberToTest);
                    if (x == 1)
                    {
                        return false;
                    }
                    if (x == numberToTest - 1)
                    {
                        break;
                    }
                }

                if (x != numberToTest - 1)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// c = b ^ e mod m
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private BigInteger ModularExponentiation(BigInteger b, BigInteger e, BigInteger m)
        {
            BigInteger eCurrent = 0;
            BigInteger c = 1;
            while (eCurrent < e)
            {
                ++eCurrent;
                c = (b*c)%m;
            }

            return c;
        }
    }
}
