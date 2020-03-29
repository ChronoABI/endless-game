using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PlayerDistandSpawnLevelPart = 30f;
    [SerializeField] Transform levelPartStart;  
    [SerializeField] List<Transform> levelPartList;
    [SerializeField] GameObject Player;
    private Vector2 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        SpawnLevelPart(); SpawnLevelPart();
        int startingSpawnLevelParts = 5;
        for(int i = 0; i<startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }
    private void Update()
    {
        if (Vector2.Distance(Player.transform.position, lastEndPosition) < PlayerDistandSpawnLevelPart)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0,levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart,lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart,Vector2 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;

    }
}
