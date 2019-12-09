using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class TirePressures
    {
        private double leftFrontPressure;
        private double rightFrontPressure;
        private double leftRearPressure;
        private double rightRearPressure;
        private Image leftFrontPicture;
        private Image rightFrontPicture;
        private Image leftRearPicture;
        private Image rightRearPicture;
        public double LeftFrontPressure 
        {
            get 
            {
                return this.leftFrontPressure;
            }
            set
            {
                if (value != this.leftFrontPressure)
                    this.leftFrontPressure = value;
               // SetImages();
            }
        }
        public double RightFrontPressure
        {
            get
            {
                return this.rightFrontPressure;
            }
            set
            {
                if (value != this.rightFrontPressure)
                    this.rightFrontPressure = value;
               // SetImages();
            }
        }
        public double LeftRearPressure
        {
            get
            {
                return this.leftRearPressure;
            }
            set
            {
                if (value != this.leftRearPressure)
                    this.leftRearPressure = value;
              //  SetImages();
            }
        }
        public double RightRearPressure
        {
            get
            {
                return this.rightRearPressure;
            }
            set
            {
                if (value != this.rightRearPressure)
                    this.rightRearPressure = value;
               // SetImages();
            }
        }
        public Image LeftFrontPicture
        {
            get 
            {
                return SetImage(LeftFrontPressure);
            }
            set
            {
                if (value != this.leftFrontPicture)
                    this.leftFrontPicture = value;
            }

        }
        public Image RightFrontPicture
        {
            get
            {
                return SetImage(RightFrontPressure);
            }
            set
            {
                if (value != this.rightFrontPicture)
                    this.rightFrontPicture = value;
            }

        }
        public Image LeftRearPicture
        {
            get
            {
                return SetImage(LeftRearPressure);
            }
            set
            {
                if (value != this.leftRearPicture)
                    this.leftRearPicture = value;
            }

        }

        public Image RightRearPicture
        {
            get
            {
                return SetImage(RightRearPressure);
            }
            set
            {
                if (value != this.rightRearPicture)
                    this.rightRearPicture = value;
            }

        }

        public Image SetImage(double Pressure)
        {
            if (Pressure <= 0)
                return Properties.Resources.cartire;
            else if (Pressure < 1.5)
                return Properties.Resources.cartireblue;
            else if (Pressure >= 1.5 && Pressure <= 3)
                return Properties.Resources.cartiregreen;
            else 
                return Properties.Resources.cartirered;
        }

    }
}
