using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Twol
{
    public partial class CBoundary
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        //the class of all the individual lists like headland, turnline, fence
        public List<CBoundaryList> bndList = new List<CBoundaryList>();

        //create a new fence and show it
        public List<vec2> fenceBeingMadePts = new List<vec2>(128);

        public int[] vbo_FenceTriangles = new int[5] { 0, 0, 0, 0, 0 };
        public int[] vbo_HeadTriangles = new int[5] { 0, 0, 0, 0, 0 };

        //boundary record properties
        public double createFenceOffset;

        public bool isFenceBeingMade;
        public bool isDrawRightSide = true, isDrawAtPivot = true, isOkToAddPoints = false;
        public bool isRecFenceWhenSectionOn = false;

        //headland properties
        public bool isHeadlandOn;

        public bool isToolInHeadland, isSectionControlledByHeadland;

        //turnline props
        public int turnSelected, closestTurnNum;

        public double iE = 0, iN = 0;

        //constructor
        public CBoundary(FormGPS _f)
        {
            mf = _f;
            turnSelected = 0;
            isHeadlandOn = false;
            isSectionControlledByHeadland = true;
        }

        public void CreateHdLineVertexArray(int bndNum)
        {
            DeleteHeadLineVertexArray(bndNum);

            vbo_HeadTriangles[bndNum] = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_HeadTriangles[bndNum]);

            float[] triangleVertexData = new float[bndList[bndNum].hdLineTriangleList.Count * 6];

            for (int i = 0; i < bndList[bndNum].hdLineTriangleList.Count; i++)
            {
                // Assuming Triangle has properties or fields: A, B, C of type vec3 with .x, .y, .z
                triangleVertexData[i * 6 + 0] = (float)bndList[0].hdLineTriangleList[i].polygonPts[0].easting;
                triangleVertexData[i * 6 + 1] = (float)bndList[0].hdLineTriangleList[i].polygonPts[0].northing;
                triangleVertexData[i * 6 + 2] = (float)bndList[0].hdLineTriangleList[i].polygonPts[1].easting;
                triangleVertexData[i * 6 + 3] = (float)bndList[0].hdLineTriangleList[i].polygonPts[1].northing;
                triangleVertexData[i * 6 + 4] = (float)bndList[0].hdLineTriangleList[i].polygonPts[2].easting;
                triangleVertexData[i * 6 + 5] = (float)bndList[0].hdLineTriangleList[i].polygonPts[2].northing;
            }

            GL.BufferData(BufferTarget.ArrayBuffer, triangleVertexData.Length * sizeof(float), triangleVertexData, BufferUsageHint.StaticDraw);
        }

        public void DeleteHeadLineVertexArray(int bndNum)
        {
            if (vbo_HeadTriangles[bndNum] != 0)
            {
                GL.DeleteBuffer(vbo_HeadTriangles[bndNum]);
                vbo_HeadTriangles[bndNum] = 0; // Set the handle to 0 (null/invalid) after deletion
            }
        }

        public void DeleteFenceTriangleVertexArray(int bndNum)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            if (vbo_FenceTriangles[bndNum] != 0)
            {
                GL.DeleteBuffer(vbo_FenceTriangles[bndNum]);
                vbo_FenceTriangles[bndNum] = 0; // Set the handle to 0 (null/invalid) after deletion
            }
        }

        public void AddToBoundList(CBoundaryList bound, int bndNum, bool add = true)
        {
            if (add)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

                if (vbo_FenceTriangles[bndNum] != 0)
                {
                    GL.DeleteBuffer(vbo_FenceTriangles[bndNum]);
                    vbo_FenceTriangles[bndNum] = 0; // Set the handle to 0 (null/invalid) after deletion
                }

                vbo_FenceTriangles[bndNum] = GL.GenBuffer();
            }

            //build the boundary, make sure is clockwise for outer counter clockwise for inner
            bound.FixFenceLine(bndNum, vbo_FenceTriangles[bndNum], add);

            if (add)
                bndList.Add(bound);
        }

        public int IsPointInsideTurnArea(vec3 pt)
        {
            if (bndList.Count > 0 && bndList[0].turnLine.IsPointInPolygon(pt))
            {
                for (int i = 1; i < bndList.Count; i++)
                {
                    if (bndList[i].isDriveThru) continue;
                    if (bndList[i].turnLine.IsPointInPolygon(pt))
                    {
                        return i;
                    }
                }
                return 0;
            }
            return -1; //is outside border turn
        }

        public bool IsPointInsideFenceArea(vec3 testPoint)
        {
            //first where are we, must be inside outer and outside of inner geofence non drive thru turn borders
            if (bndList[0].fenceLineEar.IsPointInPolygon(testPoint))
            {
                for (int i = 1; i < bndList.Count; i++)
                {
                    //make sure not inside a non drivethru boundary
                    //if (buildList[i].isDriveThru) continue;
                    if (bndList[i].fenceLineEar.IsPointInPolygon(testPoint))
                    {
                        return false;
                    }
                }
                //we are safely inside outer, outside inner boundaries
                return true;
            }
            return false;
        }

        public void DrawBnds()
        {
            DrawFenceLines();
            DrawTurnLines();
            DrawHeadlands();
        }

        public void DrawHeadlands()
        {
            //Draw headland
            if (mf.bnd.isHeadlandOn)
            {
                GL.LineWidth(Settings.User.setDisplay_lineWidth * 4);

                GL.Color4(0, 0, 0, 0.80f);
                mf.bnd.bndList[0].hdLine.DrawPolygon();

                GL.LineWidth(Settings.User.setDisplay_lineWidth);
                GL.Color4(0.960f, 0.96232f, 0.30f, 1.0f);
                mf.bnd.bndList[0].hdLine.DrawPolygon();
            }
        }

        public void DrawTurnLines()
        {
            //draw the turnLines
            if (mf.yt.isYouTurnBtnOn && !mf.ct.isContourBtnOn)
            {
                GL.LineWidth(Settings.User.setDisplay_lineWidth * 4);
                GL.Color4(0, 0, 0, 0.80f);

                for (int i = 0; i < mf.bnd.bndList.Count; i++)
                {
                    mf.bnd.bndList[i].turnLine.DrawPolygon();
                }

                GL.Color3(0.76f, 0.6f, 0.95f);
                GL.LineWidth(Settings.User.setDisplay_lineWidth);
                for (int i = 0; i < mf.bnd.bndList.Count; i++)
                {
                    mf.bnd.bndList[i].turnLine.DrawPolygon();
                }
            }
        }

        public void DrawFenceLines()
        {
            GL.Color4(0, 0, 0, 0.8);
            GL.LineWidth(Settings.User.setDisplay_lineWidth * 4);

            for (int i = 0; i < bndList.Count; i++)
            {
                bndList[i].fenceLineEar.DrawPolygon();
            }

            GL.Color4(0.95f, 0.5f, 0.50f, 1.0f);
            GL.LineWidth(Settings.User.setDisplay_lineWidth);

            for (int i = 0; i < bndList.Count; i++)
            {
                if (i > 0) GL.Color4(0.85f, 0.34f, 0.3f, 1.0f);
                bndList[i].fenceLineEar.DrawPolygon();
            }

            //for (int i = 0; i < bndList.Count; i++)
            //{
            //    GL.Color3(0.0f, 0.95f, 0.95f);
            //    GL.PointSize(4.0f);
            //    bndList[i].fenceLine.DrawPolygon(PrimitiveType.Points);
            //}


            if (fenceBeingMadePts.Count > 0)
            {
                //the boundary so far
                vec3 pivot = mf.pivotAxlePos;
                GL.LineWidth(Settings.User.setDisplay_lineWidth);
                GL.Color3(0.825f, 0.22f, 0.90f);
                fenceBeingMadePts.DrawPolygon(PrimitiveType.LineStrip);

                //line from last point to pivot marker
                GL.Color3(0.825f, 0.842f, 0.0f);
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x0700);
                GL.Begin(PrimitiveType.LineStrip);

                if (isDrawAtPivot)
                {
                    if (isDrawRightSide)
                    {
                        GL.Vertex3(fenceBeingMadePts[0].easting, fenceBeingMadePts[0].northing, 0);

                        GL.Vertex3(pivot.easting + (Math.Sin(pivot.heading - glm.PIBy2) * -createFenceOffset),
                                pivot.northing + (Math.Cos(pivot.heading - glm.PIBy2) * -createFenceOffset), 0);
                        GL.Vertex3(fenceBeingMadePts[fenceBeingMadePts.Count - 1].easting, fenceBeingMadePts[fenceBeingMadePts.Count - 1].northing, 0);
                    }
                    else
                    {
                        GL.Vertex3(fenceBeingMadePts[0].easting, fenceBeingMadePts[0].northing, 0);

                        GL.Vertex3(pivot.easting + (Math.Sin(pivot.heading - glm.PIBy2) * createFenceOffset),
                                pivot.northing + (Math.Cos(pivot.heading - glm.PIBy2) * createFenceOffset), 0);
                        GL.Vertex3(fenceBeingMadePts[fenceBeingMadePts.Count - 1].easting, fenceBeingMadePts[fenceBeingMadePts.Count - 1].northing, 0);
                    }
                }
                else if (mf.section.Count > 0) //draw from tool
                {
                    if (isDrawRightSide)
                    {
                        GL.Vertex3(fenceBeingMadePts[0].easting, fenceBeingMadePts[0].northing, 0);
                        GL.Vertex3(mf.section[mf.section.Count - 1].rightPoint.easting, mf.section[mf.section.Count - 1].rightPoint.northing, 0);
                        GL.Vertex3(fenceBeingMadePts[fenceBeingMadePts.Count - 1].easting, fenceBeingMadePts[fenceBeingMadePts.Count - 1].northing, 0);
                    }
                    else
                    {
                        GL.Vertex3(fenceBeingMadePts[0].easting, fenceBeingMadePts[0].northing, 0);
                        GL.Vertex3(mf.section[0].leftPoint.easting, mf.section[0].leftPoint.northing, 0);
                        GL.Vertex3(fenceBeingMadePts[fenceBeingMadePts.Count - 1].easting, fenceBeingMadePts[fenceBeingMadePts.Count - 1].northing, 0);
                    }
                }
                GL.End();
                GL.Disable(EnableCap.LineStipple);

                //boundary points
                GL.Color3(0.0f, 0.95f, 0.95f);
                GL.PointSize(6.0f);
                fenceBeingMadePts.DrawPolygon(PrimitiveType.Points);
            }
        }
    }
}