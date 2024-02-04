using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.RSA
{
    internal class InverseElement
    {
        public static BigInteger FindInverseElement(BigInteger g, BigInteger x, BigInteger p)
        {
            BigInteger y = BigInteger.ModPow(g, x, p);
            return y;
        }

    }
}
