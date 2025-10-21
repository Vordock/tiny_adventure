using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameObject playerPrefab;

    [Header("Pontos de Spawn")]
    [SerializeField] private Transform playerSpawnPointLeft;
    [SerializeField] private Transform playerSpawnPointRight;

    private void Start()
    {
        // Decide o lado baseado no índice do DataManager
        Transform spawnPoint = DataManager.player_spawn_index == 0
            ? playerSpawnPointLeft
            : playerSpawnPointRight;

        GameObject player = SpawnPlayerAtPosition(spawnPoint.position);

        if (player != null)
        {
            GameAction.PlayerSpawned?.Invoke();
        }
        else
        {
            Debug.LogError("Falha ao spawnar o jogador. Prefab não configurado.");
        }
    }

    private GameObject SpawnPlayerAtPosition(Vector2 position)
    {
        if (playerPrefab == null)
        {
            Debug.LogError("PlayerPrefab não atribuído no Inspector!");
            return null;
        }

        return Instantiate(playerPrefab, position, Quaternion.identity);
    }
}