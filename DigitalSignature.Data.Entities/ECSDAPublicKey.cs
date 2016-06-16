using System.Numerics;

namespace DigitalSignature.Data.Entities
{
    public class ECDSAPublicKey
    {
        public BigInteger X { get; set; }

        public BigInteger Y { get; set; }
    }
}
