using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace La2Net5
{
    public class Figure: ICloneable
    {
        public UIElement Element { get; set; }

        public Figure()
        {
            //Elements = new List<UIElement>();
        }

       
        public Point RotationPoit(double angle, Point pointInput, Point point0)//old
        {
            double angle_radian = angle * Math.PI / 180;

            double x = (pointInput.X - point0.X) * Math.Cos(angle_radian) -
                (pointInput.Y - point0.Y) * Math.Sin(angle_radian) + point0.X;

            double y = (pointInput.X - point0.X) * Math.Sin(angle_radian) +
                (pointInput.Y - point0.Y) * Math.Cos(angle_radian) + point0.Y;

            var _out = new Point(x, y);

            Debug.WriteLine($"{pointInput.X} {pointInput.Y}  {_out.X} {_out.Y}");
            return _out;
        }

        public Point RotationPoitXY(double angle, double X, double Y, Point point0)
        {
            double angle_radian = angle * Math.PI / 180;

            double _x = (X - point0.X) * Math.Cos(angle_radian) -
                (Y - point0.Y) * Math.Sin(angle_radian) + point0.X;

            double _y = (X - point0.X) * Math.Sin(angle_radian) +
                       (Y - point0.Y) * Math.Cos(angle_radian) + point0.Y;

            var _out = new Point(_x, _y);

            Debug.WriteLine($"{X} {Y}  {_out.X} {_out.Y}");
            return _out;
        }
        public object Clone()
        {
            return new Figure
            {
                Element = this.Element
            };
        }
    }
}
