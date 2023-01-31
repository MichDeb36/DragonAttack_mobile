using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Vehicle
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
    }
}
