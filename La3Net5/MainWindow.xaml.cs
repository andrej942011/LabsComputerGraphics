using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace La3Net5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double[] x;
        private double[] y;
        private double[] z;

        private double[] U;
        private double[] V;


        public MainWindow()
        {
            InitializeComponent();

            x = new double[300];
            y = new double[300];
            z = new double[300];
            U = new double[300];
            V = new double[300];

            InitializeArray();
        }

        public void InitializeArray()
        {
            #region Задание прямых
            //Ребра
            x[1] = 8; y[1] = 12; z[1] = 0;
            x[2] = 0; y[2] = 12; z[2] = 0;
            x[3] = 0; y[3] = 0; z[3] = 0;
            x[4] = 8; y[4] = 0; z[4] = 0;
            x[5] = 8; y[5] = 4; z[5] = 0;
            x[6] = 8; y[6] = 4; z[6] = 6;
            x[7] = 8; y[7] = 8; z[7] = 6;
            x[8] = 8; y[8] = 8; z[8] = 0;
            x[9] = 8; y[9] = 4; z[9] = 0;
            x[10] = 8; y[10] = 12; z[10] = 0;
            x[11] = 8; y[11] = 12; z[11] = 9;
            x[12] = 0; y[12] = 12; z[12] = 9;
            x[13] = 0; y[13] = 12; z[13] = 0;
            x[14] = 0; y[14] = 0; z[14] = 0;
            x[15] = 0; y[15] = 0; z[15] = 9;
            x[16] = 8; y[16] = 0; z[16] = 9;
            x[17] = 8; y[17] = 0; z[17] = 0;
            x[18] = 8; y[18] = 0; z[18] = 9;
            x[19] = 8; y[19] = 12; z[19] = 9;
            x[20] = 0; y[20] = 12; z[20] = 9;
            x[21] = 0; y[21] = 0; z[21] = 9;
            x[22] = 4; y[22] = 0; z[22] = 14;
            x[23] = 8; y[23] = 0; z[23] = 9;
            x[24] = 4; y[24] = 0; z[24] = 14;
            x[25] = 4; y[25] = 12; z[25] = 14;
            x[26] = 0; y[26] = 12; z[26] = 9;
            x[27] = 8; y[27] = 12; z[27] = 9;
            x[28] = 4; y[28] = 12; z[28] = 14;
            x[29] = 0; y[29] = 12; z[29] = 9;
            x[30] = 0; y[30] = 12; z[30] = 0;
            x[31] = 0; y[31] = 0; z[31] = 0;

            //Окно1
            x[33] = 8; y[33] = 1; z[33] = 3;
            x[34] = 8; y[34] = 3; z[34] = 3;
            x[35] = 8; y[35] = 3; z[35] = 6;
            x[36] = 8; y[36] = 1; z[36] = 6;
            x[37] = 8; y[37] = 1; z[37] = 3;
            x[38] = 8; y[38] = 2; z[38] = 3;
            x[39] = 8; y[39] = 2; z[39] = 6;
            x[40] = 8; y[40] = 1; z[40] = 6;
            x[41] = 8; y[41] = 1; z[41] = 5;
            x[42] = 8; y[42] = 3; z[42] = 5;

            //Окно2
            x[43] = 8; y[43] = 9; z[43] = 3;
            x[44] = 8; y[44] = 11; z[44] = 3;
            x[45] = 8; y[45] = 11; z[45] = 6;
            x[46] = 8; y[46] = 9; z[46] = 6;
            x[47] = 8; y[47] = 9; z[47] = 3;
            x[48] = 8; y[48] = 10; z[48] = 3;
            x[49] = 8; y[49] = 10; z[49] = 6;
            x[50] = 8; y[50] = 9; z[50] = 6;
            x[51] = 8; y[51] = 9; z[51] = 5;
            x[52] = 8; y[52] = 11; z[52] = 5;

            //Окно3
            x[53] = 5; y[53] = 12; z[53] = 3;
            x[54] = 3; y[54] = 12; z[54] = 3;
            x[55] = 3; y[55] = 12; z[55] = 6;
            x[56] = 5; y[56] = 12; z[56] = 6;
            x[57] = 5; y[57] = 12; z[57] = 3;
            x[58] = 4; y[58] = 12; z[58] = 3;
            x[59] = 4; y[59] = 12; z[59] = 6;
            x[60] = 5; y[60] = 12; z[60] = 6;
            x[61] = 5; y[61] = 12; z[61] = 5;
            x[62] = 3; y[62] = 12; z[62] = 5;

            //Окно4
            x[63] = 5; y[63] = 0; z[63] = 3;
            x[64] = 3; y[64] = 0; z[64] = 3;
            x[65] = 3; y[65] = 0; z[65] = 6;
            x[66] = 5; y[66] = 0; z[66] = 6;
            x[67] = 5; y[67] = 0; z[67] = 3;
            x[68] = 4; y[68] = 0; z[68] = 3;
            x[69] = 4; y[69] = 0; z[69] = 6;
            x[70] = 5; y[70] = 0; z[70] = 6;
            x[71] = 5; y[71] = 0; z[71] = 5;
            x[72] = 3; y[72] = 0; z[72] = 5;

            #endregion

            #region Задание окружности
            double r1 = 0.5; double s = 0;
            for (int i = 104; i < 144; i++)
            {
                s = s + 0.157;
                z[i] = 14; z[i + 41] = 18;
                x[i] = (9 + Math.Cos(s) * r1); x[i + 41] = x[i];
                y[i] = (12 + Math.Sin(s) * r1); y[i + 41] = y[i];
            }
            #endregion
        }

        /// <summary>
        /// Рисование фигуры 3D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDraw3D_Click(object sender, RoutedEventArgs e)
        {
            

            #region Углы в радианах
            //var t = angle * Math.PI / 180;
            double k = Convert.ToDouble(K_TB.Text) * Math.PI / 180; //угол наклона
            double l = Convert.ToDouble(L_TB.Text) * Math.PI / 180;//0.523; //угол поворота

            for (int i = 1; i < 185; i++) //адаптация координат к экрану
            {

                var m= 0.1; var oy= 400.0; var ox= 200.0;
                U[i]= Math.Round(oy + (y[i] * Math.Cos(k) - x[i] * Math.Cos(l)) / m);
                V[i]= Math.Round(ox + (-z[i] + y[i] * Math.Sin(k) + x[i] * Math.Sin(l)) / m);
            }
            #endregion

            #region Рисование фигуры
            DrawFigure3D();
            #endregion

        }

        private void btDraw2D_Click(object sender, RoutedEventArgs e)
        {
            DrawFigure2D_с_верху();
            DrawFigure2D_с_торца();
            DrawFigure2D_с_боку();
        }

        private void btCleraCanvas(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
        }

        private void Line(double x1, double y1, double x2, double y2, int i1, int i2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            canvas1.Children.Add(line);
            Debug.WriteLine($"i1:{i1} x:{x1} y:{y1} || i2:{i2} x:{x2} y:{y2}");
        }

        private void DrawFigure3D()
        {
            for (int i = 1; i < 31; i++) //Рисование ребер
            {
                Line(U[i], V[i], U[i + 1], V[i + 1], i, i + 1);
            }

            for (int i = 33; i < 41; i++) //Рисование окна 1
            {
                Line(U[i], V[i], U[i + 1], V[i + 1], i, i + 1);
            }

            for (int i = 43; i < 51; i++) //Рисование окна 2
            {
                Line(U[i], V[i], U[i + 1], V[i + 1], i, i + 1);
            }

            for (int i = 53; i < 61; i++) //Рисование окна 3
            {
                Line(U[i], V[i], U[i + 1], V[i + 1], i, i + 1);
            }

            for (int i = 63; i < 71; i++) //Рисование окна 4
            {
                Line(U[i], V[i], U[i + 1], V[i + 1], i, i + 1);
            }

            for (int i = 52; i < 72; i++) //Рисование образующих целиндр
            {
                Line(U[2 * i], V[2 * i], U[2 * i + 41], V[2 * i + 41], 2 * i, 2 * i + 41);
            }

            for (int i = 104; i < 143; i++) //Рисование окружности 3
            {
                Line(U[i], V[i], U[i + 1], V[i + 1], i, i+1);
            }

            for (int i = 145; i < 184; i++) //Рисование окружности 3
            {
                Line(U[i], V[i], U[i + 1], V[i + 1], i, i+1);
            }
        }
        private void DrawFigure2D_с_боку()//(Y:Z)
        {
            var ox = 5.0; var oy = 5.0;
            var size = 10;

            for (int i = 1; i < 31; i++) //Рисование ребер
            {
                Line((y[i] + ox) * size, (z[i] + oy) * size, (y[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 33; i < 41; i++) //Рисование окна 1
            {
                Line((y[i] + ox) * size, (z[i] + oy) * size, (y[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 43; i < 51; i++) //Рисование окна 2
            {
                Line((y[i] + ox) * size, (z[i] + oy) * size, (y[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 53; i < 61; i++) //Рисование окна 3
            {
                Line((y[i] + ox) * size, (z[i] + oy) * size, (y[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 63; i < 71; i++) //Рисование окна 4
            {
                Line((y[i] + ox) * size, (z[i] + oy) * size, (y[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 104; i < 143; i++) //Рисование окружности 3
            {
                Line((y[i] + ox) * size, (z[i] + oy) * size, (y[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 145; i < 184; i++) //Рисование окружности 4
            {
                Line((y[i] + ox) * size, (z[i] + oy) * size, (y[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 52; i < 72; i++) //Рисование образующих целиндр
            {
                Line((y[2 * i] + ox) * size, (z[2 * i] + oy) * size, (y[2 * i + 41] + ox) * size, (z[2 * i + 41] + oy) * size, i * 2, 2 * i + 41);
                //Line(U[2 * i], V[2 * i], U[2 * i + 41], V[2 * i + 41], i);
            }
        }
        private void DrawFigure2D_с_торца() //(X:Z)
        {
            var ox = 20.0; var oy = 5.0;
            var size = 10;

            for (int i = 1; i < 31; i++) //Рисование ребер
            {
                Line((x[i] + ox) * size, (z[i] + oy) * size, (x[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }
            for (int i = 33; i < 41; i++) //Рисование окна 1
            {
                Line((x[i] + ox) * size, (z[i] + oy) * size, (x[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 43; i < 51; i++) //Рисование окна 2
            {
                Line((x[i] + ox) * size, (z[i] + oy) * size, (x[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 53; i < 61; i++) //Рисование окна 3
            {
                Line((x[i] + ox) * size, (z[i] + oy) * size, (x[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 63; i < 71; i++) //Рисование окна 4
            {
                Line((x[i] + ox) * size, (z[i] + oy) * size, (x[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            
            for (int i = 104; i < 143; i++) //Рисование окружности 3
            {
                Line((x[i] + ox) * size, (z[i] + oy) * size, (x[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 145; i < 184; i++) //Рисование окружности 4
            {
                Line((x[i] + ox) * size, (z[i] + oy) * size, (x[i + 1] + ox) * size, (z[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 52; i < 72; i++) //Рисование образующих целиндр
            {
                Line((x[2 * i] + ox) * size, (z[2 * i] + oy) * size, (x[2 * i + 41] + ox) * size, (z[2 * i + 41] + oy) * size, i * 2, 2 * i + 41);
                //Line(U[2 * i], V[2 * i], U[2 * i + 41], V[2 * i + 41], i);
            }
        }
        private void DrawFigure2D_с_верху() //(Y:X)
        {
            var ox = 5.0; var oy = 25.0;
            var size = 10;

            for (int i = 1; i < 31; i++) //Рисование ребер
            {
                Line((y[i] + ox) * size, (x[i] + oy) * size, (y[i + 1] + ox) * size, (x[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 33; i < 41; i++) //Рисование окна 1
            {
                Line((y[i] + ox) * size, (x[i] + oy) * size, (y[i + 1] + ox) * size, (x[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 43; i < 51; i++) //Рисование окна 2
            {
                Line((y[i] + ox) * size, (x[i] + oy) * size, (y[i + 1] + ox) * size, (x[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 53; i < 61; i++) //Рисование окна 3
            {
                Line((y[i] + ox) * size, (x[i] + oy) * size, (y[i + 1] + ox) * size, (x[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 63; i < 71; i++) //Рисование окна 4
            {
                Line((y[i] + ox) * size, (x[i] + oy) * size, (y[i + 1] + ox) * size, (x[i + 1] + oy) * size, i, i + 1);
            }

            ////for (int i = 52; i < 72; i++) //Рисование образующих целиндр
            ////{
            ////    Line((x[2 * i] + ox) * size, (y[2 * i] + oy) * size, (x[2 * i + 41] + ox) * size, (y[2 * i + 41] + oy) * size, i*2, 2 * i + 41);
            ////    //Line(U[2 * i], V[2 * i], U[2 * i + 41], V[2 * i + 41], i);
            ////}

            //баг с отображением!!
            for (int i = 104; i < 143; i++) //Рисование окружности 3
            {
                Line((y[i] + ox) * size, (x[i] + oy) * size, (y[i + 1] + ox) * size, (x[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 145; i < 184; i++) //Рисование окружности 4
            {
                Line((y[i] + ox) * size, (x[i] + oy) * size, (y[i + 1] + ox) * size, (x[i + 1] + oy) * size, i, i + 1);
            }

            for (int i = 52; i < 72; i++) //Рисование образующих целиндр (это не видно!)
            {
                Line((y[2 * i] + ox) * size, (x[2 * i] + oy) * size, (y[2 * i + 41] + ox) * size, (x[2 * i + 41] + oy) * size, i * 2, 2 * i + 41);
                //Line(U[2 * i], V[2 * i], U[2 * i + 41], V[2 * i + 41], i);
            }
        }
    }
}
