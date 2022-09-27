using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    public Transform plaer;
    public Chunks[] chunksPrefabs;

    private int lastValuaChunks;
    private int indexator;
    private List<Chunks> spawnedChunks = new List<Chunks>();

    void Start()
    {
        spawnedChunks.Add(chunksPrefabs[0]);
    }

    
    void Update()
    {
        if (plaer.position.y > spawnedChunks[spawnedChunks.Count - 1].end.position.y - 5)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk ()
    {
        Chunks newChunks = Instantiate(chunksPrefabs[Random.Range(0, chunksPrefabs.Length)]);
        newChunks.transform.position = spawnedChunks[spawnedChunks.Count - 1].end.position - newChunks.begin.localPosition;

        spawnedChunks.Add(newChunks);
        
        indexator++;

        if (indexator>=5)
        {
            
            Destroy(spawnedChunks[lastValuaChunks].gameObject);
            lastValuaChunks++;
        }
    }
}
