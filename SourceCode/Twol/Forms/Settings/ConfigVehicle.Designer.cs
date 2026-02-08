using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twol.Classes;

using Twol.Properties;
using Microsoft.Win32;
using OpenTK.Graphics.OpenGL;

namespace Twol
{
    public partial class FormConfig
    {
        #region Vehicle Save---------------------------------------------

        private void btnVehicleLoad_Click(object sender, EventArgs e)
        {
            if (lvVehicles.SelectedItems.Count > 0)
            {
                mf.TurnOffSectionsSafely();

                RegistrySettings.Save("VehicleFileName", lvVehicles.SelectedItems[0].SubItems[0].Text);
                if (Settings.Vehicle.Load() != Settings.LoadResult.Ok) return;

                LoadBrandImage();

                mf.vehicle.LoadSettings();

                //reset Twol
                mf.LoadSettings();

                //Form Steer Settings
                PGN_252.pgn[PGN_252.countsPerDegree] = unchecked((byte)Settings.Vehicle.setAS_countsPerDegree);
                PGN_252.pgn[PGN_252.ackerman] = unchecked((byte)Settings.Vehicle.setAS_ackerman);

                PGN_252.pgn[PGN_252.wasOffsetHi] = unchecked((byte)(Settings.Vehicle.setAS_wasOffset >> 8));
                PGN_252.pgn[PGN_252.wasOffsetLo] = unchecked((byte)(Settings.Vehicle.setAS_wasOffset));

                PGN_252.pgn[PGN_252.highPWM] = unchecked((byte)Settings.Vehicle.setAS_highSteerPWM);
                PGN_252.pgn[PGN_252.lowPWM] = unchecked((byte)Settings.Vehicle.setAS_lowSteerPWM);
                PGN_252.pgn[PGN_252.gainProportional] = unchecked((byte)Settings.Vehicle.setAS_Kp);
                PGN_252.pgn[PGN_252.minPWM] = unchecked((byte)Settings.Vehicle.setAS_minSteerPWM);

                mf.SendUDPMessage(PGN_252.pgn, mf.epModule);

                //steer config
                PGN_251.pgn[PGN_251.set0] = Settings.Vehicle.setArdSteer_setting0;
                PGN_251.pgn[PGN_251.set1] = Settings.Vehicle.setArdSteer_setting1;
                PGN_251.pgn[PGN_251.maxPulse] = Settings.Vehicle.setArdSteer_maxPulseCounts;
                PGN_251.pgn[PGN_251.minSpeed] = unchecked((byte)(Settings.Vehicle.setAS_minSteerSpeed * 10));

                if (Settings.Vehicle.setAS_isConstantContourOn)
                    PGN_251.pgn[PGN_251.angVel] = 1;
                else PGN_251.pgn[PGN_251.angVel] = 0;

                mf.SendUDPMessage(PGN_251.pgn, mf.epModule);

                ///Remind the user
                mf.TimedMessageBox(2500, "Steer Settings Sent", "Were Modules Connected?");

                Log.EventWriter("Vehicle Loaded: " + RegistrySettings.vehicleFileName + ".XML");

                UpdateVehicleListView();
            }
        }

        private void btnVehicleDelete_Click(object sender, EventArgs e)
        {
            if (lvVehicles.SelectedItems.Count > 0)
            {
                if (lvVehicles.SelectedItems[0].SubItems[0].Text != RegistrySettings.vehicleFileName)
                {
                    DialogResult result3 = MessageBox.Show(
                    "Delete: " + lvVehicles.SelectedItems[0].SubItems[0].Text + ".XML",
                    gStr.Get(gs.gsSaveAndReturn),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2);
                    if (result3 == DialogResult.Yes)
                    {
                        File.Delete(Path.Combine(RegistrySettings.vehiclesDirectory, lvVehicles.SelectedItems[0].SubItems[0].Text + ".XML"));
                    }
                }
                else
                {
                    mf.TimedMessageBox(2000, "Vehicle In Use", "Select Different Vehicle");
                }
            }
            UpdateVehicleListView();
        }

        //Save As Vehicle
        private void btnVehicleSave_Click(object sender, EventArgs e)
        {
            mf.TurnOffSectionsSafely();

            btnVehicleSave.BackColor = Color.Transparent;
            btnVehicleSave.Enabled = false;            

            string vehicleName = SanitizeFileName(tboxVehicleNameSave.Text.Trim()).Trim();
            tboxVehicleNameSave.Text = "";

            if (vehicleName.Length > 0)
            {
                RegistrySettings.Save("VehicleFileName", vehicleName);
                Settings.Vehicle.Save();

                UpdateVehicleListView();
            }
        }

        private void tboxVehicleNameSave_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            btnVehicleLoad.Enabled = false;
            btnVehicleDelete.Enabled = false;

            lvVehicles.SelectedItems.Clear();

            if (String.IsNullOrEmpty(tboxVehicleNameSave.Text.Trim()))
            {
                btnVehicleSave.Enabled = false;
                btnVehicleSave.BackColor = Color.Transparent;
            }
            else
            {
                btnVehicleSave.Enabled = true;
                btnVehicleSave.BackColor = Color.LimeGreen;
            }
        }
        private void tboxVehicleNameSave_Click(object sender, EventArgs e)
        {
            if (Settings.User.setDisplay_isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
            }
        }

        private void tboxVehicleNameSave_Enter(object sender, EventArgs e)
        {
            //btnVehicleSaveAs.Enabled = false;
            btnVehicleLoad.Enabled = false;
            btnVehicleDelete.Enabled = false;

            lvVehicles.SelectedItems.Clear();
        }

        //New Vehicle
        private void tboxCreateNewVehicle_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            btnVehicleSave.Enabled = false;
            btnVehicleLoad.Enabled = false;
            btnVehicleDelete.Enabled = false;

            lvVehicles.SelectedItems.Clear();

            if (String.IsNullOrEmpty(tboxCreateNewVehicle.Text.Trim()))
            {
                btnVehicleNewSave.Enabled = false;
                btnVehicleNewSave.BackColor = Color.Transparent;
            }
            else
            {
                btnVehicleNewSave.Enabled = true;
                btnVehicleNewSave.BackColor = Color.LimeGreen;
            }
        }
        private void tboxCreateNewVehicle_Click(object sender, EventArgs e)
        {
            mf.TurnOffSectionsSafely();

            if (Settings.User.setDisplay_isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
            }
        }

        private void btnVehicleNewSave_Click(object sender, EventArgs e)
        {
            mf.TurnOffSectionsSafely();

            btnVehicleNewSave.BackColor = Color.Transparent;
            btnVehicleNewSave.Enabled = false;

            string vehicleName = SanitizeFileName(tboxCreateNewVehicle.Text.Trim()).Trim();
            tboxCreateNewVehicle.Text = "";

            if (vehicleName.Length > 0)
            {
                RegistrySettings.Save("VehicleFileName", vehicleName);
                Settings.Vehicle.Reset();

                LoadBrandImage();

                mf.vehicle.LoadSettings();

                //reset Twol
                mf.LoadSettings();

                SectionFeetInchesTotalWidthLabelUpdate();

                //Form Steer Settings
                PGN_252.pgn[PGN_252.countsPerDegree] = unchecked((byte)Settings.Vehicle.setAS_countsPerDegree);
                PGN_252.pgn[PGN_252.ackerman] = unchecked((byte)Settings.Vehicle.setAS_ackerman);

                PGN_252.pgn[PGN_252.wasOffsetHi] = unchecked((byte)(Settings.Vehicle.setAS_wasOffset >> 8));
                PGN_252.pgn[PGN_252.wasOffsetLo] = unchecked((byte)(Settings.Vehicle.setAS_wasOffset));

                PGN_252.pgn[PGN_252.highPWM] = unchecked((byte)Settings.Vehicle.setAS_highSteerPWM);
                PGN_252.pgn[PGN_252.lowPWM] = unchecked((byte)Settings.Vehicle.setAS_lowSteerPWM);
                PGN_252.pgn[PGN_252.gainProportional] = unchecked((byte)Settings.Vehicle.setAS_Kp);
                PGN_252.pgn[PGN_252.minPWM] = unchecked((byte)Settings.Vehicle.setAS_minSteerPWM);

                mf.SendUDPMessage(PGN_252.pgn, mf.epModule);

                //steer config
                PGN_251.pgn[PGN_251.set0] = Settings.Vehicle.setArdSteer_setting0;
                PGN_251.pgn[PGN_251.set1] = Settings.Vehicle.setArdSteer_setting1;
                PGN_251.pgn[PGN_251.maxPulse] = Settings.Vehicle.setArdSteer_maxPulseCounts;
                PGN_251.pgn[PGN_251.minSpeed] = unchecked((byte)(Settings.Vehicle.setAS_minSteerSpeed * 10));

                if (Settings.Vehicle.setAS_isConstantContourOn)
                    PGN_251.pgn[PGN_251.angVel] = 1;
                else PGN_251.pgn[PGN_251.angVel] = 0;

                mf.SendUDPMessage(PGN_251.pgn, mf.epModule);

                //machine module settings
                PGN_238.pgn[PGN_238.set0] = Settings.Vehicle.setArdMac_setting0;
                PGN_238.pgn[PGN_238.raiseTime] = Settings.Vehicle.setArdMac_hydRaiseTime;
                PGN_238.pgn[PGN_238.lowerTime] = Settings.Vehicle.setArdMac_hydLowerTime;

                PGN_238.pgn[PGN_238.user1] = Settings.Vehicle.setArdMac_user1;
                PGN_238.pgn[PGN_238.user2] = Settings.Vehicle.setArdMac_user2;
                PGN_238.pgn[PGN_238.user3] = Settings.Vehicle.setArdMac_user3;
                PGN_238.pgn[PGN_238.user4] = Settings.Vehicle.setArdMac_user4;

                mf.SendUDPMessage(PGN_238.pgn, mf.epModule);

                ///Remind the user
                mf.TimedMessageBox(2500, "Steer and Machine Settings Sent", "Were Modules Connected?");

                Log.EventWriter("New Vehicle Loaded: " + RegistrySettings.vehicleFileName + ".XML");

                UpdateVehicleListView();
            }
        }        

        //Functions
        private static readonly Regex InvalidFileRegex = new Regex(string.Format("[{0}]", Regex.Escape(@"<>:""/\|?*")));
        public static string SanitizeFileName(string fileName)
        {
            return InvalidFileRegex.Replace(fileName, string.Empty);
        }

        private void UpdateVehicleListView()
        {
            DirectoryInfo dinfo = new DirectoryInfo(RegistrySettings.vehiclesDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.XML");

            //load the listbox
            lvVehicles.Items.Clear();
            foreach (FileInfo file in Files)
            {
                lvVehicles.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }

            //deselect everything
            lvVehicles.SelectedItems.Clear();

            lblSummaryVehicleName.Text = "Vehicle" + ": " + RegistrySettings.vehicleFileName;
            lblSummaryToolName.Text = "Tool" + ": " + RegistrySettings.toolFileName;

            UpdateSummary();
        }

        #endregion

        #region Tool SaveLoad

        private void UpdateToolListView()
        {
            DirectoryInfo dinfo = new DirectoryInfo(RegistrySettings.toolsDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.XML");

            //load the listbox
            lvTools.Items.Clear();
            foreach (FileInfo file in Files)
            {
                lvTools.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }

            //deselect everything
            lvTools.SelectedItems.Clear();
            lblSummaryToolName.Text = RegistrySettings.workingDirectory;

            lblSummaryVehicleName.Text = "Vehicle" + ": " + RegistrySettings.vehicleFileName;
            lblSummaryToolName.Text = "Tool" + ": " + RegistrySettings.toolFileName;

            UpdateSummary();
        }

        private void btnToolDelete_Click(object sender, EventArgs e)
        {
            if (lvTools.SelectedItems.Count > 0)
            {
                if (lvTools.SelectedItems[0].SubItems[0].Text != RegistrySettings.toolFileName)
                {
                    DialogResult result3 = MessageBox.Show(
                    "Delete: " + lvTools.SelectedItems[0].SubItems[0].Text + ".XML",
                    gStr.Get(gs.gsSaveAndReturn),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2);
                    if (result3 == DialogResult.Yes)
                    {
                        File.Delete(Path.Combine(RegistrySettings.toolsDirectory, lvTools.SelectedItems[0].SubItems[0].Text + ".XML"));
                        UpdateToolListView();
                    }
                }
                else
                {
                    mf.TimedMessageBox(2000, "Tool In Use", "Select Different Tool");
                }
            }
        }

        private void btnToolLoad_Click(object sender, EventArgs e)
        {
            if (lvTools.SelectedItems.Count > 0)
            {
                mf.TurnOffSectionsSafely();

                RegistrySettings.Save("ToolFileName", lvTools.SelectedItems[0].SubItems[0].Text);
                if (Settings.Tool.Load() != Settings.LoadResult.Ok) return;

                mf.tool.LoadSettings();
                mf.SetNozzleSettings();

                //Send Pin configuration
                SendRelaySettingsToMachineModule();

                //machine settings    
                PGN_238.pgn[PGN_238.set0] = Settings.Vehicle.setArdMac_setting0;
                PGN_238.pgn[PGN_238.raiseTime] = Settings.Vehicle.setArdMac_hydRaiseTime;
                PGN_238.pgn[PGN_238.lowerTime] = Settings.Vehicle.setArdMac_hydLowerTime;

                PGN_238.pgn[PGN_238.user1] = Settings.Vehicle.setArdMac_user1;
                PGN_238.pgn[PGN_238.user2] = Settings.Vehicle.setArdMac_user2;
                PGN_238.pgn[PGN_238.user3] = Settings.Vehicle.setArdMac_user3;
                PGN_238.pgn[PGN_238.user4] = Settings.Vehicle.setArdMac_user4;

                mf.SendUDPMessage(PGN_238.pgn, mf.epModule);

                ///Remind the user
                mf.TimedMessageBox(1500, "Machine Settings Sent", "Were Modules Connected?");

                Log.EventWriter("Tool Loaded: " + RegistrySettings.toolFileName + ".XML");

                UpdateToolListView();
            }
        }

        private void btnToolNewSave_Click(object sender, EventArgs e)
        {
            mf.TurnOffSectionsSafely();

            btnToolNewSave.BackColor = Color.Transparent;
            btnToolNewSave.Enabled = false;

            string toolName = SanitizeFileName(tboxCreateNewTool.Text.Trim()).Trim();
            tboxCreateNewTool.Text = "";

            if (toolName.Length > 0)
            {
                RegistrySettings.Save("ToolFileName", toolName);
                Settings.Tool.Reset();

                mf.tool.LoadSettings();
                mf.SetNozzleSettings();

                SectionFeetInchesTotalWidthLabelUpdate();

                //Send Pin configuration
                SendRelaySettingsToMachineModule();

                ///Remind the user
                mf.TimedMessageBox(2500, "Machine Settings Sent", "Were Modules Connected?");

                Log.EventWriter("New Tool Loaded: " + RegistrySettings.toolFileName + ".XML");

                UpdateToolListView();
            }
        }

        private void btnToolSave_Click(object sender, EventArgs e)
        {
            mf.TurnOffSectionsSafely();

            btnToolSave.BackColor = Color.Transparent;
            btnToolSave.Enabled = false;

            string toolName = SanitizeFileName(tboxToolNameSave.Text.Trim()).Trim();
            tboxToolNameSave.Text = "";

            if (toolName.Length > 0)
            {
                RegistrySettings.Save("ToolFileName", toolName);
                Settings.Tool.Save();

                UpdateToolListView();
            }
        }

        private void tboxCreateNewTool_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            btnToolSave.Enabled = false;
            btnToolLoad.Enabled = false;
            btnToolDelete.Enabled = false;

            lvTools.SelectedItems.Clear();

            if (String.IsNullOrEmpty(tboxCreateNewTool.Text.Trim()))
            {
                btnToolNewSave.Enabled = false;
                btnToolNewSave.BackColor = Color.Transparent;
            }
            else
            {
                btnToolNewSave.Enabled = true;
                btnToolNewSave.BackColor = Color.LimeGreen;
            }
        }

        private void tboxCreateNewTool_Click(object sender, EventArgs e)
        {
            mf.TurnOffSectionsSafely();

            if (Settings.User.setDisplay_isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
            }
        }

        private void tboxToolNameSave_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            btnToolLoad.Enabled = false;
            btnToolDelete.Enabled = false;

            lvTools.SelectedItems.Clear();

            if (String.IsNullOrEmpty(tboxToolNameSave.Text.Trim()))
            {
                btnToolSave.Enabled = false;
                btnToolSave.BackColor = Color.Transparent;
            }
            else
            {
                btnToolSave.Enabled = true;
                btnToolSave.BackColor = Color.LimeGreen;
            }
        }

        private void tboxToolNameSave_Enter(object sender, EventArgs e)
        {
            btnToolLoad.Enabled = false;
            btnToolDelete.Enabled = false;

            lvTools.SelectedItems.Clear();
        }

        private void tboxToolNameSave_Click(object sender, EventArgs e)
        {
            if (Settings.User.setDisplay_isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
            }

        }

        #endregion

        #region Antenna Enter/Leave

        private void tabVAntenna_Enter(object sender, EventArgs e)
        {
            nudAntennaHeight.Value = Settings.Vehicle.setVehicle_antennaHeight;
            
            nudAntennaPivot.Value = Math.Abs(Settings.Vehicle.setVehicle_antennaPivot);
            //negative is to the right

            nudAntennaOffset.Value = Math.Abs(Settings.Vehicle.setVehicle_antennaOffset);

            rbtnAntennaLeft.Checked = Settings.Vehicle.setVehicle_antennaOffset > 0;
            rbtnAntennaRight.Checked = Settings.Vehicle.setVehicle_antennaOffset < 0;
            rbtnAntennaCenter.Checked = Settings.Vehicle.setVehicle_antennaOffset == 0;

            if (Settings.Vehicle.setVehicle_vehicleType == 0)
                pboxAntenna.BackgroundImage = Properties.Resources.AntennaTractor;
            else if (Settings.Vehicle.setVehicle_vehicleType == 1)
                pboxAntenna.BackgroundImage = Properties.Resources.AntennaHarvester;
            else if (Settings.Vehicle.setVehicle_vehicleType == 2)
                pboxAntenna.BackgroundImage = Properties.Resources.Antenna4WD;

            label98.Text = glm.unitsInCm;
            label99.Text = glm.unitsInCm;
            label100.Text = glm.unitsInCm;
        }

        private void rbtnAntennaLeft_Click(object sender, EventArgs e)
        {
            if (rbtnAntennaRight.Checked)
                mf.vehicle.antennaOffset = -nudAntennaOffset.Value;
            else if (rbtnAntennaLeft.Checked)
                mf.vehicle.antennaOffset = nudAntennaOffset.Value;
            else
            {
                mf.vehicle.antennaOffset = 0;
                nudAntennaOffset.Value = 0;
            }

            Settings.Vehicle.setVehicle_antennaOffset = mf.vehicle.antennaOffset;
        }

        private void nudAntennaOffset_ValueChanged(object sender, EventArgs e)
        {
            if (nudAntennaOffset.Value == 0)
            {
                rbtnAntennaLeft.Checked = false;
                rbtnAntennaRight.Checked = false;
                rbtnAntennaCenter.Checked = true;
            }
            else
            {
                if (!rbtnAntennaLeft.Checked && !rbtnAntennaRight.Checked)
                    rbtnAntennaRight.Checked = true;
            }

            rbtnAntennaLeft_Click(null, null);
        }

        private void nudAntennaPivot_ValueChanged(object sender, EventArgs e)
        {
            Settings.Vehicle.setVehicle_antennaPivot = nudAntennaPivot.Value;

            if (mf.vehicle.vehicleType == 2) Settings.Vehicle.setVehicle_antennaPivot = nudAntennaPivot.Value * -1;
            mf.vehicle.antennaPivot = Settings.Vehicle.setVehicle_antennaPivot;
        }

        private void nudAntennaHeight_ValueChanged(object sender, EventArgs e)
        {
            Settings.Vehicle.setVehicle_antennaHeight = nudAntennaHeight.Value;
            mf.vehicle.antennaHeight = Settings.Vehicle.setVehicle_antennaHeight;
        }

        #endregion

        #region Vehicle Dimensions

        private void tabVDimensions_Enter(object sender, EventArgs e)
        {
            nudWheelbase.Value = Math.Abs(Settings.Vehicle.setVehicle_wheelbase);

            nudVehicleTrack.Value = Settings.Vehicle.setVehicle_trackWidth;

            nudTractorHitchLength.Value = Math.Abs(Settings.Tool.hitchLength);

            if (mf.vehicle.vehicleType == 0)
            {
                pictureBox1.Image = Properties.Resources.RadiusWheelBase;
                nudTractorHitchLength.Visible = true;
            }
            else if (mf.vehicle.vehicleType == 1)
            {
                pictureBox1.Image = Properties.Resources.RadiusWheelBaseHarvester;
                nudTractorHitchLength.Visible = false;
            }
            else if (mf.vehicle.vehicleType == 2)
            {
                pictureBox1.Image = Properties.Resources.RadiusWheelBase4WD;
                nudTractorHitchLength.Visible = true;
            }

            if (Settings.Tool.isToolTrailing || Settings.Tool.isToolTBT)
            {
                nudTractorHitchLength.Visible = true;
                label94.Visible = true;
                lblHitchLength.Visible = true;
            }
            else
            {
                nudTractorHitchLength.Visible = false;
                label94.Visible = false;
                lblHitchLength.Visible = false;
            }

            label94.Text = glm.unitsInCm;
            label95.Text = glm.unitsInCm;
            label97.Text = glm.unitsInCm;
        }

        private void tabVDimensions_Leave(object sender, EventArgs e)
        {
        }

        private void nudTractorHitchLength_ValueChanged(object sender, EventArgs e)
        {
            Settings.Tool.hitchLength = nudTractorHitchLength.Value;
            if (!Settings.Tool.isToolFront)
            {
                Settings.Tool.hitchLength *= -1;
            }
        }

        private void nudWheelbase_ValueChanged(object sender, EventArgs e)
        {
            Settings.Vehicle.setVehicle_wheelbase = nudWheelbase.Value;
            mf.vehicle.wheelbase = Settings.Vehicle.setVehicle_wheelbase;
        }

        private void nudVehicleTrack_ValueChanged(object sender, EventArgs e)
        {
            Settings.Vehicle.setVehicle_trackWidth = nudVehicleTrack.Value;
            mf.vehicle.trackWidth = Settings.Vehicle.setVehicle_trackWidth;
            mf.tram.halfWheelTrack = mf.vehicle.trackWidth * 0.5;
        }

        #endregion

        #region VConfig Enter/Leave

        private void tabVConfig_Enter(object sender, EventArgs e)
        {
            if (mf.vehicle.vehicleType == 0) rbtnTractor.Checked = true;
            else if (mf.vehicle.vehicleType == 1) rbtnHarvester.Checked = true;
            else if (mf.vehicle.vehicleType == 2) rbtn4WD.Checked = true;

            original = null;
            TabImageSetup();
        }

        private void tabVConfig_Leave(object sender, EventArgs e)
        {
            if (rbtnTractor.Checked)
            {
                mf.vehicle.vehicleType = 0;
                Settings.Vehicle.setVehicle_vehicleType = 0;
            }
            if (rbtnHarvester.Checked)
            {
                mf.vehicle.vehicleType = 1;
                Settings.Vehicle.setVehicle_vehicleType = 1;

                if ( Settings.Tool.hitchLength < 0) Settings.Tool.hitchLength *= -1;

                Settings.Tool.isToolFront = true;
                Settings.Tool.isToolTBT = false;
                Settings.Tool.isToolTrailing = false;
                Settings.Tool.isToolRearFixed = false;
            }
            if (rbtn4WD.Checked)
            {
                mf.vehicle.vehicleType = 2;
                Settings.Vehicle.setVehicle_vehicleType = 2;
            }

            //the old brand code
            Settings.Vehicle.isVehicleImage = !cboxIsImage.Checked;

            mf.vehicleOpacityByte = (byte)(255 * (mf.vehicleOpacity));
            Settings.Vehicle.vehicleOpacity = (int)(mf.vehicleOpacity * 100);

            Settings.User.colorVehicle = mf.vehicleColor;

            if (rbtnTractor.Checked)
            {

                Bitmap bitmap = mf.GetTractorImage();

                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.Tractor]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);

            }

            if (rbtnHarvester.Checked)

            {
                Bitmap bitmap = mf.GetHarvesterImage();

                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.Harvester]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);

            }

            if (rbtn4WD.Checked)
            {
                Bitmap bitmap = mf.Get4WDFrontImage();

                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.FourWDFront]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);

                bitmap = mf.Get4WDRearImage();

                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.FourWDRear]);
                bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);
            }
        }

        //Opacity Bar

        Image original = null;

        private void rbtnVehicleType_Click(object sender, EventArgs e)
        {
            if (rbtnTractor.Checked)
            {
                mf.vehicle.vehicleType = 0;
                Settings.Vehicle.setVehicle_vehicleType = 0;
            }
            if (rbtnHarvester.Checked)
            {
                mf.vehicle.vehicleType = 1;
                Settings.Vehicle.setVehicle_vehicleType = 1;
            }
            if (rbtn4WD.Checked)
            {
                mf.vehicle.vehicleType = 2;
                Settings.Vehicle.setVehicle_vehicleType = 2;
            }

            original = null;
            TabImageSetup();
        }

        private void SetOpacity()
        {
            if (original == null) original = (Bitmap)pboxAlpha.BackgroundImage.Clone();
            pboxAlpha.BackColor = Color.Transparent;
            pboxAlpha.BackgroundImage = SetAlpha((Bitmap)original, (byte)(mf.vehicleOpacityByte));
        }

        private void btnOpacityUPGN_Click(object sender, EventArgs e)
        {
            mf.vehicleOpacity = Math.Min(mf.vehicleOpacity + 0.2, 1);
            lblOpacityPercent.Text = ((int)(mf.vehicleOpacity * 100)).ToString() + "%";
            mf.vehicleOpacityByte = (byte)(255 * (mf.vehicleOpacity));
            Settings.Vehicle.vehicleOpacity = (int)(mf.vehicleOpacity * 100);
            
            SetOpacity();
        }

        private void btnOpacityDn_Click(object sender, EventArgs e)
        {
            mf.vehicleOpacity = Math.Max(mf.vehicleOpacity - 0.2, 0.2);
            lblOpacityPercent.Text = ((int)(mf.vehicleOpacity * 100)).ToString() + "%";
            mf.vehicleOpacityByte = (byte)(255 * (mf.vehicleOpacity));
            Settings.Vehicle.vehicleOpacity = (int)(mf.vehicleOpacity * 100);
            
            SetOpacity();
        }

        private void cboxIsImage_Click(object sender, EventArgs e)
        {
            //mf.vehicleOpacity = (hsbarOpacity.Value * 0.01);
            mf.vehicleOpacityByte = (byte)(255 * (mf.vehicleOpacity));
            Settings.Vehicle.vehicleOpacity = (int)(mf.vehicleOpacity * 100);
            Settings.Vehicle.isVehicleImage = (!cboxIsImage.Checked);
            
            //original = null;
            TabImageSetup();
        }

        private void TabImageSetup()
        {
            if (Settings.Vehicle.isVehicleImage)
            {
                if (mf.vehicle.vehicleType == 0)
                {
                    //pboxAlpha.BackgroundImage = mf.GetTractorImage(Settings.Vehicle.setBrand_TBrand);
                }
                else if (mf.vehicle.vehicleType == 1)
                {

                    //pboxAlpha.BackgroundImage = mf.GetHarvesterImage(Settings.Vehicle.setBrand_HBrand);
                }
                else if (mf.vehicle.vehicleType == 2)
                {
                    //pboxAlpha.BackgroundImage = mf.Get4WDFrontImage(Settings.Vehicle.setBrand_WDBrand);
                }

                mf.vehicleOpacityByte = (byte)(255 * (mf.vehicleOpacity));
                Settings.Vehicle.vehicleOpacity = (int)(mf.vehicleOpacity * 100);
                lblOpacityPercent.Text = ((int)(mf.vehicleOpacity * 100)).ToString() + "%";
            }
            else
            {
                pboxAlpha.BackgroundImage = Properties.Resources.TriangleVehicle;
                lblOpacityPercent.Text = ((int)(mf.vehicleOpacity * 100)).ToString() + "%";
            }
            mf.vehicleColor = Color.FromArgb(254, 254, 254);

            cboxIsImage.Checked = !Settings.Vehicle.isVehicleImage;

            original = null;
            SetOpacity();
        }

        static Bitmap SetAlpha(Bitmap bmpIn, int alpha)
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            float a = alpha / 255f;
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
                            new float[] {1, 0, 0, 0, 0},
                            new float[] {0, 1, 0, 0, 0},
                            new float[] {0, 0, 1, 0, 0},
                            new float[] {0, 0, 0, a, 0},
                            new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
                g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
        }

        private void LoadBrandImage()
        {
            if (rbtnTractor.Checked)
            {
                Bitmap bitmap = mf.GetTractorImage();

                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.Tractor]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);
            }
            else if (rbtnHarvester.Checked)
            {
                Bitmap bitmap = mf.GetHarvesterImage();

                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.Harvester]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);

            }
            else if (rbtn4WD.Checked)
            {
                Bitmap bitmap = mf.Get4WDFrontImage();

                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.FourWDFront]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);
                bitmap = mf.Get4WDRearImage();

                GL.BindTexture(TextureTarget.Texture2D, mf.texture[(int)FormGPS.textures.FourWDRear]);
                bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);
            }
        }

        #endregion
    }
}

