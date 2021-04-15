using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace UWP_XAML_Notification
{
    public sealed partial class MainPage : Page
    {
        private string demoAppGuid = "1D157158-84F1-43BC-86F5-D407B9D67CD5";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void RaiseNotificationButton_Click(object sender, RoutedEventArgs e)
        {
            // All UIA events are raised indirectly through an element's AutomationPeer.
            var peer = FrameworkElementAutomationPeer.FromElement(
                        RaiseNotificationButton);
            if (peer != null)
            {
                // Any arbitrary string can be raised through this event.
                var resourceLoader = ResourceLoader.GetForCurrentView();
                var demoNotification = resourceLoader.GetString("DemoNotification");

                // Raise a UIA Notification event. The specific AutomationNotificationKind and
                // AutomationNotificationProcessing values used here are purely for demo purposes.
                // A real app would use whatever values are most appropriate for their scenarios.
                peer.RaiseNotificationEvent(
                     AutomationNotificationKind.ActionCompleted,
                     AutomationNotificationProcessing.All,
                     demoNotification,
                     demoAppGuid);
            }
        }
    }
}
