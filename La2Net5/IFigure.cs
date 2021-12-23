using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace La2Net5
{
    public interface IFigure//: ICloneable
    {
        public UIElement Drawing(double _radius);

        /// <summary>
        /// Перемещение фигуры
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public IFigure Moving_a_shape(int offset, Operation operation); //Top, Down, Left, Right

        /// <summary>
        /// Вращение фигуры отнасительно точки
        /// </summary>
        /// <param name="radians"></param>
        /// <param name="point0"></param>
        /// <returns></returns>
        public IFigure Rotation(double radians, Point point0);

        /// <summary>
        /// Масштабирование фигуры отнасительно точки
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="point0"></param>
        /// <returns></returns>
        public IFigure ToScale(double scale, Point point0);

        public IFigure CloneFigure();
    }
}
