using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Tasks;
using Tomers.Phone.Controls;

namespace BattlelogMobile.Client.View
{
    /// <summary>
    /// Mainapage
    /// </summary>
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Messenger.Default.Register<DialogMessage>(this, message => MessageBox.Show(message.Content));
        }

        private void TextChangedUpdateTrigger(object sender, TextChangedEventArgs e)
        {
            UpdateSource(sender);
        }

        private void PasswordChangedUpdateTrigger(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateSource(sender);
        }

        /// <summary>
        /// Workaround to update properties while typing
        /// </summary>
        private static void UpdateSource(object sender)
        {
            BindingExpression bindingExpression = null;
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
            }
            else
            {
                var passwordBox = sender as PasswordBox;
                if (passwordBox != null)
                    bindingExpression = passwordBox.GetBindingExpression(PasswordBox.PasswordProperty);
            }

            if (bindingExpression != null)
                bindingExpression.UpdateSource();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            while (NavigationService.RemoveBackEntry() != null)
                NavigationService.RemoveBackEntry();
            base.OnBackKeyPress(e);
        }
    }
}

