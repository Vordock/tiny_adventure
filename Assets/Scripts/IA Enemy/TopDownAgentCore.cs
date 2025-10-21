using UnityEngine;

public enum AgentState { Patrol, Chase, Attack }

public class TopDownAgentCore : MonoBehaviour
{

    public Vector2 agentDirection;
    public Vector2 lastDirection;
}