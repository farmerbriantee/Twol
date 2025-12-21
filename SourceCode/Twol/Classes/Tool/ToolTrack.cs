using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twol.Classes.Tool
{
    public class ToolTrk
    {
        public List<vec3> curvePts = new List<vec3>();
        public string name;
        public bool isVisible;
        public vec2 ptA;
        public vec2 ptB;
        public double nudgeDistance;

        public ToolTrk(TrackMode _mode = TrackMode.None)
        {
            curvePts = new List<vec3>();
            name = "New Track";
            isVisible = true;
            ptA = new vec2();
            ptB = new vec2();
            nudgeDistance = 0;
        }

        public ToolTrk(ToolTrk _trk)
        {
            curvePts = new List<vec3>(_trk.curvePts);
            name = _trk.name;
            isVisible = _trk.isVisible;
            ptA = _trk.ptA;
            ptB = _trk.ptB;
            nudgeDistance = _trk.nudgeDistance;
        }

        public static bool operator ==(ToolTrk a, ToolTrk b)
        {
            if (a is null && b is null) return true;
            if (a is null) return false;
            if (b is null) return false;
            return a.name == b.name;
            //if (ReferenceEquals(a, b)) return true;
        }

        public static bool operator !=(ToolTrk a, ToolTrk b) => !(a == b);

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            return this == (ToolTrk)obj;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
