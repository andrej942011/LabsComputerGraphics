using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using MS.Internal;

namespace La2Net5.Figures.TransformFigure
{
    public class TransformF// : Transform //RotateTransform //запечатанный класс
    {
        /// <summary>
        /// Поворот фигуры на число градусов
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public Transform Rotate(double angle)
        {
            double angle_radian = angle * Math.PI / 180;

            Debug.WriteLine($"{angle} {angle_radian}");
            Matrix matrix = new Matrix();
            matrix.Rotate(angle);

            //2 способ
            var matrix1 = MatrixRotate(angle_radian);

            Transform transform = new MatrixTransform(matrix1);

            return transform;
        }

        /// <summary>
        /// Масштабирование
        /// </summary>
        /// <param name="scale">значение масштаба</param>
        /// <returns></returns>
        public Transform ToScale(double scale)
        {
            Matrix matrix = new Matrix();
            matrix.Scale(scale, scale);

            Transform transform = new MatrixTransform(matrix);
            return transform;
        }

        private Matrix MatrixRotate(double angle)
        {
            double M11 = Math.Cos(angle);
            double M12 = Math.Sin(angle);
            double M21 = Math.Sin(angle) * -1;
            double M22 = Math.Cos(angle);

            var matrix = new Matrix(M11, M12, M21, M22, 0, 0);
            return matrix;
        }

        

    }
}
