/*	
	Crash - Controlling application for Burn
    Copyright (C) 2016  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace burn
{
    public class CHN
    {
        private Int16 mSignature;
        private Int16 mDetectorNumber;
        private Int16 mSegment;
        private char[] mSecondsStart = { ' ', ' ' };
        private Int32 mRealTime;
        private float mRealTimeSeconds;
        private Int32 mLiveTime;
        private float mLiveTimeSeconds;
        private float mDeadTime;
        private char[] mStartDate = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        private char[] mStartTime = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        private Int16 mChannelOffset;
        private Int16 mNumberOfChannels;
        private string mMeasurementStart, mMeasurementStop;
        private DateTime mStart, mStop;

        public Int16 Signature { get { return mSignature; } }
        public Int16 DetectorNumber { get { return mDetectorNumber; } }
        public Int16 Segment { get { return mSegment; } }
        public string SecondsStart { get { return mSecondsStart.ToString(); } }
        public Int32 RealTime { get { return mRealTime; } }
        public float RealTimeSeconds { get { return mRealTimeSeconds; } }
        public Int32 LiveTime { get { return mLiveTime / 50; } }
        public float LiveTimeSeconds { get { return mLiveTimeSeconds; } }
        public float DeadTime { get { return mDeadTime; } }
        public string CStartDate { get { return mStartDate.ToString(); } }
        public string CStartTime { get { return mStartTime.ToString(); } }
        public DateTime StartDate { get { return mStart; } }
        public DateTime StopDate { get { return mStop; } }
        public Int16 ChannelOffset { get { return mChannelOffset; } }
        public Int16 NumberOfChannels { get { return mNumberOfChannels; } }
        public string MeasurementStart { get { return mMeasurementStart; } }
        public string MeasurementStop { get { return mMeasurementStop; } }

        private string mFilename;
        private double mMaxCount;
        private Dictionary<string, string> mMonthMap = new Dictionary<string, string>();
        private float[] mSpectrum = null;

        public double MaxCount { get { return mMaxCount; } }
        public float[] Spectrum { get { return mSpectrum; } }

        public CHN()
        {
            mMonthMap["JAN"] = "01";
            mMonthMap["FEB"] = "02";
            mMonthMap["MAR"] = "03";
            mMonthMap["APR"] = "04";
            mMonthMap["MAY"] = "05";
            mMonthMap["JUN"] = "06";
            mMonthMap["JUL"] = "07";
            mMonthMap["AUG"] = "08";
            mMonthMap["SEP"] = "09";
            mMonthMap["OCT"] = "10";
            mMonthMap["NOV"] = "11";
            mMonthMap["DEC"] = "12";
        }

        public void Read(string chn_file, bool headerOnly)
        {
            mFilename = chn_file;
            BinaryReader reader = new BinaryReader(File.Open(mFilename, FileMode.Open));
            if (reader == null)
                throw new Exception("Failed to open spectrum file " + mFilename);

            if (!ReadHeader(reader))
                throw new Exception("Failed to read header from " + mFilename);

            if (!headerOnly)
            {
                if (!ReadSpectrum(reader))
                    throw new Exception("Failed to read spectrum from " + mFilename);
            }
            reader.Close();
        }

        private bool ReadHeader(BinaryReader reader)
        {
            mSignature = reader.ReadInt16();
            if (mSignature != -1)
                throw new Exception("Invalid signature in spectrum file " + mFilename);

            mDetectorNumber = reader.ReadInt16();
            mSegment = reader.ReadInt16();
            mSecondsStart = reader.ReadChars(2);
            mRealTime = reader.ReadInt32();
            mLiveTime = reader.ReadInt32();
            mStartDate = reader.ReadChars(8);
            mStartTime = reader.ReadChars(4);
            mChannelOffset = reader.ReadInt16();
            mNumberOfChannels = reader.ReadInt16();

            int year = Convert.ToInt32(new string(mStartDate, 5, 2));
            /*if (emulateFixCHN)            
                year += (year <= 80) ? 2000 : 1900;            
            else */
            year += (mStartDate[7] == '1') ? 2000 : 1900;

            string month = new string(mStartDate, 2, 3);
            mMeasurementStart = year.ToString() + mMonthMap[month.ToUpper()] + new string(mStartDate, 0, 2);
            mMeasurementStart += new string(mStartTime, 0, 4);

            DateTime dtStart = new DateTime(
                year,
                Convert.ToInt32(mMonthMap[month.ToUpper()]),
                Convert.ToInt32(new string(mStartDate, 0, 2)),
                Convert.ToInt32(new string(mStartTime, 0, 2)),
                Convert.ToInt32(new string(mStartTime, 2, 2)),
                0);

            mRealTimeSeconds = (float)mRealTime / 50.0f;
            mLiveTimeSeconds = (float)mLiveTime / 50.0f;
            mDeadTime = 100.0f * ((mRealTimeSeconds - mLiveTimeSeconds) / mLiveTimeSeconds);

            DateTime dtStop = dtStart.Add(new TimeSpan((long)(mRealTimeSeconds * 10000000.0f)));
            mMeasurementStop = String.Format("{0:0000}", dtStop.Year)
                + String.Format("{0:00}", dtStop.Month)
                + String.Format("{0:00}", dtStop.Day)
                + String.Format("{0:00}", dtStop.Hour)
                + String.Format("{0:00}", dtStop.Minute);

            mStart = dtStart;
            mStop = dtStop;

            return true;
        }

        private bool ReadSpectrum(BinaryReader reader)
        {
            mSpectrum = new float[mNumberOfChannels];

            float count = 0.0f;
            mMaxCount = 0.0;
            for (int i = 0; i < mNumberOfChannels; ++i)
            {
                count = (float)reader.ReadInt32();
                if (count > mMaxCount)
                    mMaxCount = count;
                mSpectrum[i] = count;
            }

            return true;
        }

        public bool Write(string base_dir, Message msg)
        {
            string filename = base_dir + msg.arguments["session_name"] + Path.DirectorySeparatorChar + msg.arguments["session_index"] + ".chn";

            BinaryWriter writer = new BinaryWriter(File.Create(filename));

            if (!WriteHeader(writer, msg))
                return false;

            if (!WriteSpectrum(writer, msg))
                return false;

            return true;
        }

        private bool WriteHeader(BinaryWriter writer, Message msg)
        {
            // TODO
            return true;
        }

        private bool WriteSpectrum(BinaryWriter writer, Message msg)
        {
            // TODO
            return true;
        }
    }    
}
