using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignature.ECDSACustom
{
    public class Curve
    {
        public BigInteger P { get; set; }

        public BigInteger A { get; set; }

        public BigInteger B { get; set; }

    }
}
