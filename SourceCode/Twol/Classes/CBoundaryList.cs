using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Twol
{
    public class CBoundaryList
    {
        public List<vec3> fenceLine = new List<vec3>(128);
        public List<vec2> fenceLineEar = new List<vec2>(128);

        public List<vec3> hdLine = new List<vec3>(128);

        public List<vec3> turnLine = new List<vec3>(128);

        //public CPolygon bndPolygon = new CPolygon();
        //public CPolygon hdLinePolygon = new CPolygon();

        public int vbo_FenceTriangles = -1;
        public int vbo_FenceTrianglesCount = 0;

        public int vbo_HeadTriangles = -1;
        public int vbo_HeadTrianglesCount = 0;

        //boundary variables
        public double area;

        public bool isDriveThru;

        private int idx = 0;
        //constructor
        public CBoundaryList()
        {
            area = 0;
            isDriveThru = false;
        }

        public void FixFenceLine(int bndNum, int vboIndex, bool add)
        {
            CalculateFenceArea(bndNum);

            fenceLine.MinimumSpacingPointRemoval();

            fenceLine.GenerateEquidistantPoints(2, true);

            fenceLine.CalculateAverageHeadings(true);

            fenceLineEar = fenceLine.ReducePointsByAngleToVec2(0.02, 20);

            fenceLine.CalculateAverageHeadings(true);

            //Triangulate the bundary polygon
            CPolygon bndPolygon = new CPolygon(fenceLineEar.ToArray());
            var fenceTriangleList = bndPolygon.Triangulate();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboIndex);

            float[] triangleVertexData = new float[fenceTriangleList.Count * 6];

            for (int i = 0; i < fenceTriangleList.Count; i++)
            {
                // Assuming Triangle has properties or fields: A, B, C of type vec3 with .x, .y, .z
                triangleVertexData[i * 6 + 0] = (float)fenceTriangleList[i].polygonPts[0].easting;
                triangleVertexData[i * 6 + 1] = (float)fenceTriangleList[i].polygonPts[0].northing;
                triangleVertexData[i * 6 + 2] = (float)fenceTriangleList[i].polygonPts[1].easting;
                triangleVertexData[i * 6 + 3] = (float)fenceTriangleList[i].polygonPts[1].northing;
                triangleVertexData[i * 6 + 4] = (float)fenceTriangleList[i].polygonPts[2].easting;
                triangleVertexData[i * 6 + 5] = (float)fenceTriangleList[i].polygonPts[2].northing;
            }

            GL.BufferData(BufferTarget.ArrayBuffer, triangleVertexData.Length * sizeof(float), triangleVertexData, BufferUsageHint.StaticDraw);
            vbo_FenceTrianglesCount = fenceTriangleList.Count * 3;

            BuildTurnLine();
        }

        public void BuildTurnLine()
        {
            //determine how wide a headland space
            double totalHeadWidth = Settings.Vehicle.set_youTurnDistanceFromBoundary;

            turnLine = fenceLine.OffsetLine(totalHeadWidth, 4, true, false);

            for (int i = turnLine.Count - 1; i >= 0; i--)
            {
                if ((idx == 0) != fenceLineEar.IsPointInPolygon(turnLine[i]))
                {
                    turnLine.RemoveAt(i);
                }
            }

            //make sure headings are correct for calculated points
            turnLine.CalculateAverageHeadings(true);

            //countExit the reference list of original curve
            int cnt = turnLine.Count;

            //the temp array
            vec3[] arr = new vec3[cnt];

            for (int s = 0; s < cnt; s++)
            {
                arr[s] = turnLine[s];
            }

            double delta = 0;
            turnLine?.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    turnLine.Add(arr[i]);
                    continue;
                }
                delta += (arr[i - 1].heading - arr[i].heading);
                if (Math.Abs(delta) > 0.005)
                {
                    turnLine.Add(arr[i]);
                    delta = 0;
                }
            }
        }

        private void ReverseWinding()
        {
            //reverse the boundary
            int cnt = fenceLine.Count;
            vec3[] arr = new vec3[cnt];
            cnt--;
            fenceLine.CopyTo(arr);
            fenceLine.Clear();
            for (int i = cnt; i >= 0; i--)
            {
                arr[i].heading -= Math.PI;
                if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                fenceLine.Add(arr[i]);
            }
        }

        private bool CalculateFenceArea(int idx)
        {
            int ptCount = fenceLine.Count;
            if (ptCount < 1) return false;

            area = 0;         // Accumulates area in the loop
            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area += (fenceLine[j].easting + fenceLine[i].easting) * (fenceLine[j].northing - fenceLine[i].northing);
            }

            bool isClockwise = area >= 0;

            area = Math.Abs(area / 2);

            //make sure is clockwise for outer counter clockwise for inner
            if ((idx == 0) != isClockwise)
            {
                ReverseWinding();
            }

            return isClockwise;
        }

        public void DeleteFenceTriangleVertexArray()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);//not sure if this matters

            if (vbo_FenceTriangles != -1)
            {
                GL.DeleteBuffer(vbo_FenceTriangles);
                vbo_FenceTriangles = -1; // Set the handle to -1 (null/invalid) after deletion
            }
        }

        public void CreateHdLineVertexArray()
        {
            DeleteHeadLineVertexArray();

            CPolygon hdLinePolygon = new CPolygon(hdLine.ToArray());
            var hdLineTriangleList = hdLinePolygon.Triangulate();

            vbo_HeadTriangles = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_HeadTriangles);

            float[] triangleVertexData = new float[hdLineTriangleList.Count * 6];

            for (int i = 0; i < hdLineTriangleList.Count; i++)
            {
                // Assuming Triangle has properties or fields: A, B, C of type vec3 with .x, .y, .z
                triangleVertexData[i * 6 + 0] = (float)hdLineTriangleList[i].polygonPts[0].easting;
                triangleVertexData[i * 6 + 1] = (float)hdLineTriangleList[i].polygonPts[0].northing;
                triangleVertexData[i * 6 + 2] = (float)hdLineTriangleList[i].polygonPts[1].easting;
                triangleVertexData[i * 6 + 3] = (float)hdLineTriangleList[i].polygonPts[1].northing;
                triangleVertexData[i * 6 + 4] = (float)hdLineTriangleList[i].polygonPts[2].easting;
                triangleVertexData[i * 6 + 5] = (float)hdLineTriangleList[i].polygonPts[2].northing;
            }

            GL.BufferData(BufferTarget.ArrayBuffer, triangleVertexData.Length * sizeof(float), triangleVertexData, BufferUsageHint.StaticDraw);

            vbo_HeadTrianglesCount = hdLineTriangleList.Count * 3;
        }

        public void DeleteHeadLineVertexArray()
        {
            if (vbo_HeadTriangles != -1)
            {
                GL.DeleteBuffer(vbo_HeadTriangles);
                vbo_HeadTriangles = -1; // Set the handle to -1 (null/invalid) after deletion
            }
        }
    }
}