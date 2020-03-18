using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManagerSingleton.Instance.Score += 1;
        Vector3 newPos = transform.position;
        newPos.x += Random.RandomRange(-5f, 5f);
        newPos.z += Random.RandomRange(-5f, 5f);
        transform.position = newPos;
    }
}
