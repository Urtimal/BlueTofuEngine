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
    public partial class MapControl : UserControl
    {
        public List<object> Elements { get; private set; }

        public MapControl()
        {
            Elements = new List<object>();

            InitializeComponent();
            Loaded += (_, __) => OnLoaded();
        }
        
        private void OnLoaded()
        {
            foreach (var element in Elements)
            {
                switch (element)
                {
                    case CellData cellData:
                        var mapCell = new MapCell();
                        mapCell.Id = cellData.Id;
                        map.Children.Add(mapCell);
                        break;
                }
            }
        }
    }
}
