using NationalInstruments.Net;
using NationalInstruments.Analysis;
using NationalInstruments.Analysis.Conversion;
using NationalInstruments.Analysis.Dsp;
using NationalInstruments.Analysis.Dsp.Filters;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis.Monitoring;
using NationalInstruments.Analysis.SignalGeneration;
using NationalInstruments.Analysis.SpectralMeasurements;
using NationalInstruments;
using NationalInstruments.UI;
using NationalInstruments.UI.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Linq;
using System.IO.Compression;
using System.Net;
using System.Globalization;

namespace projectTest1
{
    public partial class DefaultLayout : Form
    {
        //DIRECTORIES;
        static string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // AppData folder
        static string CFGFOLDER_PATH = Path.Combine(APPDATA_PATH, "Configs");     // Path for program config folder

        string labzipfile = "";
        string labfolder_path ="";
        string CFGFILE_PATH = "";   //Path for config.txt file         
        string labTimeFile = Path.Combine(CFGFOLDER_PATH, "labTime.txt");
        static string labReport_path = Path.Combine(CFGFOLDER_PATH, "labreport.txt"); // AppData folder
        static string download_report_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //report saved here for user;

        //VARIABLES;
        List<string> allknob1values = new List<string>();
        List<string> allknob2values = new List<string>();

        string datetime { get; set; }
        List<Channel> channels;
        private int numberOfChannels;
        string data1 = null;
        XDocument xdoc = new XDocument();
        List<Switch> switches;
        private int numberOfSwitches;   
        int time = 2400; //stands for 40 minutes of lab interaction time;
        int counter = 0;
        bool pause_state = false;
        bool finish_state = false;
        string xmltotxt = null;
        string encryptrpt = null;
        public string Key = "Nsi2k19!";
        private Bitmap bmp;
        private bool lab_state { get; set; } = false;
        private bool start_lab_state { get; set; } = false;
        private bool switch_creation_state { get; set; } = false;

        private string Device { get; set; } = "Dev1"; // default device name
        private string apiKey { get; set; } = "1234"; // default api key
        private string apiPort { get; set; } = "9000"; // default api port
        private string hostAddress { get; set; }
        private string runlab { get; set; } 
        
        public DefaultLayout()
        {
            InitializeComponent();
            existingLabs();
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void knob1_AfterChangeValue(object sender, AfterChangeNumericValueEventArgs e)
        {
            var knob2value = amplitude_knob.Value.ToString();
            var knob1value = frequency_knob.Value.ToString();            
        }

        private void knob2_AfterChangeValue(object sender, AfterChangeNumericValueEventArgs e)
        {
             var knob2value = amplitude_knob.Value.ToString();
             var knob1value = frequency_knob.Value.ToString();
        }
        private void knob2_MouseUp(object sender, MouseEventArgs e)
        {
            var knob2value = amplitude_knob.Value.ToString();
            var knob1value = frequency_knob.Value.ToString();
            allknob2values.Add(knob2value);
            Change_Wave();
        }

        private void knob1_MouseUp(object sender, MouseEventArgs e)
        {
            var knob2value = amplitude_knob.Value.ToString();
            var knob1value = frequency_knob.Value.ToString();
            allknob1values.Add(knob1value);
            Change_Wave();
        }
           
        //Uploading the lab files
        private void uploadLabToolStripMenuItem_Click(object sender, EventArgs e)
        {        
           if (!Directory.Exists(CFGFOLDER_PATH))
           {
                   Directory.CreateDirectory(CFGFOLDER_PATH); 
                   appDataXmlfile();
           }
           else
           {
                  appDataXmlfile();
           }      
                      
        }

        //Adding the xmlLabFile to appData files
        private void appDataXmlfile()
        {           
                var openDialog = new OpenFileDialog()
                {   
                    Filter = "Lab Files (*.zip)|*.zip",
                 };

                if (openDialog.ShowDialog() == DialogResult.OK)
                {                   
                    //ToDo                    
                    bool isValidLabFile = false;
                    try
                    {
                        using (ZipArchive zip = ZipFile.Open(openDialog.FileName, ZipArchiveMode.Read))
                        {
                            labzipfile = Path.GetFileNameWithoutExtension(openDialog.FileName);
                            labfolder_path = Path.Combine(CFGFOLDER_PATH, labzipfile);
                            CFGFILE_PATH = Path.Combine(labfolder_path, "lab.xml");

                            if (!Directory.Exists(Path.Combine(CFGFOLDER_PATH, Path.GetFileNameWithoutExtension(openDialog.FileName))))
                            {
                                foreach (ZipArchiveEntry entry in zip.Entries)
                                {
                                    if (entry.Name.Equals("lab.xml"))
                                    {
                                        isValidLabFile = true;
                                        break;
                                    }
                                }

                                if (isValidLabFile)
                                {                                                                   
                                    zip.ExtractToDirectory(Path.Combine(CFGFOLDER_PATH, labzipfile));                                 
                                   
                                }     
                            }
                            else
                            {
                                MessageBox.Show("Labfile already exists please just select i from the combo box!");
                            }                                                  
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }           
        }
        
        //adding existing labs to the combbox
        private void existingLabs()
        {
          //  ExistingLabList = "--select lab--";
            if (Directory.Exists(CFGFOLDER_PATH))
            {
                string[] existingFiles = Directory.GetDirectories(CFGFOLDER_PATH);
                List<string> labsAvailable = new List<string>();
                foreach (string item in existingFiles)
                {
                    labsAvailable.Add(Path.GetFileName(item));
                }
                ExistingLabList.Items.Clear();
                ExistingLabList.Items.AddRange(labsAvailable.ToArray());
            }
        }
        
        //loading the content from the xml file
        public void LoadCurrentFile(string path)
        {
            try
            {
            XDocument labDoc = XDocument.Load(path);

                Device = (from dev in labDoc.Descendants("Setting")
                              where (string)dev.Attribute("Name") == "Device"
                              select (string)dev.Attribute("Value").Value).FirstOrDefault();

                hostAddress = (from dev in labDoc.Descendants("Setting")
                               where (string)dev.Attribute("Name") == "Lab Url"
                               select (string)dev.Attribute("Value").Value).FirstOrDefault();
                
                switches = (from dev in labDoc.Descendants("Setting")
                            where (string)dev.Attribute("Type").Value == "Switch"
                            select new Switch
                            {
                                Name = dev.Attribute("Name").Value,
                                Url = dev.Attribute("Value").Value,
                              //  Index = int.Parse(dev.Attribute("Index").Value)
                            }).ToList<Switch>();

                channels = (from channel in labDoc.Descendants("Setting")
                            where (string)channel.Attribute("Type").Value == "Channel"
                            select new Channel
                            {
                                Name = channel.Attribute("Name").Value,
                                Url = channel.Attribute("Value").Value,
                                //DevicePath = "",//channel.Attribute("DevicePath").Value,
                                Index = int.Parse(channel.Attribute("Index").Value)
                            }
                                         ).ToList<Channel>();

                numberOfChannels = channels.Count();
                numberOfSwitches = switches.Count();

                CreateChannels(channels, hostAddress);
                lab_Circuit.Image = Image.FromFile(Path.Combine(labfolder_path, "images", "ON_OFF" + ".png"));
                label2.Visible = true;
                CreateSwitches(switches, hostAddress);
                ConnectDataSockets();                     

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //creating the switches
        public void CreateSwitches(List<Switch> labSwitches, string hostAddress)
        {           
            foreach (Switch _switch in labSwitches)
            {
                 NationalInstruments.UI.WindowsForms.Switch sw = new NationalInstruments.UI.WindowsForms.Switch();
                 ((System.ComponentModel.ISupportInitialize)(sw)).BeginInit();               
                sw.OffColor = System.Drawing.Color.Blue;
                sw.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                sw.Size = new System.Drawing.Size(58, 77);
                sw.SwitchStyle = NationalInstruments.UI.SwitchStyle.HorizontalSlide3D;
                sw.TabIndex = 5;
                sw.Value = true;
                sw.Name = _switch.Name;              
                ((System.ComponentModel.ISupportInitialize)(sw)).EndInit();
                flowLayoutPanel1.Controls.Add(sw);
                sw.StateChanged += new NationalInstruments.UI.ActionEventHandler(switches_StateChanged);
                this.components.Add(sw);
                switch_creation_state = true;
            }          
        }

        string GetSwState(bool st){
            if (st == true)
                return "on";
            else
                return "off";
        }

        void switches_StateChanged(object sender, ActionEventArgs e)
        {      
            var labSwitches = this.components.Components.OfType<NationalInstruments.UI.WindowsForms.Switch>();
            string val="";           
           
            foreach (var sw in labSwitches)
            {
                val += GetSwState(sw.Value) + "_";
            }
            if (Directory.Exists(Path.Combine(labfolder_path, "images")))
            {
                try
                {
                    val = val.Remove(val.Length - 1);
                    textBox1.Visible = false;
                    lab_Circuit.Image = Image.FromFile(Path.Combine(labfolder_path, "images", val + ".png"));
                    Toggle_Switches();
                }
                catch (Exception ex)
                {
                    lab_Circuit.Image = null;
                    textBox1.Visible = true;
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No image file exists");
                
            }
           
         }

        //creating channels for data transfer
        public void CreateChannels(List<Channel> channels, string hostAddress)
        {
            // creating the wave forms
            List<Color> colors = new List<Color> { System.Drawing.Color.Green, 
                  System.Drawing.Color.Blue, System.Drawing.Color.Red,
                  System.Drawing.Color.White,System.Drawing.Color.Brown,
                  System.Drawing.Color.DarkCyan,System.Drawing.Color.DarkOrange,System.Drawing.Color.Gainsboro};

            waveformGraph1.Plots.Clear();
            for (int i = 0; i < channels.Count; i++)
            {
                WaveformPlot plot = new WaveformPlot();

                plot.LineColor = colors[i];
                plot.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
                plot.XAxis = this.xAxis1;
                plot.YAxis = this.yAxis1;
                this.waveformGraph1.Plots.Add(plot);
            }

            //create dataSockets
            foreach (Channel channel in channels)
            {
                DataSocket dataSocket = new DataSocket(this.components);
                ((System.ComponentModel.ISupportInitialize)(dataSocket)).BeginInit();

                ((System.ComponentModel.ISupportInitialize)(dataSocket)).EndInit();

                dataSocket.Url = "dstp://" + hostAddress + channel.Url;
                dataSocket.AccessMode = NationalInstruments.Net.AccessMode.ReadAutoUpdate;
                dataSocket.DataUpdated += (object sender, DataUpdatedEventArgs e) =>
                                              {
                                                  DataSocket dS = (DataSocket)sender;

                                                  waveformGraph1.Plots[channel.Index].PlotY((double[])e.Data.Value);
                                              };
            }
        }

        //Connectiong to the data sockets
        public void ConnectDataSockets()
        {
            try
            {
                foreach (var dataSocket in this.components.Components.OfType<DataSocket>())
                {
                    if (dataSocket.IsConnected)
                        dataSocket.Disconnect();
                    dataSocket.Connect();
                    start_lab_state = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Disconnecting from the data socket
        public void DisConnectDataSockets()
        {
            try
            {
                foreach (var dataSocket in this.components.Components.OfType<DataSocket>())
                {
                    if (dataSocket.IsConnected)
                        dataSocket.Disconnect();
                    start_lab_state = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }            

        private void startLabToolStripMenuItem_Click(object sender, EventArgs e)
        {           

            try
            {
                if (ExistingLabList.SelectedIndex > -1)
                {
                  
                    labzipfile = runlab;
                    labfolder_path = Path.Combine(CFGFOLDER_PATH, labzipfile);
                    CFGFILE_PATH = Path.Combine(labfolder_path, "lab.xml");
                   
                    if (File.Exists(labTimeFile))
                    {
                        MessageBox.Show("Please resume your lab", "Start Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (File.Exists(CFGFILE_PATH))
                        {
                            XDocument labDoc = XDocument.Load(CFGFILE_PATH);
                            datetime = (from dev in labDoc.Descendants("Setting")
                                               where (string)dev.Attribute("Name") == "DateTime"
                                               select (string)dev.Attribute("Value").Value).FirstOrDefault();
                            apiPort = (from dev in labDoc.Descendants("Setting")
                                       where (string)dev.Attribute("Name") == "Api Port"
                                       select (string)dev.Attribute("Value").Value).FirstOrDefault();

                            hostAddress = (from dev in labDoc.Descendants("Setting")
                                           where (string)dev.Attribute("Name") == "Lab Url"
                                           select (string)dev.Attribute("Value").Value).FirstOrDefault();
                            string url = $"http://{hostAddress}:{apiPort}/api/time";

                            //var support_Response = Support.GetFromServer(url);                          

                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                            request.Method = "Get";
                            request.ContentType = "application/x-www-form-urlencoded";
                            request.KeepAlive = true;

                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            string myResponse = "";

                            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                            {
                                myResponse = sr.ReadToEnd();
                            }

                            //MessageBox.Show(myResponse + "\n" + m); // DEBUG MODE;

                            String serverdatetime = myResponse.ToString().Substring(1, myResponse.Length - 2);
                            DateTime servertime = DateTime.Parse(serverdatetime);

                            DateTime scheduletime = DateTime.Parse(datetime);
                            DateTime duration = scheduletime.AddMinutes(30);

                            try
                            {                              
                                if (servertime.ToShortDateString().Equals(scheduletime.ToShortDateString()))
                                {
                                    if (servertime.TimeOfDay >= scheduletime.TimeOfDay && servertime.TimeOfDay <= duration.TimeOfDay)
                                    {
                                        timer1.Enabled = true;
                                        timer1.Start();
                                        LoadCurrentFile(CFGFILE_PATH);
                                    }
                                    else if (servertime.TimeOfDay >= scheduletime.TimeOfDay && servertime.TimeOfDay > duration.TimeOfDay)
                                    {
                                        MessageBox.Show("Please Reschedule for the Lab!", "Schedule Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please wait for Lab time!", "Schedule Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please varify date scheduled", "Schedule Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }

                        else
                        {
                            MessageBox.Show("Upload lab file", "Start Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a lab to do!", "Start Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message  );
            }
            
          
          }

        // generatinng the lab report
        private void generatingLabReport()
        {
            //taking the graph screenshot
            using (Bitmap step1 = new Bitmap(waveformGraph1.ClientSize.Width, waveformGraph1.ClientSize.Height))
            {
                waveformGraph1.DrawToBitmap(step1, waveformGraph1.ClientRectangle);
                using (MemoryStream mem = new MemoryStream())
                {
                    step1.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
                    data1 = Convert.ToBase64String(mem.ToArray());

                }
            }

            XElement frequencies = new XElement("Frequencies",
               from f in allknob1values
               select
               new XElement("Frequency", f)
               );

            XElement amplitude = new XElement("Amplitudes",
                from a in allknob2values
                select
                new XElement("Amplitude", a)
                );

            var i = new List<pictures>() { 
                    new pictures() {ID = 3, image= data1},                      
                    };

            XElement labimages = new XElement("LabImages",
                     from emp in i
                     select
                         new XElement("ID", emp.ID,
                         new XElement("Image", emp.image)));

            xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("root", frequencies, amplitude, labimages));
            xmltotxt = xdoc.ToString();
            encryptrpt = AesEncryption.EncryptDataAES(xmltotxt, Key);
            
            
            if (Directory.Exists(CFGFOLDER_PATH))
            {                
                
                if (!File.Exists(labReport_path))
                {                  
                    StreamWriter savereport = new StreamWriter(labReport_path, true);
                    savereport.WriteLine(encryptrpt);
                    savereport.Close();                  
                }
                else
                {
                    MessageBox.Show("Lab already finished");
                }
            }
        }

        //downloading the labreport from appdata
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // var labreport_file = string.Empty;
            if(Directory.Exists(CFGFOLDER_PATH))
            {
                if(File.Exists(labReport_path))
                {
                    string dest= "labreport.txt";
                    string targetPath = download_report_path;
                    string destFile = Path.Combine(targetPath, dest);
                    if (!File.Exists(destFile))
                    {        
                        
                        File.Copy(labReport_path, destFile);                      
                        MessageBox.Show("Lab report saved to Downloads", "Report Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lab report already downloaded", "Report Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                  
                }
                else
                {
                    MessageBox.Show("No lab was done, please first do the lab","Report Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No lab was uploaded", "Report Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //changing the waveform
        public void Change_Wave()
        {
            var amp = amplitude_knob.Value.ToString();
            var freq = frequency_knob.Value.ToString();
            string wave_type = comboBox1.GetItemText(comboBox1.SelectedItem).ToLower();
            /*new code*/
            var url = "http://"+hostAddress+":"+apiPort+"/api/values";
            //params
            List<KeyValuePair<string, string>> @params = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Amplitude", amp),
                new KeyValuePair<string, string>("Frequency", freq),
                new KeyValuePair<string, string>("WaveType", wave_type),
                new KeyValuePair<string, string>("Device", Device),
                new KeyValuePair<string, string>("ApiKey", apiKey),

            };
            try
            {
               var response = Support.PostToServer(url, @params);
               if (response != "\"OK\"")
               {
                   MessageBox.Show("Value change failed");
               }
            }

            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message + "\n Please start lab", "Lab Interface Error");
                MessageBox.Show(ex.Message + "\n Please first Start Lab to make changes", "Lab Interface Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
            
        }

        private void Toggle_Switches()
        {
            var url = "http://" + hostAddress + ":"+apiPort+"/api/switch";
            var switch_values = new List<KeyValuePair<string, string>>();
            foreach (var sw in this.components.Components.OfType<NationalInstruments.UI.WindowsForms.Switch>())
            {
                switch_values.Add(new KeyValuePair<string, string>(sw.Name, GetSwState(sw.Value)));
            }
            switch_values.Add(new KeyValuePair<string, string>("APIKey", apiKey));
            switch_values.Add(new KeyValuePair<string, string>("Device", Device));
            try
            {
                var response = Support.PostToServer(url, switch_values);
                if (response != "\"OK\"")
                {
                    MessageBox.Show("Switch Value change failed");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Toggle Switch Error:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {            
            double new_time =  time--; // use double dataype for seconds //timespan intakes double values
            double lab_time = time--;

            TimeSpan timeSpan = TimeSpan.FromSeconds(lab_time);
            string dispay_time = timeSpan.ToString(@"hh\:mm\:ss\:fff");
            //Time.Text = new_time.ToString(); // displays seconds only;
            TimeDisplay.Text = dispay_time;

            if (new_time == 0)
            {
                timer1.Stop();
                DisConnectDataSockets();
                generatingLabReport();
                deleteXmlFile();
            }

            counter++;
            if (counter == 2) 
            {
                counter = 0;
                existingLabs();
                if (Directory.Exists(CFGFOLDER_PATH))
                {                  
                    File.WriteAllText(labTimeFile, new_time.ToString() + "\n" + runlab);                   
                }
                else
                {
                    Directory.CreateDirectory(CFGFOLDER_PATH);
                    File.WriteAllText(labTimeFile, new_time.ToString());                 
                }
            }
            
        }
            
        //Finishing the current lab
        private void finishLabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisConnectDataSockets();           
            generatingLabReport();
            finish_state = true;
            resumeToolStripMenuItem.Enabled = true;
        }

        //closing existing lab
        private void closeLabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset_Lab_Interface();     //resets all controls to default state;   
        }

        //deleting existing lab file
        private void deleteXmlFile()
        {
            if (Directory.Exists(CFGFOLDER_PATH))
            {
                string[] files = Directory.GetFiles(CFGFOLDER_PATH);           
       
                try
                {                   
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail");
                }                        
              
            }           
        }

        //screenshoting the graphs
        private void screenShotToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dialogue = new SaveFileDialog();
            dialogue.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png|Txt Image|*.txt";
            if (dialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)dialogue.OpenFile();
                if (dialogue.FileName != "")
                {
                    using (bmp = new Bitmap(waveformGraph1.ClientSize.Width, waveformGraph1.ClientSize.Height))
                    {
                        waveformGraph1.DrawToBitmap(bmp, waveformGraph1.ClientRectangle);
                        bmp.Save(fs, ImageFormat.Png);
                    }               
                   
                }
            }
        }

        //Pausing the lab
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisConnectDataSockets();
            pause_state = true;
            resumeToolStripMenuItem.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Change_Wave();
        }  
        //resuming from a pause
        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (pause_state == true)
            {
                ConnectDataSockets();
                resumeToolStripMenuItem.Enabled = false;
                
            }
            else if (finish_state == true)
            {
                ConnectDataSockets();
            }
            else
            {
                try
                {

                    if (ExistingLabList.SelectedIndex > -1)
                    {                       
                        labzipfile = runlab;
                        labfolder_path = Path.Combine(CFGFOLDER_PATH, labzipfile);
                        CFGFILE_PATH = Path.Combine(labfolder_path, "lab.xml");
                       // ExistingLabList.Enabled = false;                       
                        if (File.Exists(CFGFILE_PATH))
                        {
                            XDocument labDoc = XDocument.Load(CFGFILE_PATH);
                            datetime = (from dev in labDoc.Descendants("Setting")
                                               where (string)dev.Attribute("Name") == "DateTime"
                                               select (string)dev.Attribute("Value").Value).FirstOrDefault();
                            apiPort = (from dev in labDoc.Descendants("Setting")
                                       where (string)dev.Attribute("Name") == "Api Port"
                                       select (string)dev.Attribute("Value").Value).FirstOrDefault();

                            hostAddress = (from dev in labDoc.Descendants("Setting")
                                           where (string)dev.Attribute("Name") == "Lab Url"
                                           select (string)dev.Attribute("Value").Value).FirstOrDefault();

                            string baseAddress = "http://" + hostAddress + ":"+apiPort+"/api/time";

                            //var support_Response = Support.GetFromServer(baseAddress);

                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseAddress);
                            request.Method = "Get";
                            request.KeepAlive = true;

                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            string myResponse = "";

                            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                            {
                                myResponse = sr.ReadToEnd();
                            }

                            String serverdatetime = myResponse.ToString().Substring(1, myResponse.Length - 2);
                            DateTime servertime = DateTime.Parse(serverdatetime);
                            DateTime scheduletime = DateTime.Parse(datetime);
                            DateTime duration = scheduletime.AddMinutes(30);

                        try
                        {                  
                            if (servertime.ToShortDateString().Equals(scheduletime.ToShortDateString()))
                                {
                                    if (servertime.TimeOfDay >= scheduletime.TimeOfDay && servertime.TimeOfDay <= duration.TimeOfDay)
                                    {
                                        if (File.Exists(labTimeFile))
                                        {
                                            string remainingtime = File.ReadLines(labTimeFile).First();

                                            if (int.Parse(remainingtime) != 0)
                                            {
                                                time = int.Parse(remainingtime);
                                                timer1.Start();
                                                LoadCurrentFile(CFGFILE_PATH);
                                            }
                                            else
                                            {
                                                MessageBox.Show("No remaining time");
                                                DisConnectDataSockets();
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("No lab was running");
                                        }
                                        resumeToolStripMenuItem.Enabled = false;

                                    }
                                    else if (servertime.TimeOfDay >= scheduletime.TimeOfDay && servertime.TimeOfDay > duration.TimeOfDay)
                                    {
                                        MessageBox.Show("Please Reschedule for the Lab.");

                                    }
                                    else
                                    {
                                        MessageBox.Show("Not yet time.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please verify date scheduled.");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }

                        else
                        {
                            MessageBox.Show("Upload lab file.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a recent lab.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
            
        }

        public class Channel
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string DevicePath { get; set; }
            public int Index { get; set; }
        }

        public class pictures
        {
            public int ID { get; set; }
            public string image { get; set; }
        }
        public class Switch
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string DevicePath { get; set; }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = 1;
        }

        private void ExistingLabList_SelectedIndexChanged(object sender, EventArgs e)
        {
            runlab = ExistingLabList.GetItemText(ExistingLabList.SelectedItem);
            lab_state = true;
           if (lab_state ==  true && switch_creation_state == true)
            {
                MessageBox.Show("Please close the running lab");
            }      
        }

        private void Time_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reset_Lab_Interface()
        {
            timer1.Stop();
            DisConnectDataSockets();
            lab_Circuit.Image = null;
            deleteXmlFile();

            List<Control> listControls = new List<Control>();
            List<Control> waveform_controls = new List<Control>();
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                listControls.Add(control);
            }
            foreach (Control control in listControls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
                switch_creation_state = false;
            }

            foreach (WaveformPlot plot in waveformGraph1.Plots)
            {
                plot.ClearData();
            }

            waveformGraph1.Plots.Clear();
            //foreach (Control wave_control in waveformPl)
            //{

            //}
        }
    }
}
