using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La4Net5
{
    /// <summary>
    /// Кривоая безье
    /// </summary>
    public class BezierCurve
    {
        /// <summary>
        /// Количество точек для отрисовки.
        /// </summary>
        private const int N = 40;

        /// <summary>
        /// Параметры для отображения точек на экране
        /// </summary>
        private const float ox = 0.5f;
        private const float oy = 25.0f;
        private const int size = 40;

        /// <summary>
        /// Опорные точки.
        /// </summary>
        private PointF[] dataPoints;

        /// <summary>
        /// Точки для отрисовки
        /// </summary>
        public PointF[] DrawingPoints { get; private set; }

        /// <summary>
        /// Опорные точки
        /// </summary>
        public PointF[] DataPoints
        {
            get { return dataPoints; }
            set
            {
                if(value.Length !=4)
                    throw new ArgumentOutOfRangeException();

                dataPoints = value;

                Invalidate();
            }
        }

        /// <summary>
        /// Опорная точка
        /// </summary>
        /// <param name="i">Индекс опорной точки</param>
        public PointF this[int i]
        {
            get { return dataPoints[i]; }
            set
            {
                dataPoints[i] = value;
                Invalidate();
            }
        }

        public BezierCurve(Double[] arrX, Double[] arrY)
        {
            Marker[] markers = new Marker[4];

            if (arrX.Length != 4 && arrY.Length != 4)
                throw new ArgumentOutOfRangeException("Рзмер массива должен быть 4");

            //Оптимизация точек под экран
            for (int i = 0; i < arrX.Length; i++)
            {
                markers[i] = new Marker(((float)arrX[i] * size) + ox, ((float)arrY[i] * size) + oy);
            }

            dataPoints = markers.Select(m => m.Location).ToArray();

            Invalidate();
        }

        public BezierCurve(PointF[] points)
        {
            if (points.Length != 4)
            {
                throw new ArgumentOutOfRangeException();
            }

            dataPoints = points;

            Invalidate();
        }

        /// <summary>
        /// Обновить точки для отрисовки.
        /// </summary>
        public void Invalidate()
        {
            DrawingPoints = new PointF[N + 1];
            float dt = 1f / N;
            float t = 0f;
            for (int i = 0; i <= N; i++)
            {
                DrawingPoints[i] = B(t);
                t += dt;
            }
        }

        /// <summary>
        /// Функция кривой
        /// </summary>
        /// <param name="t">Параметр. Может изменяться от 0 до 1</param>
        /// <returns>Точка кирвой</returns>
        private PointF B(float t)
        {
            float c0 = (1 - t) * (1 - t) * (1 - t);
            float c1 = (1 - t) * (1 - t) * 3 * t;
            float c2 = (1 - t) * t * 3 * t;
            float c3 = t * t * t;
            float x = c0 * dataPoints[0].X + c1 * dataPoints[1].X + c2 * dataPoints[2].X + c3 * dataPoints[3].X;
            float y = c0 * dataPoints[0].Y + c1 * dataPoints[1].Y + c2 * dataPoints[2].Y + c3 * dataPoints[3].Y;
            return new PointF(x, y);
        }
    }
}
