using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPlingGUI
{
    public partial class MainForm : Form
    {
        private string tsharkPath = "";
        private string programDir = Environment.CurrentDirectory.ToString();
        private bool running = false;
        private Process process = new Process();
        private List<int> streams = new List<int>();


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string pfx86Path = @"C:\Program Files (x86)\Wireshark\tshark.exe";
            string pfPath = @"C:\Program Files\Wireshark\tshark.exe";
            if (File.Exists(pfPath))
            {
                tsharkPath = pfPath;
                
            }
            if (File.Exists(pfx86Path))
            {
                tsharkPath = pfx86Path;
            }
            if (tsharkPath == "")
            {
                MessageBox.Show("Wireshark installation not found.", "File not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            var tcpDumpProc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = tsharkPath,
                    Arguments = "-D",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            tcpDumpProc.Start();
            while (!tcpDumpProc.StandardOutput.EndOfStream)
            {
                string line = tcpDumpProc.StandardOutput.ReadLine();
                cbNIC.Items.Add(line);
            }

            
            string networksFile = programDir + @"\networks.txt";
            if (File.Exists(networksFile))
            {
                rtbNetworks.Text = File.ReadAllText(networksFile);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string networksFile = programDir + @"\networks.txt";
            File.WriteAllText(networksFile, rtbNetworks.Text);
            try
            {
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
            catch { }
        }

        private void StartProcess(string nic, string filter)
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo
            {
                FileName = tsharkPath,
                Arguments = "-i " + nic + " -f \"(" + filter + ") and (dst port 80 or dst port 443)\" -T fields -e tcp.len -l",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            process.StartInfo = StartInfo;
            process.OutputDataReceived += (sender, args) => ProcessData(args.Data);
            process.ErrorDataReceived += (sender, args) => ProcessData(args.Data);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

        }
        private void ProcessData(string data)
        {
            if (Int32.TryParse(data, out int val))
            {

                if (val > 0)
                {
                    Console.Beep(250, 100);
                }
            }
            
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if (running)
            {
                process.Kill();
                btnControl.Text = "Start";
                btnControl.BackColor = SystemColors.Control;
                running = false;
            } else
            {
                btnControl.Text = "Stop";
                btnControl.BackColor = Color.FromName("Green");
                string nic = cbNIC.Items[cbNIC.SelectedIndex].ToString().Split('.')[0];
                string filter = "dst net ";

                foreach (string line in rtbNetworks.Lines)
                {
                    filter += line + " or dst net ";
                }

                filter = filter.Remove(filter.Length - 12);
                StartProcess(nic, filter);    
                running = true;
            }
        }
    }
}
