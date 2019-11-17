using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class TireEqualizer
    {
        public TirePressures TirePressures { get; set; }
        public double LeftFrontPressureDif { get; set; }
        public double RightFrontPressureDif { get; set; }
        public double LeftRearPressureDif { get; set; }
        public double RightRearPressureDif { get; set; }
        public TireEqualizer(TirePressures pressures)
        {
            TirePressures = pressures;
        }
        public TireEqualizer(TirePressures pressures,double lf, double rf, double lr, double rr)
        {
            TirePressures = pressures;
            LeftFrontPressureDif = lf;
            RightFrontPressureDif = rf;
            LeftRearPressureDif = lr;
            RightRearPressureDif = rr;
        }

        public TireEqualizer()
        {
            TirePressures = new TirePressures();
        }

        public TirePressures AutomaticEqualizer()
        {
            double newLeftFrontPressure = TirePressures.LeftFrontPressure < 1.5 ? 2.25 : (TirePressures.LeftFrontPressure > 3 ? 2.25 : TirePressures.LeftFrontPressure);
            double newRightFrontPressure = TirePressures.RightFrontPressure < 1.5 ? 2.25 : (TirePressures.RightFrontPressure > 3 ? 2.25 : TirePressures.RightFrontPressure);
            double newLeftRearPressure = TirePressures.LeftRearPressure < 1.5 ? 2.25 : (TirePressures.LeftRearPressure > 3 ? 2.25 : TirePressures.LeftRearPressure);
            double newRightRearPressure = TirePressures.RightRearPressure < 1.5 ? 2.25 : (TirePressures.RightRearPressure > 3 ? 2.25 : TirePressures.RightRearPressure);

            LeftFrontPressureDif = TirePressures.LeftFrontPressure - newLeftFrontPressure;
            RightFrontPressureDif = TirePressures.RightFrontPressure - newRightFrontPressure;
            LeftRearPressureDif = TirePressures.LeftRearPressure - newLeftRearPressure;
            RightRearPressureDif = TirePressures.RightRearPressure - newRightRearPressure;

            TirePressures.RightRearPressure = newRightRearPressure;
            TirePressures.LeftFrontPressure = newLeftFrontPressure;
            TirePressures.RightFrontPressure = newRightFrontPressure;
            TirePressures.LeftRearPressure = newLeftRearPressure;

            return TirePressures;
        }
    }
}
