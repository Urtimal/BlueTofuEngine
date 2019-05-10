using D2MapViewer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MapViewer.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<object> Elements
        {
            get => GetValue(() => new ObservableCollection<object>());
            set => SetValue(value);
        }

        public override void OnLoaded()
        {
            for (int i = 0; i < 5; i++)
                Elements.Add(new CellData { Id = i });
        }
    }
}
