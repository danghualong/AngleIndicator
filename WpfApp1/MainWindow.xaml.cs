using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        LineSegment lineSegment = new LineSegment(new Point(80, 80), true);
        private void btnSet_Click(object sender, RoutedEventArgs e)
        {

            double angle = 0.0;
            double.TryParse(txtAngle.Text, out angle);
            angle = angle % 360;
            if (angle < 0)
            {
                angle += 360;
            }
            double radian = angle * Math.PI / 180;//弧度
            double r = 40;
            points.Segments.Clear();
            points.Segments.Add(new LineSegment(new Point(40, 0), true));

            if (angle > 0 && angle <= 45)
            {
                double x = Math.Tan(radian)*r+r;
                points.Segments.Add(new LineSegment(new Point(x, 0), true));
            }
            if (angle > 45 && angle <= 135)
            {
                points.Segments.Add(new LineSegment(new Point(80, 0), true));
                radian = Math.PI / 2 - radian; //弧度
                double y = r - r * Math.Tan(radian);
                points.Segments.Add(new LineSegment(new Point(80, y), true));

            }
            if (angle > 135 && angle <= 225)
            {
                points.Segments.Add(new LineSegment(new Point(80, 0), true));
                points.Segments.Add(new LineSegment(new Point(80, 80), true));
                radian = Math.PI - radian;
                double x = (1 + Math.Tan(radian)) * r;
                points.Segments.Add(new LineSegment(new Point(x,80), true));
            }

            if (angle > 225 && angle <= 315)
            {
                points.Segments.Add(new LineSegment(new Point(80, 0), true));
                points.Segments.Add(new LineSegment(new Point(80, 80), true));
                points.Segments.Add(new LineSegment(new Point(0, 80), true));
                radian = Math.PI*3/2 - radian;
                double y = (1 + Math.Tan(radian)) * r;
                points.Segments.Add(new LineSegment(new Point(0, y), true));
            }
            if (angle > 315)
            {
                points.Segments.Add(new LineSegment(new Point(80, 0), true));
                points.Segments.Add(new LineSegment(new Point(80, 80), true));
                points.Segments.Add(new LineSegment(new Point(0, 80), true));
                points.Segments.Add(new LineSegment(new Point(0,0), true));
                radian = radian-Math.PI*2;
                double x = (1 + Math.Tan(radian)) * r;
                points.Segments.Add(new LineSegment(new Point(x, 0), true));
            }
        }

        private void txtAngle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSet_Click(sender, e);
            }
        }
    }
}
