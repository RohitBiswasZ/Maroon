using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public int altitude = 256;
    public Vector3Int chunkDims = new Vector3Int(16,32,16);

    public void Generate(Vector3Int cordinate)
    {
        GameObject chunk = new GameObject("Chunk" + cordinate);
        chunk.transform.SetParent(gameObject.transform);
        chunk.transform.position = cordinate;

        for (int i = 0; i < altitude / chunkDims.y; i++)
        {
            int norY = i * chunkDims.y;
            Vector3Int subCordinate = new Vector3Int(cordinate.x, norY, cordinate.y);
            GameObject subChunk = new GameObject("SubChunks" + subCordinate);
            subChunk.transform.SetParent(chunk.transform);
            subChunk.transform.position = subCordinate;
            Debug.Log("SubChunk Index: "+ (i + 1) + " , Position: " + subCordinate);
        }
    }

    public void Start()
    {
        for (int x = 0; x < 8; x++) {
            for (int z = 0; z < 8; z++) {
                var pos = new Vector3Int(x * chunkDims.x, 0, z * chunkDims.z);
                Generate(pos);
            }
        }
    }
}
