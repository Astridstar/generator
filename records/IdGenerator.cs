namespace records;

class IdGenerator
{
    readonly object _lock = new object();

    long _id = 0;

    public long getNextId()
    {
        lock (_lock)
            return ++_id;
    }
}