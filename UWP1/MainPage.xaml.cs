using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwilioSmsUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        private readonly MessageSender _messageSender;
        public MainPage(MessageSender ms)
        {
            _messageSender = ms;
            this.InitializeComponent();
            CoreWindow.GetForCurrentThread().KeyDown += MainPage_KeyDown; ;
        }

        private void HandleAction()
        {
            _messageSender.SendSms(NumberInput.Text, MessageInput.Text);
            Output.Text = $"Message sent to {NumberInput.Text} - {MessageInput.Text}";
            MessageInput.Text = String.Empty;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HandleAction();
        }
        private void MainPage_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case Windows.System.VirtualKey.Enter:
                    // handler for enter key
                    HandleAction();
                    break;
                default:
                    break;
            }
        }
    }
}
