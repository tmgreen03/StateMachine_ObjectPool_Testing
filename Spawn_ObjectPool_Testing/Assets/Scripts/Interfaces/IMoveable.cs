using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    Rigidbody RB { get; set; }

    void Move(Vector3 velocity);
}
