using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;

namespace RobotCleanerLib
{
    public class RobotCleanerBigData : RobotCleaner
    {
        private int m_xp = int.MinValue;
        private int m_yp = int.MinValue;

        private int m_maxHeightWidth = int.MinValue;

        private MemoryMappedFile m_mmFile = null;
        private MemoryMappedViewAccessor m_view = null;


        public RobotCleanerBigData(int x, int y, int minorRange, int greaterRange) : base(x, y, minorRange, greaterRange)
        {

        }

        public override string Position
        {
            get
            {
                return string.Format("RobotCleaner = {0}, {1} | RealArrayPosition: {2}", m_xp, m_yp, m_position);
            }
        }

        public override void Init()
        {
            m_xp = m_x + Math.Abs(m_minorRange);
            m_yp = m_y + Math.Abs(m_minorRange);

            m_maxHeightWidth = Math.Abs(m_minorRange) + Math.Abs(m_greaterRange);

            m_position = (m_xp * m_minorRange) + (m_xp + m_yp);

            m_mmFile = MemoryMappedFile.CreateNew("RobotCleaner", m_minorRange * m_greaterRange,
                                                  MemoryMappedFileAccess.ReadWrite,
                                                  MemoryMappedFileOptions.DelayAllocatePages,
                                                  HandleInheritability.None);

            m_view = m_mmFile.CreateViewAccessor();
            m_view.Write<byte>(m_position, ref CLEANED);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Clean(string direction, int steps)
        {
            switch (direction)
            {
                case "N":
                    for (int i = 0; i < steps; i++)
                    {
                        if (m_xp + 1 > m_maxHeightWidth)
                            break;

                        m_xp++;
                        Clean();
                    }
                    break;
                case "E":
                    for (int i = 0; i < steps; i++)
                    {
                        if (m_yp + 1 > m_maxHeightWidth)
                            break;

                        m_yp++;
                        Clean();
                    }
                    break;
                case "S":
                    for (int i = 0; i < steps; i++)
                    {
                        if (m_xp - 1 < 0)
                            break;

                        m_xp--;
                        Clean();
                    }
                    break;
                case "W":
                    for (int i = 0; i < steps; i++)
                    {
                        if (m_yp - 1 < 0)
                            break;

                        m_yp--;
                        Clean();
                    }
                    break;
            }
        }

        private void Clean()
        {
            byte value = byte.MinValue;

            m_position = (m_xp * m_minorRange) + (m_xp + m_yp);
            m_view.Read<byte>(m_position, out value);

            if (value != CLEANED)
            {
                m_view.Write<byte>(m_position, ref CLEANED);
                m_placesCleaned++;
            }
        }

        public override void Dispose()
        {
            if (m_view != null)
                m_view.Dispose();

            if (m_mmFile != null)
                m_mmFile.Dispose();

            m_view = null;
            m_mmFile = null;
        }
    }
}
