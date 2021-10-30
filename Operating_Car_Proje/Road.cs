using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Operating_Car_Proje
{
    internal class Road
    {        
        private int _carCount = 0;
        private int _trafficFlow = 0;
        private int _bridgeCars = 0;
        public bool lamb { get; set; }
        private bool[] _isthereCar = new bool[8];
        private UIElement[] _image = new UIElement[12]; 
        
             
        public int carCount
        {
            get { return this._carCount; }
            set { this._carCount = value; }
               
        }


        public int bridgeCars
        {
            get { return this._bridgeCars; }
            set { this._bridgeCars = value; }
        }


        public int trafficFlow
        {
            get { return this._trafficFlow; }
            set { this._trafficFlow = value; }
        }

        public bool[] isthereCar
        {
            get { return this._isthereCar; }
            set { this._isthereCar = value; }
        }

        public UIElement[] image
        {
            get { return this._image; }
                          
        }

        public UIElement[] ui(Image add, int index)
        {         
            _image[index] = add;
            return _image;       
        }

       

       
    }

    public class Number
    {
        private readonly Random _gRandom = new Random();
        //private readonly Random _bRandom = new Random();
        
        public int getRandomNumber()
        {
            return _gRandom.Next(1, 4);
        }

        //public bool getRandomBool()
        //{
        //    return _bRandom.Next(1, 3) == 2;
        //}
    }

   


}
