using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomGenMess : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public Vector3 center2;
    public Vector3 size2;
    public Vector3 center3;
    public Vector3 size3;

    public GameObject dirtPrefab;
    public GameObject platePrefab;
    public GameObject toyPrefab;
    public GameObject toy2Prefab;
    public GameObject toy3Prefab;
    public GameObject puddlePrefab;


    private void Start()
    {
        if (gameObject.tag == "kitchen")
        {
            for (int i = 0; i < 8; i++)
            {
                Spawn(dirtPrefab, center, size);
                Spawn(dirtPrefab, center2, size2);
                Spawn(platePrefab, center3, size3);
            }
        }
        else if (gameObject.tag == "bedroom")
        {
            for (int i = 0; i < 4; i++)
            {
                Spawn(dirtPrefab, center, size);
                Spawn(dirtPrefab, center2, size2);
                Spawn(puddlePrefab, center3, size3);
            }
            for (int i = 0; i < 2; i++)
            {
                Spawn(toyPrefab, center2, size2);
                Spawn(toy2Prefab, center2, size2);
                Spawn(toy3Prefab, center2, size2);

            }

        }
    }

    public void Spawn(GameObject Prefab, Vector3 Center, Vector3 Size)
    {
        Vector3 position = Center + new Vector3(Random.Range(-Size.x / 2, Size.x / 2), Random.Range(-Size.y / 2, Size.y / 2), Random.Range(-Size.z / 2, Size.z / 2));
        GameObject SpawnObject = Instantiate(Prefab, position, Quaternion.identity);
        SpawnObject.transform.parent = transform;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(center, size);
        Gizmos.DrawCube(center2, size2);
        Gizmos.DrawCube(center3, size3);
    }

    




    //Old

    //void Start()
    //{
    //    if (gameObject.tag == "kitchen")
    //    {
    //        for (int i = 0; i < 8; i++)
    //        {
    //            spawnDirt();
    //            spawnPlate();
    //        }
    //    }
    //    else if(gameObject.tag == "bedroom")
    //    {
    //        for (int i = 0; i < 4; i++)
    //        {
    //            spawnDirt();
    //            spawnPuddle();
    //        }
    //        for (int i = 0; i < 2; i++)
    //        {
    //            spawnToy();
    //            spawnToy2();
    //            spawnToy3();

    //        }

    //    }

    //}

   
    //public void spawnDirt()
    //{
    //    Vector3 position = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
    //    Instantiate(dirtPrefab, position, Quaternion.identity);

    //    Vector3 position2 = center2 + new Vector3(Random.Range(-size2.x / 2, size2.x / 2), Random.Range(-size2.y / 2, size2.y / 2), Random.Range(-size2.z / 2, size2.z / 2));
    //    Instantiate(dirtPrefab, position2, Quaternion.identity);

    //}
    //public void spawnToy()
    //{
    //    Vector3 position = center2 + new Vector3(Random.Range(-size2.x / 2, size2.x / 2), Random.Range(-size2.y / 2, size2.y / 2), Random.Range(-size2.z / 2, size2.z / 2));
    //    Instantiate(toyPrefab, position, Quaternion.identity);
    //}
    //public void spawnToy2()
    //{
    //    Vector3 position = center2 + new Vector3(Random.Range(-size2.x / 2, size2.x / 2), Random.Range(-size2.y / 2, size2.y / 2), Random.Range(-size2.z / 2, size2.z / 2));
    //    Instantiate(toy2Prefab, position, Quaternion.identity);
    //}
    //public void spawnToy3()
    //{
    //    Vector3 position = center2 + new Vector3(Random.Range(-size2.x / 2, size2.x / 2), Random.Range(-size2.y / 2, size2.y / 2), Random.Range(-size2.z / 2, size2.z / 2));
    //    Instantiate(toy3Prefab, position, Quaternion.identity);
    //}

    //public void spawnPlate()
    //{
    //    Vector3 position = center3 + new Vector3(Random.Range(-size3.x / 2, size3.x / 2), Random.Range(-size3.y / 2, size3.y / 2), Random.Range(-size3.z / 2, size3.z / 2));
    //    Instantiate(platePrefab, position, Quaternion.identity);

    //}

    //public void spawnPuddle()
    //{
    //    Vector3 position = center3 + new Vector3(Random.Range(-size3.x / 2, size3.x / 2), Random.Range(-size3.y / 2, size3.y / 2), Random.Range(-size3.z / 2, size3.z / 2));
    //    Instantiate(puddlePrefab, position, Quaternion.identity);

    //}
}
