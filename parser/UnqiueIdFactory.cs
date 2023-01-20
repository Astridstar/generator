namespace parser;

class UnqiueIdFactory
{
    private UnqiueIdFactory()
    { }

    private long _id = 0;
    private static readonly object _lock = new object();
    private static readonly Lazy<UnqiueIdFactory> _singleton = new Lazy<UnqiueIdFactory>(() => new UnqiueIdFactory());

    public static UnqiueIdFactory Instance
    {
        get
        {
            return _singleton.Value;
        }
    }

    public long getNextId()
    {
        lock (_lock)
        {
            return _id++;
        }
    }
}