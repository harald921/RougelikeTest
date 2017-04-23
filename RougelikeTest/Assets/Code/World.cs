using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour 
{
    /* Fields */
    [System.Serializable] public struct WorldGenData
    {
        [Header("World Settings")]
        [Range(16,124)]
        public int chunkSize;
    }
    [SerializeField] WorldGenData _worldGenData;
    public WorldGenData worldGenData
    {
        get { return _worldGenData; }
    }

    ChunkGenerator _chunkGenerator;

    /* Base */
    void Start()
    {
        _chunkGenerator = new ChunkGenerator(this);

        _chunkGenerator.GenerateChunk();
    }

    void Update()
    {
        
    }

    /* External */

    /* Internal */
}

/* TODO LIST */
/*
 *  - Make chunks load in sprites rather than placing random colors
 *  - Make a basic marker that surrounds the tile which the player hovers with its cursor 
 */