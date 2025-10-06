public interface IPool<T>
{   
    int PoolSize { get; }
    T GetObject();
    void ReturnObject(T objectToReturn);
}