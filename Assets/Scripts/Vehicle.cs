using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    protected float speed;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    protected void Start()
    {
        speed = GameManager.Instance.GetSpeedObstacle();
    }

    protected void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
    }
}
