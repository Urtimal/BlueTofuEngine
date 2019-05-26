using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace D2WorldMapViewer
{
    public class MapCanvas : Canvas
    {
        private readonly Dictionary<float, List<Tuple<BitmapImage, Point>>> _images;
        private int _currentZoom;
        private readonly List<float> _zooms;
        private WorldMap _map;

        public MapCanvas() : base()
        {
            _images = new Dictionary<float, List<Tuple<BitmapImage, Point>>>();
            _zooms = new List<float>();
        }
        
        public void SetCurrentZoom()
        {
            Width = _map.totalWidth * _zooms[_currentZoom];
            Height = _map.totalHeight * _zooms[_currentZoom];
        }

        public void ZoomIn()
        {
            if (_currentZoom > 0)
                _currentZoom--;
            SetCurrentZoom();
        }

        public void ZoomOut()
        {
            if ((_currentZoom + 1) < _zooms.Count)
                _currentZoom++;
            SetCurrentZoom();
        }

        public void SetWorldMap(WorldMap map, string imageFolder)
        {
            _map = map;
            _zooms.AddRange(map.zoom.Select(x => float.Parse(x.Replace('.', ','))));
            foreach (var zoom in _zooms)
            {
                if (!_images.ContainsKey(zoom))
                {
                    var imgs = new List<Tuple<BitmapImage, Point>>();
                    var currentZoomFolder = Path.Combine(imageFolder, zoom.ToString().Replace(',', '.'));
                    var referenceImg = new BitmapImage(new Uri(Path.Combine(currentZoomFolder, "1.jpg")));
                    var mapWidth = Math.Ceiling((map.totalWidth * zoom) / referenceImg.PixelWidth);

                    var imgCount = Directory.EnumerateFiles(currentZoomFolder).Count();
                    for (int i = 0; i < imgCount; i++)
                    {
                        var bitmap = new BitmapImage(new Uri(Path.Combine(currentZoomFolder, (i + 1) + ".jpg")));
                        var point = new Point();
                        point.X = (i % mapWidth) * referenceImg.PixelWidth;
                        point.Y = Math.Floor(i / mapWidth) * referenceImg.PixelHeight;
                        imgs.Add(new Tuple<BitmapImage, Point>(bitmap, point));
                    }
                    _images.Add(zoom, imgs);
                }
            }

            _currentZoom = 0;
            SetCurrentZoom();
        }

        protected override void OnRender(DrawingContext dc)
        {
            if (_images.ContainsKey(_zooms[_currentZoom]))
            {
                foreach (var img in _images[_zooms[_currentZoom]])
                {
                    dc.DrawImage(img.Item1, new Rect(img.Item2, new Size(img.Item1.PixelWidth, img.Item1.PixelHeight)));
                }
            }
        }
    }
}
