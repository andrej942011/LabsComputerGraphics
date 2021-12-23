using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
using Point = System.Windows.Point;

namespace La4Net5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btBezierCurve_Click(object sender, RoutedEventArgs e)
        {
            List<BezierCurve> bezierCurves = new List<BezierCurve>();
            bezierCurves.Add(new BezierCurve(new[] { 4, 2, 2, 3.5 }, new[] { 0, 1, 3, 2.7 }));
            bezierCurves.Add(new BezierCurve(new[] { 3.5, 3, 3, 3.7 }, new[] { 2.7, 4.5, 7, 5 }));
            bezierCurves.Add(new BezierCurve(new[] { 3.7, 4, 4, 5 }, new[] { 5.0, 8, 8, 5 }));
            bezierCurves.Add(new BezierCurve(new[] { 5.0, 6, 6, 5 }, new[] { 5.0, 7, 5, 3 }));
            bezierCurves.Add(new BezierCurve(new[] { 5.0, 6, 6, 5 }, new[] { 3, 3.5, 1.5, 0 }));

            //Отрисовка точек
            foreach (var bezierCurve in bezierCurves)
            {
                PolylineDraw(bezierCurve.DataPoints.ToList(), 1);
                PolylineDraw(bezierCurve.DrawingPoints.ToList(), 0);
            }

        }

        /// <summary>
        /// Отрисовка кривой
        /// </summary>
        /// <param name="points"></param>
        /// <param name="color"></param>
        private void PolylineDraw(List<PointF> points, int color)
        {
            Polyline polyline = new Polyline();

            var pointsCollection = new PointCollection();
            foreach (var point in points)
            {
                pointsCollection.Add(new Point(point.X, point.Y));//   point);
            }
                

            polyline.Points = pointsCollection;
            if (color == 0)
            {
                polyline.Stroke = Brushes.Green;
            }
            else if (color == 1) //контур
            {
                foreach (var point in points)
                {
                    Marker marker = new Marker(point.X, point.Y);
                    canvas1.Children.Add(marker.Draw());
                }
                
                polyline.Stroke = Brushes.Red;
            }
                

            canvas1.Children.Add(polyline);
        }

        private void btCanvasClear_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
        }
    }
}
