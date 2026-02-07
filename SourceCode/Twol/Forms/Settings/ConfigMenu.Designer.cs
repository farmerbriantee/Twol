using Twol.Classes;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormConfig
    {
        private TabPage oldTabPage = null;
        private Button oldbutton = null;
        private Panel oldPanel = null;


        #region menu Buttons

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubDimensions);
            flpTop.Controls?.Add(btnSubVehicleType);
            flpTop.Controls?.Add(btnSubAntenna);
            flpTop.Controls?.Add(btnSubHeading);
            flpTop.Controls?.Add(btnSubRoll);

            for (int i = 0; i < flpTop.Controls.Count; i++)
            {
                if (flpTop.Controls[i].Visible && flpTop.Controls[i] is Button)
                {
                    flpTop.Controls[i].Width = 130;
                }
            }

            SetTab(tabSummary);
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubToolType);
            flpTop.Controls?.Add(btnSubHitch);
            flpTop.Controls?.Add(btnSubSections);
            flpTop.Controls?.Add(btnSubPivot);
            flpTop.Controls?.Add(btnSubToolOffset);
            flpTop.Controls?.Add(btnSubSwitches);
            flpTop.Controls?.Add(btnSubToolSettings);

            for (int i = 0; i < flpTop.Controls.Count; i++)
            {
                if (flpTop.Controls[i].Visible && flpTop.Controls[i] is Button)
                {
                    flpTop.Controls[i].Width = 130;
                }
            }

            SetTab(tabTSections);
        }
        private void btnArduino_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubMachineRelay);
            flpTop.Controls?.Add(btnSubMachineModule);

            for (int i = 0; i < flpTop.Controls.Count; i++)
            {
                if (flpTop.Controls[i].Visible && flpTop.Controls[i] is Button)
                {
                    flpTop.Controls[i].Width = 130;
                }
            }

            SetTab(tabAMachine);
        }
        private void btnField_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubTram);
            flpTop.Controls?.Add(btnSubUTurn);

            for (int i = 0; i < flpTop.Controls.Count; i++)
            {
                if (flpTop.Controls[i].Visible && flpTop.Controls[i] is Button)
                {
                    flpTop.Controls[i].Width = 130;
                }
            }

            SetTab(tabTram);
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubDisplay);
            flpTop.Controls?.Add(btnSubFeatureHides);

            for (int i = 0; i < flpTop.Controls.Count; i++)
            {
                if (flpTop.Controls[i].Visible && flpTop.Controls[i] is Button)
                {
                    flpTop.Controls[i].Width = 130;
                }
            }

            SetTab(tabDisplay);
        }

        private void btnSubTram_Click(object sender, EventArgs e)
        {
            SetTab(tabTram);
        }

        private void btnSubUTurn_Click(object sender, EventArgs e)
        {
            SetTab(tabUTurn);
        }

        private void btnSubDisplay_Click(object sender, EventArgs e)
        {
            SetTab(tabDisplay);
        }

        private void btnSubFeatureHides_Click(object sender, EventArgs e)
        {
            SetTab(tabBtns);
        }

        #endregion

        #region Vehicle Sub Menu Btns
        private void btnSubVehicleType_Click(object sender, EventArgs e)
        {
            SetTab(tabVConfig);
        }

        private void btnSubDimensions_Click(object sender, EventArgs e)
        {
            SetTab(tabVDimensions);
        }

        private void btnSubAntenna_Click(object sender, EventArgs e)
        {
            SetTab(tabVAntenna);
        }

        #endregion Region

        #region Tool Sub Menu

        private void btnSubToolType_Click(object sender, EventArgs e)
        {
            SetTab(tabTConfig);
        }

        private void btnSubHitch_Click(object sender, EventArgs e)
        {
            SetTab(tabTHitch);
        }

        private void btnSubToolOffset_Click(object sender, EventArgs e)
        {
            SetTab(tabToolOffset);
        }

        private void btnSubPivot_Click(object sender, EventArgs e)
        {
            SetTab(tabToolPivot);
        }

        private void btnSubSections_Click(object sender, EventArgs e)
        {
            SetTab(tabTSections);
        }

        private void btnSubSwitches_Click(object sender, EventArgs e)
        {
            SetTab(tabTSwitches);
        }

        private void btnSubToolSettings_Click(object sender, EventArgs e)
        {
            SetTab(tabTSettings);
        }
        #endregion

        #region SubMenu Data Sources


        private void btnSubHeading_Click(object sender, EventArgs e)
        {
            SetTab(tabDHeading);
        }

        private void btnSubRoll_Click(object sender, EventArgs e)
        {
            SetTab(tabDRoll);
        }

        #endregion

        #region Module

        private void btnSubMachineModule_Click(object sender, EventArgs e)
        {
            SetTab(tabAMachine);
        }

        private void btnSubMachineRelay_Click(object sender, EventArgs e)
        {
            SetTab(tabRelay);
        }


        private void SetTab(TabPage newTabPage)
        {
            if (newTabPage != null)
            {
                tab1.SelectedTab = newTabPage;

                if (newTabPage == tabSummary)
                {
                    tabSummary_Enter(null, null);
                }
                else if (newTabPage == tabDHeading)
                {
                    tabDHeading_Enter(null, null);
                }
                else if (newTabPage == tabVConfig)
                {
                    tabVConfig_Enter(null, null);
                }
                else if (newTabPage == tabDisplay)
                {
                    tabDisplay_Enter(null, null);
                }
                else if (newTabPage == tabBtns)
                {
                    tabBtns_Enter(null, null);
                }
                else if (newTabPage == tabTram)
                {
                    tabTram_Enter(null, null);
                }
                else if (newTabPage == tabAMachine)
                {
                    tabAMachine_Enter(null, null);
                }
                else if (newTabPage == tabRelay)
                {
                    tabRelay_Enter(null, null);
                }
                else if (newTabPage == tabUTurn)
                {
                    tabUTurn_Enter(null, null);
                }
                else if (newTabPage == tabDRoll)
                {
                    tabDRoll_Enter(null, null);
                }
                else if (newTabPage == tabTSettings)
                {
                    tabTSettings_Enter(null, null);
                }
                else if (newTabPage == tabTSwitches)
                {
                    tabTSwitches_Enter(null, null);
                }
                else if (newTabPage == tabTSections)
                {
                    tabTSections_Enter(null, null);
                }
                else if (newTabPage == tabToolPivot)
                {
                    tabToolPivot_Enter(null, null);
                }
                else if (newTabPage == tabToolOffset)
                {
                    tabToolOffset_Enter(null, null);
                }
                else if (newTabPage == tabTHitch)
                {
                    tabTHitch_Enter(null, null);
                }
                else if (newTabPage == tabTConfig)
                {
                    tabTConfig_Enter(null, null);
                }
                else if (newTabPage == tabVDimensions)
                {
                    tabVDimensions_Enter(null, null);
                }
                else if (newTabPage == tabVAntenna)
                {
                    tabVAntenna_Enter(null, null);
                }
                else
                {
                    throw new Exception($"Unknown tab entered: {newTabPage.Text}");
                }
            }
        }
        #endregion
    }
}