namespace C_Tests.SourceCode
{
    public class Singleton
    {
        public Guid Guide { get; private init; }
        private static readonly Object syncLock = new Object();
        private static Singleton _instance = null!;

        public static Singleton GetInstance()
        {
            lock(syncLock)
            {
                if (_instance == null)    
                    _instance = new Singleton { Guide = Guid.NewGuid() };
            }

            return _instance;
        }

        public override string ToString()
        {
            return $"{Guide}";
        }
    }
}