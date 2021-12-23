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
using La2Net5.Figures;
using La2Net5.Figures.TransformFigure;


namespace La2Net5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// https://ip76.ru/dict/affine2d/
    public partial class MainWindow : Window
    {
        private List<IFigure> Figures;
        private int offset = 10;
        public MainWindow()
        {
            InitializeComponent();
            Figures = new List<IFigure>();
        }

        private void BtCreateFigure_Click(object sender, RoutedEventArgs e)
        {
            Figures.Add(new LineF(60, 60, 200, 60));
            Figures.Add(new LineF(200, 60, 200, 200));
            Figures.Add(new LineF(200, 200, 60, 200));
            Figures.Add(new LineF(60, 200, 60, 60));

            //крыша
            Figures.Add(new TriangleT(60, 60, 135, 10, 200, 60));
            //Figures.Add(new LineF(60, 60, 135, 10));
            //Figures.Add(new LineF(135, 10, 200, 60));

            Figures.Add(new CircleF(new Point(200, 200), 128, 32));

            Drawing(Figures);
        }

        private void BtTop_Click(object sender, RoutedEventArgs e)
        {
            //default_valuesTextBox();
            for (int i = 0; i < Figures.Count; i++)
                Figures[i] = Figures[i].Moving_a_shape(offset, Operation.Top);

            Drawing(Figures);
        }
        private void BtLeft_Click(object sender, RoutedEventArgs e)
        {
            //default_valuesTextBox();
            for (int i = 0; i < Figures.Count; i++)
                Figures[i] = Figures[i].Moving_a_shape(offset, Operation.Left);

            Drawing(Figures);
        }
        private void BtRight_Click(object sender, RoutedEventArgs e)
        {
            //default_valuesTextBox();
            for (int i = 0; i < Figures.Count; i++)
                Figures[i] = Figures[i].Moving_a_shape(offset, Operation.Right);

            Drawing(Figures);
        }
        private void BtDown_Click(object sender, RoutedEventArgs e)
        {
            //default_valuesTextBox();
            for (int i = 0; i < Figures.Count; i++)
                Figures[i] = Figures[i].Moving_a_shape(offset, Operation.Down);

            Drawing(Figures);
        }

        /// <summary>
        /// Повернуть на число градусов отнасительно точки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtRotation_Click(object sender, RoutedEventArgs e)
        {
            var copyFigures =  new List<IFigure>();
            for (int i = 0; i < Figures.Count; i++)
            {
                var figure = Figures[i].CloneFigure();
                copyFigures.Add(figure);
            }

            double radius = Convert.ToDouble(Tb_Angle.Text);
            Point point0 = new Point(200,200);

            for (int i = 0; i < copyFigures.Count; i++)
                copyFigures[i] = copyFigures[i].Rotation(radius, point0);

            Drawing(copyFigures);
        }

        /// <summary>
        /// Масштабировать фигуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_Scale_Click(object sender, RoutedEventArgs e)
        {
            var copyFigures = new List<IFigure>();
            for (int i = 0; i < Figures.Count; i++)
            {
                var figure = Figures[i].CloneFigure();
                copyFigures.Add(figure);
            }

            double scale = Convert.ToDouble(Tb_Angle.Text);
            Point point0 = new Point(200, 200);

            for (int i = 0; i < copyFigures.Count; i++)
                copyFigures[i] = copyFigures[i].ToScale(scale, point0);

            Drawing(copyFigures);
        }

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
        }
        private void Drawing(IList<IFigure> _figures)
        {
            double radius = Convert.ToDouble(Tb_Angle.Text);

            //old
            foreach (var figure in _figures)
            {
                canvas1.Children.Add(figure.Drawing(radius));
            }
                

            //foreach (var itemChild in grid1.Children)
            //    Debug.WriteLine(itemChild.GetType().ToString());
        }

        /// <summary>
        /// Кнопка для тестирования кода!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtMatrix_Click(object sender, RoutedEventArgs e)
        {
            double radius = Convert.ToInt32(Tb_Angle.Text);

            //Через аффинные преобразования
            //https://ip76.ru/dict/affine2d/
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 100;
            ellipse.Height = 50;
            ellipse.Stroke = Brushes.Black;
            ellipse.RenderTransformOrigin = new Point(0.5, 0.5); //для отцентровки фигуры

            ///ellipse.Margin = new Thickness(Points[0].X - (width / 2), Points[0].Y - (height / 2), 0, 0);//внешние поля элемента
            ellipse.Margin = new Thickness(200 - (100/2), 200 - (50/2), 0, 0);

            TransformF transformF = new TransformF();

            var transform = transformF.Rotate(radius);//rotate;

            ellipse.RenderTransform = transform;//rotate;//(рабочий вариант)
            canvas1.Children.Add(ellipse);
        }

        private void BtMatrix_Scale_Click(object sender, RoutedEventArgs e)
        {
            TransformF transformF = new TransformF();
            double scale = Convert.ToInt32(Tb_Angle.Text);

            //Ellipse ellipse = new Ellipse();
            //ellipse.Width = 100;
            //ellipse.Height = 50;
            //ellipse.Stroke = Brushes.Red;
            //ellipse.RenderTransformOrigin = new Point(0.5, 0.5); //для отцентровки фигуры
            //ellipse.Margin = new Thickness(200 - (100 / 2), 200 - (50 / 2), 0, 0); //позиция

            //var transform = transformF.ToScale(scale);

            //ellipse.RenderTransform = transform;
            //canvas1.Children.Add(ellipse);

            Line line = new Line();
            line.X1 = 100;
            line.Y1 = 100;
            line.X2 = 200;
            line.Y2 = 100;
            line.Stroke = Brushes.Red;
            line.RenderTransformOrigin = new Point(0.5, 0.5); //для отцентровки фигуры

            var transform = transformF.ToScale(scale);
            line.RenderTransform = transform;
            Debug.WriteLine($"{scale} {line.X1} {line.X2}");

            canvas1.Children.Add(line);
        }

        private void default_valuesTextBox()
        {
            Tb_Angle.Text = "0";
        }

        
    }
}
