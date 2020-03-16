using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomGenMess : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public Vector3 center2;
    public Vector3 size2;

    public GameObject dirtPrefab;
  
    void Start()
    {
        if (gameObject.tag == "kitchen")
        {
            for (int i = 0; i < 6; i++)
            {
                spawnDirt();
            }
        }
        else if(gameObject.tag == "bedroom")
        {
            for (int i = 0; i < 10; i++)
            {
                spawnDirt();
            }
            
        }

    }

    public void spawnDirt()
    {
        Vector3 position = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(dirtPrefab, position, Quaternion.identity);
      
        Vector3 position2 = center2 + new Vector3(Random.Range(-size2.x / 2, size2.x / 2), Random.Range(-size2.y / 2, size2.y / 2), Random.Range(-size2.z / 2, size2.z / 2));
        Instantiate(dirtPrefab, position2, Quaternion.identity);
        
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(center, size);
        Gizmos.DrawCube(center2, size2);
    }

}
