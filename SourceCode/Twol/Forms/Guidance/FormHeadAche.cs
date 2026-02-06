using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Twol
{
    public partial class FormHeadAche : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private Point fixPt;

        private bool isA = true;
        private int start = 99999, end = 99999;
        private int bndSelect = 0;

        private bool zoomToggle;
        private double zoom = 1, sX = 0, sY = 0;

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        private bool isLinesVisible = true;

        private List<CHeadPath> tracksArr = new List<CHeadPath>();

        private int idx;

        public FormHeadAche(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormHeadLine_Load(object sender, EventArgs e)
        {
            this.Text = "1: Set distance, 2: Tap Build, 3: Create Clip Lines";

            idx = -1;
            nudSetDistance.Value = 0;
            mf.FileLoadHeadLines(tracksArr);
            FixLabelsCurve();

            lblToolWidth.Text = "( " + glm.unitsFtM + " )      Tool: "
                + ((Settings.Tool.toolWidth - Settings.Tool.overlap) * glm.m2FtOrM).ToString("N1") + glm.unitsFtM + " ";

            mf.bnd.bndList[0].hdLine?.Clear();

            Size = Settings.User.setWindow_HeadAcheSize;

            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;

            this.Top = (area.Height - this.Height) / 2;
            this.Left = (area.Width - this.Width) / 2;
            FormHeadAche_ResizeEnd(this, e);

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }
        }

        private void FormHeadLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.FileSaveHeadLines(tracksArr);

            if (tracksArr.Count > 0)
            {
                idx = 0;
            }
            else idx = -1;

            Settings.User.setWindow_HeadAcheSize = Size;
        }

        private void FormHeadAche_ResizeEnd(object sender, EventArgs e)
        {
            Width = (Height * 4 / 3);

            oglSelf.Height = oglSelf.Width = Height - 50;

            oglSelf.Left = 2;
            oglSelf.Top = 2;

            oglSelf.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //58 degrees view
            GL.Viewport(0, 0, oglSelf.Width, oglSelf.Height);
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, 1.0f, 1.0f, 20000);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);

            tlp1.Width = Width - oglSelf.Width - 4;
            tlp1.Left = oglSelf.Width;

            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;

            this.Top = (area.Height - this.Height) / 2;
            this.Left = (area.Width - this.Width) / 2;
        }

        private void FixLabelsCurve()
        {
        }

        private void btnCycleForward_Click(object sender, EventArgs e)
        {
            mf.bnd.bndList[0].hdLine?.Clear();

            if (tracksArr.Count > 0)
            {
                idx++;
                if (idx > (tracksArr.Count - 1)) idx = 0;
            }
            else
            {
                idx = -1;
            }

            FixLabelsCurve();
        }

        private void btnCycleBackward_Click(object sender, EventArgs e)
        {
            mf.bnd.bndList[0].hdLine?.Clear();

            if (tracksArr.Count > 0)
            {
                idx--;
                if (idx < 0) idx = (tracksArr.Count - 1);
            }
            else
            {
                idx = -1;
            }

            FixLabelsCurve();
        }

        private void btnDeleteCurve_Click(object sender, EventArgs e)
        {
            //mf.bnd.buildList[0].hdLine?.Clear();

            if (tracksArr.Count > 0 && idx > -1)
            {
                tracksArr.RemoveAt(idx);
                idx--;
            }

            if (tracksArr.Count > 0)
            {
                if (idx == -1)
                {
                    idx++;
                }
            }
            else idx = -1;

            FixLabelsCurve();
        }

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = oglSelf.PointToClient(Cursor.Position);

            int wid = oglSelf.Width;
            int halfWid = oglSelf.Width / 2;
            double scale = (double)wid * 0.903;

            if (cboxIsZoom.Checked && !zoomToggle)
            {
                sX = ((halfWid - (double)pt.X) / wid) * 1.1;
                sY = ((halfWid - (double)pt.Y) / -wid) * 1.1;
                zoom = 0.1;
                zoomToggle = true;
                return;
            }

            zoomToggle = false;

            //Convert to Origin in the center of window, 800 pixels
            fixPt.X = pt.X - halfWid;
            fixPt.Y = (wid - pt.Y - halfWid);

            vec3 plotPt = new vec3
            {
                //convert screen coordinates to field coordinates
                easting = fixPt.X * mf.maxFieldDistance / scale * zoom,
                northing = fixPt.Y * mf.maxFieldDistance / scale * zoom,
                heading = 0
            };

            plotPt.easting += mf.fieldCenterX + mf.maxFieldDistance * -sX;
            plotPt.northing += mf.fieldCenterY + mf.maxFieldDistance * -sY;

            pint.easting = plotPt.easting;
            pint.northing = plotPt.northing;

            zoom = 1;
            sX = 0;
            sY = 0;

            mf.bnd.bndList[0].hdLine?.Clear();
            idx = -1;

            if (isA)
            {
                double minDistA = double.MaxValue;
                start = 99999; end = 99999;

                for (int j = 0; j < mf.bnd.bndList.Count; j++)
                {
                    for (int i = 0; i < mf.bnd.bndList[j].fenceLine.Count; i++)
                    {
                        double dist = ((pint.easting - mf.bnd.bndList[j].fenceLine[i].easting) * (pint.easting - mf.bnd.bndList[j].fenceLine[i].easting))
                                        + ((pint.northing - mf.bnd.bndList[j].fenceLine[i].northing) * (pint.northing - mf.bnd.bndList[j].fenceLine[i].northing));
                        if (dist < minDistA)
                        {
                            minDistA = dist;
                            bndSelect = j;
                            start = i;
                        }
                    }
                }

                isA = false;
            }
            else
            {
                double minDistA = double.MaxValue;
                int j = bndSelect;

                for (int i = 0; i < mf.bnd.bndList[j].fenceLine.Count; i++)
                {
                    double dist = ((pint.easting - mf.bnd.bndList[j].fenceLine[i].easting) * (pint.easting - mf.bnd.bndList[j].fenceLine[i].easting))
                                    + ((pint.northing - mf.bnd.bndList[j].fenceLine[i].northing) * (pint.northing - mf.bnd.bndList[j].fenceLine[i].northing));
                    if (dist < minDistA)
                    {
                        minDistA = dist;
                        end = i;
                    }
                }

                isA = true;

                if (start == end)
                {
                    start = 99999; end = 99999;
                    mf.TimedMessageBox(2000, "Line Error", "Start Point = End Point ");
                    return;
                }

                //build the lines
                if (rbtnCurve.Checked)
                {
                    tracksArr.Add(new CHeadPath());
                    idx = tracksArr.Count - 1;

                    bool isLoop = false;
                    int limit = end;

                    if ((Math.Abs(start - end)) > (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
                    {
                        if (start < end)
                        {
                            (start, end) = (end, start);
                        }

                        isLoop = true;
                        if (start < end)
                        {
                            limit = end;
                            end = 0;
                        }
                        else
                        {
                            limit = end;
                            end = mf.bnd.bndList[bndSelect].fenceLine.Count;
                        }
                    }
                    else
                    {
                        if (start > end)
                        {
                            (start, end) = (end, start);
                        }
                    }

                    tracksArr[idx].a_point = start;
                    tracksArr[idx].trackPts?.Clear();

                    if (start < end)
                    {
                        for (int i = start; i <= end; i++)
                        {
                            //calculate the point inside the boundary
                            tracksArr[idx].trackPts.Add(new vec3(mf.bnd.bndList[bndSelect].fenceLine[i]));

                            if (isLoop && i == mf.bnd.bndList[bndSelect].fenceLine.Count - 1)
                            {
                                i = -1;
                                isLoop = false;
                                end = limit;
                            }
                        }
                    }
                    else
                    {
                        for (int i = start; i >= end; i--)
                        {
                            //calculate the point inside the boundary
                            tracksArr[idx].trackPts.Add(new vec3(mf.bnd.bndList[bndSelect].fenceLine[i]));

                            if (isLoop && i == 0)
                            {
                                i = mf.bnd.bndList[bndSelect].fenceLine.Count - 1;
                                isLoop = false;
                                end = limit;
                            }
                        }
                    }

                    //who knows which way it actually goes
                    tracksArr[idx].trackPts.CalculateAverageHeadings(false);

                    //create a name
                    tracksArr[idx].name = idx.ToString() + " Cu " + DateTime.Now.ToString("mm:ss", CultureInfo.InvariantCulture);

                    tracksArr[idx].mode = TrackMode.PolyLine;

                    btnExit.Focus();
                }
                else if (rbtnLine.Checked)
                {
                    if ((Math.Abs(start - end)) > (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
                    {
                        if (start < end)
                        {
                            (start, end) = (end, start);
                        }
                    }
                    else
                    {
                        if (start > end)
                        {
                            (start, end) = (end, start);
                        }
                    }

                    vec3 ptA = new vec3(mf.bnd.bndList[bndSelect].fenceLine[start]);
                    vec3 ptB = new vec3(mf.bnd.bndList[bndSelect].fenceLine[end]);

                    //calculate the ABLine Heading
                    double abHead = Math.Atan2(
                        mf.bnd.bndList[bndSelect].fenceLine[end].easting - mf.bnd.bndList[bndSelect].fenceLine[start].easting,
                        mf.bnd.bndList[bndSelect].fenceLine[end].northing - mf.bnd.bndList[bndSelect].fenceLine[start].northing);
                    if (abHead < 0) abHead += glm.twoPI;

                    if (idx < tracksArr.Count - 1)
                    {
                        idx++;
                        tracksArr.Insert(idx, new CHeadPath());
                    }
                    else
                    {
                        tracksArr.Add(new CHeadPath());
                        idx = tracksArr.Count - 1;
                    }

                    tracksArr[idx].a_point = start;
                    tracksArr[idx].trackPts?.Clear();

                    ptA.heading = abHead;
                    ptB.heading = abHead;

                    for (int i = 0; i <= (int)(glm.Distance(ptA, ptB)); i++)
                    {
                        vec3 ptC = new vec3(ptA)
                        {
                            easting = (Math.Sin(abHead) * i) + ptA.easting,
                            northing = (Math.Cos(abHead) * i) + ptA.northing,
                            heading = abHead
                        };
                        tracksArr[idx].trackPts.Add(ptC);
                    }

                    //create a name
                    tracksArr[idx].name = idx.ToString() + " AB " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

                    tracksArr[idx].mode = TrackMode.ABLine;
                }

                tracksArr[idx].trackPts.AddStartEndPoints(30, 2);
                tracksArr[idx].moveDistance = 0;

                //update the arrays
                start = 99999; end = 99999;
                //mf.bnd.buildList[0].hdLine?.Clear();

                if (tracksArr.Count < 1 || idx == -1) return;

                double distAway = nudSetDistance.Value;
                tracksArr[idx].moveDistance += distAway;

                var desList = tracksArr[idx].trackPts.OffsetLine(distAway, 1, tracksArr[idx].mode > TrackMode.PolyLine, false);

                tracksArr[idx].trackPts = desList;

                mf.FileSaveHeadLines(tracksArr);

                FixLabelsCurve();
            }
        }

        private void oglSelf_Paint(object sender, PaintEventArgs e)
        {
            oglSelf.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();                  // Reset The View

            //back the camera up
            GL.Translate(0, 0, -mf.maxFieldDistance * zoom);

            //translate to that spot in the world
            GL.Translate(-mf.fieldCenterX + sX * mf.maxFieldDistance, -mf.fieldCenterY + sY * mf.maxFieldDistance, 0);

            GL.LineWidth(2);

            for (int j = 0; j < mf.bnd.bndList.Count; j++)
            {
                if (j == bndSelect)
                    GL.Color3(0.8f, 0.8f, 0.8f);
                else
                    GL.Color3(0.50f, 0.25f, 0.10f);

                mf.bnd.bndList[j].fenceLine.DrawPolygon(PrimitiveType.Lines);
            }

            //the vehicle
            //GL.PointSize(8.0f);
            //GL.Begin(PrimitiveType.Points);
            //GL.Color3(0.95f, 0.90f, 0.0f);
            //GL.Vertex3(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0.0);
            //GL.End();

            //draw the line building graphics
            //if (start != 99999 || end != 99999)
            //draw the actual built lines
            //if (start == 99999 && end == 99999)
            {
                DrawBuiltLines();
            }

            DrawABTouchLine();

            GL.Disable(EnableCap.Blend);

            GL.Flush();
            oglSelf.SwapBuffers();
        }

        private void oglSelf_Resize(object sender, EventArgs e)
        {
            oglSelf.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //58 degrees view
            GL.Viewport(0, 0, oglSelf.Width, oglSelf.Height);

            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, 1.0f, 1.0f, 20000);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void DrawBuiltLines()
        {
            if (isLinesVisible && tracksArr.Count > 0)
            {
                //GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x7070);
                GL.PointSize(3);

                for (int i = 0; i < tracksArr.Count; i++)
                {
                    if (tracksArr[i].mode == TrackMode.ABLine)
                    {
                        GL.Color3(0.973f, 0.9f, 0.10f);
                    }
                    else
                    {
                        GL.Color3(0.3f, 0.99f, 0.20f);
                    }
                    tracksArr[i].trackPts.DrawPolygon(PrimitiveType.Points);
                }

                //GL.Disable(EnableCap.LineStipple);

                if (idx > -1)
                {
                    GL.LineWidth(6);
                    GL.Color3(1.0f, 0.0f, 1.0f);

                    tracksArr[idx].trackPts.DrawPolygon(PrimitiveType.LineStrip);

                    int cnt = tracksArr[idx].trackPts.Count - 1;
                    GL.PointSize(28);
                    GL.Color3(0, 0, 0);
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex3(tracksArr[idx].trackPts[0].easting, tracksArr[idx].trackPts[0].northing, 0);
                    GL.Vertex3(tracksArr[idx].trackPts[cnt].easting, tracksArr[idx].trackPts[cnt].northing, 0);
                    GL.End();

                    GL.PointSize(20);
                    GL.Color3(1.0f, 0.7f, 0.35f);
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex3(tracksArr[idx].trackPts[0].easting, tracksArr[idx].trackPts[0].northing, 0);
                    GL.Color3(0.6f, 0.75f, 0.99f);
                    GL.Vertex3(tracksArr[idx].trackPts[cnt].easting, tracksArr[idx].trackPts[cnt].northing, 0);
                    GL.End();
                }
            }

            GL.LineWidth(8);
            GL.Color3(0.93f, 0.899f, 0.50f);
            mf.bnd.bndList[0].hdLine.DrawPolygon(PrimitiveType.LineStrip);
        }

        private void DrawABTouchLine()
        {
            GL.Color3(0.65, 0.650, 0.0);
            GL.PointSize(24);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(0, 0, 0);
            if (start != 99999) GL.Vertex3(mf.bnd.bndList[bndSelect].fenceLine[start].easting, mf.bnd.bndList[bndSelect].fenceLine[start].northing, 0);
            if (end != 99999) GL.Vertex3(mf.bnd.bndList[bndSelect].fenceLine[end].easting, mf.bnd.bndList[bndSelect].fenceLine[end].northing, 0);
            GL.End();

            GL.PointSize(16);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(1.0f, 0.75f, 0.350f);
            if (start != 99999) GL.Vertex3(mf.bnd.bndList[bndSelect].fenceLine[start].easting, mf.bnd.bndList[bndSelect].fenceLine[start].northing, 0);

            GL.Color3(0.5f, 0.75f, 1.0f);
            if (end != 99999) GL.Vertex3(mf.bnd.bndList[bndSelect].fenceLine[end].easting, mf.bnd.bndList[bndSelect].fenceLine[end].northing, 0);
            GL.End();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (mf.bnd.bndList.Count > 0 && mf.bnd.bndList[0].hdLine.Count > 0)
            {
                //triangulate headland area
                mf.bnd.bndList[0].CreateHdLineVertexArray();
                mf.bnd.isHeadlandOn = true;

                mf.FileSaveHeadLines(tracksArr);
                //does headland control sections
                mf.bnd.isSectionControlledByHeadland = true;
            }
            Close();
        }

        private void nudSetDistance_ValueChanged(object sender, EventArgs e)
        {
            btnExit.Focus();
        }

        // Returns 1 if the lines intersect, otherwis

        public List<int> crossings = new List<int>(1);

        private void btnDeleteHeadland_Click(object sender, EventArgs e)
        {
            start = 99999; end = 99999;
            isA = true;
            mf.bnd.bndList[0].hdLine?.Clear();
            mf.bnd.bndList[0].DeleteHeadLineVertexArray();

            //int ptCount = mf.bnd.buildList[0].fenceLine.Count;

            //for (int i = 0; i < ptCount; i++)
            //{
            //    mf.bnd.buildList[0].hdLine.Add(new vec3(mf.bnd.buildList[0].fenceLine[i]));
            //}
        }

        private void btnBndLooPGN_Click(object sender, EventArgs e)
        {
            //sort the lines
            tracksArr.Sort((p, q) => p.a_point.CompareTo(q.a_point));
            mf.FileSaveHeadLines(tracksArr);

            idx = -1;

            //build the headland
            mf.bnd.bndList[0].hdLine?.Clear();
            mf.bnd.bndList[0].DeleteHeadLineVertexArray();

            int nextLine = 0;
            crossings.Clear();

            int isStart = 0;

            for (int lineNum = 0; lineNum < tracksArr.Count; lineNum++)
            {
                nextLine = lineNum - 1;
                if (nextLine < 0) nextLine = tracksArr.Count - 1;

                if (nextLine == lineNum)
                {
                    mf.TimedMessageBox(2000, "Create Error", "Is there maybe only 1 line?");
                    Log.EventWriter("Headache, Only 1 Line");

                    return;
                }

                for (int i = 0; i < tracksArr[lineNum].trackPts.Count - 2; i++)
                {
                    for (int k = 0; k < tracksArr[nextLine].trackPts.Count - 2; k++)
                    {
                        bool res = glm.GetLineIntersection(
                        tracksArr[lineNum].trackPts[i],
                        tracksArr[lineNum].trackPts[i + 1],

                        tracksArr[nextLine].trackPts[k],
                        tracksArr[nextLine].trackPts[k + 1], out _, out _, out _);
                        if (res)
                        {
                            if (isStart == 0) i++;
                            crossings.Add(i);
                            isStart++;
                            if (isStart == 2) goto again;
                            nextLine = lineNum + 1;

                            if (nextLine > tracksArr.Count - 1) nextLine = 0;
                        }
                    }
                }

            again:
                isStart = 0;
            }

            if (crossings.Count != tracksArr.Count * 2)
            {
                mf.TimedMessageBox(2000, "Crosings Error", "Make sure all ends cross and only once");
                Log.EventWriter("Headache, All ends cross and only once");
                mf.bnd.bndList[0].hdLine?.Clear();
                mf.bnd.bndList[0].DeleteHeadLineVertexArray();
                return;
            }

            for (int i = 0; i < tracksArr.Count; i++)
            {
                int low = crossings[i * 2];
                int high = crossings[i * 2 + 1];
                for (int k = low; k < high; k++)
                {
                    mf.bnd.bndList[0].hdLine.Add(tracksArr[i].trackPts[k]);
                }
            }

            //for (int i = 0; i < tracksArr.Count; i++)
            //{
            //    hdl.designPtsList?.Clear();

            //    int low = crossings[i * 2];
            //    int high = crossings[i * 2 + 1];
            //    for (int k = low; k < high; k++)
            //    {
            //        hdl.designPtsList.Add(tracksArr[i].trackPts[k]);
            //    }

            //    tracksArr[i].trackPts?.Clear();

            //    foreach (var item in hdl.designPtsList)
            //    {
            //        tracksArr[i].trackPts.Add(new vec3(item));
            //    }
            //}

            vec3[] hdArr;

            if (mf.bnd.bndList[0].hdLine.Count > 0)
            {
                hdArr = new vec3[mf.bnd.bndList[0].hdLine.Count];
                mf.bnd.bndList[0].hdLine.CopyTo(hdArr);
                mf.bnd.bndList[0].hdLine?.Clear();
                mf.bnd.bndList[0].DeleteHeadLineVertexArray();
            }
            else
            {
                mf.bnd.bndList[0].hdLine?.Clear();
                mf.bnd.bndList[0].DeleteHeadLineVertexArray();
                return;
            }

            //middle points
            for (int i = 1; i < hdArr.Length; i++)
            {
                hdArr[i - 1].heading = Math.Atan2(hdArr[i - 1].easting - hdArr[i].easting, hdArr[i - 1].northing - hdArr[i].northing);
                if (hdArr[i].heading < 0) hdArr[i].heading += glm.twoPI;
            }

            double delta = 0;
            for (int i = 0; i < hdArr.Length; i++)
            {
                if (i == 0)
                {
                    mf.bnd.bndList[0].hdLine.Add(new vec3(hdArr[i].easting, hdArr[i].northing, hdArr[i].heading));
                    continue;
                }
                delta += (hdArr[i - 1].heading - hdArr[i].heading);

                if (Math.Abs(delta) > 0.005)
                {
                    vec3 pt = new vec3(hdArr[i].easting, hdArr[i].northing, hdArr[i].heading);

                    mf.bnd.bndList[0].hdLine.Add(pt);
                    delta = 0;
                }
            }

            mf.FileSaveHeadland();
        }

        private void cboxToolWidths_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudSetDistance.Value = Math.Round((Settings.Tool.toolWidth - Settings.Tool.overlap) * cboxToolWidths.SelectedIndex, 1);
        }

        private void btnHeadlandOff_Click(object sender, EventArgs e)
        {
            mf.bnd.bndList[0].hdLine?.Clear();
            mf.bnd.bndList[0].DeleteHeadLineVertexArray();

            mf.FileSaveHeadland();
            mf.bnd.isHeadlandOn = false;
            Close();
        }

        private void btnBLength_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                int ptCnt = tracksArr[idx].trackPts.Count - 1;

                for (int i = 1; i < 10; i++)
                {
                    vec3 pt = new vec3(tracksArr[idx].trackPts[ptCnt]);
                    pt.easting += (Math.Sin(pt.heading) * i);
                    pt.northing += (Math.Cos(pt.heading) * i);
                    tracksArr[idx].trackPts.Add(pt);
                }
            }
        }

        private void btnBShrink_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                if (tracksArr[idx].trackPts.Count > 8)
                    tracksArr[idx].trackPts.RemoveRange(tracksArr[idx].trackPts.Count - 5, 5);
            }
        }

        private void btnALength_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                //and the beginning
                vec3 start = new vec3(tracksArr[idx].trackPts[0]);

                for (int i = 1; i < 10; i++)
                {
                    vec3 pt = new vec3(start);
                    pt.easting -= (Math.Sin(pt.heading) * i);
                    pt.northing -= (Math.Cos(pt.heading) * i);
                    tracksArr[idx].trackPts.Insert(0, pt);
                }
            }
        }

        private void btnAShrink_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                if (tracksArr[idx].trackPts.Count > 8)
                    tracksArr[idx].trackPts.RemoveRange(0, 5);
            }
        }

        private void btnCancelTouch_Click(object sender, EventArgs e)
        {
            //update the arrays
            start = 99999; end = 99999;
            isA = true;
            FixLabelsCurve();
            zoom = 1;
            sX = 0;
            sY = 0;
            zoomToggle = false;
            btnExit.Focus();
        }

        private void cboxIsZoom_CheckedChanged(object sender, EventArgs e)
        {
            zoomToggle = false;
        }

        private void oglSelf_Load(object sender, EventArgs e)
        {
            oglSelf.MakeCurrent();
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.ClearColor(0.22f, 0.22f, 0.22f, 1.0f);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }
    }
}