using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breach_Of_Contract
{
    //public class that will contain variables that relate to the screen size and ratios required to draw correctly.
    class ScreenVariables
    {
        //Attributes that will change based on native resolution.
        public int screenHeight;
        public int screenWidth;
        public double screenRatio;

        //Constructor
        public ScreenVariables(int sh,int sw)
        {
            screenHeight = sh;
            screenWidth = sw;
            screenRatio = (double)screenWidth / (double)screenHeight;
        }
    }
}
