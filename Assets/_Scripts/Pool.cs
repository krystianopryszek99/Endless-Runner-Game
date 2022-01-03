using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to spawn platfroms

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool IsExpandable;
}

public class Pool : MonoBehaviour
{
    public GameObject fencePrefab;  // used by CreateFromPool to create obstacle
    public static Pool singleton;
    public List<PoolItem> prefabItems; // list of prefabs, how many etc
    public List<GameObject> poolItemsToUse; // list to pull the prefabs from

    private void Awake()
    {
        singleton = this;

        // List of all the prefabs you want to use for spawning
        poolItemsToUse = new List<GameObject>();
        foreach(PoolItem PI in prefabItems)
        {
            for(int i = 0; i < PI.amount; i++)
            {
                GameObject GO = Instantiate(PI.prefab);
                GO.SetActive(false);
                poolItemsToUse.Add(GO);
            }
        }
    }

    // Spawns random platform
    public GameObject GetRandom()
    {
        Utils.Shuffle(poolItemsToUse);
        for( int i = 0; i < poolItemsToUse.Count; i++)
        {
            if(!poolItemsToUse[i].activeInHierarchy)
            {
                return poolItemsToUse[i];
            }
        }
        // if we get here, then nothing to use, check expandables
        foreach(PoolItem PI in prefabItems)
        {
            if(PI.IsExpandable)
            {
                GameObject GO = Instantiate(PI.prefab);
                GO.SetActive(false);
                poolItemsToUse.Add(GO);
                return GO;
            }
        }
        // finally, return null to ensure at least one return path
        // will have to deal with this later when getting platforms
        return null;

        
    }

}

// randomise the list using the fisher Yeats Shuffle
public static class Utils
{
    public static System.Random r = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n+1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
