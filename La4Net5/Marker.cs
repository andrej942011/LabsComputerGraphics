using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace La4Net5
{
    public class Marker
    {
        /// <summary>
        /// Радис маркера
        /// </summary>
        private const int Radius = 10;


        /// <summary>
        /// Ограничивающий прямоугольник
        /// </summary>
        private RectangleF rectangle;

        /// <summary>
        /// Положение маркера
        /// </summary>
        public PointF Location
        {
            get { return new PointF(rectangle.X + Radius / 2f, rectangle.Y + Radius / 2f); }
        }

        /// <summary>
        /// Создание нового маркера
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Marker(float x, float y)
        {
            rectangle = new RectangleF(x - Radius / 2f, y - Radius / 2f, Radius, Radius);
        }

        /// <summary>
        /// Для отрисовки маркера
        /// </summary>
        public Ellipse Draw()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 8;
            ellipse.Height = 8;
            ellipse.Stroke = Brushes.Black;
            ellipse.Margin = new Thickness(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            return ellipse;
        }
    }
}
