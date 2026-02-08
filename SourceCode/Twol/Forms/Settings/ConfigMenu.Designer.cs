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
        #region menu Buttons

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubRoll);
            flpTop.Controls?.Add(btnSubHeading);
            flpTop.Controls?.Add(btnSubAntenna);
            flpTop.Controls?.Add(btnSubDimensions);
            flpTop.Controls?.Add(btnSubVehicleType);

            SetTab(tabSummary, 140);
        }
        private void btnTool_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubSwitches);
            flpTop.Controls?.Add(btnSubToolSettings);
            flpTop.Controls?.Add(btnSubPivot);
            flpTop.Controls?.Add(btnSubToolOffset);
            flpTop.Controls?.Add(btnSubSections);
            flpTop.Controls?.Add(btnSubHitch);
            flpTop.Controls?.Add(btnSubToolType);

            SetTab(tabTSections, 110);
        }
        private void btnArduino_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubMachineRelay);
            flpTop.Controls?.Add(btnSubMachineModule);

            SetTab(tabAMachine, 150);
        }
        private void btnField_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubTram);
            flpTop.Controls?.Add(btnSubUTurn);

            SetTab(tabTram, 150);
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            flpTop.Controls?.Clear();
            flpTop.Controls?.Add(btnOK);
            flpTop.Controls?.Add(btnSubFeatureHides);
            flpTop.Controls?.Add(btnSubColors);
            flpTop.Controls?.Add(btnSubUser);
            flpTop.Controls?.Add(btnSubDisplay);

            SetTab(tabDisplay, 150);
        }

        #endregion
        private void SetTab(TabPage newTabPage, int width)
        {
            if (newTabPage != null)
            {
                tab1.SelectedTab = newTabPage;
            }

            for (int i = 0; i < flpTop.Controls.Count; i++)
            {
                if (flpTop.Controls[i].Visible && flpTop.Controls[i] is Button)
                {
                    flpTop.Controls[i].Width = width;
                }
            }
        }

        private void SetTab(TabPage newTabPage)
        {
            if (newTabPage != null)
            {
                tab1.SelectedTab = newTabPage;
            }
        }   

        #region subs

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
        private void btnSubColors_Click(object sender, EventArgs e)
        {
            SetTab(tabColors);
        }

        private void btnSubUser_Click(object sender, EventArgs e)
        {
            SetTab(tabUser);
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

        #endregion

    }
}