using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace D2WorldMapViewer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            var worldMapPath = @"E:\Dofus Server\Dofus 2\exported_data\output\data\WorldMaps\1.json";
            var worldMapBaseImagePath = @"E:\Dofus Server\Dofus 2\exported_data\output\pak\worldmaps";

            var worldMap = JsonConvert.DeserializeObject<WorldMap>(File.ReadAllText(worldMapPath));
            var worldMapImagePath = System.IO.Path.Combine(worldMapBaseImagePath, worldMap.id.ToString());
            drawZone.SetWorldMap(worldMap, worldMapImagePath);
        }

        Point scrollMousePoint = new Point();
        double hOff = 1;
        double vOff = 1;

        private void scrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            scrollMousePoint = e.GetPosition(scrollViewer);
            hOff = scrollViewer.HorizontalOffset;
            vOff = scrollViewer.VerticalOffset;
            scrollViewer.CaptureMouse();
        }

        private void scrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (scrollViewer.IsMouseCaptured)
            {
                scrollViewer.ScrollToHorizontalOffset(hOff + (scrollMousePoint.X - e.GetPosition(scrollViewer).X));
                scrollViewer.ScrollToVerticalOffset(vOff + (scrollMousePoint.Y - e.GetPosition(scrollViewer).Y));
            }
        }

        private void scrollViewer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            scrollViewer.ReleaseMouseCapture();
        }

        private void scrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;

            if (e.Delta > 0)
                drawZone.ZoomIn();
            else
                drawZone.ZoomOut();
        }
    }
}
