using System;
using System.Collections.Generic;

namespace Twol
{
    public class CGuidance
    {
        private readonly FormGPS mf;

        public int A, B;

        //private int rA, rB;

        public double distanceFromCurrentLine, distanceFromCurrentLineTool;
        public double steerAngle;

        public vec2 goalPoint = new vec2();

        public double rEastTrk, rNorthTrk, rTimeTrk, manualUturnHeading;

        public double inty, xTrackSteerCorrection = 0;
        public double steerHeadingError, steerHeadingErrorDegrees;

        public double distSteerError, lastDistSteerError, derivativeDistError;

        public double pivotDistanceError;

        //derivative counters
        private int counter2;

        // Should we find the global nearest curve point (instead of local) on the next search.
        public bool isFindGlobalNearestTrackPoint = true;

        //passive tool steer trigger
        public bool isPassiveTriggered = false, isPassiveSteering = false;

        public int currentLocationIndex;
        public double pivotDistanceErrorLast, pivotDerivative;
        private double segK = 0, bob = 0, bobAvg = 0;


        public CGuidance(FormGPS _f)
        {
            //constructor
            mf = _f;
        }

        public void Guidance(vec3 pivot, vec3 steer, bool Uturn, List<vec3> curList)
        {
            bool completeUturn = !Uturn;
            var vec2point = new vec2(Settings.Vehicle.setVehicle_isStanleyUsed ? steer : pivot);
            
            if (Settings.Tool.setToolSteer.isGPSToolActive)
            {
                //Tool GPS
                if (FindClosestSegment(curList, false, mf.pnTool.fix, out A, out B))
                {
                    distanceFromCurrentLineTool = FindDistanceToSegment(mf.pnTool.fix, curList[A], curList[B], out _, out _, true, false, false);

                    if (!Uturn && !mf.trk.isHeadingSameWay)
                        distanceFromCurrentLineTool *= -1.0;
                }
                else
                    distanceFromCurrentLineTool = 0;

                mf.trk.currentPassiveTrack?.Clear();
            }

            if (mf.gyd.FindClosestSegment(curList, false, vec2point, out A, out B))
            {
                distanceFromCurrentLine = FindDistanceToSegment(vec2point, curList[A], curList[B], out vec3 point, out double time, true, false, false);

                if (Uturn)
                {
                    //the number in the cancel uturn button on display
                    mf.yt.onA = 0;
                    for (int k = 0; k < A; k++)
                    {
                        mf.yt.onA += glm.Distance(curList[k], curList[k + 1]);
                    }

                    mf.yt.onA += glm.Distance(curList[A], point);
                    if (!mf.yt.isGoingStraightThrough && mf.yt.onA > mf.yt.totalUTurnLength * 0.5 || (!mf.yt.isGoingStraightThrough && mf.yt.uTurnStyle == 1 && mf.yt.onA > mf.yt.totalUTurnLength - 50))
                    {
                        mf.yt.NextPath();
                    }
                    //return and reset if too far away or end of the line
                    if (B >= curList.Count - 1 || (mf.yt.uTurnStyle == 1 && mf.isReverse) || distanceFromCurrentLine > 3)
                    {
                        completeUturn = true;
                    }
                }
                else
                    currentLocationIndex = A;

                if (!Uturn && !mf.trk.isHeadingSameWay)
                    //segCurv *= -1;
                    distanceFromCurrentLine *= -1;

                rEastTrk = point.easting;
                rNorthTrk = point.northing;
                rTimeTrk = A + time;

                double abHeading = Math.Atan2(curList[B].easting - curList[A].easting, curList[B].northing - curList[A].northing);
                if (abHeading < 0) abHeading += glm.twoPI;

                manualUturnHeading = abHeading;

                #region Stanley

                if (Settings.Vehicle.setVehicle_isStanleyUsed)//Stanley
                {

                    //distance is negative if on left, positive if on right
                    steerHeadingError = steer.heading - abHeading + (Uturn || mf.trk.isHeadingSameWay ? 0 : Math.PI);

                    //Fix the circular error
                    if (steerHeadingError > Math.PI) steerHeadingError -= glm.twoPI;
                    else if (steerHeadingError < -Math.PI) steerHeadingError += glm.twoPI;

                    if (mf.isReverse) steerHeadingError *= -1;
                    //Overshoot setting on Stanley tab
                    steerHeadingError *= mf.vehicle.stanleyHeadingErrorGain;
                    if (Uturn)
                        steerHeadingError *= mf.vehicle.uturnCompensation;

                    double sped = Math.Abs(mf.avgSpeed);
                    if (sped > 1) sped = 1 + 0.277 * (sped - 1);
                    else sped = 1;
                    double XTEc = Math.Atan((distanceFromCurrentLine * mf.vehicle.stanleyDistanceErrorGain)
                        / (sped));

                    xTrackSteerCorrection = (xTrackSteerCorrection * 0.5) + XTEc * (0.5);

                    ////derivative of steer distance error
                    //distSteerError = (distSteerError * 0.95) + ((xTrackSteerCorrection * 60) * 0.05);
                    //if (counter++ > 5)
                    //{
                    //    derivativeDistError = distSteerError - lastDistSteerError;
                    //    lastDistSteerError = distSteerError;
                    //    counter = 0;
                    //}

                    steerAngle = glm.toDegrees((xTrackSteerCorrection + steerHeadingError) * -1.0);

                    if (Math.Abs(distanceFromCurrentLine) > 0.5) steerAngle *= 0.5;
                    else steerAngle *= (1 - Math.Abs(distanceFromCurrentLine));

                    ////Tool GPS
                    //if (Settings.Tool.setToolSteer.isGPSToolActive && mf.gyd.FindClosestSegment(curList, false, mf.pnTool.fix, out A, out B))
                    //{
                    //    distanceFromCurrentLineTool = FindDistanceToSegment(mf.pnTool.fix, curList[A], curList[B], out _, out _, true, false, false);

                    //    if (!Uturn && !mf.trk.isHeadingSameWay)
                    //        distanceFromCurrentLineTool *= -1.0;
                    //}
                    //else
                    //    distanceFromCurrentLineTool = 0;
                }

                #endregion Stanley

                #region PurePursuit

                else// Pure Pursuit ------------------------------------------
                {
                    //integral slider is set to 0
                    if (mf.vehicle.purePursuitIntegralGain != 0 && !mf.isReverse)
                    {
                        pivotDistanceError = distanceFromCurrentLine * 0.2 + pivotDistanceError * 0.8;

                        if (counter2++ > 4)
                        {
                            pivotDerivative = pivotDistanceError - pivotDistanceErrorLast;
                            pivotDistanceErrorLast = pivotDistanceError;
                            counter2 = 0;
                            pivotDerivative *= 2;
                        }

                        if (mf.isBtnAutoSteerOn && mf.avgSpeed > 2.5 && Math.Abs(pivotDerivative) < 0.1 && !Uturn)
                        {
                            //if over the line heading wrong way, rapidly decrease integral
                            if ((inty < 0 && distanceFromCurrentLine < 0) || (inty > 0 && distanceFromCurrentLine > 0))
                            {
                                inty += pivotDistanceError * mf.vehicle.purePursuitIntegralGain * -0.04;
                            }
                            else
                            {
                                if (Math.Abs(distanceFromCurrentLine) > 0.02)
                                {
                                    inty += pivotDistanceError * mf.vehicle.purePursuitIntegralGain * -0.02;
                                    if (inty > 0.2) inty = 0.2;
                                    else if (inty < -0.2) inty = -0.2;
                                }
                            }
                        }
                        else inty *= 0.95;
                    }
                    else inty = 0;

                    double goalPointDistance = mf.vehicle.UpdateGoalPointDistance();

                    bool CountUp = Uturn ? !mf.isReverse : (mf.isReverse ? !mf.trk.isHeadingSameWay : mf.trk.isHeadingSameWay);

                    if (A == 0 && !CountUp && time < 0)//extend end of line
                    {
                        goalPoint.northing = rNorthTrk - (Math.Cos(abHeading) * goalPointDistance);
                        goalPoint.easting = rEastTrk - (Math.Sin(abHeading) * goalPointDistance);
                    }
                    else if (B == curList.Count - 1 && CountUp && time > 1)//extend end of line
                    {
                        goalPoint.northing = rNorthTrk + (Math.Cos(abHeading) * goalPointDistance);
                        goalPoint.easting = rEastTrk + (Math.Sin(abHeading) * goalPointDistance);
                        completeUturn = true;
                    }
                    else
                    {
                        int count = CountUp ? 1 : -1;
                        vec3 start = new vec3(rEastTrk, rNorthTrk, 0);
                        double distSoFar = 0;
                        bool loop = false;

                        for (int i = CountUp ? B : A; i < curList.Count && i >= 0;)
                        {
                            // used for calculating the length squared of next segment.
                            double tempDist = glm.Distance(start, curList[i]);

                            //will we go too far?
                            if ((tempDist + distSoFar) > goalPointDistance)
                            {
                                double j = (goalPointDistance - distSoFar) / tempDist; // the remainder to yet travel

                                goalPoint.easting = (((1 - j) * start.easting) + (j * curList[i].easting));
                                goalPoint.northing = (((1 - j) * start.northing) + (j * curList[i].northing));

                                break;
                            }
                            else distSoFar += tempDist;
                            start = curList[i];
                            i += count;
                            
                            if (i < 0)
                            {
                                if (!loop)
                                {
                                    double j = goalPointDistance - distSoFar;
                                    double head = Math.Atan2(curList[i + 2].easting - curList[i + 1].easting, curList[i + 2].northing - curList[i + 1].northing);
                                    goalPoint.northing = start.northing - (Math.Cos(head) * j);
                                    goalPoint.easting = start.easting - (Math.Sin(head) * j);
                                    break;
                                }
                                else
                                    i = curList.Count - 1;
                            }
                            if (i > curList.Count - 1)
                            {
                                if (Uturn || !loop)
                                {
                                    double j = goalPointDistance - distSoFar;
                                    double head = Math.Atan2(curList[i - 1].easting - curList[i - 2].easting, curList[i - 1].northing - curList[i - 2].northing);
                                    goalPoint.northing = start.northing + (Math.Cos(head) * j);
                                    goalPoint.easting = start.easting + (Math.Sin(head) * j);

                                    //goalPointDistance is longer than remaining u-turn
                                    completeUturn = true;

                                    break;
                                }
                                else
                                    i = 0;
                            }
                        }
                    }

                    if (isPassiveSteering && distanceFromCurrentLineTool != 0 && !Settings.Tool.setToolSteer.isActiveSteering)
                    {
                        bob = distanceFromCurrentLineTool;

                        if (!mf.trk.isHeadingSameWay)
                        {
                            bob *= -1.0;
                        }

                        if (bob > 0.5) bob = 0.5;
                        else if (bob < -0.5) bob = -0.5;
                    }

                    else
                    {
                        bob = 0;
                        bobAvg = 0;
                    }

                    vec3 p1 = curList[A];
                    vec3 p2 = curList[B];

                    double d = glm.Distance(p1, p2);

                    double theta = p2.heading - p1.heading;
                    if (theta > Math.PI)
                        theta -= Math.PI;
                    else if (theta < -Math.PI)
                        theta += Math.PI;

                    if (theta > glm.PIBy2)
                        theta -= Math.PI;
                    else if (theta < -glm.PIBy2)
                        theta += Math.PI;

                    double segCurv = ((2 * Math.Sin(theta / 2)) / -d) * Settings.Tool.setToolSteer.curvatureGain;
                    if (segCurv > 2.0)
                        segCurv = 2.0;
                    if (segCurv < -2.0)
                        segCurv = -2.0;

                    segK = 0.9 * segK + 0.1 * segCurv;

                    double gain = (Math.Abs(bob) - 0.5);
                    gain = 0.5 + gain;
                    gain *= (0.004 + Settings.Tool.setToolSteer.passiveIntegralGain);

                    if (bob < 0) bobAvg -= gain;
                    else bobAvg += gain;
                    //bobAvg += (0.01 * bob);                    

                    if (bobAvg > 0.5)
                        bobAvg = 0.5;
                    if (bobAvg < -0.5)
                        bobAvg = -0.5;

                    double dist = (segK- bobAvg);
                    if (dist > 2.0)
                        dist = 2.0;
                    if (dist < -2.0)
                        dist = -2.0;

                    if (Uturn)
                    {
                        bobAvg = 0;
                        dist = 0;
                        segCurv = 0;
                        isPassiveSteering = false;
                    }

                    goalPoint.easting += (Math.Sin(curList[B].heading + 1.57) * dist);
                    goalPoint.northing += (Math.Cos(curList[B].heading + 1.57) * dist);

                    //calc "D" the distance from pivot axle to lookahead point
                    double goalPointDistanceSquared = glm.DistanceSquared(goalPoint, pivot);

                    //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                    double localHeading = -mf.fixHeading + inty;

                    //ppRadius = goalPointDistanceSquared / (2 * (((goalPoint.easting - pivot.easting) * Math.Cos(localHeading)) + ((goalPoint.northing - pivot.northing) * Math.Sin(localHeading))));

                    steerAngle = glm.toDegrees(Math.Atan(2 * (((goalPoint.easting - pivot.easting) * Math.Cos(localHeading))
                        + ((goalPoint.northing - pivot.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                    if (Uturn)
                        steerAngle *= mf.vehicle.uturnCompensation;

                    double steerHeadingError = pivot.heading - Math.Atan2(curList[B].easting - curList[A].easting, curList[B].northing - curList[A].northing);
                    //Fix the circular error
                    if (steerHeadingError > Math.PI)
                        steerHeadingError -= Math.PI;
                    else if (steerHeadingError < -Math.PI)
                        steerHeadingError += Math.PI;

                    if (steerHeadingError > glm.PIBy2)
                        steerHeadingError -= Math.PI;
                    else if (steerHeadingError < -glm.PIBy2)
                        steerHeadingError += Math.PI;

                    mf.vehicle.modeActualHeadingError = glm.toDegrees(steerHeadingError);

                    if (!isPassiveSteering && isPassiveTriggered)
                    {
                        if (Math.Abs(mf.vehicle.modeActualHeadingError) < 1.5
                            && Math.Abs(distanceFromCurrentLine) < 0.10 && Math.Abs(distanceFromCurrentLineTool) < 0.20)
                            isPassiveSteering = true;
                    }
                }

                #endregion PurePursuit

                if (!Uturn && mf.ahrs.imuRoll != 88888)
                    steerAngle += mf.ahrs.imuRoll * -Settings.Vehicle.setAS_sideHillComp;

                if (steerAngle < -mf.vehicle.maxSteerAngle) steerAngle = -mf.vehicle.maxSteerAngle;
                if (steerAngle > mf.vehicle.maxSteerAngle) steerAngle = mf.vehicle.maxSteerAngle;

                //used for acquire/hold mode
                //used for smooth mode
                mf.vehicle.modeActualXTE = distanceFromCurrentLine;
                mf.guidanceLineDistanceOff = distanceFromCurrentLine;
                mf.guidanceLineSteerAngle = steerAngle;
            }
            else
            {
                //invalid distance so tell AS module
                distanceFromCurrentLine = 0;
                mf.guidanceLineDistanceOff = double.NaN;
                distanceFromCurrentLineTool = 0;
                completeUturn = true;
            }
            if (Uturn && completeUturn)
                mf.yt.CompleteYouTurn();
        }

        public bool FindClosestSegment(List<vec3> points, bool loop, vec2 point, out int AA, out int BB, int start = 0, int end = int.MaxValue)
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

        public double FindDistanceToSegment(vec2 pt, vec3 p1, vec3 p2, out vec3 point, out double Time, bool signed = false, bool aa = true, bool bb = true)
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

        public int FindGlobalRoughNearest(vec2 pivot, List<vec3> points, int step, bool force)
        {
            if (force || isFindGlobalNearestTrackPoint)
            {
                currentLocationIndex = 0;
                double minDistA = double.MaxValue;
                for (int j = 0; j < points.Count; j += step)
                {
                    double dist = glm.DistanceSquared(pivot, points[j]);
                    if (dist < minDistA)
                    {
                        minDistA = dist;
                        currentLocationIndex = j;
                    }
                }
                isFindGlobalNearestTrackPoint = false;
            }

            return currentLocationIndex;
        }
    }

    public static class ChaikinSmoothing
    {
        /// <summary>
        /// Applies Chaikin's corner-cutting algorithm to smooth a polyline.
        /// </summary>
        /// <param name="points">The original list of points (polyline).</param>
        /// <param name="iterations">The number of smoothing iterations to apply.</param>
        /// <param name="preserveEndPoints">Whether to keep the start and end points in their original positions.</param>
        /// <returns>A new list of smoothed points.</returns>
        public static List<vec3> Smooth(List<vec3> points, int iterations, bool preserveEndPoints = true)
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
                // If the user wants a closed polygon, the last R point implicitly connects to the first Q point.
                // A separate implementation is needed for perfect closed-loop handling by wrapping indices (not shown here).

                currentPoints = nextPoints;
            }

            return currentPoints;
        }
    }
}