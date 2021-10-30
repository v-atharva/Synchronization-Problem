using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Operating_Car_Proje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        #region Private Members

        Road road1 = new Road();
        Road road2 = new Road();
        Road road3 = new Road();
        Number number = new Number();
        DispatcherTimer generatorT = new System.Windows.Threading.DispatcherTimer();
        DispatcherTimer moveCarT = new System.Windows.Threading.DispatcherTimer();
        DispatcherTimer refresh = new System.Windows.Threading.DispatcherTimer();


        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            generatorT.Tick += new EventHandler(generatorT_Tick);
            generatorT.Interval = new TimeSpan(0, 0, 0, 0, 333);

            refresh.Tick += new EventHandler(refreshUI_Tick);
            refresh.Interval = new TimeSpan(0, 0, 0, 0, 1);

            moveCarT.Tick += new EventHandler(moveCarT_Tick);
            moveCarT.Interval = new TimeSpan(0, 0, 0, 0, 500);

        }



        #endregion

        /// <summary>
        /// Timer Functions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveCarT_Tick(object sender, EventArgs e)
        {
            moveCar();
            LambConditions();
        }

        private void generatorT_Tick(object sender, EventArgs e)
        {
            generateCar();
        }

        private void refreshUI_Tick(object sender, EventArgs e)
        {

            graphmoveCar();
        }

        /// <summary>
        /// Handles button events...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            road1.lamb = true;
            road2.lamb = true;
            road3.lamb = false;
            setImages();
            moveCarT.Start();
            generatorT.Start();
            refresh.Start();




        }       
       
        public void setLamb(bool condition, int bnumber)
        {

            if (condition)
            {
                graphLamb(bnumber);

            }

            else
            {
                var x = number.getRandomNumber();
                graphLamb(x);

            }



        }

        public void LambConditions()
        {
            
            var x = true;

            if (road1.trafficFlow == 3 && road1.lamb == false)
            {
                if (road2.trafficFlow > road3.trafficFlow)
                {
                    setLamb(true, 3);

                }
                else
                    setLamb(true, 2);

                x = false;
            }

            if (road1.trafficFlow == 0 && road1.lamb == true)
            {
                setLamb(true, 1);
                x = false;

            }

            // Road 2

            if (road2.trafficFlow == 3 && road2.lamb == false)
            {
                if (road1.trafficFlow > road3.trafficFlow)
                {
                    setLamb(true, 3);
                }
                else
                    setLamb(true, 1);

                x = false;
            }

            if (road2.trafficFlow == 0 && road2.lamb == true)
            {
                setLamb(true, 2);
                x = false;
            }

            // Road 3

            if (road3.trafficFlow == 3 && road3.lamb == false)
            {
                if (road1.trafficFlow > road2.trafficFlow)
                {
                    setLamb(true, 2);
                }
                else
                    setLamb(true, 1);
                x = false;
            }

            if (road3.trafficFlow == 0 && road3.lamb == true)
            {
                setLamb(true, 3);
                x = false;
            }

            if (x)
            {
                setLamb(false, 0);

            }



        }
        
        /// <summary>
        /// Move Car variables set
        /// </summary>
        public void moveCar()
        {

            if (road1.bridgeCars > 0)
            {
                if (road1.isthereCar[3])
                {
                    road1.isthereCar[3] = false;
                    road1.bridgeCars--;
                }
                if (road1.isthereCar[2])
                {
                    road1.isthereCar[2] = false;
                    road1.isthereCar[3] = true;

                }
                if (road1.isthereCar[1])
                {
                    road1.isthereCar[1] = false;
                    road1.isthereCar[2] = true;

                }
                if (road1.isthereCar[0])
                {
                    road1.isthereCar[0] = false;
                    road1.isthereCar[1] = true;
                }

            }
           

            if (road3.bridgeCars > 0)
            {
                if (road3.isthereCar[3])
                {
                    road3.isthereCar[3] = false;
                    road3.bridgeCars--;
                }
                if (road3.isthereCar[2])
                {
                    road3.isthereCar[2] = false;
                    road3.isthereCar[3] = true;

                }
                if (road3.isthereCar[1])
                {
                    road3.isthereCar[1] = false;
                    road3.isthereCar[2] = true;

                }
                if (road3.isthereCar[0])
                {
                    road3.isthereCar[0] = false;
                    road3.isthereCar[1] = true;
                }

            }

            if (road2.bridgeCars > 0)
            {
                
                if (road2.isthereCar[7])
                {
                    road2.isthereCar[7] = false;
                    road2.bridgeCars--;
                }
                if (road2.isthereCar[6])
                {
                    road2.isthereCar[6] = false;
                    road2.isthereCar[7] = true;

                }
                if (road2.isthereCar[5])
                {
                    road2.isthereCar[5] = false;
                    road2.isthereCar[6] = true;

                }
                if (road2.isthereCar[4])
                {
                    road2.isthereCar[4] = false;
                    road2.isthereCar[5] = true;
                }

                if (road2.isthereCar[3])
                {
                    road2.isthereCar[3] = false;
                    road2.bridgeCars--;
                }
                if (road2.isthereCar[2])
                {
                    road2.isthereCar[2] = false;
                    road2.isthereCar[3] = true;

                }
                if (road2.isthereCar[1])
                {
                    road2.isthereCar[1] = false;
                    road2.isthereCar[2] = true;

                }
                if (road2.isthereCar[0])
                {
                    road2.isthereCar[0] = false;
                    road2.isthereCar[1] = true;
                }

            }

            // Lamb to end

            if (road1.lamb && road1.trafficFlow >= 1)
            {
                if (road1.image[1].Visibility == Visibility.Visible)
                {
                    road1.trafficFlow--;
                    road1.bridgeCars++;
                    road1.isthereCar[0] = true;
                    
                }
            }

           
            if (road3.lamb && road3.trafficFlow >= 1)
            {
                if (road3.image[1].Visibility == Visibility.Visible)
                {
                    road3.trafficFlow--;
                    road3.bridgeCars++;
                    road3.isthereCar[0] = true;
                }
            }
            if (road2.lamb && road2.trafficFlow >= 1)
            {
                if (road2.image[1].Visibility == Visibility.Visible)
                {
                    road2.trafficFlow--;
                    road2.bridgeCars++;
                    if (road1.lamb && road1.isthereCar[0])
                    {
                        road2.isthereCar[4] = true;

                    }
                    else if(road3.lamb && road3.isthereCar[0])
                    {
                        road2.isthereCar[0] = true;
                    }
                    else if (road1.carCount>road3.carCount)
                    {
                        road2.isthereCar[4] = true;
                    }
                    else
                        road2.isthereCar[0] = true;
                }

            }



        }

        /// <summary>
        /// Assign all car image to variable
        /// </summary>
        public void setImages()
        {
            //road 1
            road1.ui(Road1_1, 3);
            road1.ui(Road1_2, 2);
            road1.ui(Road1_3, 1);
            road1.ui(Road1_b1, 4);
            road1.ui(Road1_b2, 5);
            road1.ui(Road1_b3, 6);
            road1.ui(Road1_b4, 7);

            // road 2

            road2.ui(Road2_1, 3);
            road2.ui(Road2_2, 2);
            road2.ui(Road2_3, 1);
            road2.ui(Road2_btop1, 4);
            road2.ui(Road2_btop2, 5);
            road2.ui(Road2_btop3, 6);
            road2.ui(Road2_btop4, 7);
            road2.ui(Road2_bbot1, 8);
            road2.ui(Road2_bbot2, 9);
            road2.ui(Road2_bbot3, 10);
            road2.ui(Road2_bbot4, 11);

            //road 3
            road3.ui(Road3_1, 3);
            road3.ui(Road3_2, 2);
            road3.ui(Road3_3, 1);
            road3.ui(Road3_b1, 4);
            road3.ui(Road3_b2, 5);
            road3.ui(Road3_b3, 6);
            road3.ui(Road3_b4, 7);


        }
        /// <summary>
        /// Clear all images on grid
        /// </summary>
        public void clearImages()
        {
            for (int i = 1; i < 8; i++)
            {
                road1.image[i].Visibility = Visibility.Hidden;
                road3.image[i].Visibility = Visibility.Hidden;
            }
            for (int j = 1; j < 12; j++)
            {
                road2.image[j].Visibility = Visibility.Hidden;
            }

        }

        /// <summary>
        /// Generate a car condition: carCount is least then 20
        /// </summary>
        public int generateCar()
        {
            if ((road1.carCount & road2.carCount & road3.carCount) >19)
            {
                return 0;
            }
            AGAIN:
            var x = number.getRandomNumber();

            if (x == 1)
            {
                if (road1.carCount > 19)
                {
                    goto AGAIN;
                }
                road1.trafficFlow++;
                road1.carCount++;
                return 0;
            }

            if (x == 2)
            {
                if (road2.carCount > 19)
                {
                    goto AGAIN;
                }
                road2.trafficFlow++;
                road2.carCount++;
                return 0;
            }

            if (x == 3)
            {
                if (road3.carCount > 19)
                {
                    goto AGAIN;
                }
                road3.trafficFlow++;
                road3.carCount++;
                return 0;
            }
            return 0;

        }
        
        /// <summary>
        /// Show lamb on form and set value of lamb variable
        /// </summary>
        /// <param name="number"></param>
    
        public void graphLamb(int number)
        {

            if (number == 1)
            {
                Road1green.Visibility = Visibility.Hidden;
                Road1red.Visibility = Visibility.Visible;

                Road2green.Visibility = Visibility.Visible;
                Road2red.Visibility = Visibility.Hidden;

                Road3green.Visibility = Visibility.Visible;
                Road3red.Visibility = Visibility.Hidden;

                road1.lamb = false;
                road2.lamb = true;
                road3.lamb = true;

            }

            if (number == 2)
            {
                Road1green.Visibility = Visibility.Visible;
                Road1red.Visibility = Visibility.Hidden;

                Road2green.Visibility = Visibility.Hidden;
                Road2red.Visibility = Visibility.Visible;

                Road3green.Visibility = Visibility.Visible;
                Road3red.Visibility = Visibility.Hidden;

                road1.lamb = true;
                road2.lamb = false;
                road3.lamb = true;
            }

            if (number == 3)
            {
                Road1green.Visibility = Visibility.Visible;
                Road1red.Visibility = Visibility.Hidden;

                Road2green.Visibility = Visibility.Visible;
                Road2red.Visibility = Visibility.Hidden;

                Road3green.Visibility = Visibility.Hidden;
                Road3red.Visibility = Visibility.Visible;

                road1.lamb = true;
                road2.lamb = true;
                road3.lamb = false;

            }



        }
        /// <summary>
        /// Move Car graph set
        /// </summary>
        public void graphmoveCar()
        {
            clearImages();
            //  Begin to bridge

            if (road1.trafficFlow < 4)
            {
                for (var i = 1; i <= road1.trafficFlow; i++)
                {
                    road1.image[i].Visibility = Visibility.Visible;

                }


            }

            if (road2.trafficFlow < 4)
            {
                for (var i = 1; i <= road2.trafficFlow; i++)
                {
                    road2.image[i].Visibility = Visibility.Visible;

                }


            }

            if (road3.trafficFlow < 4)
            {
                for (var i = 1; i <= road3.trafficFlow; i++)
                {
                    road3.image[i].Visibility = Visibility.Visible;

                }


            }

            // Bridge to end

            for (int i = 0; i < 4; i++)
            {
                if (road1.isthereCar[i])
                {
                    road1.image[i+4].Visibility = Visibility.Visible;

                }

                if (road3.isthereCar[i])
                {
                    road3.image[i+4].Visibility = Visibility.Visible;
                }            
                

            }
            for (int j = 0; j < 8; j++)
            {
                if (road2.isthereCar[j])
                {
                    road2.image[j + 4].Visibility = Visibility.Visible;

                }
            }

            GreenCount.Text = road1.carCount.ToString();
            RedCount.Text = road2.carCount.ToString();
            BlueCount.Text = road3.carCount.ToString();
           

       

        }


    }
}
