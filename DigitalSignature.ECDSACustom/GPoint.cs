using System.Numerics;

namespace DigitalSignature.ECDSACustom
{
    public class GPoint
    {
        public Curve Curve { get; set; }

        public BigInteger Gx { get; set; }

        public BigInteger Gy { get; set; }

        public BigInteger Q { get; set; }
    }
}
