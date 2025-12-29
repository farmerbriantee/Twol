using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using Twol.Classes;
using Twol.Classes.Tool;
using Twol.Mapping;
using Twol.Properties;

namespace Twol
{
    //the main form object
    public partial class FormGPS : Form
    {
        //To bring forward  if running
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWind, int nCmdShow);

        #region // Class Props and instances

        //maximum sections available
        public const int MAXSECTIONS = 256;

        //current fields
        public string currentFieldDirectory, displayFieldName, currentJobDirectory, displayJobName;

        private bool leftMouseDownOnOpenGL, rightMouseDown; //mousedown event in opengl window
        public int flagNumberPicked = 0;

        //bool for whether or not a Field and job is active
        public bool isFieldStarted = false, isJobStarted = false, isBtnAutoSteerOn;

        //texture holders
        public uint[] texture;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swFrame = new Stopwatch();

        private readonly Stopwatch algoTimer = new Stopwatch();

        public double secondsSinceStart;
        public double gridToolSpacing;

        //the currentversion of software
        public string currentVersionStr, inoVersionStr;

        public int inoVersionInt;

        //private readonly Stopwatch swDraw = new Stopwatch();
        //swDraw.Reset();
        //swDraw.Start();
        //swDraw.Stop();
        //label3.Text = ((double) swDraw.ElapsedTicks / (double) System.Diagnostics.Stopwatch.Frequency * 1000).ToString();

        //Time to do fix position update and draw routine
        public double frameTime = 0;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        //private readonly Stopwatch swHz = new Stopwatch();

        //Time to do fix position update and draw routine
        public double gpsHz = 10;

        public int pbarSteer, pbarMachine, pbarUDP;

        public double nudNumber = 0;

        public char[] hotkeys;

        //used by filePicker Form to return picked file and directory
        public string filePickerFileAndDirectory, jobPickerFileAndDirectory;

        //the position of the GPS Data window within the FormGPS window
        public int GPSDataWindowLeft = 80, GPSDataWindowTopOffset = 220;

        //the autoManual drive button. Assume in Auto
        public bool isInAutoDrive = true;

        //isGPSData form up
        public bool isGPSSentencesOn = false, isKeepOffsetsOn = false;

        /// <summary>
        /// create the scene camera
        /// </summary>
        public CCamera camera;

        /// <summary>
        /// create world grid
        /// </summary>
        public WorldFloor worldGrid;

        /// <summary>
        /// Represents the world map associated with the current instance.
        /// </summary>
        public WorldTileMap worldMap;

        /// <summary>
        /// The NMEA class that decodes it
        /// </summary>
        public CNMEA pn;

        /// <summary>
        /// The NMEA class that decodes it
        /// </summary>
        public CNMEA pnTool;

        /// <summary>
        /// a List of patches to draw
        /// </summary>
        public List<CPatches> triStrip = new List<CPatches>();

        /// <summary>
        /// TramLine class for boundary and settings
        /// </summary>
        public CTram tram;

        /// <summary>
        /// Contour Mode Instance
        /// </summary>
        public CContour ct;

        /// <summary>
        /// Track Instance
        /// </summary>
        public CTracks trk;

        /// <summary>
        /// Tool Track Instance
        /// </summary>
        public CTracksTool trkTool;

        /// <summary>
        /// Auto Headland YouTurn
        /// </summary>
        public CYouTurn yt;

        /// <summary>
        /// Our vehicle only
        /// </summary>
        public CVehicle vehicle;

        /// <summary>
        /// Just the tool attachment that includes the sections
        /// </summary>
        public CTool tool;

        /// <summary>
        /// All the structs for recv and send of information out ports
        /// </summary>
        public CModuleComm mc;

        /// <summary>
        /// The boundary object
        /// </summary>
        public CBoundary bnd;

        /// <summary>
        /// Building a headland instance
        /// </summary>
        public CHeadLine hdl;

        /// <summary>
        /// The internal simulator
        /// </summary>
        public CSim sim;

        /// <summary>
        /// Heading, Roll, Pitch, GPS, Properties
        /// </summary>
        public CAHRS ahrs;

        /// <summary>
        /// Heading, Roll, Pitch, GPS, Properties
        /// </summary>
        public CAHRS ahrsTool;

        /// <summary>
        /// Most of the displayed field data for GUI
        /// </summary>
        public CFieldData fd;

        ///// <summary>
        ///// Sound
        ///// </summary>
        public CSound sounds;

        /// <summary>
        /// The font class
        /// </summary>
        public Font font;

        /// <summary>
        /// The new steer algorithms
        /// </summary>
        public CGuidance gyd;

        /// <summary>
        /// The new steer algorithms
        /// </summary>
        public CGuidanceTool gydTool;

        /// <summary>
        /// The new brightness code
        /// </summary>
        public CWindowsSettingsBrightnessController displayBrightness;

        /// <summary>
        /// Nozzle class
        /// </summary>
        public CNozzle nozz;

        /// <summary>
        /// Nozzle class
        /// </summary>
        public Map map;

        #endregion // Class Props and instances

        //The method assigned to the PowerModeChanged event call
        private void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            //We are interested only in StatusChange cases
            if (e.Mode.HasFlag(Microsoft.Win32.PowerModes.StatusChange))
            {
                PowerLineStatus powerLineStatus = SystemInformation.PowerStatus.PowerLineStatus;

                Log.EventWriter($"Power Line Status Change to: {powerLineStatus}");

                if (powerLineStatus == PowerLineStatus.Online)
                {
                    btnChargeStatus.BackColor = Color.YellowGreen;

                    Form f = Application.OpenForms["FormSaveOrNot"];

                    if (f != null)
                    {
                        f.Focus();
                        f.Close();
                    }
                }
                else
                {
                    btnChargeStatus.BackColor = Color.LightCoral;
                }

                if (Settings.User.setDisplay_isShutdownWhenNoPower && powerLineStatus == PowerLineStatus.Offline)
                {
                    Log.EventWriter("Shutdown Computer By Power Lost Setting");
                    Close();
                }
            }
        }

        public FormGPS()
        {
            //winform initialization
            InitializeComponent();

            ControlExtension.Draggable(panel_IO, true);

            //time keeper
            secondsSinceStart = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;

            camera = new CCamera();

            //create the world grid
            worldGrid = new WorldFloor(this);

            //create the world map
            worldMap = new WorldTileMap(this);

            //our vehicle made with gl object and pointer of mainform
            vehicle = new CVehicle(this);

            tool = new CTool(this);

            //our NMEA parser
            pn = new CNMEA(this);

            //our NMEA parser for GPS 2
            pnTool = new CNMEA(this);

            //new instance of contour mode
            ct = new CContour(this);

            //new track instance
            trk = new CTracks(this);

            //new track instance
            trkTool = new CTracksTool(this);

            //new instance of contour mode
            hdl = new CHeadLine(this);

            ////new instance of auto headland turn
            yt = new CYouTurn(this);

            //module communication
            mc = new CModuleComm(this);

            //boundary object
            bnd = new CBoundary(this);

            //nmea simulator built in.
            sim = new CSim(this);

            ////all the attitude, heading, rollDual, pitch reference system
            ahrs = new CAHRS();

            ////all the attitude, heading, rollDual, pitch reference system GPS2
            ahrsTool = new CAHRS();

            //fieldData all in one place
            fd = new CFieldData(this);

            //start the stopwatch
            //swFrame.Start();

            //instance of tram
            tram = new CTram(this);

            //access to font class
            font = new Font(this);

            //the new steer algorithms
            gyd = new CGuidance(this);

            //the new steer algorithms
            gydTool = new CGuidanceTool(this);

            //sounds class
            sounds = new CSound();

            //brightness object class
            displayBrightness = new CWindowsSettingsBrightnessController(Settings.User.setDisplay_isBrightnessOn);

            //Application rate controller
            nozz = new CNozzle(this);

            //map class
            map = new Map(this);
        }

        private void FormGPS_Load(object sender, EventArgs e)
        {
            if (!gStr.Load()) YesMessageBox("Serious error loading languages");

            if (!Settings.User.isTermsAccepted)
            {
                using (var form = new Form_First(this))
                {
                    if (form.ShowDialog(this) != DialogResult.OK)
                    {
                        Log.EventWriter("Terms Not Accepted");
                        FileSaveSystemEvents();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Log.EventWriter("Terms Accepted");
                    }
                }
            }

            this.MouseWheel += ZoomByMouseWheel;

            //System Event to check when Power Mode has changed.
            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            //start udp server if required
            if (Settings.IO.setUDP_isOn)
                LoadUDPServer();

            if (Settings.IO.setUDP_isLoopBack)
                StartPluginsServer();

            ConfigureNTRIP();

            //boundaryToolStripBtn.Enabled = false;
            FieldMenuButtonEnableDisable(false);

            //make sure current field directory exists, null if not
            currentFieldDirectory = Settings.Vehicle.setF_CurrentFieldDir;

            if (currentFieldDirectory != "")
            {
                string dir = Path.Combine(RegistrySettings.fieldsDirectory, currentFieldDirectory);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    currentFieldDirectory = "";
                    Settings.Vehicle.setF_CurrentFieldDir = "";

                    Log.EventWriter("Field Directory is Empty or Missing");
                }
            }

            currentJobDirectory = Settings.Vehicle.setF_CurrentJobDir;

            if (currentFieldDirectory != "" && currentJobDirectory != "")
            {
                string dir = Path.Combine(RegistrySettings.fieldsDirectory, currentFieldDirectory, currentJobDirectory);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    currentJobDirectory = "";
                    Settings.Vehicle.setF_CurrentJobDir = "";

                    Log.EventWriter("Job Directory is Empty or Missing");
                }
            }

            Log.EventWriter("Program Directory: " + Application.StartupPath);
            Log.EventWriter("Fields Directory: " + (RegistrySettings.fieldsDirectory));

            currentVersionStr = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            string[] fullVers = currentVersionStr.Split('.');
            int inoV = int.Parse(fullVers[0], CultureInfo.InvariantCulture);
            inoV += int.Parse(fullVers[1], CultureInfo.InvariantCulture);
            //inoV += int.Parse(fullVers[2], CultureInfo.InvariantCulture);
            inoVersionInt = inoV;
            inoVersionStr = inoV.ToString();

            if (Settings.User.setDisplay_isBrightnessOn)
            {
                if (displayBrightness.isWmiMonitor)
                {
                    Settings.User.setDisplay_brightnessSystem = displayBrightness.GetBrightness();
                }
                else
                {
                    btnBrightnessDn.Enabled = false;
                    btnBrightnessUp.Enabled = false;
                }

                //display brightness
                if (displayBrightness.isWmiMonitor)
                {
                    if (Settings.User.setDisplay_brightness < Settings.User.setDisplay_brightnessSystem)
                    {
                        Settings.User.setDisplay_brightness = Settings.User.setDisplay_brightnessSystem;
                    }

                    displayBrightness.SetBrightness(Settings.User.setDisplay_brightness);
                }
                else
                {
                    btnBrightnessDn.Enabled = false;
                    btnBrightnessUp.Enabled = false;
                }
            }

            //default values for PGNs
            LoadPGNS();

            // load all the gui elements in gui.designer.cs
            LoadSettings();

            tool.LoadSettings();
            vehicle.LoadSettings();

            //nmea limiter
            //udpWatch.Start();

            btnChangeMappingColor.Text = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            hotkeys = new char[19];

            hotkeys = Settings.User.hotkeys.ToCharArray();

            lbl_IO_Profile.Text = RegistrySettings.IOFileName;

            Log.EventWriter("Terms Accepted");

            if (RegistrySettings.vehicleFileName == "Default" || RegistrySettings.toolFileName == "Default")
            {
                Log.EventWriter("Using Default Vehicle At Start Warning");

                YesMessageBox("Using Default Vehicle" + "\r\n\r\n" + "Load Existing Vehicle or Save As a New One !!!"
                    + "\r\n\r\n" + "Changes will NOT be Saved for Default Vehicle");

                using (FormConfig form = new FormConfig(this))
                {
                    form.ShowDialog(this);
                }
            }

            if (RegistrySettings.IOFileName == "Default")
            {
                Log.EventWriter("Using Default IO At Start Warning");

                YesMessageBox("Using Default IO Profile" + "\r\n\r\n" + "Load Existing Profile or Save As a New One !!!"
                    + "\r\n\r\n" + "Changes will NOT be Saved for Default Profile");

                using (var form = new FormProfiles(this))
                {
                    form.ShowDialog(this);
                    if (form.DialogResult == DialogResult.Yes)
                    {
                        Log.EventWriter("Program Reset: Saving or Selecting Profile");

                        Settings.IO.Save();
                        ExitShutdown();
                    }
                }

                lbl_IO_Profile.Text = RegistrySettings.IOFileName;
            }

            RescanPorts();

            if (!Settings.IO.setUDP_isOn) ReconnectSerialPorts();

        }

        #region Shutdown Handling

        private void FormGPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }

            f = Application.OpenForms["FormFieldData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }

            f = Application.OpenForms["FormPan"];

            if (f != null)
            {
                isPanFormVisible = false;
                f.Focus();
                f.Close();
            }

            f = Application.OpenForms["FormTimedMessage"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }

            if (this.OwnedForms.Any())
            {
                TimedMessageBox(2000, gStr.Get(gs.gsWindowsStillOpen), gStr.Get(gs.gsCloseAllWindowsFirst));
                e.Cancel = true;
                return;
            }

            int choice = SaveOrNot();

            //simple cancel return to Twol
            if (choice == 1)
            {
                e.Cancel = true;
                return;
            }

            map.isShuttingDown = true;

            if (isFieldStarted)
            {
                SetWorkState(btnStates.Off);

                FileSaveEverythingBeforeClosingField();
            }

            SaveFormGPSWindowSettings();

            double minutesSinceStart = ((DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds) / 60;
            if (minutesSinceStart < 1)
            {
                minutesSinceStart = 1;
            }

            //Log.EventWriter("Missed Sentence Counter Total: " + missedSentenceCount.ToString()
            //    + "   Missed Per Minute: " + ((double)missedSentenceCount / minutesSinceStart).ToString("N4"));

            Log.EventWriter("Program Exit: " + DateTime.Now.ToString("f", CultureInfo.CreateSpecificCulture(RegistrySettings.culture)) + "\r");

            //save current vehicle
            Settings.Vehicle.Save();

            //save current Tool
            Settings.Tool.Save();

            //save current User
            Settings.User.Save();

            //save current IO
            Settings.IO.Save();

            //write the log file
            FileSaveSystemEvents();

            if (displayBrightness.isWmiMonitor)
                displayBrightness.SetBrightness(Settings.User.setDisplay_brightnessSystem);

            if (UDPSocket != null)
            {
                try
                {
                    UDPSocket.Shutdown(SocketShutdown.Both);
                }
                finally { UDPSocket.Close(); }
            }

            if (UDPSocketTool != null)
            {
                try
                {
                    UDPSocketTool.Shutdown(SocketShutdown.Both);
                }
                finally { UDPSocketTool.Close(); }
            }
        }

        #endregion

        public int SaveOrNot()
        {
            CloseTopMosts();

            using (FormSaveOrNot form = new FormSaveOrNot())
            {
                DialogResult result = form.ShowDialog(this);

                if (result == DialogResult.OK) return 0;      //Exit to windows
                if (result == DialogResult.Ignore) return 1;   //Ignore & return
                if (result == DialogResult.Yes) return 2;   //Shutdown computer

                return 1;  // oops something is really busted
            }
        }

        private void FormGPS_ResizeEnd(object sender, EventArgs e)
        {
            PanelsAndOGLSize();

            Form f = Application.OpenForms["FormGPSData"];
            if (f != null)
            {
                f.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
                f.Left = this.Left + GPSDataWindowLeft;
            }

            f = Application.OpenForms["FormFieldData"];
            if (f != null)
            {
                f.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
                f.Left = this.Left + GPSDataWindowLeft;
            }

            f = Application.OpenForms["FormPan"];
            if (f != null)
            {
                f.Top = this.Height / 3 + this.Top;
                f.Left = this.Width - 400 + this.Left;
            }

            Panel_IO_Location();
        }

        public void FileSaveEverythingBeforeClosingField()
        {
            FieldMenuButtonEnableDisable(false);
            displayFieldName = gStr.Get(gs.gsNone);

            JobClose();
            FieldClose();

            this.Text = "TWOL";
        }

        public void FieldNew()
        {
            isFieldStarted = true;
            isJobStarted = false;

            startCounter = 0;

            btnTrack.Enabled = true;
            btnCycleLines.Image = Properties.Resources.ABLineCycle;
            btnCycleLinesBk.Image = Properties.Resources.ABLineCycleBk;

            btnAutoSteer.Enabled = true;

            btnFlag.Enabled = true;

            //update the menu
            this.menustripLanguage.Enabled = false;
            //boundaryToolStripBtn.Enabled = true;
            isPanelBottomHidden = false;

            FieldMenuButtonEnableDisable(true);
            PanelUpdateRightAndBottom();
            PanelsAndOGLSize();

            fileSaveCounter = 25;
            lblGuidanceLine.Visible = false;
            lblHardwareMessage.Visible = false;

            oglMain.MakeCurrent();
        }

        public void JobNew()
        {
            btnContour.Enabled = true;

            isJobStarted = true;
            btnFieldStats.Visible = true;

            btnSectionMasterManual.Visible = btnSectionMasterAuto.Visible = true;

            SetSectionButtonVisible(true);

            PanelsAndOGLSize();
        }

        public void JobClose()
        {
            if (isJobStarted)
            {
                TurnOffSectionsSafely();

                btnSectionMasterManual.Visible = btnSectionMasterAuto.Visible = true;
                Settings.Vehicle.setF_CurrentJobDir = currentJobDirectory;

                //auto save the field patches, contours accumulated so far
                FileSaveSections();
                FileSaveContour();

                //NMEA elevation file
                if (Settings.User.isLogElevation && sbElevationString.Length > 0) FileSaveElevation();

                Log.EventWriter("** Closed **   " + currentJobDirectory + "   "
                    + DateTime.Now.ToString("f", CultureInfo.CreateSpecificCulture(RegistrySettings.culture)));

                isJobStarted = false;
            }

            displayJobName = gStr.Get(gs.gsNone);

            //clear out contour and Lists
            btnContour.Enabled = false;
            ct.ResetContour();
            ct.isContourBtnOn = false;
            btnContour.Image = Properties.Resources.ContourOff;
            ct.isContourOn = false;

            SetSectionButtonVisible(false);

            triStrip?.Clear();
            patchList?.Clear();
            patchSaveList?.Clear();
            contourSaveList?.Clear();
        }

        private void btnProfiles_Click(object sender, EventArgs e)
        {
            if (RegistrySettings.IOFileName == "Default")
            {
                TimedMessageBox(3000, "Default Profile Used", "Create or Choose a Profile");
            }

            using (var form = new FormProfiles(this))
            {
                form.ShowDialog(this);
                if (form.DialogResult == DialogResult.Yes)
                {
                    Log.EventWriter("Program Reset: Saving or Selecting Profile");

                    Settings.IO.Save();
                    ExitShutdown();
                }
            }

            lbl_IO_Profile.Text = RegistrySettings.IOFileName;
        }

        private void nudToolOffset_ValueChanged(object sender, EventArgs e)
        {
            sim.toolOffset = (double)nudToolOffset.Value * 0.001;
        }

        public void FieldClose()
        {
            Settings.Vehicle.setF_CurrentFieldDir = currentFieldDirectory;

            if (isFieldStarted)
            {
                FileSaveTracks();

                Log.EventWriter("** Closed **   " + currentFieldDirectory + "   "
                    + DateTime.Now.ToString("f", CultureInfo.CreateSpecificCulture(RegistrySettings.culture)));

            }

            sbElevationString.Clear();

            //reset field offsets
            if (!isKeepOffsetsOn)
            {
                pn.fixOffset.easting = 0;
                pn.fixOffset.northing = 0;
            }

            //turn off headland
            bnd.isHeadlandOn = false;

            btnFieldStats.Visible = false;

            //make sure hydraulic lift is off
            PGN_239.pgn[PGN_239.hydLift] = 0;
            lblHardwareMessage.Visible = false;

            lblGuidanceLine.Visible = false;
            lblHardwareMessage.Visible = false;

            //zoom gone
            oglZoom.SendToBack();

            //clean all the lines
            bnd.bndList.Clear();

            FieldMenuButtonEnableDisable(false);

            menustripLanguage.Enabled = true;
            isFieldStarted = false;

            //clear the flags
            flagPts.Clear();

            //ABLine
            tram.tramList?.Clear();

            //clean up tram
            tram.displayMode = 0;
            tram.tramBndInnerArr?.Clear();
            tram.tramBndOuterArr?.Clear();

            btnCycleLines.Image = Properties.Resources.ABLineCycle;
            btnCycleLinesBk.Image = Properties.Resources.ABLineCycleBk;

            //AutoSteer
            btnAutoSteer.Enabled = false;
            SetAutoSteerButton(false, "Field Closed");

            //tracks
            trk.ResetTrack();

            //auto YouTurn shutdown
            SetYouTurnButton(false);

            //reset acre and distance counters
            fd.workedAreaTotal = 0;

            //reset GUI areas
            fd.UpdateFieldBoundaryGUIAreas();

            displayFieldName = gStr.Get(gs.gsNone);

            isPanelBottomHidden = false;

            PanelsAndOGLSize();

            PanelUpdateRightAndBottom();
        }

        // Return True if percent of a rectangle is over total screen area of all monitors
        public bool IsOnScreen(System.Drawing.Point RecLocation, System.Drawing.Size RecSize, double MinPercentOnScreen = 0.8)
        {
            double PixelsVisible = 0;
            System.Drawing.Rectangle Rec = new System.Drawing.Rectangle(RecLocation, RecSize);

            foreach (Screen Scrn in Screen.AllScreens)
            {
                System.Drawing.Rectangle r = System.Drawing.Rectangle.Intersect(Rec, Scrn.WorkingArea);
                // intersect rectangle with screen
                if (r.Width != 0 & r.Height != 0)
                {
                    PixelsVisible += (r.Width * r.Height);
                    // tally visible pixels
                }
            }
            return PixelsVisible >= (Rec.Width * Rec.Height) * MinPercentOnScreen;
        }

        private void FormGPS_Move(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];
            if (f != null)
            {
                f.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
                f.Left = this.Left + GPSDataWindowLeft;
            }

            f = Application.OpenForms["FormFieldData"];
            if (f != null)
            {
                f.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
                f.Left = this.Left + GPSDataWindowLeft;
            }

            f = Application.OpenForms["FormPan"];
            if (f != null)
            {
                f.Top = this.Top + 75;
                f.Left = this.Left + this.Width - 380;
            }
        }

        public void KeyboardToText(TextBox sender, Form owner)
        {
            var colour = sender.BackColor;
            sender.BackColor = Color.Red;
            using (FormKeyboard form = new FormKeyboard(sender.Text))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    sender.Text = form.ReturnString;
                }
            }
            sender.BackColor = colour;
        }

        public void FieldMenuButtonEnableDisable(bool isOn)
        {
            SmoothABtoolStripMenu.Enabled = isOn;
            deleteContourPathsToolStripMenuItem.Enabled = isOn;
            boundaryToolToolStripMenu.Enabled = isOn;

            boundariesToolStripMenuItem.Enabled = isOn;
            headlandToolStripMenuItem.Enabled = isOn;
            headlandBuildToolStripMenuItem.Enabled = isOn;
            flagByLatLonToolStripMenuItem.Enabled = isOn;
            recordedPathStripMenu.Enabled = isOn;
        }

        //take the distance from object and convert to camera data
        public void SetZoom()
        {
            if (Settings.User.setDisplay_camZoom < 5.0) Settings.User.setDisplay_camZoom = 5.0;
            if (Settings.User.setDisplay_camZoom > 800) Settings.User.setDisplay_camZoom = 800;
            camera.camSetDistance = Settings.User.setDisplay_camZoom * Settings.User.setDisplay_camZoom * -1;

            //match grid to cam distance and redo perspective
            gridToolSpacing = (int)((camera.camSetDistance / -10) / Settings.Tool.toolWidth * 2 + 0.5);
            if (gridToolSpacing < 1) gridToolSpacing = 1;
            camera.gridZoom = gridToolSpacing * Settings.Tool.toolWidth;
            ChangePerspective();
        }

        //message box pops up with info then goes away
        public void TimedMessageBox(int timeout, string s1, string s2)
        {
            FormTimedMessage form = new FormTimedMessage(timeout, s1, s2);
            form.Show(this);
            this.Activate();
        }

        public void YesMessageBox(string s1)
        {
            var form = new FormYes(s1);
            form.ShowDialog(this);
        }

        public enum textures : uint
        {
            Floor, Font,
            Turn, TurnCancel, TurnManual,
            Compass, Speedo, SpeedoNeedle,
            Lift, SteerPointer,
            SteerDot, Tractor, QuestionMark,
            FrontWheels, FourWDFront, FourWDRear,
            Harvester,
            Lateral, bingGrid,
            NoGPS, ZoomIn48, ZoomOut48,
            Pan, MenuHideShow,
            ToolWheels, Tire, TramDot,
            YouTurnU, YouTurnH, CrossTrackBkgrnd,
            PanUp, PanDn, Floor2
        }

        public void LoadGLTextures()
        {
            GL.Enable(EnableCap.Texture2D);

            Bitmap[] oglTextures = new Bitmap[]
            {
                Resources.z_Floor,
                Resources.z_Font,
                Resources.z_Turn,
                Resources.z_TurnCancel,
                Resources.z_TurnManual,
                Resources.z_Compass,
                Resources.z_Speedo,
                Resources.z_SpeedoNeedle,
                Resources.z_Lift,
                Resources.z_SteerPointer,
                Resources.z_SteerDot,
                Resources.z_Tractor,
                Resources.z_QuestionMark,
                Resources.z_FrontWheels,
                Resources.z_4WDFront,
                Resources.z_4WDRear,
                Resources.z_Harvester,
                Resources.z_LateralManual,
                Resources.z_bingMap,
                Resources.z_NoGPS,
                Resources.ZoomIn48,
                Resources.ZoomOut48,
                Resources.Pan,
                Resources.MenuHideShow,
                Resources.z_Tool,
                Resources.z_Tire,
                Resources.z_TramOnOff,
                Resources.YouTurnU,
                Resources.YouTurnH,
                Resources.z_crossTrackBkgnd,
                Resources.PanUp,
                Resources.PanDn,
                Resources.z_Floor2
            };

            texture = new uint[oglTextures.Length];

            for (int h = 0; h < oglTextures.Length; h++)
            {
                using (Bitmap bitmap = oglTextures[h])
                {
                    GL.GenTextures(1, out texture[h]);
                    GL.BindTexture(TextureTarget.Texture2D, texture[h]);
                    BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                    bitmap.UnlockBits(bitmapData);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                }
            }
        }

        // Generates a random number within a range.
        public double RandomNumber(double min, double max)
        {
            return min + _random.NextDouble() * (max - min);
        }

        private readonly Random _random = new Random();
    }//class FormGPS
}//namespace Twol