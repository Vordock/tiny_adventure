using UnityEngine;

namespace tiny_adventure
{
    [CreateAssetMenu(menuName = "TinyAdventure/NPC Dialogue")]
    public class NPCDialogue : ScriptableObject
    {
        [TextArea] public string[] lines;
    }
}