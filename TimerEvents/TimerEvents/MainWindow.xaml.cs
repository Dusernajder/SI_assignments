using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TimerEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            window_Loaded(myProgressBar, new RoutedEventArgs());
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
            _timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            myProgressBar.Value += 10;
            if (myProgressBar.Value >= 100) 
            {
                _timer.Stop();
            }
        }
    }
}