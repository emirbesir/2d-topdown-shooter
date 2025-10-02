public class BulletPool : ObjectPoolBase, IPool<Bullet>
{
    public Bullet GetObject()
    {
        return GetFromPool().GetComponent<Bullet>();
    }

    public void ReturnObject(Bullet bullet)
    {
        ReturnToPool(bullet.gameObject);
    }
}
