using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator.ViewModel
{
    class MViewModel : INotifyPropertyChanged
    {
        private string _textblock;
        public string TextBlock { get { return _textblock; } set { _textblock = value; OnPropertyChanged(""); } }
        public MViewModel() { }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
