using Microsoft.Win32.TaskScheduler;
using System.Diagnostics;
using System.Security.Principal;
//using static System.Windows.Forms.Design.AxImporter;

namespace Rainmetrist
{
    public partial class Form1 : Form
    {
        private string AppName = "Rainmetrist";

        private string versionPrg = "1.0";

        private string taskName = "VX777__WEATHER_TASK";

        private List<TwHosts>? twHostsList;

        private TaskService ts;

        private int repeatIntervalMinutes = 5;

        private string appStartPath = Application.StartupPath;

        private Microsoft.Win32.TaskScheduler.Task myTask;

        public Form1()
        {
            InitializeComponent();

            ToolStripMenuItem configItem = new ToolStripMenuItem("Конфиг");
            configItem.Click += configItem_Click;
            menuStrip1.Items.Add(configItem);

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XMLWorker xmlWorker = new XMLWorker();
            xmlWorker.LoadConfig2(Application.StartupPath + "disp.conf", out twHostsList);
            textBox1.Text = twHostsList[0].hst;
            textBox2.Text = twHostsList[1].hst;
            textBox3.Text = twHostsList[2].hst;
            textBox4.Text = twHostsList[3].hst;
            textBox5.Text = twHostsList[0].cls;
            textBox6.Text = twHostsList[1].cls;
            textBox7.Text = twHostsList[2].cls;
            textBox8.Text = twHostsList[3].cls;
            textBox9.Text = repeatIntervalMinutes.ToString();

            buttonStop.Enabled = false;

            if ( GetRegisteredTask() )
            {
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
            }
        }

        void configItem_Click(object sender, EventArgs e)
        {
            string pathToFile = Application.StartupPath + "disp.conf";
            Process.Start("notepad.exe", pathToFile);
        }

        void aboutItem_Click(object sender, EventArgs e)
        {
            var isDebuggerAttached = System.Diagnostics.Debugger.IsAttached;
            string dbgq = string.Empty;

            if (isDebuggerAttached)
            {
                dbgq = "\n ___DEBUG_MODE___";
            }
            MessageBox.Show("Автор: Николаев Александр\n https://github.com/verelex\n trayweather@mynv.ru" + dbgq, $"{AppName} {versionPrg}");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            createScheduledTask();
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }

        private void createScheduledTask()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //using (TaskService ts = new TaskService(@"\\RemoteServer", "username", "domain", "password"))
            ts = TaskService.Instance; // Local machine

            // Create a new task definition and assign properties
            TaskDefinition td = ts.NewTask();
            td.RegistrationInfo.Author = userName;
            td.RegistrationInfo.Source = "user";
            td.RegistrationInfo.Date = DateTime.Now;
            td.RegistrationInfo.URI = @"\" + taskName;
            td.RegistrationInfo.Description = "Invoke Weather Dispatcher";
            td.RegistrationInfo.Documentation = "https://github.com/verelex";
            //td.RegistrationInfo.SecurityDescriptor = ?
            //td.RegistrationInfo.SecurityDescriptorSddlForm = ?
            //td.RegistrationInfo.XmlText = loadXML !!!???

            td.Principal.LogonType = TaskLogonType.InteractiveToken;

            // Create a trigger that will fire the task at this time everyday
            DailyTrigger dt = td.Triggers.Add( new DailyTrigger() );
            dt.StartBoundary = DateTime.Now + TimeSpan.FromMinutes(1);
            //dt.EndBoundary = null;
            double d = double.Parse(textBox9.Text, System.Globalization.CultureInfo.InvariantCulture);
            dt.Repetition.Interval = TimeSpan.FromMinutes(d); // повторять через N минут
            dt.Repetition.Duration = TimeSpan.Zero; // постоянно
            dt.Repetition.StopAtDurationEnd = false;

            td.Settings.StartWhenAvailable = true;
            td.Settings.DisallowStartIfOnBatteries = false;
            td.Settings.AllowHardTerminate = false;
            td.Settings.AllowDemandStart = true; // по требованю
            td.Settings.StartWhenAvailable = true; // tckb ghjgeotyj
            td.Settings.StopIfGoingOnBatteries = false;
            td.Settings.DeleteExpiredTaskAfter = TimeSpan.Zero; // not deletable
            td.Settings.Enabled = true;
            td.Settings.ExecutionTimeLimit = TimeSpan.Zero; // infinity
            td.Settings.RestartCount = 3;
            td.Settings.RestartInterval = TimeSpan.FromMinutes(1);
            td.Settings.Hidden = false;
            td.Settings.UseUnifiedSchedulingEngine = true;
            td.Settings.RunOnlyIfIdle = false;
            td.Settings.WakeToRun = false;
            td.Settings.IdleSettings.StopOnIdleEnd = false;
            td.Settings.IdleSettings.RestartOnIdle = false;
            //td.Settings.

            // Create an action that will launch Notepad whenever the trigger fires
            //td.Actions.Add(new ExecAction("notepad.exe", @"C:\Users\verel\Desktop\test.log", appStartPath));
            td.Actions.Add(new ExecAction( appStartPath + "WeatherDispatcher1.exe", "VXNKL", appStartPath) );

            // Register the task in the root folder.
            // (Use the username here to ensure remote registration works.)
            //ts.RootFolder.RegisterTaskDefinition(@"Test", td, TaskCreation.CreateOrUpdate, "username");
            myTask = ts.RootFolder.RegisterTaskDefinition(taskName, td);
            
        }

        private bool GetRegisteredTask()
        {
            if (ts == null)
            {
                ts = TaskService.Instance; // Local machine
            }

            if (myTask == null)
            {
                myTask = ts.GetTask(taskName);
                if (myTask == null)
                {
                    return false;
                }
            }

            if (myTask != null)
            {
                return true;  // Task already registered
            }
  
            return false; // Task not present
        }

        private void DeleteTask()
        {
            // Retrieve the task, change the trigger and re-register it.
            // A taskName by itself assumes the root folder
            /*if (ts == null) 
            {
                ts = TaskService.Instance; // Local machine
            }

            if (myTask == null)
            {
                myTask = ts.GetTask(taskName);
                if (myTask == null) return;
            }
            myTask.Definition.Triggers[0].StartBoundary = DateTime.Today + TimeSpan.FromDays(7);
            myTask.RegisterChanges();
            */
            // Check to make sure account privileges allow task deletion
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                throw new Exception($"Не возможно удалить задачу с правами '{identity.Name}' нет нужного уровня доступа." +
                "Попробуйте запустить программу с правами администратора.");

            // Remove the task we just created
            ts.RootFolder.DeleteTask(taskName);
        }

        private void buttonSaveCfg_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Сохранить конфиг?", "Опции были изменены", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {

                twHostsList[0].SetAll(textBox1.Text, textBox5.Text);
                twHostsList[1].SetAll(textBox2.Text, textBox6.Text);
                twHostsList[2].SetAll(textBox3.Text, textBox7.Text);
                twHostsList[3].SetAll(textBox4.Text, textBox8.Text);

                XMLWorker xmlWorker = new XMLWorker();
                xmlWorker.SaveConfig2(Application.StartupPath + "disp.conf", twHostsList);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (GetRegisteredTask())
            {
                DeleteTask();
            }
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //
        }
    }
}
