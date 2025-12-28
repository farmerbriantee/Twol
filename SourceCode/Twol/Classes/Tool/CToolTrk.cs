using System.Collections.Generic;

namespace Twol.Classes.Tool
{
    public class CToolTrk
    {
        public List<vec3> curvePts = new List<vec3>();
        public string name;
        public bool isVisible;
        public vec2 ptA;
        public vec2 ptB;
        public double nudgeDistance;

        public CToolTrk(string _name = "1")
        {
            curvePts = new List<vec3>();
            name = _name;
            isVisible = true;
            ptA = new vec2();
            ptB = new vec2();
            nudgeDistance = 0;
        }

        public CToolTrk(CToolTrk _trk)
        {
            curvePts = new List<vec3>(_trk.curvePts);
            name = _trk.name;
            isVisible = _trk.isVisible;
            ptA = _trk.ptA;
            ptB = _trk.ptB;
            nudgeDistance = _trk.nudgeDistance;
        }
    }
}
