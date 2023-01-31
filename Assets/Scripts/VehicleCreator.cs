using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCreator : MonoBehaviour
{
    [SerializeField] List<GameObject> tankCollection = new List<GameObject>();
    [SerializeField] List<GameObject> carCollection = new List<GameObject>();
    [SerializeField] int poolSize;
    private Vector3 startPosition = new Vector3 (0, 0, 0);
    
    int RandomTank()
    {
        int rand = Random.Range(0, tankCollection.Count);
        return rand;
    }
    int RandomCar()
    {
        int rand = Random.Range(0, carCollection.Count);
        return rand;
    }
    GameObject RandomVehicle()
    {
        GameObject randVehicle;
        int rand = Random.Range(0, 10);
        if(rand < 5)
        {
            randVehicle = tankCollection[RandomTank()];
        }
        else
        {
            randVehicle = carCollection[RandomCar()];
        }

        return randVehicle;
    }
    public GameObject CreateVehicle()
    {
        
        GameObject vehicle = Instantiate(RandomVehicle(), startPosition, Quaternion.identity);
        vehicle.SetActive(false);
        return vehicle;
    }
    public List<GameObject> CreatePoolingVehicle()
    {
        List<GameObject> pool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            pool.Add(CreateVehicle());
        }
        return pool;
    }
}
