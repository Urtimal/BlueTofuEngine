using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace D2MapViewer.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Dictionary<string, object> _values;

        public BaseViewModel()
        {
            _values = new Dictionary<string, object>();
        }

        protected T GetValue<T>(Func<T> defaultValue = null, [CallerMemberName]string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return default(T);

            if (!_values.ContainsKey(propertyName))
            {
                if (defaultValue != null)
                    _values.Add(propertyName, defaultValue());
                else
                    _values.Add(propertyName, default(T));
            }

            return (T)_values[propertyName];
        }

        protected void SetValue<T>(T value, [CallerMemberName]string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;

            if (_values.ContainsKey(propertyName))
                _values[propertyName] = value;
            else
                _values.Add(propertyName, value);
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnLoaded() { }
    }
}
