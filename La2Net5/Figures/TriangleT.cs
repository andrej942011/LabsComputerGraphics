using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using La2Net5.Figures.TransformFigure;

namespace La2Net5.Figures
{
    public class TriangleT : Figure, IFigure
    {
        //private Point a;
        //private Point b;
        //private Point c;

        public TriangleT()
        {
            
        }
        public TriangleT(int x1, int y1, int x2, int y2, int x3, int y3): base()
        {
            //var a = new Point(x1, y1);
            //var b = new Point(x2, y2);
            //var c = new Point(x3, y3);

            //AddPoint(a);
            //AddPoint(b);
            //AddPoint(c);

            Element = CreatePolygon(x1, y1, x2, y2, x3, y3);
            //Elements.Add(CreatePolygon(x1, y1, x2, y2, x3, y3));
        }

        private Polygon CreatePolygon(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Polygon poligon = new Polygon();
            poligon.Stroke = Brushes.Red;
            poligon.Points.Add(new Point(x1, y1));
            poligon.Points.Add(new Point(x2, y2));
            poligon.Points.Add(new Point(x3, y3));

            return poligon;
        } 

        

        public UIElement Drawing(double _radius)
        {
            //Polygon poligon = new Polygon();
            //var br = Brushes.Red;
            //poligon.Stroke = br;
            //foreach (var point in Points)
            //{
            //    poligon.Points.Add(point);
            //}
            ////poligon.Points.Add(a);
            ////poligon.Points.Add(b);
            ////poligon.Points.Add(c);

            //return poligon;

            var poligonCopy = (Polygon) Element;

            Polygon poligon = new Polygon();
            poligon.Stroke = poligonCopy.Stroke;
            for (int i = 0; i<poligonCopy.Points.Count; i++)
            {
                poligon.Points.Add(poligonCopy.Points[i]);
            }
            //poligon.Points.Add(poligonCopy.Points[0]);
            //poligon.Points.Add(poligonCopy.Points[1]);
            //poligon.Points.Add(poligonCopy.Points[2]);
            poligon.RenderTransform = poligonCopy.RenderTransform;

            return poligon;
        }

        public IFigure Moving_a_shape(int offset, Operation operation)
        {
            Polygon polygon = (Polygon)Element;//(Line)Elements[0];
            for (int i = 0; i < polygon.Points.Count; i++)
            {
                double y = polygon.Points[i].Y;
                double x = polygon.Points[i].X;

                if (operation == La2Net5.Operation.Down)
                    y += offset;

                else if (operation == La2Net5.Operation.Top)
                    y -= offset;

                else if (operation == La2Net5.Operation.Left)
                    x -= offset;

                else if (operation == La2Net5.Operation.Right)
                    x += offset;

                polygon.Points[i] = new Point(x, y);
            }

            Element = polygon;

            return this;
        }

        public IFigure Rotation(double radians, Point point0)
        {
            //old
            //for (int i = 0; i < Points.Count; i++)
            //    Points[i] = RotationPoit(radians, Points[i], point0);
            Polygon polygon = (Polygon) Element;
            for (int i = 0; i < polygon.Points.Count; i++)
            {
                Point pointEdit = polygon.Points[i];
                //развернем точку, отн другой точки на колличество градусов
                pointEdit = RotationPoitXY(radians, polygon.Points[i].X, polygon.Points[i].Y, point0);

                polygon.Points[i] = pointEdit;
            }

            Element = polygon;
            return this;
        }

        public IFigure ToScale(double scale, Point point0)
        {
            TransformF transformF = new TransformF();

            Polygon polygon = (Polygon) Element;
            polygon.Stroke = Brushes.Green;
            polygon.RenderTransformOrigin = new Point(0.5, 0.5);

            var transform = transformF.ToScale(scale);
            polygon.RenderTransform = transform;
            for (int i = 0; i < polygon.Points.Count; i++)
            {
                Debug.WriteLine($"Scale Polygon {scale} {polygon.Points[i].X} {polygon.Points[i].Y}");
            }

            Element = polygon;
            return this;
        }

        public IFigure CloneFigure()
        {
            var clonePoints = (Figure)Clone();
            TriangleT figureReturne = new TriangleT();

            //Новый клон
            figureReturne.Element = clonePoints.Element;

            return figureReturne;
        }

       
    }
}
