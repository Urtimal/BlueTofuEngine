using D2MapViewer.Data;
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

namespace D2MapViewer.Controls
{
    /// <summary>
    /// Logique d'interaction pour MapCell.xaml
    /// </summary>
    public partial class MapCell : UserControl
    {
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(MapCell), new PropertyMetadata(0));
        
        public bool DisplayGrid
        {
            get { return (bool)GetValue(DisplayGridProperty); }
            set { SetValue(DisplayGridProperty, value); }
        }
        public static readonly DependencyProperty DisplayGridProperty =
            DependencyProperty.Register("DisplayGrid", typeof(bool), typeof(MapCell), new PropertyMetadata(true));
        
        public bool DisplayNumber
        {
            get { return (bool)GetValue(DisplayNumberProperty); }
            set { SetValue(DisplayNumberProperty, value); }
        }
        public static readonly DependencyProperty DisplayNumberProperty =
            DependencyProperty.Register("DisplayNumber", typeof(bool), typeof(MapCell), new PropertyMetadata(true));
        
        public bool Mov
        {
            get { return (bool)GetValue(MovProperty); }
            set { SetValue(MovProperty, value); }
        }
        public static readonly DependencyProperty MovProperty =
            DependencyProperty.Register("Mov", typeof(bool), typeof(MapCell), new PropertyMetadata(false));
        
        public bool LineOfSight
        {
            get { return (bool)GetValue(LineOfSightProperty); }
            set { SetValue(LineOfSightProperty, value); }
        }
        public static readonly DependencyProperty LineOfSightProperty =
            DependencyProperty.Register("LineOfSight", typeof(bool), typeof(MapCell), new PropertyMetadata(false));
        

        public MapCell()
        {
            InitializeComponent();

            DataContext = this;
            Loaded += (_, __) =>
            {
                var pos = GetPos();
                Canvas.SetLeft(this, pos.X);
                Canvas.SetTop(this, pos.Y);
            };
        }

        public Point GetPos()
        {
            var relativeX = Id % Constants.MapWidth;
            var relativeY = Id / Constants.MapWidth;
            var isSubLine = relativeY % 2 == 1;
            var x = relativeX * Constants.CellWidth;
            var y = (relativeY / 2) * Constants.CellHeight;
            if (isSubLine)
            {
                x += Constants.CellHalfWidth;
                y += Constants.CellHalfHeight;
            }
            return new Point(x, y);
        }
    }
}
