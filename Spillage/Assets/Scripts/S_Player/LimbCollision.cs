using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    private void OnCollisionEnter(Collision collision)
    {
        print("limb hit ground!");
        player.Grounded();
    }
}
