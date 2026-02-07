//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Twol.Properties;
using System.Globalization;
using System.IO;
using System.Media;
using System.Reflection;
using System.Collections.Generic;

using System.Text;
using Twol.Classes;

namespace Twol
{
    public partial class FormGPS
    {
        //ABLines directory
        public string ablinesDirectory;
        public string fieldData, guidanceLineText;
        private int _iPrevMoveX, _iPrevMoveY;

        //colors for sections and field background
        public byte flagColor = 0;

        //polygon mode for section drawing
        public bool isDrawPolygons = false, isPauseFieldTextCounter = false;

        public Color vehicleColor;
        public double vehicleOpacity;
        public byte vehicleOpacityByte;

        public bool isFlashOnOff = false, isPanFormVisible = false;
        public bool isPanelBottomHidden = false;

        public int makeUTurnCounter = 0;

        //makes nav panel disappear after 6 seconds
        private int navPanelCounter = 0, trackMethodPanelCounter = 0;
        public uint sentenceCounter = uint.MaxValue;
        public int guideLineCounter = 0;
        public int hardwareLineCounter = 0;
        public bool isHardwareMessages = false;

        private int currentFieldTextCounter = 0;

        //For field saving in background
        private int fileSaveCounter = 1;
        private int counterCheckInternet = 1;

        private int threeSecondCounter = 0;
        public int twoSecondCounter = 0;
        private int oneSecondCounter = 0;
        private int oneHalfSecondCounter = 0;

        //Timer triggers at 250 msec
        private void tmrWatchdog_tick(object sender, EventArgs e)
        {
            if (sentenceCounter == 10)
            {
                Log.EventWriter("No GPS Warning - Lost GPS");
            }

            if (++sentenceCounter > 11)
            {
                ShowNoGPSWarning();

                oneSecondCounter++;

                if (oneSecondCounter >= 4)
                {
                    //reset the counter
                    oneSecondCounter = 0;
                    
                    UpdateNTRIP();

                    //Hello Alarm logic
                    DoHelloAlarmLogic();
                    DoTraffic();
                }

                return;
            }

            //////////////////////////////////////////////////////////////////////////////////////
            //every 3 second update status
            if (threeSecondCounter >= 3)
            {
                //reset the counter
                threeSecondCounter = 0;

                if (!isPauseFieldTextCounter)
                {
                    if (++currentFieldTextCounter > 3) currentFieldTextCounter = 0;
                }

                if (isBtnAutoSteerOn || workState != btnStates.Off)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                }

                if (isFieldStarted)
                {
                    switch (currentFieldTextCounter)
                    {
                        case 0:
                            lblCurrentField.Text = gStr.Get(gs.gsField) + ": " + displayFieldName + " * Job: " + displayJobName;
                            break;

                        case 1:
                            lblCurrentField.Text = (bnd.bndList.Count > 0 ? fd.AreaBoundaryLessInners
                                + "  " : "") + "App: " + fd.WorkedArea
                                + "  Actual: " + fd.ActualAreaWorked
                                + "  " + fd.WorkedAreaRemainPercentage
                                + "  " + fd.WorkRateHour;
                            break;

                        case 2:
                            if (trks.currentRefTrack != null)
                                lblCurrentField.Text = "Line: " + trks.currentRefTrack.name;
                            else
                                lblCurrentField.Text = "Line: " + gStr.Get(gs.gsNoGuidanceLines);
                            break;

                        case 3:
                            lblCurrentField.Text = "";
                            break;

                        default:
                            break;
                    }

                    if (tram.displayMode == 0)
                        tram.isRightManualOn = tram.isLeftManualOn = false;
                }
                else
                {
                    switch (currentFieldTextCounter)
                    {
                        case 0:
                            lblCurrentField.Text = (Settings.Tool.toolWidth * glm.m2FtOrM).ToString("N2") + glm.unitsFtM + " - " + RegistrySettings.vehicleFileName;
                            break;

                        case 1:
                            lblCurrentField.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss ");
                            break;

                        case 2:
                            lblCurrentField.Text = "Lat: " + pn.latitude.ToString("N7") + "   Lon: " + pn.longitude.ToString("N7");
                            break;

                        case 3:
                            lblCurrentField.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss ");
                            break;

                        case 4:
                            lblCurrentField.Text = "";
                            break;

                        default:
                            break;
                    }
                }

                if (isPauseFieldTextCounter)
                {
                    lblCurrentField.Text = "\u23F8" + " " + lblCurrentField.Text;
                }
                else
                {
                    lblCurrentField.Text = "\u25B6" + " " + lblCurrentField.Text;
                }

                //fix
                if (timerSim.Enabled && pn.fixQuality++ > 5) pn.fixQuality = 2;

                counterCheckInternet += 3;

                //set btninternetconnection to correct image - checked every 50 secs by CheckInternetConnection
                btnInternetConnection.BackColor = isInternetConnected ? Color.PaleGreen : Color.Salmon;
            }

            /////////////////////////////   2 second  ////////////////////////////////////////
            //every 2 second update status
            if (twoSecondCounter >= 2)
            {
                //reset the counter
                twoSecondCounter = 0;

                //hide the Nav panel in 6  secs
                if (panelNavigation.Visible)
                {
                    if (navPanelCounter-- <= 0)
                    {
                        panelNavigation.Visible = false;
                    }
                }

                //send a hello to modules
                SendUDPMessage(helloFromTwol, epModule);

                //Hello Alarm logic
                DoHelloAlarmLogic();

                DoTraffic();

                //if (ntripCounter > 30)
                //{
                //    isNTRIPToggle = !isNTRIPToggle;
                //    if (isNTRIPToggle) btnRTCM_Top.BackColor = Color.LightGray;
                //    else btnRTCM_Top.BackColor = Color.PaleGreen;
                //}
                //else
                //{
                //    btnRTCM_Top.BackColor = Color.Transparent;
                //}

                btnRTCM_Top.BackColor = (ntripCounter > 30) ? Color.PaleGreen : Color.Salmon;

            }//end every 2 seconds

            //every second update all status //////   1 Second ////////////////////////////
            if (oneSecondCounter >= 8)
            {
                //reset the counter
                oneSecondCounter = 0;

                //general counters
                twoSecondCounter++;
                threeSecondCounter++;

                //counter used for saving field in background - is actually 30 second
                fileSaveCounter++;

                //wait to engage deadzone before time is up
                vehicle.deadZoneDelayCounter++;

                //auto find closest track counter
                trks.autoTrack3SecTimer++;

                //used for alarm flashing
                isFlashOnOff = !isFlashOnOff;

                lblFix.Text = FixQuality + "Age: " + pn.age.ToString("N1") + "   " + frameTime.ToString("N1") ;

                switch (pn.fixQuality)
                {
                    case 4:
                        btnGPSData.BackColor = Color.PaleGreen;
                        break;
                    case 5:
                        btnGPSData.BackColor = Color.Orange;
                        break;
                    case 2:
                        btnGPSData.BackColor = Color.Yellow;
                        break;
                    default:
                        btnGPSData.BackColor = Color.Red;
                        break;
                }

                if (flp1.Visible)
                {
                    if (trackMethodPanelCounter-- < 1) flp1.Visible = false;
                }

                if (isJobStarted && Settings.Tool.setApp_isNozzleApp)
                {
                    UpdateNozzleMainPanel();
                }

                if (gydTool.manualSteerTimer > 0) gydTool.manualSteerTimer--;

                UpdateNTRIP();
            }

            //every half of a second update all status  ////////////////    0.5  0.5   0.5    0.5    /////////////////
            if (oneHalfSecondCounter >= 4)
            {
                //reset the counter
                oneHalfSecondCounter = 0;

                //the main formgps window
                //status strip values
                distanceToolBtn.Text = fd.DistanceUser + "\r\n" + fd.WorkedUserArea;
                btnAutoSteerConfig.Text = SetSteerAngle + "\r\n" + ActualSteerAngle;

                //Nozzz

                if (mc.actualToolAngleDegrees != double.MaxValue)
                {
                    btnToolSteerConfig.Text = mc.actualToolAngleDegrees.ToString("N1") + "°";
                }

                for (int j = 0; j < controlLbls.Count; j++)
                {
                    //if section is on, green, if off, red color
                    if (section[j].isSectionOn)
                    {
                        if (section[j].sectionBtnState == btnStates.Auto)
                        {
                            //GL.Color3(0.0f, 0.9f, 0.0f);
                            if (section[j].isMappingOn) controlLbls[j].BackColor = Settings.User.setDisplay_isDayMode ? Color.Lime : Color.ForestGreen;
                            else controlLbls[j].BackColor = Color.DeepPink;
                        }
                        else controlLbls[j].BackColor = Settings.User.setDisplay_isDayMode ? Color.Yellow : Color.DarkGoldenrod;
                    }
                    else
                    {
                        if (!section[j].isMappingOn) controlLbls[j].BackColor = Settings.User.setDisplay_isDayMode ? Color.Red : Color.Crimson;
                        else controlLbls[j].BackColor = Color.RoyalBlue;
                        //GL.Color3(0.7f, 0.2f, 0.2f);
                    }
                }

            } //end every 1/2 second

            //every 1/8 second update  ///////////////////////////   One Eighth Second ////////////////////////////
            {
                //reset the counter
                oneHalfSecondCounter++;
                oneSecondCounter++;
                makeUTurnCounter++;

                secondsSinceStart = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;
            }

        }//wait till timer fires again.

        public void LoadSettings()
        {
            guidelinesToolStripMenuItem.Checked = Settings.User.isSideGuideLines;

            nozzleAppToolStripMenuItem.Checked = Settings.Tool.setApp_isNozzleApp;

            panelSim.Visible = timerSim.Enabled = simulatorOnToolStripMenuItem.Checked = Settings.User.isSimulatorOn;
            cboxEnableToolDualGPS.Checked = Settings.User.isSimToolDualOn;

            SetFeatureSettings();

            //OGL control
            cboxpRowWidth.SelectedIndex = (Settings.Vehicle.set_youSkipWidth - 1);
            btnYouSkipEnable.Image = Resources.YouSkipOff;

            ChangeMetricImperial();

            SetNozzleSettings();

            SetToolSettings();

            vehicleOpacity = ((double)(Settings.Vehicle.vehicleOpacity) * 0.01);
            vehicleOpacityByte = (byte)(255 * ((double)(Settings.Vehicle.vehicleOpacity) * 0.01));

            if (Settings.Tool.setToolSteer.isGPSToolActive) btnGPSTool.Enabled = true;
            else btnGPSTool.Enabled = false;

            //set the flag mark button to red dot
            btnFlag.Image = Properties.Resources.FlagRed;

            vehicleColor = Settings.User.colorVehicle;

            btnHeadlandOnOff.Image = bnd.isHeadlandOn ? Properties.Resources.HeadlandOn : Properties.Resources.HeadlandOff;

            //btnChangeMappingColor.BackColor = sectionColorDay;
            btnChangeMappingColor.Text = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            yt.ResetCreatedYouTurn();

            //workswitch stuff

            fd.workedAreaTotalUser = Settings.Vehicle.setF_UserTotalArea;

            if (Settings.User.setDisplay_isStartFullScreen)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            //main window first
            //main window first
            if (Settings.User.setWindow_Maximized)
            {
                WindowState = FormWindowState.Normal;
                Location = Settings.User.setWindow_Location;
                Size = Settings.User.setWindow_Size;
            }
            else if (Settings.User.setWindow_Minimized)
            {
                //WindowState = FormWindowState.Minimized;
                Location = Settings.User.setWindow_Location;
                Size = Settings.User.setWindow_Size;
            }
            else
            {
                Location = Settings.User.setWindow_Location;
                Size = Settings.User.setWindow_Size;
            }

            if (!IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }

            //night mode
            SwapDayNightMode(false);

            //load uturn properties
            yt.LoadSettings();

            bnd.isSectionControlledByHeadland = true;
            cboxIsSectionControlled.Image = Properties.Resources.HeadlandSectionOn;

            //right side build
            PanelBuildRightMenu(Settings.User.setDisplay_buttonOrder.Split(','));

            PanelsAndOGLSize();
            PanelUpdateRightAndBottom();

            SetZoom();

            lblGuidanceLine.BringToFront();
            lblHardwareMessage.BringToFront();
            isHardwareMessages = Settings.User.setDisplay_isHardwareMessages;

            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
            {
                btnChargeStatus.BackColor = Color.YellowGreen;
            }
            else
            {
                btnChargeStatus.BackColor = Color.LightCoral;
            }

            SetText();

            Panel_IO_Location();
            panel_IO.Visible = false;

            cboxIsIMUModule.Checked = Settings.IO.setMod_isIMUConnected;
            cboxIsSteerModule.Checked = Settings.IO.setMod_isSteerConnected;
            cboxIsMachineModule.Checked = Settings.IO.setMod_isMachineConnected;

            btnGPSTool.Visible = Settings.Tool.setToolSteer.isGPSToolActive;

            SetModulesOnOff();

            //if (Settings.Tool.setToolSteer.isFollowCurrent || Settings.Tool.setToolSteer.isFollowPivot || Settings.Tool.setToolSteer.isRecordToolLine)
            //{
            //    //show FormToolManual
            //    Form form = new FormToolManual(this);
            //    form.Show(this);
            //}
        }

        public void SetFeatureSettings()
        {
            //field menu
            boundariesToolStripMenuItem.Visible = Settings.User.setFeatures.isBoundaryOn;
            headlandToolStripMenuItem.Visible = Settings.User.setFeatures.isHeadlandOn;
            headlandBuildToolStripMenuItem.Visible = Settings.User.setFeatures.isHeadlandOn;
            tramsMultiMenuField.Visible = Settings.User.setFeatures.isTramOn;
            recordedPathStripMenu.Visible = Settings.User.setFeatures.isRecPathOn;

            //tools menu
            //deleteContourPathsToolStripMenuItem.Visible = Settings.User.setFeatures.isHideContourOn;

            //left side
            btnToolSteerConfig.Visible = true;
        }

        public void SetNozzleSettings()
        {
            //Nozzle Spray Controller

            PGN_226.pgn[PGN_226.calNumHi] = unchecked((byte)(Settings.Tool.setNozz.calNumber >> 8)); ;
            PGN_226.pgn[PGN_226.calNumLo] = unchecked((byte)(Settings.Tool.setNozz.calNumber));
            PGN_226.pgn[PGN_226.pressureCalHi] = unchecked((byte)(Settings.Tool.setNozz.pressureCal >> 8));
            PGN_226.pgn[PGN_226.pressureCalLo] = unchecked((byte)(Settings.Tool.setNozz.pressureCal));
            PGN_226.pgn[PGN_226.Kp] = Settings.Tool.setNozz.Kp;
            PGN_226.pgn[PGN_226.Ki] = Settings.Tool.setNozz.Ki;
            PGN_226.pgn[PGN_226.minPressure] = unchecked((byte)(Settings.Tool.setNozz.pressureMin));
            PGN_226.pgn[PGN_226.fastPWM] = Settings.Tool.setNozz.fastPWM;
            PGN_226.pgn[PGN_226.slowPWM] = Settings.Tool.setNozz.slowPWM;
            PGN_226.pgn[PGN_226.deadbandError] = Settings.Tool.setNozz.deadbandError;
            PGN_226.pgn[PGN_226.switchAtFlowError] = Settings.Tool.setNozz.switchAtRateError;

            if (Settings.Tool.setNozz.isBypass)
                PGN_226.pgn[PGN_226.isBypass] = 1;
            else
                PGN_226.pgn[PGN_226.isBypass] = 0;

            if (Settings.Tool.setNozz.isMeter)
                PGN_226.pgn[PGN_226.isBypass] += 2;
            else
                PGN_226.pgn[PGN_226.isBypass] = 0;

            //manual rate setting
            PGN_225.pgn[PGN_225.rate] = Settings.Tool.setNozz.manualRate;

            //units
            if (cboxRate1Rate2Select.Checked)
            {
                cboxRate1Rate2Select.Text = Settings.Tool.setNozz.rateSet2 + (nozz.rateTextArr[Settings.Tool.setNozz.unitsIdx]);
                nozz.rateSetSelected = Settings.Tool.setNozz.rateSet2;
            }
            else
            {
                cboxRate1Rate2Select.Text = Settings.Tool.setNozz.rateSet1 + (nozz.rateTextArr[Settings.Tool.setNozz.unitsIdx]);
                nozz.rateSetSelected = Settings.Tool.setNozz.rateSet1;
            }

            btnSprayVolumeTotal.Text = Settings.Tool.setNozz.unitsApplied.ToString("#0.0");
            lblAreaPossible.Text = "0.0";

            if (!Settings.Tool.setNozz.isAppliedUnitsNotTankDisplayed)
                lbl_Volume.Text = "Tank" + (nozz.unitsTextArr[Settings.Tool.setNozz.unitsIdx]);
            else
                lbl_Volume.Text = "App" + (nozz.unitsTextArr[Settings.Tool.setNozz.unitsIdx]);

            lblTankArea.Text = (Settings.User.isMetric ? "Ha" : "Acre");

        }

        public void SetToolSettings()
        {
            //if (Settings.Tool.setToolSteer.isGPSToolActive)
            {
                PGN_232.pgn[PGN_232.gainP] = Settings.Tool.setToolSteer.gainP;
                PGN_232.pgn[PGN_232.integral] = Settings.Tool.setToolSteer.integral;
                PGN_232.pgn[PGN_232.minPWM] = Settings.Tool.setToolSteer.minPWM;
                PGN_232.pgn[PGN_232.countsPerDegree] = Settings.Tool.setToolSteer.countsPerDegree;
                PGN_232.pgn[PGN_232.ackerman] = Settings.Tool.setToolSteer.ackermann;

                PGN_232.pgn[PGN_232.wasOffsetHi] = unchecked((byte)(Settings.Tool.setToolSteer.wasOffset >> 8));
                PGN_232.pgn[PGN_232.wasOffsetLo] = unchecked((byte)(Settings.Tool.setToolSteer.wasOffset));

                PGN_231.pgn[PGN_231.invertWAS] = Settings.Tool.setToolSteer.isInvertWAS;
                PGN_231.pgn[PGN_231.invertSteer] = Settings.Tool.setToolSteer.isInvertSteer;
                PGN_231.pgn[PGN_231.maxSteerAngle] = Settings.Tool.setToolSteer.maxSteerAngle;
            }
        }

        public void SetText()
        {
            enterSimCoordsToolStripMenuItem.Text = gStr.Get(gs.gsEnterSimCoords);
            menustripLanguage.Text = gStr.Get(gs.gsLanguage);

            simulatorOnToolStripMenuItem.Text = gStr.Get(gs.gsSimulatorOn);
            resetALLToolStripMenuItem.Text = gStr.Get(gs.gsResetAll);

            //toolStripColors.Text = gStr.Get(gs.gsColors);
            //toolStripSectionColors.Text = "Section " + gStr.Get(gs.gsColors);
            //toolStripConfig.Text = gStr.Get(gs.gsConfiguration);
            //toolStripSteerSettings.Text = gStr.Get(gs.gsAutoSteer);
            //toolStripWorkingDirectories.Text = gStr.Get(gs.gsDirectories);

            resetEverythingToolStripMenuItem.Text = gStr.Get(gs.gsResetAllForSure);

            //Tools Menu
            boundariesToolStripMenuItem.Text = gStr.Get(gs.gsBoundary);
            headlandToolStripMenuItem.Text = gStr.Get(gs.gsHeadland);
            headlandBuildToolStripMenuItem.Text = gStr.Get(gs.gsHeadland) + " Builder";
            //deleteContourPathsToolStripMenuItem.Text = gStr.Get(gs.gsDeleteContourPaths);
            deleteAppliedToolStripMenuItem.Text = gStr.Get(gs.gsDeleteAppliedArea);
            tramsMultiMenuField.Text = gStr.Get(gs.gsTramLines) + " Multi";

            recordedPathStripMenu.Text = gStr.Get(gs.gsRecordedPathMenu);
            flagByLatLonToolStripMenuItem.Text = gStr.Get(gs.gsFlagByLatLon);
            boundaryToolToolStripMenu.Text = gStr.Get(gs.gsBoundary) + " Tool";
        }

        public void UpdateNTRIP()
        {
            if (Settings.IO.setNTRIP_isOn || Settings.IO.setPass_isOn)
            {
                DoNTRIPSecondRoutine();

                if (panel_IO.Visible)
                {
                    if (Settings.IO.setNTRIP_isOn)
                    {
                        lblNTRIPBytes.Text = ((tripBytes >> 10)).ToString("###,###,### kb");

                        //Bypass if sleeping
                        //if (focusSkipCounter != 0)
                        {
                            //update byte counter and up counter
                            if (ntripCounter > 59) btnStartStopNtrip.Text = (ntripCounter >> 6) + " Min";
                            else if (ntripCounter < 60 && ntripCounter > 25) btnStartStopNtrip.Text = ntripCounter + " Secs";
                            else btnStartStopNtrip.Text = "In " + (Math.Abs(ntripCounter - 25)) + " secs";

                            //watchdog for Ntrip
                            if (isNTRIP_Connecting)
                            {
                                lblWatch.Text = "Authourizing";
                            }
                            else
                            {
                                if (Settings.IO.setNTRIP_isOn && NTRIP_Watchdog > 10)
                                {
                                    lblWatch.Text = "Waiting";
                                }
                                else
                                {
                                    lblWatch.Text = "Listening";

                                    if (Settings.IO.setNTRIP_isOn)
                                    {
                                        lblWatch.Text += " NTRIP";
                                    }
                                }
                            }

                            if (Settings.IO.setNTRIP_sendGGAInterval > 0 && isNTRIP_Sending)
                            {
                                lblWatch.Text = "Send GGA";
                                isNTRIP_Sending = false;
                            }
                        }
                    }
                    else if (Settings.IO.setPass_isOn)
                    {
                        //pbarNtripMenu.Value = unchecked((byte)(tripBytes * 0.02));
                        lblNTRIPBytes.Text = ((tripBytes >> 10)).ToString("###,###,### kb");

                        //update byte counter and up counter
                        if (ntripCounter > 59) btnStartStopNtrip.Text = (ntripCounter >> 6) + " Min";
                        else if (ntripCounter < 60 && ntripCounter > 22) btnStartStopNtrip.Text = ntripCounter + " Secs";
                        else btnStartStopNtrip.Text = "In " + (Math.Abs(ntripCounter - 22)) + " secs";
                    }
                }
            }

        }

        public void UpdateNozzleMainPanel()
        {
            if (Settings.Tool.setNozz.isAppliedUnitsNotTankDisplayed)
                btnSprayVolumeTotal.Text = Settings.Tool.setNozz.unitsApplied.ToString("#0.0");
            else
                btnSprayVolumeTotal.Text = (Settings.Tool.setNozz.unitsTankStart - Settings.Tool.setNozz.unitsApplied).ToString("#0.0");

            lblAreaPossible.Text = ((Settings.Tool.setNozz.unitsTankStart - Settings.Tool.setNozz.unitsApplied)
                / (nozz.rateSetSelected + 0.01)).ToString("N1");

            //pressure reading
            btnSprayPSI.Text = nozz.pressureActual.ToString();

            //volume per minute displays at top of panel
            lblGPM_Set.Text = ((double)(nozz.rateSet) * 0.01).ToString("N1");
            btnSprayGalPerMinActual.Text = (((double)(nozz.rateActual)) * 0.01).ToString("N2");

            //the main GPA display and button
            if (nozz.currentWidthMeters < 0.2)
            {
                btnSprayGalPerAcre.Text = "Off";
                btnSprayGalPerAcre.BackColor = Color.Transparent;
            }
            else
            {
                //volume per area calcs - GPM and L/Ha
                if (Settings.User.isMetric)
                {
                    //(Liters per minute * 600) / (𝑠𝑤𝑎𝑡ℎ 𝑤𝑖𝑑𝑡ℎ in meter 𝑥 𝐾mh)
                    nozz.rateActualFiltered = (nozz.rateActualFiltered * 0.6)
                        + (nozz.rateActual * 6 / (nozz.currentWidthMeters * pn.avgSpeed + 0.01)) * 0.4;
                }
                else
                {
                    //(GPM x 5,940) / (MPH x Width in inches)
                    nozz.rateActualFiltered = (nozz.rateActualFiltered * 0.6)
                        + ((nozz.rateActual * 59.4) / (nozz.currentWidthMeters * glm.m2InchOrCm * pn.avgSpeed * glm.kmhToMphOrKmh + 0.01) * 0.4);
                }

                //display actual rate
                if (nozz.rateActualFiltered < 100)
                    btnSprayGalPerAcre.Text = (nozz.rateActualFiltered).ToString("N1");
                else
                    btnSprayGalPerAcre.Text = (nozz.rateActualFiltered).ToString("N0");

                //flow error alarm
                if ((Math.Abs(nozz.rateSetSelected - nozz.rateActualFiltered)) > (nozz.rateSetSelected * Settings.Tool.setNozz.rateAlarmPercent))
                {
                    if (isFlashOnOff) btnSprayGalPerAcre.BackColor = Color.DarkRed;
                    else btnSprayGalPerAcre.BackColor = Color.Transparent;
                }
                else
                {
                    btnSprayGalPerAcre.BackColor = Color.DarkGreen;
                }

                if (nozz.isFlowingFlag) lblIsFlowing.BackColor = Color.LightGreen;
                else lblIsFlowing.BackColor = Color.OrangeRed;

                //lblPWM_Nozz.Text = nozz.pwmDriveActual.ToString();
                //lblFlowHz_Nozz.Text = nozz.frequency.ToString() + " Hz";

            }
        }

        public void ChangeMetricImperial()
        {
            if (Settings.User.isMetric)
            {
                glm.inchOrCm2m = 0.01;
                glm.m2InchOrCm = 100.0;

                glm.cm2CmOrIn = 1;

                glm.m2FtOrM = 1.0;
                glm.ftOrMtoM = 1.0;

                glm.kmhToMphOrKmh = 1;
                glm.mphOrKmhToKmh = 1;

                glm.unitsFtM = " m";
                glm.unitsInCm = " cm";
                glm.unitsInCmNS = "cm";
                glm.unitsKmhMph = gStr.Get(gs.gsKMH);
                glm.unitsHaOrAc = " Ha";
                glm.unitsHaOrAcHr = " ha/hr";

                //m2 to Hectare
                glm.m22HaOrAc = 0.0001;
            }
            else
            {
                //inches to meters
                glm.inchOrCm2m = 0.0254;
                //meters to inches
                glm.m2InchOrCm = 39.3701;

                //meters to feet
                glm.m2FtOrM = 3.28084;
                //feet to meters
                glm.ftOrMtoM = 0.3048;

                //cm to inch
                glm.cm2CmOrIn = 0.3937;

                glm.kmhToMphOrKmh = 0.621371;//Km/H to mph
                glm.mphOrKmhToKmh = 1.60934;//mph to Km/H

                glm.unitsInCm = " in";
                glm.unitsInCmNS = "in";
                glm.unitsFtM = " ft";
                glm.unitsKmhMph = gStr.Get(gs.gsMPH);
                glm.unitsHaOrAc = " Ac";
                glm.unitsHaOrAcHr = " ac/hr";

                //Meters to Acres
                glm.m22HaOrAc = 0.000247105;
            }
        }

        public void PanelUpdateRightAndBottom()
        {
            Form fcc = Application.OpenForms["FormTrackFilter"];

            if (isFieldStarted)
            {
                bool isBnd = bnd.bndList.Count > 0;
                bool isHdl = isBnd && bnd.bndList[0].hdLine.Count > 0;

                bool istram = (tram.tramList.Count + tram.tramBndOuterArr.Count) > 0;

                int tracksVisible = trks.GetVisibleTracks();

                btnContourLock.Visible = ct.isContourBtnOn;

                btnAutoSteer.Enabled = trks.currentRefTrack != null || ct.isContourBtnOn;

                bool validTrk = trks.currentRefTrack != null && !ct.isContourBtnOn;

                btnAutoYouTurn.Visible = validTrk && isBnd;
                btnCycleLines.Visible = tracksVisible > 1 && validTrk;
                btnCycleLinesBk.Visible = tracksVisible > 1 && validTrk;

                cboxpRowWidth.Visible = validTrk;
                btnYouSkipEnable.Visible = validTrk;

                btnSnapToPivot.Visible = validTrk && Settings.User.setFeatures.isABLineOn;
                btnAdjLeft.Visible = validTrk && Settings.User.setFeatures.isABLineOn;
                btnAdjRight.Visible = validTrk && Settings.User.setFeatures.isABLineOn;

                btnAutoTrack.Visible = tracksVisible > 1 && !ct.isContourBtnOn;

                btnTramDisplayMode.Visible = istram;
                btnHeadlandOnOff.Visible = isHdl;

                cboxIsSectionControlled.Visible = isHdl;

                PanelSizeRightAndBottom();


                if (fcc == null && trks.gArr.Count > 0)
                {
                    Form form = new FormTrackFilter(this);
                    form.Show(this);
                }
                else
                {
                    if (fcc != null && trks.gArr.Count == 0)
                    {
                        fcc.Focus();
                        fcc.Close();
                    }
                }
            }
            else
            {
                if (fcc != null)
                {
                    fcc.Focus();
                    fcc.Close();
                }
            }
        }

        public void PanelBuildRightMenu(string[] buttonOrder)
        {
            panelRight.Controls.Clear();

            for (int i = 0; i < buttonOrder.Length; i++)
            {
                switch (buttonOrder[i])
                {
                    case "0":
                        panelRight.Controls.Add(btnAutoSteer);
                        break;

                    case "1":
                        panelRight.Controls.Add(btnAutoYouTurn);
                        break;

                    case "2":
                        panelRight.Controls.Add(btnSectionMasterAuto);
                        break;

                    case "3":
                        panelRight.Controls.Add(btnSectionMasterManual);
                        break;

                    case "4":
                        panelRight.Controls.Add(btnAutoTrack);
                        break;

                    case "5":
                        panelRight.Controls.Add(btnCycleLinesBk);
                        break;

                    case "6":
                        panelRight.Controls.Add(btnCycleLines);
                        break;

                    case "7":
                        panelRight.Controls.Add(btnContour);
                        panelRight.Controls.Add(btnContourLock);
                        break;

                    default:
                        break;
                }
            }

            panelRight.Controls.Add(lblNumCu);
        }

        public void PanelSizeRightAndBottom()
        {
            btnResetToolHeading.Visible = false;
            int viz = 0;
            for (int i = 0; i < panelRight.Controls.Count; i++)
            {
                if (panelRight.Controls[i].Visible && panelRight.Controls[i] is Button) viz++;
            }

            if (viz == 0) return;

            int sizer = (Height - 140) / (viz);
            if (sizer > 120) { sizer = 120; }

            for (int i = 0; i < panelRight.Controls.Count; i++)
            {
                if (panelRight.Controls[i].Visible && panelRight.Controls[i] is Button)
                {
                    panelRight.Controls[i].Height = sizer;
                }
            }

            if (panelBottom.Visible)
            {
                viz = 0;
                for (int i = 0; i < panelBottom.Controls.Count; i++)
                {
                    if (panelBottom.Controls[i].Visible && panelBottom.Controls[i] is Button)
                        viz++;
                    if (panelBottom.Controls[i].Visible && panelBottom.Controls[i] is CheckBox)
                        viz++;
                }

                if (viz == 0) return;
                if (viz > 9 && Width < 1190)
                {
                    btnResetToolHeading.Visible = false;
                }
                else
                {
                    btnResetToolHeading.Visible = true;
                    viz++;
                }

                sizer = (Width - 185) / (viz);
                if (sizer > 150) { sizer = 150; }

                for (int i = 0; i < panelBottom.Controls.Count; i++)
                {
                    if (panelBottom.Controls[i].Visible && panelBottom.Controls[i] is Button)
                        panelBottom.Controls[i].Width = sizer;
                    if (panelBottom.Controls[i].Visible && panelBottom.Controls[i] is CheckBox)
                        panelBottom.Controls[i].Width = sizer;
                }

            }

            btnFlag.Text = Settings.Vehicle.setVehicle_isStanleyUsed ? "S" : "P";
        }

        private void PanelsAndOGLSize()
        {
            tlpNozzle.Visible = false;
            int tlpWidth = 0;

            if (Settings.Tool.setApp_isNozzleApp && isJobStarted)
            {
                tlpNozzle.Visible = isJobStarted && Settings.Tool.setApp_isNozzleApp;
                tlpWidth = tlpNozzle.Width;
            }

            GPSDataWindowLeft = (isPanelBottomHidden ? 10 : 85) + tlpWidth;

            oglMain.Left = (isPanelBottomHidden ? 5 : 80) + tlpWidth;
            oglMain.Width = this.Width - (oglMain.Left + (isJobStarted ? 75 : 5));
            oglMain.Height = this.Height - (55 + (!isJobStarted || isPanelBottomHidden ? 0 : 70));

            tlpNozzle.Left = (isPanelBottomHidden ? 5 : 80);
            tlpNozzle.Height = oglMain.Height;

            panelSim.Top = Height - (!isJobStarted || isPanelBottomHidden ? 60 : 130);
            panelSim.Left = this.Width - (oglMain.Width / 2 +430);
            panelSim.Width = 700;

            panelRight.Visible = isJobStarted;
            panelBottom.Visible = isJobStarted && !isPanelBottomHidden;
            panelLeft.Visible = !isPanelBottomHidden;

            PanelSizeRightAndBottom();

            Panel_IO_Location();
        }

        private void Panel_IO_Location()
        {
                panel_IO.Location = new Point(this.Width - panel_IO.Width - (isJobStarted?90:40), oglMain.Height / 2 - 230);            
        }

        public void NotifyTrackChange()
        {
            if (trks.currentRefTrack != null)
            {
                guideLineCounter = 20;
                lblGuidanceLine.Visible = true;
                lblGuidanceLine.Text = trks.currentRefTrack.name + " " + trks.gArr.Count.ToString() + " Tracks ";
            }
            else
            {
                guideLineCounter = 12;
                lblGuidanceLine.Visible = true;
                lblGuidanceLine.Text = trks.gArr.Count.ToString() + " Tracks, " + trks.GetVisibleTracks().ToString() + " Visible";
            }
        }

        private void ZoomByMouseWheel(object sender, MouseEventArgs e)
        {
            if (Settings.User.setDisplay_camZoom <= 20) Settings.User.setDisplay_camZoom -= Settings.User.setDisplay_camZoom * 0.06 * Math.Sign(e.Delta);
            else Settings.User.setDisplay_camZoom -= Settings.User.setDisplay_camZoom * 0.02 * Math.Sign(e.Delta);

            SetZoom();
        }

        public void SwapDayNightMode(bool swap = true)
        {
            if (swap)
                Settings.User.setDisplay_isDayMode = !Settings.User.setDisplay_isDayMode;

            Color foreColor = Settings.User.setDisplay_isDayMode ? Settings.User.colorTextDay : Settings.User.colorTextNight;
            btnDayNightMode.Image = Settings.User.setDisplay_isDayMode ? Properties.Resources.WindowNightMode : Properties.Resources.WindowDayMode;
            this.BackColor = Settings.User.setDisplay_isDayMode ? Settings.User.colorDayFrame : Settings.User.colorNightFrame;

            foreach (Control c in this.Controls)
            {
                //if (c is Label || c is Button)
                {
                    c.ForeColor = foreColor;
                }
            }

            foreach (Control c in panelRight.Controls)
            {
                //if (c is Label || c is Button)
                {
                    c.ForeColor = foreColor;
                }
            }

            foreach (Control c in panelNavigation.Controls)
            {
                //if (c is Label || c is Button)
                {
                    c.ForeColor = foreColor;
                }
            }
            foreach (Control c in flowLayoutPanelTop.Controls)
            {
                //if (c is Label || c is Button)
                {
                    c.ForeColor = foreColor;
                }
            }

            foreach (Control c in panel_IO.Controls)
            {
                //if (c is Label || c is Button)
                {
                    c.ForeColor = foreColor;
                }
            }

            btnChangeMappingColor.ForeColor = foreColor;
        }

        public void SaveFormGPSWindowSettings()
        {
            //save window settings
            if (WindowState == FormWindowState.Maximized)
            {
                Settings.User.setWindow_Location = RestoreBounds.Location;
                Settings.User.setWindow_Size = RestoreBounds.Size;
                Settings.User.setWindow_Maximized = false;
                Settings.User.setWindow_Minimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Settings.User.setWindow_Location = Location;
                Settings.User.setWindow_Size = Size;
                Settings.User.setWindow_Maximized = false;
                Settings.User.setWindow_Minimized = false;
            }
            else
            {
                Settings.User.setWindow_Location = RestoreBounds.Location;
                Settings.User.setWindow_Size = RestoreBounds.Size;
                Settings.User.setWindow_Maximized = false;
                Settings.User.setWindow_Minimized = true;
            }

            Settings.Vehicle.setF_UserTotalArea = fd.workedAreaTotalUser;
        }

        public string FindDirection(double heading)
        {
            if (heading < 0) heading += glm.twoPI;

            heading = glm.toDegrees(heading);

            if (heading > 337.5 || heading < 22.5)
            {
                return (" " + gStr.Get(gs.gsNorth) + " ");
            }
            if (heading > 22.5 && heading < 67.5)
            {
                return (" " + gStr.Get(gs.gsN_East) + " ");
            }
            if (heading > 67.5 && heading < 111.5)
            {
                return (" " + gStr.Get(gs.gsEast) + " ");
            }
            if (heading > 111.5 && heading < 157.5)
            {
                return (" " + gStr.Get(gs.gsS_East) + " ");
            }
            if (heading > 157.5 && heading < 202.5)
            {
                return (" " + gStr.Get(gs.gsSouth) + " ");
            }
            if (heading > 202.5 && heading < 247.5)
            {
                return (" " + gStr.Get(gs.gsS_West) + " ");
            }
            if (heading > 247.5 && heading < 292.5)
            {
                return (" " + gStr.Get(gs.gsWest) + " ");
            }
            if (heading > 292.5 && heading < 337.5)
            {
                return (" " + gStr.Get(gs.gsN_West) + " ");
            }
            return (" ?? ");
        }

        //Mouse Clicks 
        private void oglMain_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                int centerX = oglMain.Width / 2;
                int centerY = oglMain.Height / 2;

                //0 at bottom for opengl, 0 at top for windows, so invert Y value
                Point point = oglMain.PointToClient(Cursor.Position);

                if (isFieldStarted)
                {
                    if (!ct.isContourBtnOn && trks.currentGuidanceTrack.Count > 1)
                    {
                        //uturn and swap uturn direction
                        if (point.Y < 150 && point.Y > 90)
                        {
                            int middle = centerX + oglMain.Width / 5;
                            if (yt.isYouTurnBtnOn && point.X > middle - 80 && point.X < middle + 80)
                            {
                                SwapDirection();
                                return;
                            }

                            //k turn or u turn
                            middle += 140;
                            if (point.X > middle - 25 && point.X < middle + 25)
                            {
                                yt.uTurnStyle++;
                                if (yt.uTurnStyle > 1) yt.uTurnStyle = 0;
                                yt.ResetCreatedYouTurn();

                                Settings.Vehicle.set_uTurnStyle = yt.uTurnStyle;

                                return;
                            }

                            if ( Settings.User.setFeatures.isUTurnOn && isBtnAutoSteerOn)
                            {
                                //manual uturn triggering
                                middle = centerX - oglMain.Width / 4;
                                if (point.X > middle - 100 && point.X < middle + 100)
                                {
                                    if (yt.isYouTurnTriggered)
                                    {
                                        yt.ResetCreatedYouTurn();
                                    }
                                    else
                                    {
                                        if (Settings.Vehicle.setAS_functionSpeedLimit > pn.avgSpeed)
                                        {
                                            yt.BuildManualYouTurn(point.X > middle);
                                        }
                                        else
                                        {
                                            SpeedLimitExceeded();
                                        }
                                        return;
                                    }
                                }
                            }
                        }

                        //lateral
                        else if (Settings.User.setFeatures.isLateralOn && isBtnAutoSteerOn && point.Y < 240 && point.Y > 170)
                        {
                            int middle = centerX - oglMain.Width / 4;
                            if (point.X > middle - 100 && point.X < middle + 100)
                            {
                                if (Settings.Vehicle.setAS_functionSpeedLimit > pn.avgSpeed)
                                {
                                    yt.BuildManualYouLateral(point.X > middle);
                                }
                                else
                                {
                                    SpeedLimitExceeded();
                                }
                            }
                        }
                    }

                    //pan and hide menus
                    if (point.X > 30 && point.X < 60)
                    {
                        if (point.Y > 50 && point.Y < 80)
                        {
                            isPanFormVisible = true;
                            Form f = Application.OpenForms["FormPan"];

                            if (f != null)
                            {
                                f.Focus();
                                return;
                            }

                            Form form = new FormPan(this);
                            form.Show(this);

                            form.Top = this.Height / 3 + this.Top;
                            form.Left = this.Width - 400 + this.Left;
                        }

                        if (isFieldStarted)
                        {
                            if (point.Y > oglMain.Height - 60 && point.Y < oglMain.Height - 30)
                            {
                                isPanelBottomHidden = !isPanelBottomHidden;
                                PanelsAndOGLSize();
                                return;
                            }
                        }
                    }

                    //tram override
                    int bottomSide = oglMain.Height / 5 + 25;

                    if (Settings.Tool.isDisplayTramControl && (point.Y > (bottomSide - 50) && point.Y < bottomSide))
                    {
                        if (point.X > centerX - 100 && point.X < centerX - 20)
                        {
                            tram.isLeftManualOn = !tram.isLeftManualOn;
                        }
                        if (point.X > centerX + 20 && point.X < centerX + 100)
                        {
                            tram.isRightManualOn = !tram.isRightManualOn;
                        }
                    }
                }

                //zoom buttons
                if (point.X > oglMain.Width - 80)
                {
                    int zoom = 0;
                    //---
                    if (point.Y < 260 && point.Y > 170)
                    {
                        zoom = 1;
                    }

                    //++
                    if (point.Y < 120 && point.Y > 30)
                    {
                        zoom = -1;
                    }

                    if (zoom != 0)
                    {
                        if (Settings.User.setDisplay_camZoom <= 20) Settings.User.setDisplay_camZoom += Settings.User.setDisplay_camZoom * 0.2 * zoom;
                        else Settings.User.setDisplay_camZoom += Settings.User.setDisplay_camZoom * 0.1 * zoom;
                        SetZoom();
                        return;
                    }

                    if (point.Y < 420 && point.Y > 320)
                    {
                        Settings.User.setDisplay_panMove -= 1;
                        if (Settings.User.setDisplay_panMove < -4) Settings.User.setDisplay_panMove = -4;
                    }

                    if (point.Y < 480 && point.Y > 400)
                    {
                        Settings.User.setDisplay_panMove += 1;
                        if (Settings.User.setDisplay_panMove > 4) Settings.User.setDisplay_panMove = 4;                   }
                }

                //vehicle direcvtion reset
                if (point.X > centerX - 40 && point.X < centerX + 40
                    && point.Y > centerY - 60 && point.Y < centerY + 60)
                {
                    if (!Settings.Vehicle.setIMU_isReverseOn || pn.isDualGPSConnected) return;

                    imuGPS_Offset += Math.PI;
                    TimedMessageBox(2000, "Reverse Direction", "");
                    Log.EventWriter("Direction Reset, Drive Forward");

                    return;
                }

                mouseX = point.X;
                mouseY = oglMain.Height - point.Y;

                //prevent flag selection if flag form is up
                Form fc = Application.OpenForms["Flags"];
                if (fc != null)
                {
                    fc.Focus();
                    return;
                }

                leftMouseDownOnOpenGL = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!isPanFormVisible)
                {
                    isPanFormVisible = true;
                    Form f = Application.OpenForms["FormPan"];

                    if (f != null)
                    {
                        f.Focus();
                        return;
                    }

                    Form form = new FormPan(this);
                    form.Show(this);

                    form.Top = this.Height / 3 + this.Top;
                    form.Left = this.Width - 400 + this.Left;
                }
                    
                rightMouseDown = true;
                _iPrevMoveX = e.X;
                _iPrevMoveY = e.Y;
            }
        }

        private void OglMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (rightMouseDown)
            {
                int distanceX = e.X - _iPrevMoveX;
                int distanceY = e.Y - _iPrevMoveY;

                _iPrevMoveX = e.X;
                _iPrevMoveY = e.Y;

                camera.panX += distanceX * (Settings.User.setDisplay_camZoom / 100);
                camera.panY -= distanceY * (Settings.User.setDisplay_camZoom / 100);
            }
        }

        private void oglMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                rightMouseDown = false;
        }

        private void SpeedLimitExceeded()
        {
            TimedMessageBox(2000, gStr.Get(gs.gsTooFast), gStr.Get(gs.gsSlowDownBelow) + " "
                + (Settings.Vehicle.setAS_functionSpeedLimit * glm.kmhToMphOrKmh).ToString("N1") + " " + glm.unitsKmhMph);

            Log.EventWriter("UTurn or Lateral Speed exceeded");

        }

        public void SwapDirection()
        {
            if (!yt.isYouTurnTriggered)
                yt.isTurnLeft = !yt.isTurnLeft;

            yt.ResetCreatedYouTurn();
        }

        //Function to delete flag
        public void DeleteSelectedFlag()
        {
            //delete selected flag and set selected to none
            flagPts.RemoveAt(flagNumberPicked - 1);
            flagNumberPicked = 0;

            // re-sort the id's based on how many flags left
            int flagCnt = flagPts.Count;
            if (flagCnt > 0)
            {
                for (int i = 0; i < flagCnt; i++) flagPts[i].ID = i + 1;
            }
        }

        private void ShowNoGPSWarning()
        {
            //update main window
            sentenceCounter = 300;
            oglMain.MakeCurrent();
            oglMain.Refresh();
        }

        #region Properties // ---------------------------------------------------------------------

        public string Latitude { get { return Convert.ToString(Math.Round(pn.latitude, 7)); } }
        public string Longitude { get { return Convert.ToString(Math.Round(pn.longitude, 7)); } }
        public string SatsTracked { get { return Convert.ToString(pn.satellitesTracked); } }
        public string HDOP { get { return Convert.ToString(pn.hdop); } }
        public string Heading { get { return Convert.ToString(Math.Round(glm.toDegrees(fixHeading), 1)) + "\u00B0"; } }
        public string GPSHeading { get { return (Math.Round(glm.toDegrees(gpsHeading), 1)) + "\u00B0"; } }
        public string FixQuality
        {
            get
            {
                if (pn.fixQuality == 0) return "Invalid: ";
                else if (pn.fixQuality == 1) return "GPS single: ";
                else if (pn.fixQuality == 2) return "DGPS: ";
                else if (pn.fixQuality == 3) return "PPS: ";
                else if (pn.fixQuality == 4) return "RTK fix: ";
                else if (pn.fixQuality == 5) return "RTK Float: ";
                else if (pn.fixQuality == 6) return "Estimate: ";
                else if (pn.fixQuality == 7) return "Man IP: ";
                else if (pn.fixQuality == 8) return "Sim: ";
                else return "Unknown: ";
            }
        }
        public string GyroInDegrees
        {
            get
            {
                if (ahrs.imuHeading != 99999)
                    return Math.Round(ahrs.imuHeading, 1) + "\u00B0";
                else return "-";
            }
        }
        public string RollInDegrees
        {
            get
            {
                if (ahrs.imuRoll != 88888)
                    return Math.Round((ahrs.imuRoll), 1) + "\u00B0";
                else return "-";
            }
        }
        public string SetSteerAngle { get { return (guidanceVehicleSteerAngle).ToString("N1"); } }
        public string ActualSteerAngle { get { return (mc.actualSteerAngleDegrees).ToString("N1"); } }

        //Metric and Imperial Properties
        public string Speed
        {
            get
            {
                if (pn.avgSpeed > 2)
                    return (pn.avgSpeed * glm.kmhToMphOrKmh).ToString("N1");
                else
                    return (pn.avgSpeed * glm.kmhToMphOrKmh).ToString("N2");
            }
        }

        public string ElevationInMeters { get { return Convert.ToString((Math.Round((pn.elevation * glm.m2FtOrM), 2))); } }

        public string DistPivot
        {
            get
            {
                if (distancePivotToTurnLine > 0)
                    return (glm.m2FtOrM * distancePivotToTurnLine).ToString("0") + glm.unitsFtM;
                else return "--";
            }
        }

        #endregion properties 

        //Load Bitmaps brand
        public Bitmap GetTractorImage()
        {
            Bitmap bitmap;
                bitmap = Resources.z_Tractor;

            return bitmap;
        }

        public Bitmap GetHarvesterImage()
        {
            Bitmap harvesterbitmap;
                harvesterbitmap = Resources.z_Harvester;

            return harvesterbitmap;
        }

        public Bitmap Get4WDFrontImage()
        {
            Bitmap bitmap4WDFront;
                bitmap4WDFront = Resources.z_4WDFront;

            return bitmap4WDFront;
        }

        public Bitmap Get4WDRearImage()
        {
            Bitmap bitmap4WDRear;
                bitmap4WDRear = Resources.z_4WDRear;

            return bitmap4WDRear;
        }

    }//end class
}//end namespace