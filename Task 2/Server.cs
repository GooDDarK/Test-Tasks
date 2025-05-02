using System;
using System.Threading;

namespace Task_2
{
    public static class Server
    {
        static int count = 0;
        static ReaderWriterLockSlim rw = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            rw.EnterReadLock();

            try
            {
                return count;
            }
            finally
            {
                rw.ExitReadLock();
            }
        }

        public static void AddToCount(int addValue)
        {
            rw.EnterWriteLock();

            try
            {
                count += addValue;
            }
            finally
            {
                rw.ExitWriteLock();
            }
        }
    }
}
