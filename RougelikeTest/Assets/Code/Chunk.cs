using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    /* Fields */
    World _world;

    GameObject _chunkGO;

    /* Base */
    public Chunk(World inWorld)
    {
        _world = inWorld;

        _chunkGO = new GameObject()
        {
            name = "Chunk"
        };

        MeshRenderer renderer = _chunkGO.AddComponent<MeshRenderer>();
        MeshFilter filter = _chunkGO.AddComponent<MeshFilter>();

        int chunkSize = inWorld.worldGenData.chunkSize;
        int tileCount = chunkSize * chunkSize;
        int vertexSize = chunkSize + 1;
        int vertexCount = vertexSize * vertexSize;
        int triangleCount = tileCount * 2;

        Vector3[] vertices = new Vector3[vertexCount];
        Vector3[] normals = new Vector3[vertexCount];
        Vector2[] UVs = new Vector2[vertexCount];
        int[] triangles = new int[triangleCount * 3];

        for (int y = 0; y < vertexSize; y++)
            for (int x = 0; x < vertexSize; x++)
            {
                vertices[y * vertexSize + x] = new Vector3(x, y, 0);
                normals[y * vertexSize + x] = Vector3.up;
                UVs[y * vertexSize + x] = new Vector2((float)x / chunkSize, (float)y / chunkSize);
            }

        for (int y = 0; y < chunkSize; y++)
            for (int x = 0; x < chunkSize; x++)
            {
                int currentTileID = y * chunkSize + x;
                int triVertOffset = y * vertexSize + x;
                int triangleOffset = currentTileID * 6;

                triangles[triangleOffset + 0] = triVertOffset;
                triangles[triangleOffset + 1] = triVertOffset + vertexSize;
                triangles[triangleOffset + 2] = triVertOffset + vertexSize + 1;

                triangles[triangleOffset + 3] = triVertOffset;
                triangles[triangleOffset + 4] = triVertOffset + vertexSize + 1;
                triangles[triangleOffset + 5] = triVertOffset + 1;
            }


        filter.mesh = new Mesh()
        {
            vertices = vertices,
            normals = normals,
            uv = UVs,
            triangles = triangles
        };

        int textureSize = chunkSize * 64;

        Color[] newColorMap = new Color[textureSize * textureSize];
        for (int y = 0; y < textureSize; y++)
            for (int x = 0; x < textureSize; x++)
                newColorMap[y * textureSize + x] = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f));

        if (!renderer.material.mainTexture)
            renderer.material.mainTexture = new Texture2D(textureSize, textureSize);

        ((Texture2D)renderer.material.mainTexture).filterMode = FilterMode.Point;
        ((Texture2D)renderer.material.mainTexture).wrapMode = TextureWrapMode.Clamp;
        ((Texture2D)renderer.material.mainTexture).SetPixels(newColorMap);
        ((Texture2D)renderer.material.mainTexture).Apply();
    }

    /* External */

    /* Internal */
}