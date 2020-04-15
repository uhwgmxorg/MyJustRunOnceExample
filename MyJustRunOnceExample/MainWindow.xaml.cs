using System;
using System.Windows;

namespace MyJustRunOnceExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Threading.Mutex _mutex;
        public string MutexName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            CheckRunningInstances();
        }
        private void CheckRunningInstances()
        {
            string user = System.Environment.GetEnvironmentVariable("USERNAME");
            MutexName = "E158AF9B-35DF-4236-B511-962469239749__" + user;
            _mutex = new System.Threading.Mutex(true, MutexName);
            if (!_mutex.WaitOne(0))
            {
                System.Windows.MessageBox.Show("Program can only run ones!", System.Reflection.Assembly.GetEntryAssembly().GetName().Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Environment.Exit(-2);
            }
            labelMutexName.Content = MutexName;
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// Button_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        #endregion

    }
}
