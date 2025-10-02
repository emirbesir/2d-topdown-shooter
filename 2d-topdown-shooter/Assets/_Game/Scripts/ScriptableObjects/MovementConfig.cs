using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "Config/MovementConfig")]
public class MovementConfig : ScriptableObject
{
    [SerializeField, Range(0f, 20f)] private float moveSpeed = 5f;
    
    public float MoveSpeed => moveSpeed;
}
