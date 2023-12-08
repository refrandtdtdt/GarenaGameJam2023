using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject[] terrainPrefabs;
    public int gridX = 16;
    public int gridY = 16;
    public float playerDetectionDistance = 4f;

    public Transform player; // Reference to the player's transform

    private List<GameObject> generatedTerrain = new List<GameObject>();
    private float lastGeneratedX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //for (int x = 0; x < 8; x++ )
        //{
        //    int rand_i = Random.Range(0, terrainPrefabs.Length);
        //    GameObject terrainPrefab = terrainPrefabs[rand_i];

        //    Vector3 spawnPosition = new Vector3(x* gridX, 0, 0);

        //    GameObject instantiatedTerrain = Instantiate(terrainPrefab, spawnPosition, Quaternion.identity);

        //    instantiatedTerrain.transform.parent = transform;
        //}
        GenerateInitialTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGenerateTerrain();
    }

    void GenerateInitialTerrain()
    {
        for (int x = 0; x < 8; x++)
        {
            GenerateTerrainAtPosition(x * gridX);
        }

        lastGeneratedX = (8 - 1) * gridX;
    }
    void GenerateTerrainAtPosition(float xPosition)
    {
        int randIndex = Random.Range(0, terrainPrefabs.Length);
        GameObject terrainPrefab = terrainPrefabs[randIndex];

        Vector3 spawnPosition = new Vector3(xPosition, 0, 0);
        GameObject instantiatedTerrain = Instantiate(terrainPrefab, spawnPosition, Quaternion.identity);

        instantiatedTerrain.transform.parent = transform;
        generatedTerrain.Add(instantiatedTerrain);
    }

    void CheckGenerateTerrain()
    {
        float playerX = player.position.x;

        // Check if the player is within the detection distance of the last generated terrain
        if (playerX > lastGeneratedX - playerDetectionDistance * gridX)
        {
            // Generate new terrain
            GenerateTerrainAtPosition(lastGeneratedX + gridX);

            // Remove the terrain behind the player
            if (generatedTerrain.Count > 1)
            {
                Destroy(generatedTerrain[0]);
                generatedTerrain.RemoveAt(0);
            }

            lastGeneratedX += gridX;
        }
    }
}
