using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Twol
{
    public class CBoundaryList
    {
        public List<vec3> fenceLine = new List<vec3>(128);
        public List<vec2> fenceLineEar = new List<vec2>(128);
        public List<Triangle> fenceTriangleList = new List<Triangle>(128);

        public List<vec3> hdLine = new List<vec3>(128);
        public List<Triangle> hdLineTriangleList = new List<Triangle>(128);

        public List<vec3> turnLine = new List<vec3>(128);

        //public CPolygon bndPolygon = new CPolygon();
        //public CPolygon hdLinePolygon = new CPolygon();

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
            fenceTriangleList = bndPolygon.Triangulate();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboIndex);

            double[] triangleVertexData = new double[fenceTriangleList.Count * 6];

            for (int i = 0; i < fenceTriangleList.Count; i++)
            {
                // Assuming Triangle has properties or fields: A, B, C of type vec3 with .x, .y, .z
                triangleVertexData[i * 6 + 0] = fenceTriangleList[i].polygonPts[0].easting;
                triangleVertexData[i * 6 + 1] = fenceTriangleList[i].polygonPts[0].northing;
                triangleVertexData[i * 6 + 2] = fenceTriangleList[i].polygonPts[1].easting;
                triangleVertexData[i * 6 + 3] = fenceTriangleList[i].polygonPts[1].northing;
                triangleVertexData[i * 6 + 4] = fenceTriangleList[i].polygonPts[2].easting;
                triangleVertexData[i * 6 + 5] = fenceTriangleList[i].polygonPts[2].northing;
            }

            GL.BufferData(BufferTarget.ArrayBuffer, triangleVertexData.Length * sizeof(double), triangleVertexData, BufferUsageHint.StaticDraw);

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
    }
}