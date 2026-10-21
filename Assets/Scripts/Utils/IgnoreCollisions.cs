using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IgnoreCollisions : MonoBehaviour
{
    [SerializeField]
    Collider thisCollider;

    [SerializeField]
    Collider[] collidersToIgnore;

    void Start()
    {
        foreach(Collider otherCollider in collidersToIgnore)
        {
            Physics.IgnoreCollision(thisCollider, otherCollider, true);
        }
    }
}
