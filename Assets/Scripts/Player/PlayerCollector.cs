using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            GameManager.Instance.AddPoints(other.GetComponent<Collectible>().points);
            Destroy(other.gameObject);
        }
    }
}
