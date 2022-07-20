using MagicTheme.Utils.Loggers;
using Microsoft.UI.Xaml;
using SettingsUI.Helpers;
using System;
using Windows.ApplicationModel.Activation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MagicTheme
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>

        private static readonly ILogger Logger = AppLogger.GetLoggerForCurrentClass();
        

        public App()
            {
            this.InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
             }

        private void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            if (args.UWPLaunchActivatedEventArgs.Kind == ActivationKind.CommandLineLaunch)
            {
                Logger.Info("Starting app with command line arguments: {0}", string.Join(", ", args.Arguments));

                switch (args.Arguments)
                    {
                        case "-light":

                            break;

                        case "-dark":
                            break;

                        case "-change":

                            
                            break;

                        case "-update":

                            break;

                        case "-clean":
                            break;
                   
                        case "-test":
                        Console.WriteLine("Success!");
                        break;

                        default:
                            break;
                    }
                }
            else 
            {


                m_window = new MainWindow();
            if (OSVersionHelper.IsWindows11_OrGreater)
            {
            ThemeHelper.Initialize(m_window, BackdropType.Mica);
            }
            else
            {
            ThemeHelper.Initialize(m_window, BackdropType.DesktopAcrylic);
            }
            //m_window.SetWindowSize(900, 450);
           // notificationManager.Init(notificationManager, OnNotificationInvoked);
            m_window.Activate();
              Logger.Info("Starting app..."+ "BackdropType is"+ BackdropType.DefaultColor.ToString());
            }
        }
        private void OnNotificationInvoked(string obj)
        {
            
        }
        void OnProcessExit(object sender, EventArgs e)
        {
            //   notificationManager.Unregister();
            Logger.Info("Exit with code 0");
        }
        
        private Window m_window;
       // private NotificationManager notificationManager;
    }
}
