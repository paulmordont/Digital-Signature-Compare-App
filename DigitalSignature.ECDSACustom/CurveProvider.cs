using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignature.ECDSACustom
{
    public class CurveProvider
    {
        private GPoint current;

        private GPoint NistP192 = new GPoint
        {
            Curve =
                new Curve
                {
                    A = -3,
                    B =
                        BigInteger.Parse("64210519e59c80e70fa7e9ab72243049feb8deecc146b9b1",
                            NumberStyles.HexNumber),
                    P = BigInteger.Parse("6277101735386680763835789423207666416083908700390324961279")
                },
            Gx = BigInteger.Parse("188da80eb03090f67cbf20eb43a18800f4ff0afd82ff1012", NumberStyles.HexNumber),
            Gy = BigInteger.Parse("07192b95ffc8da78631011ed6b24cdd573f977a11e794811", NumberStyles.HexNumber),
            Q = BigInteger.Parse("6277101735386680763835789423176059013767194773182842284081", NumberStyles.Any)
        };

        public GPoint GetCurrentGPoint
        {
            get { return current; }
        }

        public CurveProvider()
        {
            current = NistP192;
        }

        public void SetNewGPoint(GPoint gPoint)
        {
            current = gPoint;
        }

        public void SetNewGPoint(int nistStandart)
        {
            switch (nistStandart)
            {
                case 192:
                    current = NistP192;
                    break;
                default:
                    current = NistP192;
                    break;
            }
        }
    }
}
