using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model.TokenApproach
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
