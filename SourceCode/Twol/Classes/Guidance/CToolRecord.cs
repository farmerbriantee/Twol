using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Twol
{
    public class CToolRecord
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        public bool isToolRecordOn, isToolRecordBtnOn;


        public vec2 boxA = new vec2(0, 0), boxB = new vec2(0, 2);

        //list of strip data individual points
        public List<vec3> ptList = new List<vec3>();

        //list of the list of individual Lines for entire field
        public List<List<vec3>> stripList = new List<List<vec3>>();

        //list of points for the new tool recording line
        public List<vec3> trList = new List<vec3>();

        //constructor
        public CToolRecord(FormGPS _f)
        {
            mf = _f;
            trList.Capacity = 128;
            ptList.Capacity = 128;
        }

        public bool isLocked = false;

        //start stop and add points to list
        public void StartToolRecordLine()
        {
            ptList = new List<vec3>(16);
            stripList.Add(ptList);
            isToolRecordOn = true;
            return;
        }

        //Add current position to stripList
        public void AddPoint(vec3 toolPos)
        {
            ptList.Add(new vec3(toolPos.easting,toolPos.northing, 0));
        }

        //End the strip
        public void StopToolRecordLine()
        {
            //make sure its long enough to bother
            if (ptList.Count > 5)
            {
                //add the point list to the save list for appending to tool record file
                mf.toolRecordSaveList.Add(ptList);
            }
            //delete ptList
            else
            {
                ptList.Clear();
            }

            //turn it off
            isToolRecordOn = false;
        }

        //Reset the toolRec to zip
        public void ResetToolRecord()
        {
            stripList.Clear();
            ptList?.Clear();
            trList?.Clear();
        }
    }//class
}//namespace