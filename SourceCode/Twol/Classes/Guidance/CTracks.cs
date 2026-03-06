using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twol.Classes;

namespace Twol
{
    public enum TrackMode
    { toolLineInner = -2, toolLineOuter = -1, None = 0, ABLine = 2, PolyLine = 4, Polygon = 32, waterPivot = 64 };//, Heading, Circle, Spiral

    public class CTracks
    {
        //pointers to mainform controls
        private readonly FormGPS mf;

        private List<CTrk> _gListArr = new List<CTrk>();

        public IReadOnlyList<CTrk> gArr => _gListArr;

        private CTrk _currentRefTrack;

        public bool isHeadingSameWay = true, lastIsHeadingSameWay = true;
        public double howManyPathsAway, lastHowManyPathsAway;
        public bool isWest;

        public bool isAutoTrack;
        public int autoTrack3SecTimer;

        public List<vec3> smooList = new List<vec3>();

        //the list of toBeSmoothedList of curve to drive on
        public List<vec3> currentGuidanceTrack = new List<vec3>();

        //guidelines
        public List<List<vec3>> guideArr = new List<List<vec3>>();

        private bool isBusyWorking = false;

        public bool isTrackValid;

        public double lastSecond = 0;

        //design a new track
        public List<vec3> designPtsList = new List<vec3>();
        public vec2 designPtA = new vec2(0.2, 0.15);
        public vec2 designPtB = new vec2(0.3, 0.3);
        public vec2 designLineEndA = new vec2(0.2, 0.15);
        public vec2 designLineEndB = new vec2(0.3, 0.3);
        public double designHeading = 0;

        //flag for starting stop adding toBeSmoothedList for curve
        public bool isMakingTrack, isMakingABLine;

        //design tool line
        public List<vec3> toolDesignPtsList = new List<vec3>();
        public bool isRecordingCurveTrack;

        private const double Is45DegInRads = 0.785398;  // 45 deg
        private const double Is225DegInRads = 3.92699;  // 225 deg

        public CTracks(FormGPS _f)
        {
            //constructor
            mf = _f;
        }

        public CTrk currentRefTrack
        {
            get => _currentRefTrack;
            set
            {
                if (_currentRefTrack != value)
                {
                    _currentRefTrack = value;

                    isTrackValid = false;

                    mf.SetAutoSteerButton(false, _currentRefTrack == null ? gStr.Get(gs.gsNoABLineActive) : "Track Changed");

                    //mf.SetYouTurnButton(false);
                    //ss Log.EventWriter("Autosteer Stop, No Tracks Available");

                    int index2 = _gListArr.FindIndex(x => x == _currentRefTrack);
                    mf.lblNumCu.Text = (index2 + 1).ToString() + "/" + gArr.Count.ToString();
                    mf.lblNumCu.Visible = !mf.ct.isContourBtnOn;
                    mf.PanelUpdateRightAndBottom();
                }
            }
        }

        public int FindClosestRefTrack(vec3 steer)
        {
            if (_gListArr.Count == 0) return -1;

            //only 1 track
            if (_gListArr.Count == 1)
            {
                currentRefTrack = _gListArr[0];
                return 0;
            }

            int trak = -1;
            int cntr = 0;

            //Count visible
            for (int i = 0; i < _gListArr.Count; i++)
            {
                if (_gListArr[i].isVisible)
                {
                    cntr++;
                    trak = i;
                }
            }

            //no visible tracks
            if (cntr == 0) return -1;

            double minDistA = double.MaxValue;
            double dist;
            int A, B;

            for (int i = 0; i < _gListArr.Count; i++)
            {
                //if (!isAlignedArr[i]) continue;
                if (!gArr[i].isVisible) continue;

                if (mf.gyd.FindClosestSegment(gArr[i].curvePts, false, mf.guidanceLookPos, out A, out B))
                {
                    dist = mf.gyd.FindDistanceToSegment(mf.guidanceLookPos, gArr[i].curvePts[A], gArr[i].curvePts[B], out _, out _, false, false, false);

                    if (dist < minDistA)
                    {
                        minDistA = dist;
                        trak = i;
                    }
                }
            }

            currentRefTrack = _gListArr[trak];

            return trak;
        }

        public async Task GetDistanceFromRefTrack(CTrk track, vec3 pivot)
        {
            if (track == null) return;

            bool loops = track.mode > TrackMode.PolyLine;
            double widthMinusOverlap;

            if (Settings.Tool.setToolSteer.toolGuidanceSpacing == 0 || track.mode >= TrackMode.None)
                widthMinusOverlap = Settings.Tool.toolWidth - Settings.Tool.overlap;
            else
                widthMinusOverlap = Settings.Tool.setToolSteer.toolGuidanceSpacing;

            double distanceFromRefLine = 0;

            if (!isTrackValid || ((mf.secondsSinceStart - lastSecond) > 2 && (!mf.isBtnAutoSteerOn || mf.mc.steerSwitchHigh)))
            {
                lastSecond = mf.secondsSinceStart;
                if (track.mode != TrackMode.waterPivot)
                {
                    int refCount = track.curvePts.Count;
                    if (refCount < 2)
                    {
                        currentGuidanceTrack?.Clear();
                        return;
                    }

                    //int cc = mf.gyd.FindGlobalRoughNearest(mf.guidanceLookPos, track.curvePts, 10, !isTrackValid);

                    if (mf.gyd.FindClosestSegment(track.curvePts, loops, mf.guidanceLookPos, out int rA, out int rB))//, cc - 10, cc + 10))
                    {
                        distanceFromRefLine = mf.gyd.FindDistanceToSegment(mf.guidanceLookPos, track.curvePts[rA], track.curvePts[rB], out vec3 point, out _, true, false, false);

                        //same way as line creation or not
                        isHeadingSameWay = Math.PI - Math.Abs(Math.Abs(pivot.heading + glm.toRadians(mf.mc.actualSteerAngleDegrees) - track.curvePts[rA].heading) - Math.PI) < glm.PIBy2;
                    }
                }
                else //pivot guide list
                {
                    //cross product
                    isHeadingSameWay = ((mf.pivotAxlePos.easting - track.ptA.easting) * (mf.steerAxlePos.northing - track.ptA.northing)
                        - (mf.pivotAxlePos.northing - track.ptA.northing) * (mf.steerAxlePos.easting - track.ptA.easting)) < 0;

                    //pivot circle center
                    distanceFromRefLine = -glm.Distance(mf.guidanceLookPos, track.ptA);
                }

                if (track.mode > TrackMode.None) distanceFromRefLine -= (0.5 * widthMinusOverlap);

                double RefDist = (distanceFromRefLine + (isHeadingSameWay ? Settings.Tool.offset : -Settings.Tool.offset) - (track.nudgeDistance)) / widthMinusOverlap;

                if (RefDist < 0) howManyPathsAway = (int)(RefDist - 0.5);
                else howManyPathsAway = (int)(RefDist + 0.5);

                if (Settings.Tool.setToolSteer.passesPerReference != 0 && track.mode < TrackMode.None)
                {
                    switch (Settings.Tool.setToolSteer.passesPerReference)
                    {
                        case 1:
                            //nothing but center (0)
                            if (howManyPathsAway != 0) howManyPathsAway = 0;
                            break;

                        case 2:
                            //not center and only +-1
                            if (howManyPathsAway == 0 || Math.Abs(howManyPathsAway) > 1)
                            {
                                if (distanceFromRefLine >= 0) howManyPathsAway = 1;
                                else howManyPathsAway = -1;
                            }
                            break;

                        case 3:
                            //center and -1 or +1 only
                            if (Math.Abs(howManyPathsAway) > 1)
                            {
                                if (distanceFromRefLine >= (0.5 * widthMinusOverlap)) howManyPathsAway = 1;
                                else if (distanceFromRefLine < -(0.5 * widthMinusOverlap)) howManyPathsAway = -1;
                            }
                            break;

                        case 4:
                            //not 0 and not even
                            if (howManyPathsAway == 0 || Math.Abs(howManyPathsAway) % 2 == 0 || Math.Abs(howManyPathsAway) > 3)
                            {
                                if (distanceFromRefLine >= 0)
                                {
                                    if (distanceFromRefLine < (2 * widthMinusOverlap)) howManyPathsAway = 1;
                                    else howManyPathsAway = 3;
                                }
                                else
                                {
                                    if (distanceFromRefLine > (-2 * widthMinusOverlap)) howManyPathsAway = -1;
                                    else howManyPathsAway = -3;
                                }
                            }
                            break;
                    }
                }
            }


            if (!isTrackValid || howManyPathsAway != lastHowManyPathsAway || (isHeadingSameWay != lastIsHeadingSameWay && Settings.Tool.offset != 0))
            {
                if (!isBusyWorking)
                {
                    try
                    {
                        isBusyWorking = true;
                        isTrackValid = true;
                        lastHowManyPathsAway = howManyPathsAway;
                        lastIsHeadingSameWay = isHeadingSameWay;
                        double distAway = widthMinusOverlap * howManyPathsAway + (isHeadingSameWay ? -Settings.Tool.offset : Settings.Tool.offset) + (track.nudgeDistance);

                        if (track.mode > TrackMode.None) distAway += (0.5 * widthMinusOverlap);

                        if (track.mode < TrackMode.None)
                        {
                            //is track between 45 and 225 degrees or not
                            if (track.heading < 3.92699 && track.heading > 0.785398) distAway += -Settings.Tool.setToolSteer.nudgeGlobal;
                            else distAway += Settings.Tool.setToolSteer.nudgeGlobal;
                        }

                        currentGuidanceTrack = await Task.Run(() => BuildCurrentGuidanceTrack(distAway, track));

                        if (!mf.yt.isYouTurnTriggered)
                        {
                            mf.yt.ResetCreatedYouTurn();
                        }

                        mf.gyd.isFindGlobalNearestTrackPoint = true;
                    }
                    catch (Exception ex)
                    {
                        Log.EventWriter("GetDistanceFromRef Catch: " + ex.ToString());
                    }
                    finally
                    {
                        isBusyWorking = false;
                    }
                }
            }
        }

        public List<vec3> BuildCurrentGuidanceTrack(double distAway, CTrk track)
        {
            //the new current guidance track
            List<vec3> newCurList = new List<vec3>(64);

            try
            {
                //if (track.mode == TrackMode.ABLine)
                //{
                //    //simple shift of A and B points
                //    vec3 pt = new vec3(track.ptA);
                //    pt.easting += (Math.Sin(track.heading + glm.PIBy2) * distAway);
                //    pt.northing += (Math.Cos(track.heading + glm.PIBy2) * distAway);
                //    pt.heading = track.heading;
                //    newCurList.Add(pt);

                //    pt = new vec3(track.ptB);
                //    pt.easting += (Math.Sin(track.heading + glm.PIBy2) * distAway);
                //    pt.northing += (Math.Cos(track.heading + glm.PIBy2) * distAway);
                //    pt.heading = track.heading;
                //    newCurList.Add(pt);

                //    newCurList.AddStartEndPoints(4, 5000);
                //    return newCurList;
                //}

                bool loops = track.mode == TrackMode.Polygon;

                if (track.mode == TrackMode.waterPivot)
                {
                    //max 2 cm offset from correct circle or limit to 500
                    double Angle = glm.twoPI / Math.Min(Math.Max(Math.Ceiling(glm.twoPI / (2 * Math.Acos(1 - (0.02 / Math.Abs(distAway))))), 100), 1000);

                    vec3 centerPos = new vec3(track.ptA.easting, track.ptA.northing, 0);
                    double rotation = 0;

                    while (rotation < glm.twoPI)
                    {
                        //Update the heading
                        rotation += Angle;
                        //Add the new coordinate to the path
                        newCurList.Add(new vec3(centerPos.easting + distAway * Math.Sin(rotation), centerPos.northing + distAway * Math.Cos(rotation), 0));
                    }

                    newCurList.CalculateAverageHeadings(true);
                }

                else
                {
                    double step = 1;

                    newCurList = track.curvePts.OffsetLine(distAway, step, loops, track.mode == TrackMode.ABLine);

                    if (track.mode != TrackMode.ABLine)
                    {
                        newCurList.SmoothSegments(2);
                        newCurList.CatmullFix(1);

                        if (Settings.Tool.setToolSteer.isPassiveSteering)
                        {
                            newCurList.GenerateEquidistantPoints(0.95, loops);
                            newCurList.CalculateAverageHeadings(loops);
                            newCurList.ReducePointsByAngle(0.005, 5);
                        }
                        else
                        {
                            newCurList.GenerateEquidistantPoints(1.8, loops);
                            newCurList.CalculateAverageHeadings(loops);
                            newCurList.ReducePointsByAngle(0.01, 40);
                        }

                    }

                    if (track.mode != TrackMode.Polygon)
                        newCurList.AddStartEndPoints(2, 1000);
                }
            }
            catch (Exception e)
            {
                Log.EventWriter("Exception Build new offset curve" + e.ToString());
            }

            return newCurList;
        }

        public void DrawTrack()
        {
            try
            {
                if (guideArr.Count > 0)
                {
                    GL.LineWidth(Settings.User.setDisplay_lineWidth * 3);
                    GL.Color3(0, 0, 0);

                    for (int i = 0; i < guideArr.Count; i++)
                    {
                        guideArr[i].DrawPolygon(currentRefTrack.mode != TrackMode.Polygon ? PrimitiveType.LineStrip : PrimitiveType.LineLoop);
                    }

                    GL.LineWidth(Settings.User.setDisplay_lineWidth);
                    GL.Color4(0.2, 0.75, 0.2, 0.6);

                    for (int i = 0; i < guideArr.Count; i++)
                    {
                        guideArr[i].DrawPolygon(currentRefTrack.mode != TrackMode.Polygon ? PrimitiveType.LineStrip : PrimitiveType.LineLoop);
                    }
                }

                //Draw Tracks
                if (currentRefTrack != null && currentGuidanceTrack != null && currentGuidanceTrack.Count > 0) //normal
                {
                    GL.LineWidth(Settings.User.setDisplay_lineWidth * 4);
                    GL.Color3(0, 0, 0);

                    currentGuidanceTrack.DrawPolygon(currentRefTrack.mode <= TrackMode.PolyLine ? PrimitiveType.LineStrip : PrimitiveType.LineLoop);

                    GL.LineWidth(Settings.User.setDisplay_lineWidth);
                    GL.Color3(0.95f, 0.2f, 0.95f);

                    currentGuidanceTrack.DrawPolygon(currentRefTrack.mode <= TrackMode.PolyLine ? PrimitiveType.LineStrip : PrimitiveType.LineLoop);

                    GL.Color3(0.95f, 0.92f, 0.95f);
                    GL.PointSize(4);
                    currentGuidanceTrack.DrawPolygon(PrimitiveType.Points);

                    mf.yt.DrawYouTurn();
                }

                //draw reference tracks
                if (gArr != null && gArr.Count != 0)
                {
                    GL.LineWidth(1);
                    //GL.PointSize(4);
                    GL.Color3(0.95f, 0.5f, 0.5f);

                    for (int i = 0; i < gArr.Count; i++)
                    {
                        if (!gArr[i].isVisible) continue;

                        if (Settings.Tool.setToolSteer.isRecordToolLine)
                        {
                            if (gArr[i].mode == TrackMode.toolLineInner || gArr[i].mode == TrackMode.toolLineOuter)
                            {
                                continue;
                            }
                        }
                        gArr[i].curvePts.DrawPolygonThirds(PrimitiveType.LineStrip);
                    }
                }

                if (currentRefTrack != null)
                {
                    if (currentRefTrack.mode != TrackMode.waterPivot)
                    {
                        if (currentRefTrack.curvePts == null || currentRefTrack.curvePts.Count == 0) return;

                        GL.Enable(EnableCap.LineStipple);
                        GL.LineStipple(8, 0x0F00);
                        GL.LineWidth(Settings.User.setDisplay_lineWidth * 2);
                        GL.Color3(0.96, 0.2f, 0.2f);
                        currentRefTrack.curvePts.DrawPolygonThirds(PrimitiveType.LineStrip);
                        GL.Disable(EnableCap.LineStipple);

                        if (mf.font.isFontOn)
                        {
                            GL.Color3(0.40f, 0.90f, 0.95f);
                            mf.font.DrawText3D(currentRefTrack.ptA.easting, currentRefTrack.ptA.northing, "&A", true);
                            mf.font.DrawText3D(currentRefTrack.ptB.easting, currentRefTrack.ptB.northing, "&B", true);
                        }

                        //GL.PointSize(4);
                        //GL.Color3(0.95f, 0.992f, 0.95f);
                        //currentRefTrack.curvePts.DrawPolygon(PrimitiveType.Points);
                    }
                    else
                    {
                        GL.PointSize(15.0f);
                        GL.Begin(PrimitiveType.Points);
                        GL.Vertex3(currentRefTrack.ptA.easting, currentRefTrack.ptA.northing, 0);
                        GL.End();
                    }
                }
            }
            catch (Exception e)
            {
                Log.EventWriter("Exception Draw Track: " + e.ToString());
            }
        }

        //private List<List<vec3>> BuildTrackGuidelines(double distAway, int _passes, CTrk track)
        //{
        //    // the listlist of all the guidelines
        //    List<List<vec3>> newGuideLL = new List<List<vec3>>();

        //    try
        //    {
        //        for (int numGuides = -_passes; numGuides <= _passes; numGuides++)
        //        {
        //            if (numGuides == 0) continue;

        //            //the list of toBeSmoothedList of curve new list from async
        //            List<vec3> newGuideList = new List<vec3>
        //            {
        //                Capacity = 128
        //            };

        //            double nextGuideDist = (Settings.Tool.toolWidth - Settings.Tool.overlap) * numGuides +
        //                (isHeadingSameWay ? -Settings.Tool.offset : Settings.Tool.offset);

        //            //nextGuideDist += (0.5 * (Settings.Tool.toolWidth - Settings.Tool.overlap));

        //            nextGuideDist += distAway;

        //            double step = (Settings.Tool.toolWidth - Settings.Tool.overlap) * 0.48;
        //            if (step > 4) step = 4;
        //            if (step < 1) step = 1;

        //            newGuideList = track.curvePts.OffsetLine(nextGuideDist, step, track.mode > TrackMode.PolyLine);

        //            if (mf.bnd.bndList.Count > 0)
        //            {
        //                for (int i = newGuideList.Count - 1; i >= 0; i--)
        //                {
        //                    if (!mf.bnd.bndList[0].fenceLineEar.IsPointInPolygon(newGuideList[i]))
        //                    {
        //                        newGuideList.RemoveAt(i);
        //                    }
        //                }
        //            }

        //            if (newGuideList.Count > 5) newGuideLL.Add(newGuideList);

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Log.EventWriter("Exception Build new offset curve" + e.ToString());
        //    }

        //    return newGuideLL;
        //}

        public void DrawNewABLine()
        {
            //ABLine Line currently being designed
            GL.LineWidth(Settings.User.setDisplay_lineWidth);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.95f, 0.70f, 0.50f);
            GL.Vertex3(designLineEndA.easting, designLineEndA.northing, 0);
            GL.Vertex3(designLineEndB.easting, designLineEndB.northing, 0);
            GL.End();

            GL.Color3(0.2f, 0.950f, 0.20f);
            mf.font.DrawText3D(designPtA.easting, designPtA.northing, "&A", true);
            mf.font.DrawText3D(designPtB.easting, designPtB.northing, "&B", true);
        }

        public void DrawNewTrack()
        {
            DrawNewABLine();

            if (designPtsList.Count > 0)
            {
                GL.Color3(0.95f, 0.42f, 0.750f);
                GL.LineWidth(4.0f);
                designPtsList.DrawPolygon(PrimitiveType.LineStrip);

                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x0F00);
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.99f, 0.99f, 0.0);
                GL.Vertex3(designPtsList[designPtsList.Count - 1].easting, designPtsList[designPtsList.Count - 1].northing, 0);
                GL.Vertex3(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0);
                GL.End();

                GL.Disable(EnableCap.LineStipple);
            }
            if (toolDesignPtsList.Count > 0)
            {
                GL.Color3(0.95f, 0.42f, 0.750f);
                GL.LineWidth(10.0f);
                toolDesignPtsList.DrawPolygon(PrimitiveType.Lines);
            }
        }

        public void FinishToolLineRecording()
        {
            mf.trks.toolDesignPtsList.Add(new vec3(mf.toolPivotPos));

            //make a new tool track
            var track = new CTrk(TrackMode.toolLineInner)
            {
                name = (mf.gydTool.isboundaryLine ? "T_Bnd " : "T_Fld ") + (mf.trks.gArr.Count + 1).ToString("000")
            };

            if (mf.gydTool.isboundaryLine) track.mode = TrackMode.toolLineOuter;

            mf.trks.toolDesignPtsList.SmoothSegments();
            mf.trks.toolDesignPtsList.Reverse();
            mf.trks.toolDesignPtsList.GenerateEquidistantPoints(2, false);
            mf.trks.toolDesignPtsList.CalculateAverageHeadings(false);
            mf.trks.toolDesignPtsList.ReducePointsByAngle();

            track.heading = mf.trks.toolDesignPtsList.TrackAverageHeading();

            track.curvePts = new List<vec3>(mf.trks.toolDesignPtsList);

            track.curvePts.AddEndPoints(1, 30);
            track.curvePts.AddStartPoints(1, 30);

            track.ptA = new vec2(track.curvePts[0].easting, track.curvePts[0].northing);
            track.ptB = new vec2(track.curvePts[track.curvePts.Count - 1].easting, track.curvePts[track.curvePts.Count - 1].northing);

            AddTrack(track);

            mf.FileSaveNewToolTrack(track);
        }

        public void AddTrack(CTrk track)
        {
            if (track == null) return;

            string name = track.name;

            while (_gListArr.Any(t => t.name == name))
                name += " ";

            track.name = name;

            _gListArr.Add(track);
        }

        public void SetTracks(List<CTrk> tracks)
        {
            _gListArr = tracks;
        }

        public void setTrack(CTrk track)
        {
            int index = _gListArr.FindIndex(item => item == track);
            if (index != -1)
            {
                if (track == currentRefTrack)
                    isTrackValid = false;
                _gListArr[index] = track;
            }
        }

        public int TrackIndex(CTrk track)
        {
            return _gListArr.FindIndex(item => item == track);
        }

        public void MoveTrackUp(CTrk track)
        {
            int index = _gListArr.IndexOf(track);
            if (track == null || index == 0)
                return;

            _gListArr.Reverse(index - 1, 2);
        }

        public void MoveTrackDn(CTrk track)
        {
            int index = _gListArr.IndexOf(track);

            if (track == null || index == (_gListArr.Count - 1))
                return;

            _gListArr.Reverse(index, 2);
        }

        public void RemoveTrack(CTrk track)
        {
            _gListArr.Remove(track);
        }

        //sort the tracks
        public void SortTracks()
        {
            _gListArr.Sort((a, b) =>
                string.Compare(a?.name, b?.name, StringComparison.OrdinalIgnoreCase));
        }
        public int GetVisibleTracks()
        {
            int tracksVisible = 0;
            foreach (var track in gArr)
            {
                if (track.isVisible) tracksVisible++;
            }
            return tracksVisible;
        }

        public CTrk GetNextTrack(CTrk track, List<CTrk> gTemp, bool next = true, bool invisible = false)
        {
            int index = gTemp.FindIndex(x => x == track);

            if (next)
                return gTemp.Skip(index + 1).Concat(gTemp.Take(index)).FirstOrDefault(x => x.isVisible || invisible);
            else
                return gTemp.Take(index).Reverse().Concat(gTemp.Skip(index + 1).Reverse()).FirstOrDefault(x => x.isVisible || invisible);
        }

        public void GetNextTrack(bool next = true)
        {
            int index = _gListArr.FindIndex(x => x == currentRefTrack);

            if (next)
                currentRefTrack = gArr.Skip(index + 1).Concat(gArr.Take(index)).FirstOrDefault(x => x.isVisible);
            else
                currentRefTrack = gArr.Take(index).Reverse().Concat(gArr.Skip(index + 1).Reverse()).FirstOrDefault(x => x.isVisible);
        }

        public CTrk CreateDesignedABTrack(bool isRefRightSide)
        {
            var track = new CTrk(TrackMode.ABLine);

            //fill in the dots between A and B
            double len = glm.Distance(designPtA, designPtB);
            if (len < 20)
            {
                designPtB.easting = designPtA.easting + (Math.Sin(designHeading) * 50);
                designPtB.northing = designPtA.northing + (Math.Cos(designHeading) * 50);
            }

            track.curvePts.Add(new vec3(designPtA, designHeading));
            track.curvePts.Add(new vec3(designPtB, designHeading));
            track.heading = designHeading;

            double dist = (Settings.Tool.toolWidth - Settings.Tool.overlap) * (isRefRightSide ? 0.5 : -0.5) + Settings.Tool.offset;
            NudgeRefTrack(track, dist);

            track.ptA = new vec2(track.curvePts[0]);
            track.ptB = new vec2(track.curvePts[track.curvePts.Count - 1]);

            AddTrack(track);
            return track;
        }

        public void NudgeTrack(CTrk track, double dist)
        {
            isTrackValid = false;
            if (track != null)
                track.nudgeDistance += isHeadingSameWay ? dist : -dist;
        }

        public void NudgeDistanceReset(CTrk track)
        {
            isTrackValid = false;
            track.nudgeDistance = 0;
        }

        public void SnapToPivot(CTrk track)
        {
            NudgeTrack(track, mf.gyd.distanceFromCurrentLine);
        }

        public void NudgeRefTrack(CTrk track, double distAway)
        {
            isTrackValid = false;

            var curList = track.curvePts.OffsetLine(distAway, 1, track.mode > TrackMode.PolyLine, track.mode == TrackMode.ABLine);

            if (track.mode != TrackMode.ABLine)
            {
                //curList.CalculateAverageHeadings(track.mode > TrackMode.PolyLine);

                int cnt = curList.Count;
                if (cnt > 6)
                {
                    vec3[] arr = new vec3[cnt];
                    curList.CopyTo(arr);

                    curList.Clear();

                    for (int i = 0; i < (arr.Length - 1); i++)
                    {
                        arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                        if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                        if (arr[i].heading >= glm.twoPI) arr[i].heading -= glm.twoPI;
                    }

                    arr[arr.Length - 1].heading = arr[arr.Length - 2].heading;

                    //replace the array
                    cnt = arr.Length;
                    double distance;
                    double spacing = 2;

                    //add the first point of loop - it will be p1
                    curList.Add(arr[0]);

                    for (int i = 0; i < cnt - 3; i++)
                    {
                        // add p2
                        curList.Add(arr[i + 1]);

                        distance = glm.Distance(arr[i + 1], arr[i + 2]);

                        if (distance > spacing)
                        {
                            int loopTimes = (int)(distance / spacing + 1);
                            for (int j = 1; j < loopTimes; j++)
                            {
                                vec3 pos = new vec3(glm.Catmull(j / (double)(loopTimes), arr[i], arr[i + 1], arr[i + 2], arr[i + 3]));
                                curList.Add(pos);
                            }
                        }
                    }

                    curList.Add(arr[cnt - 2]);
                    curList.Add(arr[cnt - 1]);
                }
            }
            else
            {
                //find the A and B toBeSmoothedList in the ref

                int aClose = 0, bClose = 0;
                double minDist = double.MaxValue;

                for (int i = 0; i < track.curvePts.Count; i++)
                {
                    double dist = glm.DistanceSquared(track.curvePts[i], track.ptA);
                    if (dist < minDist)
                    {
                        aClose = i;
                        minDist = dist;
                    }
                }
                minDist = double.MaxValue;
                for (int i = 0; i < track.curvePts.Count; i++)
                {
                    double dist = glm.DistanceSquared(track.curvePts[i], track.ptB);
                    if (dist < minDist)
                    {
                        bClose = i;
                        minDist = dist;
                    }
                }

                track.ptA.easting = (track.curvePts[aClose].easting);
                track.ptA.northing = (track.curvePts[aClose].northing);
                track.ptB.easting = (track.curvePts[bClose].easting);
                track.ptB.northing = (track.curvePts[bClose].northing);
            }

            curList.CalculateAverageHeadings(track.mode > TrackMode.PolyLine);
            track.curvePts = curList;
        }

        public void ResetTrack()
        {
            currentGuidanceTrack?.Clear();
            currentRefTrack = null;
            _gListArr.Clear();
        }

        public bool PointOnLine(vec3 pt1, vec3 pt2, vec3 pt)
        {
            vec2 r = new vec2(0, 0);
            if (pt1.northing == pt2.northing && pt1.easting == pt2.easting) { pt1.northing -= 0.00001; }

            double U = ((pt.northing - pt1.northing) * (pt2.northing - pt1.northing)) + ((pt.easting - pt1.easting) * (pt2.easting - pt1.easting));

            double Udenom = Math.Pow(pt2.northing - pt1.northing, 2) + Math.Pow(pt2.easting - pt1.easting, 2);

            U /= Udenom;

            r.northing = pt1.northing + (U * (pt2.northing - pt1.northing));
            r.easting = pt1.easting + (U * (pt2.easting - pt1.easting));

            double minx, maxx, miny, maxy;

            minx = Math.Min(pt1.northing, pt2.northing);
            maxx = Math.Max(pt1.northing, pt2.northing);

            miny = Math.Min(pt1.easting, pt2.easting);
            maxy = Math.Max(pt1.easting, pt2.easting);
            return _ = r.northing >= minx && r.northing <= maxx && (r.easting >= miny && r.easting <= maxy);
        }
    }

    public class CTrk
    {
        public List<vec3> curvePts = new List<vec3>();
        public double heading;
        public string name;
        public bool isVisible;
        public vec2 ptA;
        public vec2 ptB;
        public TrackMode mode;
        public double nudgeDistance;

        public CTrk(TrackMode _mode = TrackMode.None)
        {
            curvePts = new List<vec3>();
            heading = 3;
            name = "New Track";
            isVisible = true;
            ptA = new vec2();
            ptB = new vec2();
            mode = _mode;
            nudgeDistance = 0;
        }

        public CTrk(CTrk _trk)
        {
            curvePts = new List<vec3>(_trk.curvePts);
            heading = _trk.heading;
            name = _trk.name;
            isVisible = _trk.isVisible;
            ptA = _trk.ptA;
            ptB = _trk.ptB;
            mode = _trk.mode;
            nudgeDistance = _trk.nudgeDistance;
        }

        public static bool operator ==(CTrk a, CTrk b)
        {
            if (a is null && b is null) return true;
            if (a is null) return false;
            if (b is null) return false;
            return a.name == b.name;
            //if (ReferenceEquals(a, b)) return true;
        }

        public static bool operator !=(CTrk a, CTrk b) => !(a == b);

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CTrk other)) return false;
            return this == other;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

//public async Task GetDistanceFromRefTrack(CTrk track, vec3 pivot)
//{
//    double widthMinusOverlap = Settings.Tool.toolWidth - Settings.Tool.overlap;

//    if (!isTrackValid ||
//        ((mf.secondsSinceStart - lastSecond) > 2 && (!mf.isBtnAutoSteerOn || mf.mc.steerSwitchHigh)))
//    {
//        double distanceFromRefLine = 0;
//        lastSecond = mf.secondsSinceStart;
//        if (track.mode != TrackMode.waterPivot)
//        {
//            int refCount = track.curvePts.Count;
//            if (refCount < 2)
//            {
//                currentGuidanceTrack?.Clear();
//                return;
//            }

//            if (mf.gyd.FindClosestSegment(track.curvePts, false, mf.guidanceLookPos, out int rA, out int rB))//, cc - 10, cc + 10))
//            {
//                //find distance to segment from ref line
//                distanceFromRefLine = mf.gyd.FindDistanceToSegment(mf.guidanceLookPos, track.curvePts[rA], track.curvePts[rB], out vec3 point, out _, true, false, false);

//                //same way as line creation or not
//                isHeadingSameWay = Math.PI - Math.Abs(Math.Abs(pivot.heading + glm.toRadians(mf.mc.actualSteerAngleDegrees) - track.curvePts[rA].heading) - Math.PI) < glm.PIBy2;
//            }
//        }
//        else //pivot guide list
//        {
//            //cross product
//            isHeadingSameWay = ((mf.pivotAxlePos.easting - track.ptA.easting) * (mf.steerAxlePos.northing - track.ptA.northing)
//                - (mf.pivotAxlePos.northing - track.ptA.northing) * (mf.steerAxlePos.easting - track.ptA.easting)) < 0;

//            //pivot circle center
//            distanceFromRefLine = -glm.Distance(mf.guidanceLookPos, track.ptA);
//        }

//        //add edge guidance offset
//        if (track.mode > TrackMode.None) distanceFromRefLine -= (0.5 * widthMinusOverlap);

//        //calculate how many paths away from reference line
//        double refDist = (distanceFromRefLine + (isHeadingSameWay ? Settings.Tool.offset : -Settings.Tool.offset) - (track.nudgeDistance)) / widthMinusOverlap;

//        if (refDist < 0) howManyPathsAway = (int)(refDist - 0.5);
//        else howManyPathsAway = (int)(refDist + 0.5);
//    }

//    if (!isTrackValid || howManyPathsAway != lastHowManyPathsAway || (isHeadingSameWay != lastIsHeadingSameWay && Settings.Tool.offset != 0))
//    {
//        if (!isBusyWorking)
//        {
//            isBusyWorking = true;
//            try
//            {
//                isTrackValid = true;
//                lastHowManyPathsAway = howManyPathsAway;
//                lastIsHeadingSameWay = isHeadingSameWay;
//                double distAway = widthMinusOverlap * howManyPathsAway + (isHeadingSameWay ? -Settings.Tool.offset : Settings.Tool.offset) + (track.nudgeDistance);

//                //Add egde guidance offset
//                if (track.mode > TrackMode.None) distAway += (0.5 * widthMinusOverlap);

//                //determine global line direction for nudge direction
//                if (track.mode < TrackMode.None)
//                {
//                    //is track between 45 and 225 degrees or not
//                    if (track.heading < Is225DegInRads && track.heading > Is45DegInRads) distAway += -Settings.Tool.setToolSteer.nudgeGlobal;
//                    else distAway += Settings.Tool.setToolSteer.nudgeGlobal;
//                }

//                //create current guidance lines to follow
//                if (track.mode == TrackMode.ABLine)
//                {
//                    //simple shift of A and B points
//                    currentGuidanceTrack.Clear();
//                    BuildCurrentGuidanceABLine(track, distAway);
//                }
//                else if (track.mode == TrackMode.Polygon)
//                {
//                    currentGuidanceTrack = await Task.Run(() => BuildCurrentGuidanceTrack(distAway, track));

//                    if (!mf.yt.isYouTurnTriggered)
//                    {
//                        mf.yt.ResetCreatedYouTurn();
//                    }

//                    mf.gyd.isFindGlobalNearestTrackPoint = true;

//                    guideArr?.Clear();
//                    if (Settings.User.isSideGuideLines && mf.camera.camSetDistance > Settings.Tool.toolWidth * -400)
//                    {
//                        //build the list list of guide lines
//                        guideArr = await Task.Run(() => BuildTrackGuidelines(distAway, Settings.Vehicle.setAS_numGuideLines, track));
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Log.EventWriter("BuildGuidanceCatch: " + ex.ToString());
//            }
//            finally
//            {
//                isBusyWorking = false;
//            }
//        }
//    }
//}