using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator
{
    /* Fields */
    World _world;

    /* Base */
    public ChunkGenerator(World inWorld)
    {
        _world = inWorld;
    }

    /* External */
    public Chunk GenerateChunk()
    {
        Chunk newChunk = new Chunk(_world);

        return newChunk;
    }

    /* Internal */
}