using System.Collections.Generic;

namespace Twol.Classes.Tool
{
    public class CTrkTool
    {
        public List<vec3> curvePts = new List<vec3>();
        public double heading;
        public string name;
        public bool isVisible;
        public vec2 ptA;
        public vec2 ptB;
        public TrackMode mode;
        public double nudgeDistance;

        public CTrkTool(TrackMode _mode = TrackMode.toolLineInner)
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

        public CTrkTool(CTrkTool _trk)
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
    }
}
