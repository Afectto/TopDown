using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyPrefab;
    [SerializeField] private int countSpawnEnemy;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private float avoidPlayerRadius;
    
    private Vector3 _playerPosition;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        _playerPosition = playerManager.transform.position;
        for (int i = 0; i < countSpawnEnemy; i++)
        {
            SpawnNewEnemy();
        }
    }

    private void SpawnNewEnemy()
    {
        var randomPoint = GenerateRandomPoint();

        Instantiate(enemyPrefab, randomPoint, quaternion.identity);
    }
    
    private Vector3 GenerateRandomPoint()
    {
        Vector3 randomPoint = GetRandomPointInCameraView();
        while (Vector3.Distance(randomPoint, _playerPosition) < avoidPlayerRadius)
        {
            randomPoint = GetRandomPointInCameraView();
        }

        return randomPoint;
    }

    private Vector3 GetRandomPointInCameraView()
    {
        float randomX = Random.Range(0f, Screen.width);
        float randomY = Random.Range(0f, Screen.height);

        Vector3 randomScreenPos = new Vector3(randomX, randomY, _mainCamera.nearClipPlane);
        Vector3 randomWorldPos = _mainCamera.ScreenToWorldPoint(randomScreenPos);

        return randomWorldPos;
    }
}
