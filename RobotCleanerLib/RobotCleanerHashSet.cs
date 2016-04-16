using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RobotCleanerLib
{
    public class RobotCleanerHashSet : RobotCleaner
    {
        private HashSet<Tuple<int, int>> m_hashSet;

        public RobotCleanerHashSet(int x, int y, int minorRange, int greaterRange) : base(x, y, minorRange, greaterRange)
        {

        }

        public override string Position
        {
            get
            {
                return string.Format("RobotCleaner = {0}, {1}", m_x, m_y);
            }
        }

        public override void Init()
        {
            m_hashSet = new HashSet<Tuple<int, int>>();
            m_hashSet.Add(new Tuple<int, int>(m_x, m_y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Clean(string direction, int steps)
        {
            switch (direction)
            {
                case "N":
                    for (int i = 0; i < steps; i++)
                    {
                        if (m_x + 1 > m_greaterRange)
                            break;

                        m_x++;
                        m_hashSet.Add(new Tuple<int, int>(m_x, m_y));
                    }
                    break;
                case "E":
                    for (int i = 0; i < steps; i++)
                    {
                        if (m_y + 1 > m_greaterRange)
                            break;

                        m_y++;
                        m_hashSet.Add(new Tuple<int, int>(m_x, m_y));
                    }
                    break;
                case "S":
                    for (int i = 0; i < steps; i++)
                    {
                        if (m_x - 1 < m_minorRange)
                            break;

                        m_x--;
                        m_hashSet.Add(new Tuple<int, int>(m_x, m_y));
                    }
                    break;
                case "W":
                    for (int i = 0; i < steps; i++)
                    {
                        if (m_y - 1 < m_minorRange)
                            break;

                        m_y--;
                        m_hashSet.Add(new Tuple<int, int>(m_x, m_y));
                    }
                    break;
            }

            m_placesCleaned = m_hashSet.Count;
        }

        public override void Dispose()
        {
            m_hashSet.Clear();
            m_hashSet = null;
        }
    }
}
