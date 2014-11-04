
namespace Patterns.Creational
{

    public class Singleton
    {
        private static readonly object SyncObj = new object();
        private static Singleton instance;
        private static int i=1;
        private static readonly object VarSyncObj = new object();
        private Singleton()
        {
        }

        public  static Singleton Instance()
        {
            if (instance == null)
            {
                lock (SyncObj)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }

        public int GetValue()
        {

            lock (VarSyncObj)
            {
                return i++;
            }
        }
    }
}
