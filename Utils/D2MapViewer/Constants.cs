using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MapViewer
{
    public static class Constants
    {
        public const int MapWidth = 14;
        public const int MapHeight = 20;
        public const double CellWidth = 86;
        public const double CellHeight = 43;
        public const double CellHalfWidth = 43;
        public const double CellHalfHeight = 21.5;
        public const int MapCellsCount = 560;
        public const int AltitudePixelUnit = 10;

        public const string ElementsPath = @"E:\Dofus Server\BlueTofuEngine\Utils\D2DataReader\bin\Debug\netcoreapp3.0\output\elements";
        public const string GfxPath = @"E:\Dofus Server\BlueTofuEngine\Utils\D2DataReader\bin\Debug\netcoreapp3.0\output\pak\world\png";
    }
}
