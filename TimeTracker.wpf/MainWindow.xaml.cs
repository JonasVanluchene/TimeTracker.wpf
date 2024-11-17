using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TimeTracker.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        Stopwatch stopWatch = new Stopwatch();
        DispatcherTimer dispatcherTimerClock = new DispatcherTimer();
        DispatcherTimer dispatcherTimerStopWatch = new DispatcherTimer();
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            dispatcherTimerClock.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimerClock.Tick += RefreshTimer;
            dispatcherTimerClock.Start();

            dispatcherTimerStopWatch.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimerStopWatch.Tick += RefreshStopWatch;




        }

        public void RefreshTimer(Object sender, EventArgs e)
        {
            
            
            txbCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public void RefreshStopWatch(Object sender, EventArgs e)
        {
            TimeSpan ts = stopWatch.Elapsed;
            txbCounter.Text = $"{ts.Hours.ToString("00")}:{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}"; 
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

            
            stopWatch.Start();
            if (stopWatch.IsRunning)
            {
                btnStart.Content = "start";
            }

            dispatcherTimerStopWatch.Start();

        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning) 
            {
                stopWatch.Stop();
                btnStart.Content = (btnStart.Content == "continue") ? "start" : "continue";
            }

            
        }

        
       
    }
}