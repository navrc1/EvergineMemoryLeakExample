using System.Windows;
using System.Windows.Input;
using Window = System.Windows.Window;

namespace UIWindowSystemsDemo.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EvergineDisplayHelper displayHelper1;
        private EvergineDisplayHelper displayHelper2;
        private InteractionService interactionService;

        public MainWindow()
        {
            InitializeComponent();

            displayHelper1 = new EvergineDisplayHelper(WaveContainer);
            displayHelper1.Load("DefaultDisplay");

            displayHelper2 = new EvergineDisplayHelper(WaveContainer2);
            displayHelper2.Load("Display2");

            RegisterInteractionService();
        }

        private void RegisterInteractionService()
        {
            var application = ((App)Application.Current).EvergineApplication;
            interactionService = new InteractionService();
            application.Container.RegisterInstance(interactionService);
        }

        private void NativeControlMouseUp(object sender, MouseButtonEventArgs e)
        {
            ((FrameworkElement)sender).ReleaseMouseCapture();
        }

        private void NativeControlMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((FrameworkElement)sender).Focus();
            ((FrameworkElement)sender).CaptureMouse();
        }

        private void ResetCameraClick(object sender, RoutedEventArgs e)
        {
            interactionService.ResetCamera();
        }

        private void DisplacementChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            interactionService.Displacement = (float)e.NewValue;
        }

        private void ToggleSphereResizing(object sender, RoutedEventArgs e) {
            interactionService.ResizeSpheres = !interactionService.ResizeSpheres;
        }
    }
}
