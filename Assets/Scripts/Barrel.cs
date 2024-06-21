using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        CheckBounds();
    }
    
    private void CheckBounds()
    {
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }
}
