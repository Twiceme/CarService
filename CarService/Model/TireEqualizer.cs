using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class TireEqualizer
    {
        private TirePressures newTirePreassures;
        public TirePressures TirePressures { get; set; }

        public TirePressures NewTirePressures
        {
            get
            {
                return this.newTirePreassures;               
            }
            set
            {
                if(value != this.newTirePreassures)
                    this.newTirePreassures = value;
            }
        }
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

        public TireEqualizer(ClientsData client, TirePressures newtirePressures)
        {
            this.TirePressures = client.TirePreasures;
            this.NewTirePressures = newtirePressures;
        }

        public TireEqualizer()
        {
            TirePressures = new TirePressures();
            this.NewTirePressures = new TirePressures();
        }

        public void AutomaticEqualizer()
        {
            double newLeftFrontPressure = TirePressures.LeftFrontPressure < 1.5 ? 2.25 : (TirePressures.LeftFrontPressure > 3 ? 2.25 : TirePressures.LeftFrontPressure);
            double newRightFrontPressure = TirePressures.RightFrontPressure < 1.5 ? 2.25 : (TirePressures.RightFrontPressure > 3 ? 2.25 : TirePressures.RightFrontPressure);
            double newLeftRearPressure = TirePressures.LeftRearPressure < 1.5 ? 2.25 : (TirePressures.LeftRearPressure > 3 ? 2.25 : TirePressures.LeftRearPressure);
            double newRightRearPressure = TirePressures.RightRearPressure < 1.5 ? 2.25 : (TirePressures.RightRearPressure > 3 ? 2.25 : TirePressures.RightRearPressure);

            LeftFrontPressureDif = TirePressures.LeftFrontPressure - newLeftFrontPressure;
            RightFrontPressureDif = TirePressures.RightFrontPressure - newRightFrontPressure;
            LeftRearPressureDif = TirePressures.LeftRearPressure - newLeftRearPressure;
            RightRearPressureDif = TirePressures.RightRearPressure - newRightRearPressure;

            NewTirePressures.RightRearPressure = newRightRearPressure;
            NewTirePressures.LeftFrontPressure = newLeftFrontPressure;
            NewTirePressures.RightFrontPressure = newRightFrontPressure;
            NewTirePressures.LeftRearPressure = newLeftRearPressure;         
        }

        public void SetImages()
        {
            if (NewTirePressures.LeftFrontPressure == 0)
                NewTirePressures.LeftFrontPicture = Properties.Resources.cartire;
            else if (NewTirePressures.LeftFrontPressure < 1.5)
                NewTirePressures.LeftFrontPicture = Properties.Resources.cartireblue;
            else if (NewTirePressures.LeftFrontPressure >= 1.5 && NewTirePressures.LeftFrontPressure <= 3)
                NewTirePressures.LeftFrontPicture = Properties.Resources.cartiregreen;
            else if (NewTirePressures.LeftFrontPressure > 3)
                NewTirePressures.LeftFrontPicture = Properties.Resources.cartirered;
            if (NewTirePressures.LeftRearPressure == 0)
                NewTirePressures.LeftRearPicture = Properties.Resources.cartire;
            else if (NewTirePressures.LeftRearPressure < 1.5)
                NewTirePressures.LeftRearPicture = Properties.Resources.cartireblue;
            else if (NewTirePressures.LeftRearPressure >= 1.5 && NewTirePressures.LeftRearPressure <= 3)
                NewTirePressures.LeftRearPicture = Properties.Resources.cartiregreen;
            else if (NewTirePressures.LeftRearPressure > 3)
                NewTirePressures.LeftRearPicture = Properties.Resources.cartirered;
            if (NewTirePressures.RightFrontPressure == 0)
                NewTirePressures.RightFrontPicture = Properties.Resources.cartire;
            else if (NewTirePressures.RightFrontPressure < 1.5)
                NewTirePressures.RightFrontPicture = Properties.Resources.cartireblue;
            else if (NewTirePressures.RightFrontPressure >= 1.5 && NewTirePressures.RightFrontPressure <= 3)
                NewTirePressures.RightFrontPicture = Properties.Resources.cartiregreen;
            else if (NewTirePressures.RightFrontPressure > 3)
                NewTirePressures.RightFrontPicture = Properties.Resources.cartirered;
            if (NewTirePressures.RightRearPressure == 0)
                NewTirePressures.RightRearPicture = Properties.Resources.cartire;
            else if (NewTirePressures.RightRearPressure < 1.5)
                NewTirePressures.RightRearPicture = Properties.Resources.cartireblue;
            else if (NewTirePressures.RightRearPressure >= 1.5 && NewTirePressures.RightRearPressure <= 3)
                NewTirePressures.RightRearPicture = Properties.Resources.cartiregreen;
            else if (NewTirePressures.RightRearPressure > 3)
                NewTirePressures.RightRearPicture = Properties.Resources.cartirered;

        }
    }
}
