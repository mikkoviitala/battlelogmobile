using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using Microsoft.Phone.Tasks;

namespace BattlelogMobile.Log
{
    public class EmailLogProvider
    {
        private const string Message = "Would you like to send automated error report to help resolve this issue?";
        private const string Caption = "Crash detected";
        private const MessageBoxButton Buttons = MessageBoxButton.OKCancel;
        private const MessageBoxResult Send = MessageBoxResult.OK;

        private const string Subject = "Battlelog Mobile Error Report";
        private const string To = "battlelogmobile@inbox.com";

        private const string Filename = "UnhandledException.txt";
        private static readonly IsolatedStorageFile Store = IsolatedStorageFile.GetUserStoreForApplication();

        public static void Log(Exception exception)
        {
            using (TextWriter writer = new StreamWriter(Store.OpenFile(Filename, FileMode.Create)))
            {
                writer.WriteLine("Date: {0}", DateTime.Now);
                writer.WriteLine(string.Empty);
                writer.WriteLine("Exception: {0}", exception);
            }
        }

        public static async void ReportException()
        {
            if (!Store.FileExists(Filename))
                return;

            string content;
            using (TextReader reader = new StreamReader(Store.OpenFile(Filename, FileMode.Open)))
                content = await reader.ReadToEndAsync();

            Store.DeleteFile(Filename);

            if (MessageBox.Show(Message, Caption, Buttons) == Send)
            {
                var email = new EmailComposeTask
                {
                    To = To,
                    Subject = Subject,
                    Body = content
                };
                email.Show();
            }
        }
    }
}
