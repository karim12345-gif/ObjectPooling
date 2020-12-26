using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool; // which object to pool which is the pizza or the ammo of the player
    public int amountToPool; // the amount u will enter , ex 20 

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list -- if we have 20 (then it will loop till 20 )
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) // i<20. will incremeant the objects 
        {
            GameObject obj = (GameObject)Instantiate(objectToPool); // here we will create new objects(pizza in this case)
            obj.SetActive(false); // to disactivate it 
            pooledObjects.Add(obj); // to add it to the list 
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }

}
