using Clipper2Lib;
using System;
using System.Collections.Generic;

namespace Twol
{
    public static class TrackMethods
    {
        public static void CalculateAverageHeadings(this List<vec3> points, bool loop)
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = points.Count;

            if (cnt > 1)
            {
                vec3[] arr = new vec3[cnt];
                cnt--;
                points.CopyTo(arr);
                points.Clear();

                //first point needs last, first, second points
                vec3 pt3 = arr[0];
                if (loop)
                    pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
                else
                    pt3.heading = Math.Atan2(arr[1].easting - arr[0].easting, arr[1].northing - arr[0].northing);

                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                points.Add(pt3);

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    points.Add(pt3);
                }

                //last and first point
                pt3 = arr[cnt];
                if (loop)
                    pt3.heading = Math.Atan2(arr[0].easting - arr[cnt - 1].easting, arr[0].northing - arr[cnt - 1].northing);
                else
                    pt3.heading = Math.Atan2(arr[cnt].easting - arr[cnt - 1].easting, arr[cnt].northing - arr[cnt - 1].northing);

                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                points.Add(pt3);
            }
        }

        public static void CalculateSingleHeadings(this List<vec3> points, bool loop)
        {
            //to calc heading based on next point.
            int cnt = points.Count;

            if (cnt > 1)
            {
                vec3[] arr = new vec3[cnt];
                cnt--;
                points.CopyTo(arr);
                points.Clear();

                //first point needs last, first, second points
                vec3 pt3 = arr[0];
                if (loop)
                    pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
                else
                    pt3.heading = Math.Atan2(arr[1].easting - arr[0].easting, arr[1].northing - arr[0].northing);

                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                points.Add(pt3);

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    points.Add(pt3);
                }

                //last and first point
                pt3 = arr[cnt];
                if (loop)
                    pt3.heading = Math.Atan2(arr[0].easting - arr[cnt - 1].easting, arr[0].northing - arr[cnt - 1].northing);
                else
                    pt3.heading = Math.Atan2(arr[cnt].easting - arr[cnt - 1].easting, arr[cnt].northing - arr[cnt - 1].northing);

                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                points.Add(pt3);
            }
        }

        public static void GenerateEquidistantPoints(this List<vec3> points, double spacing, bool isLoop)
        {
            var result = new List<vec3>();
            const double eps = 1e-9;

            if (points == null || points.Count == 0) return;
            if (spacing <= 0) return;
            if (points.Count == 1) return;

            int n = points.Count;

            // build segment lengths and cumulative distances
            List<double> segLen = new List<double>();
            List<double> cumul = new List<double> { 0.0 };

            double total = 0.0;
            for (int i = 0; i < n - 1; i++)
            {
                double d = glm.Distance(points[i], points[i + 1]);
                segLen.Add(d);
                total += d;
                cumul.Add(total);
            }

            if (isLoop)
            {
                double d = glm.Distance(points[n - 1], points[0]);
                segLen.Add(d);
                total += d;
                cumul.Add(total);
            }

            // nothing to sample if tiny total length
            if (total < eps)
            {
                return;
            }

            // Add the first point
            result.Add(new vec3(points[0]));

            // sample points at multiples of spacing
            double tDist = spacing;
            while (tDist < total - eps)
            {
                // find segment index where cumul[idx] < tDist <= cumul[idx+1]
                int segIndex = -1;
                int segCount = segLen.Count;
                for (int i = 0; i < segCount; i++)
                {
                    if (tDist <= cumul[i + 1] + eps)
                    {
                        segIndex = i;
                        break;
                    }
                }
                if (segIndex == -1)
                {
                    // fallback: place at end
                    if (!isLoop)
                    {
                        result.Add(new vec3(points[n - 1]));
                    }
                    break;
                }

                double segStartDist = cumul[segIndex];
                double local = tDist - segStartDist;
                double thisSegLen = segLen[segIndex];
                double frac = thisSegLen < eps ? 0.0 : (local / thisSegLen);

                // determine segment endpoints (wrap for loop)
                vec3 a = points[segIndex];
                vec3 b = (segIndex + 1 < n) ? points[segIndex + 1] : points[0];

                double x = a.easting + (b.easting - a.easting) * frac;
                double y = a.northing + (b.northing - a.northing) * frac;

                result.Add(new vec3(x, y, 0));

                tDist += spacing;
            }

            // For open polyline ensure last point present
            if (!isLoop)
            {
                vec3 last = points[n - 1];
                if (result.Count == 0 || glm.Distance(result[result.Count - 1], last) > 1e-6)
                    result.Add(new vec3(last));
            }

            points.Clear();
            points.AddRange(result);
        }

        public static void ReducePointsByAngle(this List<vec3> points, double angleDelta = 0.005, double spread = 30)
        {
            double delta = 0;
            int cont = points.Count;
            vec3[] smList = new vec3[cont];
            cont--;
            points.CopyTo(smList);
            points.Clear();
            int counter = 0;
            double check;

            for (int i = 0; i < cont; i++)
            {
                if (i < 2 || i > cont - 3)
                {
                    points.Add(new vec3(smList[i]));
                    continue;
                }
                check = (smList[i - 1].heading - smList[i].heading);
                if (check > Math.PI || check < -Math.PI)
                {
                    if (check > 0) check -= glm.twoPI;
                    else check += glm.twoPI;
                }
                delta += check;
                if (Math.Abs(delta) > angleDelta || counter > spread)
                {
                    points.Add(new vec3(smList[i]));
                    delta = 0;
                    counter = 0;
                }
                counter++;
            }
        }

        public static List<vec2> ReducePointsByAngleToVec2(this List<vec3> points, double angleDelta = 0.02, double spread = 30)
        {
            List<vec2> smList = new List<vec2>();

            double delta = 0;
            int cont = points.Count;
            cont--;
            int counter = 0;
            double check;

            for (int i = 0; i < cont; i++)
            {
                if (i < 2 || i > cont - 3)
                {
                    smList.Add(new vec2(points[i].easting, points[i].northing));
                    continue;
                }
                check = (points[i - 1].heading - points[i].heading);
                if (check > Math.PI || check < -Math.PI)
                {
                    if (check > 0) check -= glm.twoPI;
                    else check += glm.twoPI;
                }
                delta += check;
                if (Math.Abs(delta) > angleDelta || counter > spread)
                {
                    smList.Add(new vec2(points[i].easting, points[i].northing));
                    delta = 0;
                    counter = 0;
                }
                counter++;
            }

            return smList;
        }

        public static void MinimumSpacingPointRemoval(this List<vec3> points, double spacing = 1)
        {
            //make sure distance isn't too small between points on headland
            spacing *= spacing;
            int ptCount = points.Count;

            for (int i = 0; i < ptCount - 1; i++)
            {
                double distance = glm.DistanceSquared(points[i], points[i + 1]);
                if (distance < spacing)
                {
                    points.RemoveAt(i + 1);
                    ptCount = points.Count;
                    i--;
                }
            }
        }

        public static List<vec3> OffsetLine(this List<vec3> points, double distance, double minDist, bool loop)
        {
            points.CalculateAverageHeadings(loop);

            var result = new List<vec3>();
            //countExit the points from the boundary
            int count = points.Count;

            double distSq = distance * distance - 0.0001;

            //make the boundary tram outer array
            for (int i = 0; i < count; i++)
            {
                //calculate the point inside the boundary
                var easting = points[i].easting + (Math.Cos(points[i].heading) * distance);
                var northing = points[i].northing - (Math.Sin(points[i].heading) * distance);

                bool Add = true;

                for (int j = 0; j < count; j++)
                {
                    double check = glm.DistanceSquared(northing, easting, points[j].northing, points[j].easting);
                    if (check < distSq)
                    {
                        Add = false;
                        break;
                    }
                }

                if (Add)
                {
                    if (result.Count > 0)
                    {
                        double dist = glm.DistanceSquared(northing, easting, result[result.Count - 1].northing, result[result.Count - 1].easting);
                        if (dist > minDist)
                            result.Add(new vec3(easting, northing));
                    }
                    else
                        result.Add(new vec3(easting, northing));
                }
            }

            return result;
        }

        public static List<vec3> ClipperOffsetPolygon(this List<vec3> points, double distAway)
        {
            List<vec3> outputPts = new List<vec3>();

            //convert to Clipper path
            Path64 path = new Path64(points.Count);

            for (int i = 0; i < points.Count; i++)
            {
                path.Add(new Point64(points[i].easting * 10000, points[i].northing * 10000));
            }

            bool isPos = Clipper.IsPositive(path);

            ClipperOffset co = new ClipperOffset();
            co.ReverseSolution = true;
            co.AddPath(path, JoinType.Round, EndType.Polygon);

            Paths64 solution = new Paths64();

            co.Execute(distAway * -10000, solution);

            if (solution.Count > 0)
            {
                //convert back to vec3 list
                for (int i = solution[0].Count - 1; i >= 0; i--)
                {
                    outputPts.Add(new vec3((solution[0][i].X / 10000.0), (solution[0][i].Y / 10000.0), 0));
                }
            }

            //outputPts.GenerateEquidistantPoints(2, true);

            //outputPts.ChaikinsSmooth(2, true);

            outputPts.CalculateAverageHeadings(true);

            outputPts.ReducePointsByAngle(0.005);

            outputPts.CalculateAverageHeadings(true);

            return outputPts;
        }

        public static List<vec3> ClipperOffsetPolyline(this List<vec3> points, double distAway, vec2 steer)
        {
            List<vec3> outPts = new List<vec3>();

            //convert to Clipper path
            Path64 path = new Path64(points.Count + 2);

            vec3 pt = new vec3(points[0].easting, points[0].northing);
            pt.easting -= (Math.Sin(points[0].heading) * 3000);
            pt.northing -= (Math.Cos(points[0].heading) * 3000);
            path.Add(new Point64(pt.easting * 10000, pt.northing * 10000));

            for (int i = 0; i < points.Count; i++)
            {
                path.Add(new Point64(points[i].easting * 10000, points[i].northing * 10000));
            }

            pt = new vec3(points[points.Count - 1].easting, points[points.Count - 1].northing);
            pt.easting += (Math.Sin(points[points.Count - 1].heading) * 3000);
            pt.northing += (Math.Cos(points[points.Count - 1].heading) * 3000);
            path.Add(new Point64(pt.easting * 10000, pt.northing * 10000));

            bool isPos = Clipper.IsPositive(path);

            ClipperOffset co = new ClipperOffset();

            if (distAway >= 0)
                co.ReverseSolution = true;

            co.AddPath(path, JoinType.Round, EndType.Round);

            Paths64 solution = new Paths64();

            co.Execute(distAway * 10000, solution);

            if (solution.Count > 0)
            {
                //convert back to vec3 list
                for (int i = solution[0].Count - 1; i >= 0; i--)
                {
                    outPts.Add(new vec3((solution[0][i].X / 10000.0), (solution[0][i].Y / 10000.0), 0));
                }
            }


            double dist;
            int AA = -1;
            double minDistA = double.MaxValue;
            for (int A = 0; A < outPts.Count - 1; A++)
            {
                dist = FindDistanceToSegment(steer, outPts[A], outPts[A + 1], out _, out _);

                if (dist < minDistA)
                {
                    minDistA = dist;
                    AA = A;
                }
            }


            dist = FindDistanceToSegment(steer, outPts[AA], outPts[AA + 1], out _, out _, true);

            //outPts.GenerateEquidistantPoints(4, false);  
            //outPts.ReducePointsByAngle(0.01, 400);
            //outPts.CalculateAverageHeadings(false);

            List<vec3> pts = new List<vec3>();

            if (AA == 0) AA = outPts.Count - 1;

            for (int i = AA; i >= 0;)
            {
                if (Math.Abs(outPts[i].easting) < 1500 && Math.Abs(outPts[i].northing) < 1500)
                {
                    i--;
                    if (i < 0) i = outPts.Count - 1;
                }
                else
                {
                    AA = i;
                    break;
                }
            }

            minDistA = 0;

            AA++;
            if (AA >= outPts.Count) AA = 0;


            for (int i = AA; i < outPts.Count - 1;)
            {
                if (Math.Abs(outPts[i].easting) < 3000 && Math.Abs(outPts[i].northing) < 3000)
                {
                    pts.Add(new vec3(outPts[i]));
                    i++;
                    if (i >= outPts.Count) i = 0;
                }
                else
                {
                    break;
                }
            }

            //pts.MinimumSpacingPointRemoval(1);

            //return outPts;
            pts.GenerateEquidistantPoints(2, false);

            //pts.ChaikinsSmooth(2, false);

            pts.CalculateAverageHeadings(false);
            pts.ReducePointsByAngle(0.005, 30);

            return pts;
        }

        public static List<vec3> ClipperOffsetCenterGuidance(this List<vec3> points, double distAway, vec2 lookPos, bool isZeroAway)
        {
            List<vec3> outPts = new List<vec3>();

            //convert to Clipper path
            Path64 path = new Path64(points.Count + 2);

            vec3 pt = new vec3(points[0].easting, points[0].northing);
            pt.easting -= (Math.Sin(points[0].heading) * 3000);
            pt.northing -= (Math.Cos(points[0].heading) * 3000);
            path.Add(new Point64(pt.easting * 10000, pt.northing * 10000));

            for (int i = 0; i < points.Count; i++)
            {
                path.Add(new Point64(points[i].easting * 10000, points[i].northing * 10000));
            }

            pt = new vec3(points[points.Count - 1].easting, points[points.Count - 1].northing);
            pt.easting += (Math.Sin(points[points.Count - 1].heading) * 3000);
            pt.northing += (Math.Cos(points[points.Count - 1].heading) * 3000);
            path.Add(new Point64(pt.easting * 10000, pt.northing * 10000));

            bool isPos = Clipper.IsPositive(path);

            ClipperOffset co = new ClipperOffset();

            if (distAway >= 0)
                co.ReverseSolution = true;

            co.AddPath(path, JoinType.Round, EndType.Round);

            Paths64 solution = new Paths64();

            co.Execute(distAway * 10000, solution);

            if (solution.Count > 0)
            {
                //convert back to vec3 list
                for (int i = solution[0].Count - 1; i >= 0; i--)
                {
                    outPts.Add(new vec3((solution[0][i].X / 10000.0), (solution[0][i].Y / 10000.0), 0));
                }
            }

            double dist;
            int AA = -1;
            double minDistA = double.MaxValue;
            for (int A = 0; A < outPts.Count - 1; A++)
            {
                dist = FindDistanceToSegment(lookPos, outPts[A], outPts[A + 1], out _, out _);

                if (dist < minDistA)
                {
                    minDistA = dist;
                    AA = A;
                }
            }


            dist = FindDistanceToSegment(lookPos, outPts[AA], outPts[AA + 1], out _, out _, true);

            //outPts.GenerateEquidistantPoints(4, false);  
            //outPts.ReducePointsByAngle(0.01, 400);
            //outPts.CalculateAverageHeadings(false);

            List<vec3> pts = new List<vec3>();

            if (AA == 0) AA = outPts.Count - 1;

            for (int i = AA; i >= 0;)
            {
                if (Math.Abs(outPts[i].easting) < 1500 && Math.Abs(outPts[i].northing) < 1500)
                {
                    i--;
                    if (i < 0) i = outPts.Count - 1;
                }
                else
                {
                    AA = i;
                    break;
                }
            }

            minDistA = 0;

            AA++;
            if (AA >= outPts.Count) AA = 0;


            for (int i = AA; i < outPts.Count - 1;)
            {
                if (Math.Abs(outPts[i].easting) < 3000 && Math.Abs(outPts[i].northing) < 3000)
                {
                    pts.Add(new vec3(outPts[i]));
                    i++;
                    if (i >= outPts.Count) i = 0;
                }
                else
                {
                    break;
                }
            }

            //pts.MinimumSpacingPointRemoval(1);
            if (isZeroAway)
            {
                pts.Reverse();
                pts.CalculateAverageHeadings(false);
            }

            //return outPts;
            pts.GenerateEquidistantPoints(2, false);

            //pts.ChaikinsSmooth(2, false);

            pts.CalculateAverageHeadings(false);
            pts.ReducePointsByAngle(0.005, 30);

            return pts;
        }

        public static bool FindClosestSegment(List<vec3> points, bool loop, vec2 point, out int AA, out int BB, int start = 0, int end = int.MaxValue)
        {
            AA = -1;
            BB = -1;
            double minDistA = double.MaxValue;
            int A = -1;
            if (start < 0) start = 0;
            else A = start - 1;

            for (int B = start; B < points.Count && B < end; A = B++)
            {
                if (B == 0)
                {
                    if (!loop)
                        continue;
                    A = points.Count - 1;
                }

                double dist = FindDistanceToSegment(point, points[A], points[B], out _, out _);

                if (dist < minDistA)
                {
                    minDistA = dist;
                    AA = A;
                    BB = B;
                }
            }
            return AA >= 0;
        }

        public static double FindDistanceToSegment(vec2 pt, vec3 p1, vec3 p2, out vec3 point, out double Time, bool signed = false, bool aa = true, bool bb = true)
        {
            double dx = p2.northing - p1.northing;
            double dy = p2.easting - p1.easting;

            if (Math.Abs(dx) < double.Epsilon && Math.Abs(dy) < double.Epsilon)
            {
                Time = 0;
                dx = pt.northing - p1.northing;
                dy = pt.easting - p1.easting;
                point = p1;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            Time = ((pt.northing - p1.northing) * dx + (pt.easting - p1.easting) * dy) / (dx * dx + dy * dy);

            if (aa && Time < 0)
            {
                point = p1;
                dx = pt.northing - p1.northing;
                dy = pt.easting - p1.easting;
            }
            else if (bb && Time > 1)
            {
                point = p2;
                dx = pt.northing - p2.northing;
                dy = pt.easting - p2.easting;
            }
            else
            {
                point = new vec3((p1.easting + Time * dy), (p1.northing + Time * dx), Math.Atan2(dy, dx));
                dx = pt.northing - point.northing;
                dy = pt.easting - point.easting;
            }

            if (signed)
            {
                double sign = Math.Sign((p2.northing - p1.northing) * (pt.easting - p1.easting) - (p2.easting - p1.easting) * (pt.northing - p1.northing));

                return sign * Math.Sqrt(dx * dx + dy * dy);
            }
            else
                return Math.Sqrt(dx * dx + dy * dy);
        }

        public static void AddStartEndPoints(this List<vec3> xList, int ptsToAdd = 10, double distBetweenPoints = 50)
        {
            vec3 start = new vec3(xList[0]);

            for (int i = 1; i < ptsToAdd; i++)
            {
                vec3 pt = new vec3(start);
                pt.easting -= (Math.Sin(pt.heading) * i * distBetweenPoints);
                pt.northing -= (Math.Cos(pt.heading) * i * distBetweenPoints);
                xList.Insert(0, pt);
            }

            int ptCnt = xList.Count - 1;
            for (int i = 1; i < ptsToAdd; i++)
            {
                vec3 pt = new vec3(xList[ptCnt]);
                pt.easting += (Math.Sin(pt.heading) * i * distBetweenPoints);
                pt.northing += (Math.Cos(pt.heading) * i * distBetweenPoints);
                xList.Add(pt);
            }
        }

        public static void AddStartPoints(this List<vec3> xList, int ptsToAdd = 10, double distBetweenPoints = 50)
        {
            vec3 start = new vec3(xList[0]);

            for (int i = 1; i < ptsToAdd; i++)
            {
                vec3 pt = new vec3(start);
                pt.easting -= (Math.Sin(pt.heading) * i * distBetweenPoints);
                pt.northing -= (Math.Cos(pt.heading) * i * distBetweenPoints);
                xList.Insert(0, pt);
            }
        }

        public static void AddEndPoints(this List<vec3> xList, int ptsToAdd = 10, double distBetweenPoints = 50)
        {
            int ptCnt = xList.Count - 1;
            for (int i = 1; i < ptsToAdd; i++)
            {
                vec3 pt = new vec3(xList[ptCnt]);
                pt.easting += (Math.Sin(pt.heading) * i * distBetweenPoints);
                pt.northing += (Math.Cos(pt.heading) * i * distBetweenPoints);
                xList.Add(pt);
            }
        }

        public static void SmoothSegments(this List<vec3> points, int smPts = 4)
        {
            int cnt = points.Count;
            if (cnt == 0 || smPts <= 0) return;

            vec3[] arr = new vec3[cnt];

            // copy first smPts/2 (or all, if fewer)
            for (int s = 0; s < smPts / 2 && s < cnt; s++)
            {
                arr[s].easting = points[s].easting;
                arr[s].northing = points[s].northing;
                arr[s].heading = points[s].heading;
            }

            // copy last smPts/2
            for (int s = cnt - (smPts / 2); s < cnt; s++)
            {
                arr[s].easting = points[s].easting;
                arr[s].northing = points[s].northing;
                arr[s].heading = points[s].heading;
            }

            // average middle region
            for (int i = smPts / 2; i < cnt - (smPts / 2); i++)
            {
                double sumEast = 0;
                double sumNorth = 0;

                for (int j = -smPts / 2; j < smPts / 2; j++)
                {
                    int idx = i + j;
                    if (idx < 0 || idx >= cnt) continue;

                    sumEast += points[idx].easting;
                    sumNorth += points[idx].northing;
                }

                arr[i].easting = sumEast / smPts;
                arr[i].northing = sumNorth / smPts;
                arr[i].heading = points[i].heading;
            }

            points.Clear();
            points.AddRange(arr);
        }

        public static double TrackAverageHeading(this List<vec3> points)
        {
            //calculate average heading of line
            double x = 0, y = 0;
            foreach (vec3 pt in points)
            {
                x += Math.Cos(pt.heading);
                y += Math.Sin(pt.heading);
            }
            x /= points.Count;
            y /= points.Count;

            double aveLineHeading = Math.Atan2(y, x);
            if (aveLineHeading < 0) aveLineHeading += glm.twoPI;

            return aveLineHeading;
        }

        public static void ChaikinsSmooth(this List<vec3> points, int iterations, bool preserveEndPoints = true)
        {
            List<vec3> currentPoints = new List<vec3>(points);

            for (int iter = 0; iter < iterations; iter++)
            {
                List<vec3> nextPoints = new List<vec3>();

                // Optionally preserve the start point for non-closed polylines
                if (preserveEndPoints && currentPoints.Count > 0)
                {
                    nextPoints.Add(currentPoints[0]);
                }

                for (int i = 0; i < currentPoints.Count - 1; i++)
                {
                    vec3 p0 = currentPoints[i];
                    vec3 p1 = currentPoints[i + 1];

                    // Calculate Q and R points, which are 25% and 75% along the segment
                    nextPoints.Add(new vec3(0.75f * p0.easting + 0.25f * p1.easting, 0.75f * p0.northing + 0.25f * p1.northing, 0));
                    nextPoints.Add(new vec3(0.25f * p0.easting + 0.75f * p1.easting, 0.25f * p0.northing + 0.75f * p1.northing, 0));
                }

                // Optionally preserve the end point for non-closed polylines
                if (preserveEndPoints && currentPoints.Count > 1)
                {
                    nextPoints.Add(currentPoints[currentPoints.Count - 1]);
                }

                currentPoints = nextPoints;
            }

            points?.Clear();
            points.AddRange(currentPoints);
        }
    }
}

