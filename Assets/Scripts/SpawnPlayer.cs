using Unity.Cinemachine;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameObject playerPrefab;

    [Header("Pontos de Spawn")]
    [SerializeField] private Transform playerSpawnPointLeft;
    [SerializeField] private Transform playerSpawnPointRight;

    [SerializeField] private CinemachineCamera cinemaCam;

    private void Start()
    {
        // Decide o lado baseado no índice do DataManager
        Transform spawnPoint = DataManager.player_spawn_index == 0
            ? playerSpawnPointLeft
            : playerSpawnPointRight;

        if (spawnPoint != null)
        {
            SpawnPlayerAtPosition(spawnPoint.position);
        }

        else
        {
            Debug.LogError("Falha ao spawnar o jogador. Prefab não configurado.");
        }
    }

    private void SpawnPlayerAtPosition(Vector3 position)
    {
        if (playerPrefab == null)
        {
            Debug.LogError("No PlayerPrefab found!");
            return;
        }

        GameObject player = Instantiate(playerPrefab, position, Quaternion.identity);
        ActionManager.PlayerSpawned?.Invoke();

        if (cinemaCam) cinemaCam.Target.TrackingTarget = player.transform;
    }
}