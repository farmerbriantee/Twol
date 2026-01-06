using System;
using System.Collections.Generic;
using Twol.Classes.Tool;

namespace Twol
{
    public class CGuidanceTool
    {
        private readonly FormGPS mf;

        public int A, B;

        public double distanceFromCurrentLineTool;

        public bool isGuidanceModeRecordNewTracks = false, isRecordingToolLine = false,
            isRecordToolLineTriggered = false;

        public bool isboundaryLine;

        public vec2 goalPoint = new vec2();

        public bool isAutoSteerBtnOn = false, isSectionsOn = false;

        // Should we find the global nearest curve point (instead of local) on the next search.
        public bool isFindGlobalNearestTrackPoint = true;

        //for direction steering of tool manually
        public int manualSteerTimer = 0;
        public bool isManualSteerRight = false, isZeroToolSteer = false;

        public CGuidanceTool(FormGPS _f)
        {
            //constructor
            mf = _f;
        }

        //in pivot follow mode - tool to vehicle pivot history
        public void GuidanceFollowPivot(vec3 pivot, vec3 steer, bool Uturn, List<vec3> curList)
        {
            if (FindClosestSegment(curList, false, mf.pnTool.fix, out A, out B))
            {
                distanceFromCurrentLineTool = FindDistanceToSegment(mf.pnTool.fix, curList[A], curList[B], out _, out _, true, false, false);
            }
            else
            {
                distanceFromCurrentLineTool = double.NaN;
            }

            mf.guidanceToolXTE = distanceFromCurrentLineTool;
        }

        // in tool line mode - record and playback of tool line
        public void GuidanceToolLineRecord(bool isUTurn)
        {
            if (isGuidanceModeRecordNewTracks && !isUTurn && !isRecordingToolLine && isSectionsOn) // && isAutoSteerBtnOn
            {
                isRecordingToolLine = true;
                // start recording a new design track
                mf.trkTool.designPtsList?.Clear();
            }

            //line complete
            if (isRecordingToolLine && (isUTurn || !isSectionsOn || !isGuidanceModeRecordNewTracks)) // && isAutoSteerBtnOn
            {
                if (mf.trkTool.designPtsList.Count > 20)
                {
                    FinishToolLineRecording();
                }

                //clean up
                isRecordingToolLine = false;
                mf.trkTool.designPtsList?.Clear();
            }
        }

        private void FinishToolLineRecording()
        {
            mf.trkTool.designPtsList.Add(new vec3(mf.toolPivotPos));

            //make a new tool track
            var track = new CTrkTool(TrackMode.toolLineInner);

            track.name = (mf.gydTool.isboundaryLine ? "Outer " : "Inner ") + mf.trkTool.tArr.Count.ToString("000");

            mf.trkTool.SmoothAB(ref mf.trkTool.designPtsList, 6, false);

            mf.trkTool.designPtsList.CalculateHeadings(false);

            double delta = 0;
            int cont = mf.trkTool.designPtsList.Count;
            vec3[] smList = new vec3[cont];
            cont--;
            mf.trkTool.designPtsList.CopyTo(smList);
            mf.trkTool.designPtsList.Clear();
            int counter = 0;
            double check;

            for (int i = 0; i < cont; i++)
            {
                if (i < 2 || i > cont - 3)
                {
                    mf.trkTool.designPtsList.Add(new vec3(smList[i]));
                    continue;
                }
                check = (smList[i - 1].heading - smList[i].heading);
                if (check > Math.PI || check < -Math.PI)
                {
                    if (check > 0) check -= glm.twoPI;
                    else check += glm.twoPI;
                }
                delta += check;
                if (Math.Abs(delta) > 0.01 || counter > 20)
                {
                    mf.trkTool.designPtsList.Add(new vec3(smList[i]));
                    delta = 0;
                    counter = 0;
                }
                counter++;
            }

            //write out the Curve Points
            foreach (vec3 item in mf.trkTool.designPtsList)
            {
                track.curvePts.Add(item);
            }

            mf.trkTool.AddEndPoints(ref track.curvePts, 4);
            mf.trkTool.AddStartPoints(ref track.curvePts, 4);

            track.ptA = new vec2(track.curvePts[0].easting, track.curvePts[0].northing);
            track.ptB = new vec2(track.curvePts[track.curvePts.Count - 1].easting, track.curvePts[track.curvePts.Count - 1].northing);

            mf.trkTool.AddTrack(track);

            mf.FileSaveToolTrack(track);
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
        //public void Guidance(vec3 pivot, vec3 steer, bool Uturn, List<vec3> curList)
        //{
        //    bool completeUturn = !Uturn;
        //    var vec2point = new vec2(Settings.Vehicle.setVehicle_isStanleyUsed ? steer : pivot);

        //    //in passive only do tool to current vehicle line
        //    if (Settings.Tool.setToolSteer.isPassiveSteering)
        //    {
        //        //Tool GPS
        //        if (FindClosestSegment(curList, false, mf.pnTool.fix, out A, out B))
        //        {
        //            distanceFromCurrentLineTool = FindDistanceToSegment(mf.pnTool.fix, curList[A], curList[B], out _, out _, true, false, false);

        //            if (!Uturn && !mf.trk.isHeadingSameWay)
        //                distanceFromCurrentLineTool *= -1.0;
        //        }
        //        else
        //            distanceFromCurrentLineTool = 0;
        //    }

        //    if (mf.gyd.FindClosestSegment(curList, false, vec2point, out A, out B))
        //    {
        //        distanceFromCurrentLine = FindDistanceToSegment(vec2point, curList[A], curList[B], out vec3 point, out double time, true, false, false);

        //        if (Uturn)
        //        {
        //            //the number in the cancel uturn button on display
        //            mf.yt.onA = 0;
        //            for (int k = 0; k < A; k++)
        //            {
        //                mf.yt.onA += glm.Distance(curList[k], curList[k + 1]);
        //            }

        //            mf.yt.onA += glm.Distance(curList[A], point);
        //            if (!mf.yt.isGoingStraightThrough && mf.yt.onA > mf.yt.totalUTurnLength * 0.5 || (!mf.yt.isGoingStraightThrough && mf.yt.uTurnStyle == 1 && mf.yt.onA > mf.yt.totalUTurnLength - 50))
        //            {
        //                mf.yt.NextPath();
        //            }
        //            //return and reset if too far away or end of the line
        //            if (B >= curList.Count - 1 || (mf.yt.uTurnStyle == 1 && mf.isReverse) || distanceFromCurrentLine > 3)
        //            {
        //                completeUturn = true;
        //            }
        //        }
        //        else
        //            currentLocationIndex = A;

        //        if (!Uturn && !mf.trk.isHeadingSameWay)
        //            //segCurv *= -1;
        //            distanceFromCurrentLine *= -1;

        //        rEastTrk = point.easting;
        //        rNorthTrk = point.northing;
        //        rTimeTrk = A + time;

        //        double abHeading = Math.Atan2(curList[B].easting - curList[A].easting, curList[B].northing - curList[A].northing);
        //        if (abHeading < 0) abHeading += glm.twoPI;

        //        manualUturnHeading = abHeading;

        //        #region Stanley

        //        if (Settings.Vehicle.setVehicle_isStanleyUsed)//Stanley
        //        {

        //            //distance is negative if on left, positive if on right
        //            steerHeadingError = steer.heading - abHeading + (Uturn || mf.trk.isHeadingSameWay ? 0 : Math.PI);

        //            //Fix the circular error
        //            if (steerHeadingError > Math.PI) steerHeadingError -= glm.twoPI;
        //            else if (steerHeadingError < -Math.PI) steerHeadingError += glm.twoPI;

        //            if (mf.isReverse) steerHeadingError *= -1;
        //            //Overshoot setting on Stanley tab
        //            steerHeadingError *= mf.vehicle.stanleyHeadingErrorGain;
        //            if (Uturn)
        //                steerHeadingError *= mf.vehicle.uturnCompensation;

        //            double sped = Math.Abs(mf.avgSpeed);
        //            if (sped > 1) sped = 1 + 0.277 * (sped - 1);
        //            else sped = 1;
        //            double XTEc = Math.Atan((distanceFromCurrentLine * mf.vehicle.stanleyDistanceErrorGain)
        //                / (sped));

        //            xTrackSteerCorrection = (xTrackSteerCorrection * 0.5) + XTEc * (0.5);

        //            ////derivative of steer distance error
        //            //distSteerError = (distSteerError * 0.95) + ((xTrackSteerCorrection * 60) * 0.05);
        //            //if (counter++ > 5)
        //            //{
        //            //    derivativeDistError = distSteerError - lastDistSteerError;
        //            //    lastDistSteerError = distSteerError;
        //            //    counter = 0;
        //            //}

        //            steerAngle = glm.toDegrees((xTrackSteerCorrection + steerHeadingError) * -1.0);

        //            if (Math.Abs(distanceFromCurrentLine) > 0.5) steerAngle *= 0.5;
        //            else steerAngle *= (1 - Math.Abs(distanceFromCurrentLine));

        //            ////Tool GPS
        //            //if (Settings.Tool.setToolSteer.isGPSToolActive && mf.gyd.FindClosestSegment(curList, false, mf.pnTool.fix, out A, out B))
        //            //{
        //            //    distanceFromCurrentLinePassiveTool = FindDistanceToSegment(mf.pnTool.fix, curList[A], curList[B], out _, out _, true, false, false);

        //            //    if (!Uturn && !mf.trk.isHeadingSameWay)
        //            //        distanceFromCurrentLinePassiveTool *= -1.0;
        //            //}
        //            //else
        //            //    distanceFromCurrentLinePassiveTool = 0;
        //        }

        //        #endregion Stanley

        //        #region PurePursuit

        //        else// Pure Pursuit ------------------------------------------
        //        {
        //            //integral slider is set to 0
        //            if (mf.vehicle.purePursuitIntegralGain != 0 && !mf.isReverse)
        //            {
        //                pivotDistanceError = distanceFromCurrentLine * 0.2 + pivotDistanceError * 0.8;

        //                if (counter2++ > 4)
        //                {
        //                    pivotDerivative = pivotDistanceError - pivotDistanceErrorLast;
        //                    pivotDistanceErrorLast = pivotDistanceError;
        //                    counter2 = 0;
        //                    pivotDerivative *= 2;
        //                }

        //                if (mf.isBtnAutoSteerOn && mf.avgSpeed > 2.5 && Math.Abs(pivotDerivative) < 0.1 && !Uturn)
        //                {
        //                    //if over the line heading wrong way, rapidly decrease integral
        //                    if ((inty < 0 && distanceFromCurrentLine < 0) || (inty > 0 && distanceFromCurrentLine > 0))
        //                    {
        //                        inty += pivotDistanceError * mf.vehicle.purePursuitIntegralGain * -0.04;
        //                    }
        //                    else
        //                    {
        //                        if (Math.Abs(distanceFromCurrentLine) > 0.02)
        //                        {
        //                            inty += pivotDistanceError * mf.vehicle.purePursuitIntegralGain * -0.02;
        //                            if (inty > 0.2) inty = 0.2;
        //                            else if (inty < -0.2) inty = -0.2;
        //                        }
        //                    }
        //                }
        //                else inty *= 0.95;
        //            }
        //            else inty = 0;

        //            double goalPointDistance = mf.vehicle.UpdateGoalPointDistance();

        //            bool CountUp = Uturn ? !mf.isReverse : (mf.isReverse ? !mf.trk.isHeadingSameWay : mf.trk.isHeadingSameWay);

        //            if (A == 0 && !CountUp && time < 0)//extend end of line
        //            {
        //                goalPoint.northing = rNorthTrk - (Math.Cos(abHeading) * goalPointDistance);
        //                goalPoint.easting = rEastTrk - (Math.Sin(abHeading) * goalPointDistance);
        //            }
        //            else if (B == curList.Count - 1 && CountUp && time > 1)//extend end of line
        //            {
        //                goalPoint.northing = rNorthTrk + (Math.Cos(abHeading) * goalPointDistance);
        //                goalPoint.easting = rEastTrk + (Math.Sin(abHeading) * goalPointDistance);
        //                completeUturn = true;
        //            }
        //            else
        //            {
        //                int count = CountUp ? 1 : -1;
        //                vec3 start = new vec3(rEastTrk, rNorthTrk, 0);
        //                double distSoFar = 0;
        //                bool loop = false;

        //                for (int i = CountUp ? B : A; i < curList.Count && i >= 0;)
        //                {
        //                    // used for calculating the length squared of next segment.
        //                    double tempDist = glm.Distance(start, curList[i]);

        //                    //will we go too far?
        //                    if ((tempDist + distSoFar) > goalPointDistance)
        //                    {
        //                        double j = (goalPointDistance - distSoFar) / tempDist; // the remainder to yet travel

        //                        goalPoint.easting = (((1 - j) * start.easting) + (j * curList[i].easting));
        //                        goalPoint.northing = (((1 - j) * start.northing) + (j * curList[i].northing));

        //                        break;
        //                    }
        //                    else distSoFar += tempDist;
        //                    start = curList[i];
        //                    i += count;

        //                    if (i < 0)
        //                    {
        //                        if (!loop)
        //                        {
        //                            double j = goalPointDistance - distSoFar;
        //                            double head = Math.Atan2(curList[i + 2].easting - curList[i + 1].easting, curList[i + 2].northing - curList[i + 1].northing);
        //                            goalPoint.northing = start.northing - (Math.Cos(head) * j);
        //                            goalPoint.easting = start.easting - (Math.Sin(head) * j);
        //                            break;
        //                        }
        //                        else
        //                            i = curList.Count - 1;
        //                    }
        //                    if (i > curList.Count - 1)
        //                    {
        //                        if (Uturn || !loop)
        //                        {
        //                            double j = goalPointDistance - distSoFar;
        //                            double head = Math.Atan2(curList[i - 1].easting - curList[i - 2].easting, curList[i - 1].northing - curList[i - 2].northing);
        //                            goalPoint.northing = start.northing + (Math.Cos(head) * j);
        //                            goalPoint.easting = start.easting + (Math.Sin(head) * j);

        //                            //goalPointDistance is longer than remaining u-turn
        //                            completeUturn = true;

        //                            break;
        //                        }
        //                        else
        //                            i = 0;
        //                    }
        //                }
        //            }

        //            if (Settings.Tool.setToolSteer.isPassiveSteering && isPassiveSteeringFlag && distanceFromCurrentLineTool != 0)
        //            {
        //                bob = distanceFromCurrentLineTool;

        //                if (!mf.trk.isHeadingSameWay)
        //                {
        //                    bob *= -1.0;
        //                }

        //                if (bob > 0.5) bob = 0.5;
        //                else if (bob < -0.5) bob = -0.5;
        //            }

        //            else
        //            {
        //                bob = 0;
        //                bobAvg = 0;
        //            }

        //            vec3 p1 = curList[A];
        //            vec3 p2 = curList[B];

        //            double d = glm.Distance(p1, p2);

        //            double theta = p2.heading - p1.heading;
        //            if (theta > Math.PI)
        //                theta -= Math.PI;
        //            else if (theta < -Math.PI)
        //                theta += Math.PI;

        //            if (theta > glm.PIBy2)
        //                theta -= Math.PI;
        //            else if (theta < -glm.PIBy2)
        //                theta += Math.PI;

        //            double segCurv = ((2 * Math.Sin(theta / 2)) / -d) * Settings.Tool.setToolSteer.curvatureGain;
        //            if (segCurv > 2.0)
        //                segCurv = 2.0;
        //            if (segCurv < -2.0)
        //                segCurv = -2.0;

        //            segK = 0.9 * segK + 0.1 * segCurv;

        //            double gain = (Math.Abs(bob) - 0.5);
        //            gain = 0.5 + gain;
        //            gain *= (0.004 + Settings.Tool.setToolSteer.passiveIntegralGain);

        //            if (bob < 0) bobAvg -= gain;
        //            else bobAvg += gain;
        //            //toolDistanceAvg += (0.01 * toolDistance);                    

        //            if (bobAvg > 0.5)
        //                bobAvg = 0.5;
        //            if (bobAvg < -0.5)
        //                bobAvg = -0.5;

        //            double dist = (segK - bobAvg);
        //            if (dist > 2.0)
        //                dist = 2.0;
        //            if (dist < -2.0)
        //                dist = -2.0;

        //            if (Uturn)
        //            {
        //                bobAvg = 0;
        //                dist = 0;
        //                segCurv = 0;
        //                isPassiveSteeringFlag = false;
        //            }

        //            goalPoint.easting += (Math.Sin(curList[B].heading + 1.57) * dist);
        //            goalPoint.northing += (Math.Cos(curList[B].heading + 1.57) * dist);

        //            //calc "D" the distance from pivot axle to lookahead point
        //            double goalPointDistanceSquared = glm.DistanceSquared(goalPoint, pivot);

        //            //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
        //            double localHeading = -mf.fixHeading + inty;

        //            //ppRadius = goalPointDistanceSquared / (2 * (((goalPoint.easting - pivot.easting) * Math.Cos(localHeading)) + ((goalPoint.northing - pivot.northing) * Math.Sin(localHeading))));

        //            steerAngle = glm.toDegrees(Math.Atan(2 * (((goalPoint.easting - pivot.easting) * Math.Cos(localHeading))
        //                + ((goalPoint.northing - pivot.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

        //            if (Uturn)
        //                steerAngle *= mf.vehicle.uturnCompensation;

        //            double steerHeadingError = pivot.heading - Math.Atan2(curList[B].easting - curList[A].easting, curList[B].northing - curList[A].northing);
        //            //Fix the circular error
        //            if (steerHeadingError > Math.PI)
        //                steerHeadingError -= Math.PI;
        //            else if (steerHeadingError < -Math.PI)
        //                steerHeadingError += Math.PI;

        //            if (steerHeadingError > glm.PIBy2)
        //                steerHeadingError -= Math.PI;
        //            else if (steerHeadingError < -glm.PIBy2)
        //                steerHeadingError += Math.PI;

        //            mf.vehicle.modeActualHeadingError = glm.toDegrees(steerHeadingError);

        //            if (!isPassiveSteeringFlag && isPassiveTriggered)
        //            {
        //                if (Math.Abs(mf.vehicle.modeActualHeadingError) < 1.5
        //                    && Math.Abs(distanceFromCurrentLine) < 0.10 && Math.Abs(distanceFromCurrentLineTool) < 0.20)
        //                    isPassiveSteeringFlag = true;
        //            }
        //        }

        //        #endregion PurePursuit

        //        if (!Uturn && mf.ahrs.imuRoll != 88888)
        //            steerAngle += mf.ahrs.imuRoll * -Settings.Vehicle.setAS_sideHillComp;

        //        if (steerAngle < -mf.vehicle.maxSteerAngle) steerAngle = -mf.vehicle.maxSteerAngle;
        //        if (steerAngle > mf.vehicle.maxSteerAngle) steerAngle = mf.vehicle.maxSteerAngle;

        //        //used for acquire/hold mode
        //        //used for smooth mode
        //        mf.vehicle.modeActualXTE = distanceFromCurrentLine;
        //        mf.guidanceVehicleXTE = distanceFromCurrentLine;
        //        mf.guidanceVehicleSteerAngle = steerAngle;
        //    }
        //    else
        //    {
        //        //invalid distance so tell AS module
        //        distanceFromCurrentLine = 0;
        //        mf.guidanceVehicleXTE = double.NaN;
        //        distanceFromCurrentLineTool = 0;
        //        completeUturn = true;
        //    }
        //    if (Uturn && completeUturn)
        //        mf.yt.CompleteYouTurn();
        //}

    }
}