using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporteZone : MonoBehaviour
{
    public int teleportIndex = 0;

    public int newSceneIndex = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (teleportIndex == 0)
            {
                DataManager.player_spawn_index = 0;

                SceneManager.LoadScene(newSceneIndex);
            }
            else
            {
                DataManager.player_spawn_index = 1;

                SceneManager.LoadScene(newSceneIndex);
            }
        }
    }
}
