public interface IPool<T>
{
    T GetObject();
    void ReturnObject(T objectToReturn);
}