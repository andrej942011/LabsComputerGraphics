using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace La2Net5.Figures
{
    public class CircleF : Figure, IFigure
    {
        //private Point a;
        private double width;
        private double height;
        private double radius;

        private Point centerP; //центральная точка

        public CircleF(Point _a, double _width, double _height) : base()
        {
            width = _width;
            height = _height;
            centerP = _a;
            radius = 0;

            Element = CreateEllipse(width, height, centerP);
        }

        private Ellipse CreateEllipse(double _width, double _height, Point _centerP)
        {
            centerP = _centerP;

            Ellipse ellipse = new Ellipse();
            ellipse.Width = _width;
            ellipse.Height = _height;
            ellipse.Stroke = Brushes.Black;
            ellipse.RenderTransformOrigin = new Point(0.5, 0.5); //для отцентровки фигуры

            //double left = centerP.X - (_width/2);
            //double top = centerP.Y - (_height/2);
            ellipse.Margin = ThicknessEllipse(_centerP, _width, _height);//new Thickness(left, top, 0, 0);

            return ellipse;
        }

        private Thickness ThicknessEllipse(Point centerP, double width, double height)
        {
            var thickness = new Thickness();
            thickness.Left = centerP.X - (width / 2);
            thickness.Top = centerP.Y - (height / 2);
            thickness.Right = 0;
            thickness.Bottom = 0;

            return thickness;
        }

        public IFigure Moving_a_shape(int offset, Operation operation)
        {
            Ellipse ellipse = (Ellipse) Element;

            if (operation == La2Net5.Operation.Down)
            {
                centerP.Y += offset;
                //bottom += offset;
                //Debug.WriteLine($"{thickness.Bottom} {bottom}");

            }
            else if (operation == La2Net5.Operation.Top)
            {
                centerP.Y -= offset;
                //top += offset;
                //Debug.WriteLine(offset);
            }


            else if (operation == La2Net5.Operation.Left)
            {
                centerP.X -= offset;
                //left += offset;
            }


            else if (operation == La2Net5.Operation.Right)
            {
                centerP.X += offset;
                ////right += offset;
                //left -= offset;
                //Debug.WriteLine($"{thickness.Left} {left}");
            }

            double left = centerP.X - (ellipse.Width / 2);
            double top = centerP.Y - (ellipse.Height / 2);
            ellipse.Margin = new Thickness(left, top, 0, 0);

            //ellipse.Margin = thickness;
            Element = ellipse;

            return this;
        }

        public UIElement Drawing(double _radius)
        {
            radius = _radius;
            var ellipseCopy = (Ellipse) Element;

            Ellipse ellipse = new Ellipse();
            ellipse.Width = ellipseCopy.Width;
            ellipse.Height = ellipseCopy.Height;
            ellipse.Stroke = ellipseCopy.Stroke;
            ellipse.Margin = ellipseCopy.Margin;//new Thickness(Points[0].X - (width / 2), Points[0].Y - (height / 2), 0, 0);//внешние поля элемента

            //Для поворота
            ellipse.RenderTransformOrigin = new Point(0.5, 0.5); //для поворота отнасительно центра фигуры
            RotateTransform rotate = new RotateTransform(radius); //Points[0].X - (width / 2), Points[0].Y - (height / 2)
            ellipse.RenderTransform = rotate;

            //Debug.WriteLine($"Drawing Circle px:{Points[0].X} py:{Points[0].Y} w:{width} h:{height}");
            return ellipse;
        }

        public IFigure Rotation(double _radius, Point point0)
        {
            radius = _radius;

            //for (int i = 0; i < Points.Count; i++)
            //    Points[i] = RotationPoit(_radius, Points[i], point0);

            return this;
        }

        public IFigure ToScale(double scale, Point point0)
        {
            var ellipseCopy = (Ellipse)Element;
            ellipseCopy.Width *= scale;
            ellipseCopy.Height *= scale;
            Debug.WriteLine($"{point0.X} {point0.Y}");

            Point pointScale = new Point(centerP.X, centerP.Y);
            pointScale.X *= scale;
            pointScale.Y *= scale;
            ellipseCopy.Margin = ThicknessEllipse(pointScale, ellipseCopy.Width, ellipseCopy.Height);

            //Заменим на смещенную центральную точку для эллипса
            centerP = pointScale;//new Point(pointScale.X, pointScale.Y);

            Element = ellipseCopy;
            return this;
        }

        public IFigure CloneFigure()
        {
            var clonePoints = (Figure)Clone();
            CircleF figureReturne = new CircleF(centerP, width, height);

            figureReturne.Element = clonePoints.Element;

            return figureReturne;
        }

        
    }
}
