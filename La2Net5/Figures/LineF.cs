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
    public class LineF: Figure, IFigure
    {
        public LineF()
        { }

        public LineF(Point _a, Point _b): base()
        {
            //AddPoint(_a);
            //AddPoint(_b);
        }

        public LineF(int x1, int y1, int x2, int y2): base()
        {
            //var a = new Point(x1, y1);
            //var b = new Point(x2, y2);

            //AddPoint(a);
            //AddPoint(b);

            //Другая реализация
            Element = CreateLine(x1, y1, x2, y2);
            //Elements.Add(CreateLine(x1, y1, x2, y2));
        }

        private Line CreateLine(int x1, int y1, int x2, int y2)
        {
            var line = new Line();
            var br = Brushes.Red;
            line.Stroke = br;
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;

            return line;
        }

        public UIElement Drawing(double _radius)
        {
            //old
            //Line line = new Line();
            //var br = Brushes.Red;
            //line.Stroke = br;
            //line.X1 = Points[0].X;
            //line.Y1 = Points[0].Y;
            //line.X2 = Points[1].X;
            //line.Y2 = Points[1].Y;

            var linecopy = (Line) Element;//(Line)Elements[0];

            Line line = new Line();//(Line) Elements[0];
            var br = Brushes.Red;
            line.Stroke = linecopy.Stroke;//br;
            line.X1 = linecopy.X1;
            line.Y1 = linecopy.Y1;
            line.X2 = linecopy.X2;
            line.Y2 = linecopy.Y2;
            line.RenderTransform = linecopy.RenderTransform;

            return line;
        }

        public IFigure Moving_a_shape(int offset, Operation operation)
        {
            Line line = (Line) Element;//(Line)Elements[0];
            if (operation == La2Net5.Operation.Down)
            {
                line.Y1 += offset;
                line.Y2 += offset;
                //point_changes.Y += offset;
            }
            else if (operation == La2Net5.Operation.Top)
            {
                line.Y1 -= offset;
                line.Y2 -= offset;
                //point_changes.X -= offset;
            }
                

            else if (operation == La2Net5.Operation.Left)
            {
                line.X1 -= offset;
                line.X2 -= offset;
                //point_changes.X -= offset;
            }
                

            else if (operation == La2Net5.Operation.Right)
            {
                line.X1 += offset;
                line.X2 += offset;
                //point_changes.X += offset;
            }
                

            //Operation(offset, operation);
            Element = line;
            return this;
        }

        public IFigure Rotation(double radians, Point point0)
        {
            //Debug.WriteLine($"{a.X} {a.Y} || {b.X} {b.Y}");

            Line line = (Line) Element;//(Line)Elements[0];
            Point a = RotationPoitXY(radians, line.X1, line.Y1, point0);
            Point b = RotationPoitXY(radians, line.X2, line.Y2, point0);
            line.X1 = a.X;
            line.Y1 = a.Y;
            line.X2 = b.X;
            line.Y2 = b.Y;

            Element = line;
            return this;
        }

        public IFigure ToScale(double scale, Point point0)
        {
            TransformF transformF = new TransformF();

            Line lineSourse = (Line) Element;//(Line)Elements[0];

            lineSourse.Stroke = Brushes.Green;
            lineSourse.RenderTransformOrigin = new Point(0.5, 0.5); //для отцентровки фигуры

            var transform = transformF.ToScale(scale);
            lineSourse.RenderTransform = transform;
            Debug.WriteLine($"Scale Line {scale} {lineSourse.X1} {lineSourse.X2}");

            Element = lineSourse;
            return this;
        }

        public IFigure CloneFigure()
        {
            var clonePoints = (Figure)Clone();
            LineF figureReturne = new LineF();
            //figureReturne.Elements.AddRange(clonePoints.Elements);//!!!!
            figureReturne.Element = clonePoints.Element;

            return figureReturne;
        }
    }
}
