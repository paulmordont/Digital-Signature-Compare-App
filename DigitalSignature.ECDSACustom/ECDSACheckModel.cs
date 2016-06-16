using System.Numerics;

namespace DigitalSignature.ECDSACustom
{
    public class ECDSACheckModel
    {
        public bool SignOk { get; set; }

        public BigInteger MessageHash { get; set; }

        public ECDSASignature Sign { get; set; }
    }
}
