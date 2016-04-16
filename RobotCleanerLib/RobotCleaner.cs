using System;

namespace RobotCleanerLib
{
    public abstract class RobotCleaner : IDisposable
    {
        protected byte CLEANED = 1;

        protected int m_minorRange = int.MinValue;
        protected int m_greaterRange = int.MinValue;

        protected int m_x = int.MinValue;
        protected int m_y = int.MinValue;
        protected int m_placesCleaned = 1;

        protected long m_position = long.MinValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="minorRange">identical minor range to both x and y</param>
        /// <param name="greaterRange">identical greater range to both x and y</param>
        public RobotCleaner(int x, int y, int minorRange, int greaterRange)
        {
            m_x = x;
            m_y = y;

            m_minorRange = minorRange;
            m_greaterRange = greaterRange;
        }

        public string PlacesCleaned
        {
            get { return string.Format("=> Cleaned: {0}", m_placesCleaned.ToString()); }
        }

        public abstract string Position { get; }

        public abstract void Init();
        public abstract void Clean(string direction, int steps);
        public abstract void Dispose();
    }
}
