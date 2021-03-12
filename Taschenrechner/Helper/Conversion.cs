using System;

namespace Taschenrechner.Helper
{
    public class Conversion
    {
        double result = 0;

        public double degreeToRadiant(double d)
        {
            result = d * (Math.PI / 180);

            return result;
        }
    }
}
