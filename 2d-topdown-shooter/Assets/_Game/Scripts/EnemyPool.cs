public class EnemyPool : ObjectPoolBase, IPool<EnemyMovement>
{
    public EnemyMovement GetObject()
    {
        return GetFromPool().GetComponent<EnemyMovement>();
    }

    public void ReturnObject(EnemyMovement enemy)
    {
        ReturnToPool(enemy.gameObject);
    }
}
