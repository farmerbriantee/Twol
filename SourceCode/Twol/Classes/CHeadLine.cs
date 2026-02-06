using System.Collections.Generic;

namespace Twol
{
    public class CHeadLine
    {
        public List<CHeadPath> tracksArr = new List<CHeadPath>();

        public int idx;

        public CHeadLine()
        {
        }

        //for calculating for display the averaged new line
    }

    public class CHeadPath
    {
        public List<vec3> trackPts = new List<vec3>();
        public string name = "";
        public double moveDistance = 0;
        public TrackMode mode = 0;
        public int a_point = 0;
    }
}