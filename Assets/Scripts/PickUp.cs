using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Vector3 move = Vector3.zero;
    public float speed = 1f;
    void Update()
    {
        transform.Translate(move * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameManagerSingleton.Instance.Score += 1;
        Vector3 newPos = transform.position;
        newPos.x += Random.RandomRange(-6f, 6f);
        newPos.z += Random.RandomRange(-6f, 6f);
        transform.position = newPos;
        move.x = Random.RandomRange(-speed, speed);
        move.z = Random.RandomRange(-speed, speed);
    }
}
