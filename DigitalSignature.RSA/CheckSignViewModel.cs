using System.Numerics;

namespace DigitalSignature.RSA
{
    public class CheckSignViewModel
    {
        public BigInteger DecryptedSignHash { get; set; }

        public BigInteger SentMessageHash { get; set; }

        public BigInteger Sign { get; set; }

        public bool SignOk { get; set; }
    }
}
