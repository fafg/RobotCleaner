namespace RobotCleanerLib
{
    public class RobotCleanerFactory
    {
        public static RobotCleaner CreateBigData(int x, int y, int minorRange, int greaterRange)
        {
            return new RobotCleanerBigData(x, y, minorRange, greaterRange);
        }

        public static RobotCleaner CreateHashSet(int x, int y, int minorRange, int greaterRange)
        {
            return new RobotCleanerHashSet(x, y, minorRange, greaterRange);
        }
    }
}
