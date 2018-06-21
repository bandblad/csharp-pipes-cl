using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace main_proc_client
{
    public partial class MainWindow : Form
    {
        volatile NamedPipeClientStream namedPipe = null;
        volatile string pipeName = null;
        volatile bool isConnectedToPipe = false;

        private void LogToWindow(string info)
        {
            rtbLogWindow.Invoke((MethodInvoker)(() =>
            {
                rtbLogWindow.AppendText($"\r\n{DateTime.Now.ToLocalTime()} <=> {info}");
                rtbLogWindow.ScrollToCaret();
            }));
        }

        private void setCTextInvoke(Control target, string arg)
        {
            target.Invoke((MethodInvoker)(() => target.Text = arg));
        }

        private void setCEnabledInvoke(Control target, bool arg)
        {
            target.Invoke((MethodInvoker)(() => target.Enabled = arg));
        }

        public MainWindow()
        {
            InitializeComponent();

            // Create event handlers
            bSubmit.Click += BSubmit_Click;
            bSendMessage.Click += BSendMessage_Click;
            FormClosing += MainWindow_FormClosing;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool Reason = e.CloseReason == CloseReason.UserClosing;
            bool Length = rtbLogWindow.Text.Length > 0;

            if (Reason && Length)
            {
                var result = MessageBox.Show(
                    "Do you want to save application .log file?", 
                    "Question", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button1
                    );

                // Save log to file if user agreed
                if (result == DialogResult.Yes)
                {
                    using (var sfd = new SaveFileDialog())
                    {
                        sfd.RestoreDirectory = true;
                        sfd.FileName = $"{DateTime.Now.Ticks}.log";
                        sfd.DefaultExt = "log";
                        sfd.Filter = "Log files (*.log)|*.log";

                        if (sfd.ShowDialog() == DialogResult.OK)
                            using (var sw = new StreamWriter(sfd.OpenFile()))
                                sw.WriteLine(rtbLogWindow.Text);
                    }
                }
            }
        }

        private void BSendMessage_Click(object sender, EventArgs e)
        {
            // Create separate thread for sending messages
            var ButtonHandlerThread = new Thread(() =>
            {
                try
                {
                    // Write message to pipe
                    var message = tbMessage.Text;
                    if (message.Length > 0)
                    {
                        var bBuffer = Encoding.Unicode.GetBytes(message);
                        var bBufferCount = Encoding.Unicode.GetByteCount(message);

                        namedPipe.Write(bBuffer, 0, bBufferCount);

                        // Add new entry to log
                        LogToWindow($"Client sent message: {message};");
                    }
                }
                catch (ArgumentException)
                {
                    LogToWindow("Message buffer failed;");
                }
                catch (Exception)
                {
                    LogToWindow($"Client lost connection to [{pipeName}];");

                    isConnectedToPipe = false;
                    setCEnabledInvoke(bSendMessage, false);
                    setCEnabledInvoke(tbMessage, false);

                    if (namedPipe != null)
                    {
                        namedPipe.Close();
                        namedPipe = null;
                    }

                    // Change text of button
                    setCTextInvoke(bSubmit, "Connect");
                }
            });
            ButtonHandlerThread.IsBackground = true;
            ButtonHandlerThread.Start();
        }

        private void BSubmit_Click(object sender, EventArgs e)
        {
            // Start new thread 
            // and connect/disconnect pipe
            var ButtonHandlerThread = new Thread(() =>
            {
                // Disable button so client can't
                // interrupt operations
                setCEnabledInvoke(tbPipeName, false);
                setCEnabledInvoke(bSubmit, false);

                // Connect/Disconnect client
                if (isConnectedToPipe)
                {
                    // Disconnect old pipe
                    isConnectedToPipe = false;
                    setCEnabledInvoke(bSendMessage, false);
                    setCEnabledInvoke(tbMessage, false);

                    if (namedPipe != null)
                    {
                        namedPipe.Close();
                        namedPipe = null;
                    }

                    // Change text of button
                    setCTextInvoke(bSubmit, "Connect");

                    // Add new entry to log
                    LogToWindow($"Client disconnected from pipe [{pipeName}];");
                }
                else
                {
                    // Update pipe name and connect to server
                    if ((pipeName = tbPipeName.Text).Length > 0)
                    {
                        // Create new one-directional Named Pipe
                        namedPipe = new NamedPipeClientStream(".", pipeName, PipeDirection.Out);

                        // Try to connect client side 
                        // with server side of pipe
                        try
                        {
                            namedPipe.Connect(5000);
                            LogToWindow($"Client connected to pipe [{pipeName}];");

                            // Unblock message section
                            isConnectedToPipe = true;
                            setCEnabledInvoke(bSendMessage, true);
                            setCEnabledInvoke(tbMessage, true);

                            // Change text of button
                            setCTextInvoke(bSubmit, "Disconnect");
                        }
                        catch (Exception)
                        {
                            LogToWindow($"Failed to connect to pipe [{pipeName}];");
                        }
                    }
                    else
                        LogToWindow("Pipe name can't be empty string;");
                }

                // Re-enable button
                setCEnabledInvoke(bSubmit, true);
                setCEnabledInvoke(tbPipeName, true);
            });
            ButtonHandlerThread.IsBackground = true;
            ButtonHandlerThread.Start();
        }
    }
}
