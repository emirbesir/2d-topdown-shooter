using System;
using UnityEngine;

public interface IPlayerInput
{
    Vector2 GetMoveInput();
    Vector2 GetMouseWorldPosition();

    event Action OnAttack;
}
