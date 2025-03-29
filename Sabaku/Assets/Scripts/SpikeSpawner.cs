using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpikeSpawner : MonoBehaviour
{
    public Tile spike;
    public List<Vector3Int> positions;
    public Tilemap tilemap;
    [ContextMenu("SpawnAllSpikes")]
    void SpawnAllSpikes()
    {
        foreach(var position in positions)
        {
            tilemap.SetTile(position, spike);
        }
    }

    public void SpawnSpikes(int number)
    {
        for(int i = 0; i < number; i++)
        {
            if (positions.Count > 0) {
                int randomSpike = Random.Range(0, positions.Count);
                Vector3Int position = positions[randomSpike];
                tilemap.SetTile(position, spike);
                positions.Remove(position);
            }
        }
    }
}
