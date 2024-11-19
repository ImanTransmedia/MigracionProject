using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneTargetManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Spawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DeleteSpawned()
    {
        Spawned = GameObject.FindGameObjectsWithTag("Spawned");

        foreach (GameObject obj in Spawned)
        {
            Destroy(obj);
        }

        Debug.Log("Scene cleaned");
    }
}
