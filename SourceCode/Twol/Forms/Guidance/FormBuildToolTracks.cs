using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Twol.Classes;

namespace Twol
{
    public partial class FormBuildToolTracks : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private Point fixPt;

        private int selectedLineIndex = 0;

        private bool isCancel = false;

        private double zoom = 1, sX = 0, sY = 0;

        public List<CTrk> gTemp = new List<CTrk>();

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        private bool isDrawSections = true;

        public double remoteHeading = 0.0;

        //list of the list of patch data individual triangles for tool recording
        public List<List<vec3>> recList = new List<List<vec3>>();

        public FormBuildToolTracks(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormBuildToolTracks_Load(object sender, EventArgs e)
        {
            Size = Settings.User.setWindow_BuildToolTracksSize;

            if (!mf.IsOnScreen(Location, Size, 1))
            {
                Top = 0;
                Left = 0;
            }

            //load the tool recording file
            FileLoadToolRecord(Path.Combine(RegistrySettings.fieldsDirectory, mf.currentFieldDirectory, mf.currentJobDirectory, "ToolRecording.txt"));
            FixLabelsCurve();
        }

        public void FileLoadToolRecord(string dir)
        {
            if (!File.Exists(dir))
            {
                mf.TimedMessageBox(2000, gStr.Get(gs.gsToolSteerConfiguration), "ToolRecording.Txt is Missing");
                return;
            }

            //Points in Patch followed by easting, heading, northing, elevation
            else
            {
                using (StreamReader reader = new StreamReader(dir))
                {
                    try
                    {
                        //read header
                        string line;
                        while (!reader.EndOfStream)
                        {
                            //read how many vertices in the following patch
                            line = reader.ReadLine();
                            int verts = int.Parse(line);
                            if (verts > 10)
                            {
                                vec3 vecFix = new vec3(0, 0, 0);

                                var ptList = new List<vec3>();
                                ptList.Capacity = verts + 1;

                                for (int v = 0; v < verts; v++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vecFix.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                    vecFix.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                    vecFix.heading = double.Parse(words[2], CultureInfo.InvariantCulture);
                                    ptList.Add(vecFix);
                                }

                                recList.Add(ptList);
                            }
                            else
                            {
                                for (int v = 0; v < verts; v++)
                                {
                                    line = reader.ReadLine();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log.EventWriter("Loading ToolRec file" + e.ToString());

                        mf.TimedMessageBox(2000, gStr.Get("Tool Recording File is Corrupt"), gStr.Get(gs.gsButFieldIsLoaded));
                    }
                }
            }
        }

        private void FormBuildToolTracks_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isCancel)
            {
            }
            Settings.User.setWindow_BuildToolTracksSize = Size;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isCancel = false;
            mf.toolRecordSaveList.Clear();
            mf.toolRecordSaveList.AddRange(recList);
            mf.FileSaveToolRecordList(false);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            Close();
        }

        private void btnSelectCurve_Click(object sender, EventArgs e)
        {
            selectedLineIndex++;
            if (selectedLineIndex >= recList.Count) selectedLineIndex = 0;
            FixLabelsCurve();
        }

        private void btnSelectCurveBk_Click(object sender, EventArgs e)
        {
            selectedLineIndex--;
            if (selectedLineIndex < 0) selectedLineIndex = recList.Count - 1;
            FixLabelsCurve();
        }

        private void btnDeleteCurve_Click(object sender, EventArgs e)
        {
            if (recList.Count > 0)
            {
                recList.RemoveAt(selectedLineIndex);
                if (selectedLineIndex >= recList.Count) selectedLineIndex = 0;
                if (selectedLineIndex < 0) selectedLineIndex = recList.Count - 1;
            }
            else
            {
                selectedLineIndex = -1;
            }

            FixLabelsCurve();
        }

        private void FixLabelsCurve()
        {
            lblCurveSelected.Text = (selectedLineIndex + 1).ToString() + " / " + recList.Count.ToString();
        }

        private void btnOuterLine_Click(object sender, EventArgs e)
        {
            if (recList.Count > 0 && selectedLineIndex >= 0 && selectedLineIndex < recList.Count && recList[selectedLineIndex].Count > 0)
            {
                // Copy the struct, modify, and assign back to the list
                vec3 temp = recList[selectedLineIndex][0];
                temp.heading = 1;
                recList[selectedLineIndex][0] = temp;
            }

            selectedLineIndex++;
            if (selectedLineIndex >= recList.Count) selectedLineIndex = 0;
            FixLabelsCurve();

        }

        private void btnMakeCurve_Click(object sender, EventArgs e)
        {
            vec3 temp = recList[selectedLineIndex][0];
            temp.heading = 2;
            recList[selectedLineIndex][0] = temp;

            selectedLineIndex++;
            if (selectedLineIndex >= recList.Count) selectedLineIndex = 0;
            FixLabelsCurve();

            // "A_Fld Cu " : "A_Bnd Cu ";
        }
        private void btnJoinCurve_Click(object sender, EventArgs e)
        {
            vec3 temp = recList[selectedLineIndex][0];
            temp.heading = 3;
            recList[selectedLineIndex][0] = temp;
        }


        private void btnMakeABLine_Click(object sender, EventArgs e)
        {
            FixLabelsCurve();
        }

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = oglSelf.PointToClient(Cursor.Position);

            int wid = oglSelf.Width;
            int halfWid = oglSelf.Width / 2;
            double scale = (double)wid * 0.903;

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

            double minDistA = double.MaxValue;
            pint.easting = plotPt.easting;
            pint.northing = plotPt.northing;

            for (int j = 0; j < recList.Count; j++)
            {
                for (int i = 0; i < recList[j].Count; i++)
                {
                    double dist = ((pint.easting - recList[j][i].easting) * (pint.easting - recList[j][i].easting))
                                    + ((pint.northing - recList[j][i].northing) * (pint.northing - recList[j][i].northing));
                    if (dist < minDistA)
                    {
                        minDistA = dist;
                        selectedLineIndex = j;
                    }
                }
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

            if (isDrawSections)
            {
                GL.Color3(0.2f, 0.2f, 0.2f);

                //for every new chunk of patch
                foreach (var triList in mf.patchList)
                {
                    triList.DrawPolygon(8, 1, PrimitiveType.TriangleStrip);
                }
            }

            GL.LineWidth(3);

            for (int j = 0; j < mf.bnd.bndList.Count; j++)
            {
                GL.Color3(0.62f, 0.635f, 0.635f);
                mf.bnd.bndList[j].fenceLineEar.DrawPolygon(PrimitiveType.LineLoop);
            }

            if (recList.Count > 0 && selectedLineIndex >= 0 && selectedLineIndex < recList.Count)
            {
                GL.PointSize(2);
                for (int i = 0; i < recList.Count; i++)
                {
                    if (recList[i][0].heading == 0) GL.Color3(0.19, 1.0, 1.0);
                    else if (recList[i][0].heading == 1) GL.Color3(1.0, 0.09, 0.56);
                    else if (recList[i][0].heading == 2) GL.Color3(0.39, 1.0, 0.396);
                    else if (recList[i][0].heading == 3) GL.Color3(0.39, 0.9, 1.0);

                    recList[i].DrawPolygon(PrimitiveType.Points);
                }

                //selected line
                GL.Color3(1.0f, 0.975f, 0.9350f);
                GL.PointSize(4);
                GL.Begin(PrimitiveType.Points);

                for (int i = 0; i < recList[selectedLineIndex].Count; i += 5)
                {
                    GL.Vertex2(recList[selectedLineIndex][i].easting, recList[selectedLineIndex][i].northing);
                }
                GL.End();

                //start of Line
                GL.Color3(1.0f, 0.75f, 0.350f);

                GL.PointSize(12);
                for (int i = 0; i < recList.Count; i++)
                {
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex2(recList[i][0].easting, recList[i][0].northing);
                    GL.End();
                }
            }

            //the vehicle
            //GL.PointSize(16.0f);
            //GL.Begin(PrimitiveType.Points);
            //GL.Color3(1.0f, 0.00f, 0.0f);
            //GL.Vertex2(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing);
            //GL.End();

            //GL.PointSize(8.0f);
            //GL.Begin(PrimitiveType.Points);
            //GL.Color3(0.00f, 0.0f, 0.0f);
            //GL.Vertex2(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing);
            //GL.End();

            //draw the line building graphics
            //DrawABTouchPoints();

            GL.Flush();
            oglSelf.SwapBuffers();
        }

        private void DrawABTouchPoints()
        {
            GL.PointSize(24);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0, 0, 0);
            GL.Vertex2(pint.easting, pint.northing);
            GL.End();

            GL.PointSize(16);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(1.0f, 0.75f, 0.350f);
            GL.Vertex2(pint.easting, pint.northing);
            GL.End();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();
        }

        private void btnALength_Click(object sender, EventArgs e)
        {
            if (recList.Count > 0)
            {
                //and the beginning
                vec3 start = new vec3(recList[selectedLineIndex][0]);
                double heading = Math.Atan2(recList[selectedLineIndex][1].easting - recList[selectedLineIndex][0].easting, recList[selectedLineIndex][1].northing - recList[selectedLineIndex][0].northing);

                vec3 pt = new vec3(start);
                pt.easting -= (Math.Sin(heading) * 5);
                pt.northing -= (Math.Cos(heading) * 5);
                pt.heading = start.heading;
                recList[selectedLineIndex].Insert(0, pt);
            }
        }

        private void bntALengthShorter_Click(object sender, EventArgs e)
        {
            if (recList.Count > 0)
            {
                recList[selectedLineIndex].RemoveAt(0);
            }
        }

        private void btnBLength_Click(object sender, EventArgs e)
        {
            if (recList.Count > 0)
            {
                vec3 start = new vec3(recList[selectedLineIndex][recList[selectedLineIndex].Count - 1]);
                double heading = Math.Atan2(recList[selectedLineIndex][recList[selectedLineIndex].Count - 1].easting - recList[selectedLineIndex][recList[selectedLineIndex].Count - 2].easting, recList[selectedLineIndex][recList[selectedLineIndex].Count - 1].northing - recList[selectedLineIndex][recList[selectedLineIndex].Count - 2].northing);

                vec3 pt = new vec3(start);
                pt.easting += (Math.Sin(heading) * 3);
                pt.northing += (Math.Cos(heading) * 3);
                pt.heading = start.heading;
                recList[selectedLineIndex].Add(pt);
            }
        }

        private void btnBLengthShorter_Click(object sender, EventArgs e)
        {
            if (recList.Count > 0)
            {
                recList[selectedLineIndex].RemoveAt(recList[selectedLineIndex].Count - 1);
            }
        }

        private void oglSelf_Resize(object sender, EventArgs e)
        {
            oglSelf.Height = oglSelf.Width;

            oglSelf.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //58 degrees view
            GL.Viewport(0, 0, oglSelf.Width, oglSelf.Height);

            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, 1.0f, 1.0f, 20000);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void oglSelf_Load(object sender, EventArgs e)
        {
            oglSelf.MakeCurrent();
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}