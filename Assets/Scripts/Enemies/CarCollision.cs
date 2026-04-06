using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public Transform[] movementPoints;
    public float speed = 3f;
    public float waitTime = 1f;

    private int currentIndex = 0;
    private float waitCounter;

    private void Update()
    {
        MovementCar();
    }

    void MovementCar()
    {
        if (movementPoints.Length == 0) return;

        Transform target = movementPoints[currentIndex];

        // Movimento
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Rotação
        Vector3 dir = (target.position - transform.position).normalized;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }

        // Chegou no ponto
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            waitCounter += Time.deltaTime;

            if (waitCounter >= waitTime)
            {
                currentIndex = (currentIndex + 1) % movementPoints.Length;
                waitCounter = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            UIManager.Instance.LoseGameUI(this);
        }
    }
}
