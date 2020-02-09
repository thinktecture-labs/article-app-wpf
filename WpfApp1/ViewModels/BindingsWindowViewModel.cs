using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.ViewModels
{
    public class BindingsWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string helloWorldText = "Hello World!";
        public string HelloWorldText
        {
            get
            {
                return helloWorldText;
            }
            set
            {
                helloWorldText = value;
                OnPropertyChanged();
            }
        }

        public double Price => 100;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
