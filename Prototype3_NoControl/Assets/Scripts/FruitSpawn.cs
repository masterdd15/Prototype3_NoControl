using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{

    public List<GameObject> targetList;

    // Start is called before the first frame update
    void Start()
    {
        //We are loading in all of our fruit 3D models into our list
        targetList = new List<GameObject>(Resources.LoadAll<GameObject>("FruitPrefabs"));
        CreateFruit();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFruit()
    {
        GameObject newObj = targetList[1];
        newObj.AddComponent<SphereCollider>();
        newObj.AddComponent<Rigidbody>();
        Instantiate(targetList[1], transform.position, Quaternion.identity);
    }
}
