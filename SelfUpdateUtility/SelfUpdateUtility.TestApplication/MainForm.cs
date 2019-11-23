using SelfUpdateUtility.Library;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SelfUpdateUtility.TestApplication
{
    public partial class MainForm : Form
    {
        public MainForm(string[] args)
        {
            InitializeComponent();
            InitializeArgumentsTextBox(args);            
            InitializeProcessIdTextBox();
            UpdateLastModifiedTextBox();
        }

        public SelfUpdate SelfUpdate { get; set; }

        private void InitializeProcessIdTextBox()
        {
            var currentProcess = Process.GetCurrentProcess();
            processIdTextBox.Text += $" {currentProcess.Id}";
        }

        private void InitializeArgumentsTextBox(string[] args)
        {
            string text = string.Join(" ", args);
            if (string.IsNullOrEmpty(text))
            {
                text = "none";
            }

            argumentsTextBox.Text = text;
        }

        private void UpdateLastModifiedTextBox()
        {
            string text = "not available";
            DateTime? lastModified = LocalTimestamp.GetUtcDateTime();
            if (lastModified.HasValue)
            {
                text = lastModified.Value.ToLocalTime().ToString();
            }

            lastModifiedTextBox.Text = text;
        }

        private async void OnPushButtonClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                await SelfUpdate.Push();
                UpdateLastModifiedTextBox();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ShowThreadExceptionDialog(ex);
            }
        }

        private async void OnPullButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (await SelfUpdate.IsUpToDate())
                {
                    MessageBox.Show(
                        "The application is up to date.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    await SelfUpdate.Pull();
                    Cursor.Current = Cursors.Default;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowThreadExceptionDialog(ex);
            }
        }

        private void ShowThreadExceptionDialog(Exception ex)
        {
            // workaround for Mono not catching unhandled exceptions
            using (var form = new ThreadExceptionDialog(ex))
            {
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.Abort)
                {
                    Close();
                }
            }
        }
    }
}
