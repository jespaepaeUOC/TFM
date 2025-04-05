using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpikeSpawner : MonoBehaviour
{
    public Tile spike;
    public List<Vector3Int> posibleSpikesPositions;
    public List<Vector3Int> spawnedSpikesPositions;
    public Tilemap tilemap;
    [ContextMenu("SpawnAllSpikes")]
    void SpawnAllSpikes()
    {
        foreach(var position in posibleSpikesPositions)
        {
            tilemap.SetTile(position, spike);
        }
    }
    [ContextMenu("DeleteAllSpikes")]
    public void DeleteAllSpikes()
    {
        int initialNumberOfspawnedSpikesPositions = spawnedSpikesPositions.Count;
        for(int i = initialNumberOfspawnedSpikesPositions-1; i >= 0; i--)
        {
            Vector3Int position = spawnedSpikesPositions[i];
            tilemap.SetTile(position, null);
            posibleSpikesPositions.Add(position);
            spawnedSpikesPositions.Remove(position);
        }
    }

    public void SpawnSpikes(int number)
    {
        for(int i = 0; i < number; i++)
        {
            if (posibleSpikesPositions.Count > 0) {
                int randomSpike = Random.Range(0, posibleSpikesPositions.Count);
                Vector3Int position = posibleSpikesPositions[randomSpike];
                tilemap.SetTile(position, spike);
                posibleSpikesPositions.Remove(position);
                spawnedSpikesPositions.Add(position);
            }
        }
    }
}
