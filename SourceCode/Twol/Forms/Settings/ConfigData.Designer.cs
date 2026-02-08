using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Twol.Classes;

namespace Twol
{
    public partial class FormConfig
    {
        #region Heading
        private void tabDHeading_Enter(object sender, EventArgs e)
        {
            nudDualHeadingOffset.Value = Settings.Vehicle.setGPS_dualHeadingOffset;
            nudDualReverseDistance.Value = Settings.Vehicle.setGPS_dualReverseDetectionDistance;

            hsbarFusion.Value = (int)(Settings.Vehicle.setIMU_fusionWeight2 * 500);
            lblFusion.Text = (hsbarFusion.Value).ToString();
            lblFusionIMU.Text = (100 - hsbarFusion.Value).ToString();

            cboxIsRTK.Checked = Settings.Vehicle.setGPS_isRTK;
            cboxIsRTK_KillAutoSteer.Checked = Settings.Vehicle.setGPS_isRTK_KillAutoSteer;

            cboxIsReverseOn.Checked = Settings.Vehicle.setIMU_isReverseOn;

            if (Settings.Vehicle.setF_minHeadingStepDistance == 1.0)
                cboxMinGPSStep.Checked = true;
            else
                cboxMinGPSStep.Checked = false;

            if (cboxMinGPSStep.Checked)
            {
                Settings.Vehicle.setF_minHeadingStepDistance = 1.0;
                Settings.Vehicle.setGPS_minimumStepLimit = 0.1;
                cboxMinGPSStep.Text = "10 cm";
                lblHeadingDistance.Text = "100 cm";
            }
            else
            {
                Settings.Vehicle.setF_minHeadingStepDistance = 0.5;
                Settings.Vehicle.setGPS_minimumStepLimit = 0.05;
                cboxMinGPSStep.Text = "5 cm";
                lblHeadingDistance.Text = "50 cm";
            }

            if (mf.ahrs.imuHeading != 99999)
            {
                hsbarFusion.Enabled = true;
            }
            else
            {
                hsbarFusion.Enabled = false;
            }

            //nudMinimumFrameTime.Value = Properties.Settings.Default.SetGPS_udpWatchMsec;

            //nudForwardComp.Value = (decimal)(Properties.Settings.Default.setGPS_forwardComp);
            //nudReverseComp.Value = (decimal)(Properties.Settings.Default.setGPS_reverseComp);
            //nudAgeAlarm.Value = Properties.Settings.Default.setGPS_ageAlarm;
        }

        private void tabDHeading_Leave(object sender, EventArgs e)
        {
            Settings.Vehicle.setGPS_isRTK = cboxIsRTK.Checked;

            Settings.Vehicle.setIMU_isReverseOn = cboxIsReverseOn.Checked;
            Settings.Vehicle.setGPS_isRTK_KillAutoSteer = cboxIsRTK_KillAutoSteer.Checked;

            if (cboxMinGPSStep.Checked)
            {
                Settings.Vehicle.setF_minHeadingStepDistance = 1.0;
                Settings.Vehicle.setGPS_minimumStepLimit = 0.1;
            }
            else
            {
                Settings.Vehicle.setF_minHeadingStepDistance = 0.5;
                Settings.Vehicle.setGPS_minimumStepLimit = 0.05;
            }            
        }

        private void nudDualHeadingOffset_ValueChanged(object sender, EventArgs e)
        {
            Settings.Vehicle.setGPS_dualHeadingOffset = nudDualHeadingOffset.Value;
        }

        private void nudDualReverseDistance_ValueChanged(object sender, EventArgs e)
        {
            Settings.Vehicle.setGPS_dualReverseDetectionDistance = nudDualReverseDistance.Value;
        }

        private void cboxMinGPSStePGN_Click(object sender, EventArgs e)
        {
            if (cboxMinGPSStep.Checked)
            {
                Settings.Vehicle.setF_minHeadingStepDistance = 1;
                Settings.Vehicle.setGPS_minimumStepLimit = 0.1;
                cboxMinGPSStep.Text = "10 cm";
                lblHeadingDistance.Text = "100 cm";
            }
            else
            {
                Settings.Vehicle.setF_minHeadingStepDistance = 0.5;
                Settings.Vehicle.setGPS_minimumStepLimit = 0.05;
                cboxMinGPSStep.Text = "5 cm";
                lblHeadingDistance.Text = "50 cm";
            }

        }

        private void hsbarFusion_ValueChanged(object sender, EventArgs e)
        {
            lblFusion.Text = (hsbarFusion.Value).ToString()+"%";
            lblFusionIMU.Text = (100 - hsbarFusion.Value).ToString()+"%";

            Settings.Vehicle.setIMU_fusionWeight2 = (double)hsbarFusion.Value * 0.002;
        }

        #endregion

        #region Roll

        private void tabDRoll_Enter(object sender, EventArgs e)
        {
            //Roll
            lblRollZeroOffset.Text = Settings.Vehicle.setIMU_rollZero.ToString("N2");
            hsbarRollFilter.Value = (int)(Settings.Vehicle.setIMU_rollFilter * 100);
            cboxDataInvertRoll.Checked = Settings.Vehicle.setIMU_invertRoll;
        }

        private void cboxDataInvertRoll_Click(object sender, EventArgs e)
        {
            Settings.Vehicle.setIMU_invertRoll = !Settings.Vehicle.setIMU_invertRoll;
        }

        private void hsbarRollFilter_ValueChanged(object sender, EventArgs e)
        {
            lblRollFilterPercent.Text = hsbarRollFilter.Value.ToString();
            Settings.Vehicle.setIMU_rollFilter = hsbarRollFilter.Value * 0.01;
        }

        private void btnRollOffsetDown_Click(object sender, EventArgs e)
        {
            Settings.Vehicle.setIMU_rollZero -= 0.1;
            lblRollZeroOffset.Text = Settings.Vehicle.setIMU_rollZero.ToString("N2");
        }

        private void btnRollOffsetUPGN_Click(object sender, EventArgs e)
        {
            Settings.Vehicle.setIMU_rollZero += 0.1;
            lblRollZeroOffset.Text = Settings.Vehicle.setIMU_rollZero.ToString("N2");
        }

        private void btnZeroRoll_Click(object sender, EventArgs e)
        {
            if (mf.ahrs.imuRoll != 88888)
            {
                mf.ahrs.imuRoll += Settings.Vehicle.setIMU_rollZero;
                Settings.Vehicle.setIMU_rollZero = mf.ahrs.imuRoll;
                lblRollZeroOffset.Text = Settings.Vehicle.setIMU_rollZero.ToString("N2");
                Log.EventWriter("Roll Zeroed with " + Settings.Vehicle.setIMU_rollZero.ToString());
            }
            else
            {
                lblRollZeroOffset.Text = "***";
            }
        }

        private void btnRemoveZeroOffset_Click(object sender, EventArgs e)
        {
            Settings.Vehicle.setIMU_rollZero = 0;
            lblRollZeroOffset.Text = "0.00";
            Log.EventWriter("Roll Zero Offset Removed");
        }

        #endregion

        #region Features On Off

        private void tabBtns_Enter(object sender, EventArgs e)
        {
            cboxFeatureTram.Checked = Settings.User.setFeatures.isTramOn;
            cboxFeatureHeadland.Checked = Settings.User.setFeatures.isHeadlandOn;
            cboxFeatureBoundary.Checked = Settings.User.setFeatures.isBoundaryOn;

            //the nudge controls at bottom menu
            cboxFeatureNudge.Checked = Settings.User.setFeatures.isABLineOn;
            //cboxFeatureBoundaryContour.Checked = Properties.Settings.Default.setFeatures.isBndContourOn;
            cboxFeatureABSmooth.Checked = Settings.User.setFeatures.isABSmoothOn;
            cboxFeatureHideContour.Checked = Settings.User.setFeatures.isHideContourOn;

            cboxFeatureUTurn.Checked = Settings.User.setFeatures.isUTurnOn;
            cboxFeatureLateral.Checked = Settings.User.setFeatures.isLateralOn;

            cboxTurnSound.Checked = Settings.User.sound_isUturnOn;
            cboxSteerSound.Checked = Settings.User.sound_isAutoSteerOn;
            cboxSectionsSound.Checked = Settings.User.sound_isSectionsOn;

            cboxShutdownWhenNoPower.Checked = Settings.User.setDisplay_isShutdownWhenNoPower;
            cboxHardwareMessages.Checked = Settings.User.setDisplay_isHardwareMessages;
        }

        private void tabBtns_Leave(object sender, EventArgs e)
        {
            Settings.User.setFeatures.isTramOn = cboxFeatureTram.Checked;
            Settings.User.setFeatures.isHeadlandOn = cboxFeatureHeadland.Checked;

            Settings.User.setFeatures.isABLineOn = cboxFeatureNudge.Checked;

            Settings.User.setFeatures.isBoundaryOn = cboxFeatureBoundary.Checked;
            Settings.User.setFeatures.isABSmoothOn = cboxFeatureABSmooth.Checked;
            Settings.User.setFeatures.isHideContourOn = cboxFeatureHideContour.Checked;

            Settings.User.setFeatures.isLateralOn = cboxFeatureLateral.Checked;
            Settings.User.setFeatures.isUTurnOn = cboxFeatureUTurn.Checked;

            mf.SetFeatureSettings();

            Settings.User.sound_isUturnOn = cboxTurnSound.Checked;
            Settings.User.sound_isAutoSteerOn = cboxSteerSound.Checked;
            Settings.User.sound_isSectionsOn = cboxSectionsSound.Checked;

            Settings.User.setDisplay_isShutdownWhenNoPower = cboxShutdownWhenNoPower.Checked;
            Settings.User.setDisplay_isHardwareMessages = cboxHardwareMessages.Checked;            
        }

        #endregion

        #region Tab Display
        private void tabDisplay_Enter(object sender, EventArgs e)
        {
            chkDisplayFloor.Checked = Settings.User.setDisplay_isTextureOn;
            chkDisplayMapping.Checked = Settings.User.isWorldMapOn;

            chkDisplayGrid.Checked = Settings.User.isGridOn;
            chkDisplaySpeedo.Checked = Settings.User.isSpeedoOn;

            chkSvennArrow.Checked = Settings.User.setDisplay_isSvennArrowOn;
            chkDisplayExtraGuides.Checked = Settings.User.isSideGuideLines;

            chkDirectionMarkers.Checked = Settings.User.isDirectionMarkers;
            chkSectionLines.Checked = Settings.User.setDisplay_isSectionLinesOn;
            chkLineSmooth.Checked = Settings.User.setDisplay_isLineSmooth;
        }

        private void tabDisplay_Leave(object sender, EventArgs e)
        {
            SaveDisplaySettings();
        }

        private void chkDisplayMapping_Click(object sender, EventArgs e)
        {
            if (chkDisplayMapping.Checked)
            {
                if (chkDisplayFloor.Checked)
                {
                    chkDisplayFloor.Checked = false;
                }
            }
        }

        private void chkDisplayFloor_Click(object sender, EventArgs e)
        {
            if (chkDisplayFloor.Checked)
            {
                if (chkDisplayMapping.Checked)
                {
                    chkDisplayMapping.Checked = false;
                }
            }
        }

        private void SaveDisplaySettings()
        {

            Settings.User.setDisplay_isTextureOn = chkDisplayFloor.Checked;

            Settings.User.isWorldMapOn = chkDisplayMapping.Checked;
            if (Settings.User.isWorldMapOn) Settings.User.setDisplay_isTextureOn = false;

            Settings.User.isGridOn = chkDisplayGrid.Checked;
            Settings.User.isSpeedoOn = chkDisplaySpeedo.Checked;

            Settings.User.setDisplay_isSvennArrowOn = chkSvennArrow.Checked;

            Settings.User.isDirectionMarkers = chkDirectionMarkers.Checked;
            Settings.User.setDisplay_isSectionLinesOn = chkSectionLines.Checked;
            Settings.User.setDisplay_isLineSmooth = chkLineSmooth.Checked;
        }

        private void SaveUserSettings()
        {
            Settings.User.isMetric = rbtnDisplayMetric.Checked;
            Settings.User.isSideGuideLines = chkDisplayExtraGuides.Checked;

            Settings.User.setDisplay_isBrightnessOn = chkDisplayBrightness.Checked;
            mf.isDrawPolygons = chkDisplayPolygons.Checked;

            Settings.User.setDisplay_isStartFullScreen = chkDisplayStartFullScreen.Checked;
            Settings.User.isLogElevation = chkDisplayLogElevation.Checked;

            Settings.User.setDisplay_isKeyboardOn = chkDisplayKeyboard.Checked;
        }

        #endregion

        #region User Tab

        private void tabUser_Enter(object sender, EventArgs e)
        {
            chkDisplayLogElevation.Checked = Settings.User.isLogElevation;
            rbtnDisplayMetric.Checked = Settings.User.isMetric;
            rbtnDisplayImperial.Checked = !rbtnDisplayMetric.Checked;
            nudNumGuideLines.Value = Settings.Vehicle.setAS_numGuideLines;

            chkDisplayBrightness.Checked = Settings.User.setDisplay_isBrightnessOn;
            chkDisplayPolygons.Checked = mf.isDrawPolygons;
            chkDisplayStartFullScreen.Checked = Settings.User.setDisplay_isStartFullScreen;
            chkDisplayKeyboard.Checked = Settings.User.setDisplay_isKeyboardOn;

        }

        private void tabUser_Leave(object sender, EventArgs e)
        {
            SaveUserSettings();
        }

        private void rbtnDisplayImperial_Click(object sender, EventArgs e)
        {
            mf.TimedMessageBox(2000, "Units Set", "Imperial");
            Log.EventWriter("Units To Imperial");

            Settings.User.isMetric = false;
            mf.ChangeMetricImperial();

            lblVehicleToolWidth.Text = Convert.ToString((int)(Settings.Tool.toolWidth * glm.m2InchOrCm));
            SectionFeetInchesTotalWidthLabelUpdate();
        }

        private void rbtnDisplayMetric_Click(object sender, EventArgs e)
        {
            mf.TimedMessageBox(2000, "Units Set", "Metric");
            Log.EventWriter("Units to Metric");

            Settings.User.isMetric = true;
            mf.ChangeMetricImperial();

            lblVehicleToolWidth.Text = Convert.ToString((int)(Settings.Tool.toolWidth * glm.m2InchOrCm));
            SectionFeetInchesTotalWidthLabelUpdate();
        }

        private void nudNumGuideLines_ValueChanged(object sender, EventArgs e)
        {
            Settings.Vehicle.setAS_numGuideLines = (int)nudNumGuideLines.Value;
        }

        private void btnSetDirectories_Click(object sender, EventArgs e)
        {
            if (mf.isFieldStarted)
            {
                mf.TimedMessageBox(2000, gStr.Get(gs.gsFieldIsOpen), gStr.Get(gs.gsCloseFieldFirst));
                return;
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Currently: " + RegistrySettings.workingDirectory;

            if (RegistrySettings.workingDirectory == "Default") fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else fbd.SelectedPath = RegistrySettings.workingDirectory;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                RegistrySettings.Save("WorkingDirectory", fbd.SelectedPath);
                //RegistrySettings.CreateDirectories();

                //restart program
                MessageBox.Show(gStr.Get(gs.gsProgramWillExitPleaseRestart));
                Close();
            }
        }

        private void btnHotkeys_Click(object sender, EventArgs e)
        {
            using (var form = new Form_Keys(mf))
            {
                form.ShowDialog(this);
            }

        }

        private void btnLogViewer_Click(object sender, EventArgs e)
        {
            Form form = new FormEventViewer(Path.Combine(RegistrySettings.logsDirectory, "TWOL_Events_Log.txt"));
            form.Show(this);
        }

        #endregion

        #region Tab Colors

        private void btnSetColors_Click(object sender, EventArgs e)
        {
            using (var form = new FormColor(mf))
            {
                form.ShowDialog(this);
            }

        }

        private void btnSectionColors_Click(object sender, EventArgs e)
        {
            if (Settings.Tool.isSectionsNotZones)
            {
                using (var form = new FormColorSection(mf))
                {
                    form.ShowDialog(this);
                }
            }
            else
            {
                mf.TimedMessageBox(2000, "Cannot use with zones", "Only for Sections");
            }

        }

        #endregion
    }
}
