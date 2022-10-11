using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed = 0;
    public float distance = 0;
    public Vector3 spawnPoint = new Vector3(0, 0, 0);

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(spawnPoint, transform.position) >= distance) Destroy(gameObject);
    }
}
