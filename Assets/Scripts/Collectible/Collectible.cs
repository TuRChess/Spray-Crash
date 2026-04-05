using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points;
    public float speedRotate;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.rotation.x, speedRotate, transform.rotation.z);
    }
}
