using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	Transform player; // Referência ao transform do jogador
	public float smoothSpeed = 0.125f; // Velocidade de suavização
	public Vector3 offset; // Deslocamento da câmera em relação ao jogador

	[Header("Limites da câmera")]
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	void OnEnable()
	{
		ActionManager.PlayerSpawned += SetPlayer;
	}

	void OnDisable()
	{
		ActionManager.PlayerSpawned -= SetPlayer;
	}

	void SetPlayer()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate()
	{
		if (player != null)
		{
			// Posição desejada com offset
			Vector3 desiredPosition = player.position + offset;

			// Suavização
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

			// Aplica limites
			float clampedX = Mathf.Clamp(smoothedPosition.x, minX, maxX);
			float clampedY = Mathf.Clamp(smoothedPosition.y, minY, maxY);

			// Atualiza posição da câmera mantendo o Z original
			transform.position = new Vector3(clampedX, clampedY, transform.position.z);
		}
	}
}