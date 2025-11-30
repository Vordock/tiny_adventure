using UnityEngine;
using System;
using TMPro;

namespace tiny_adventure
{
    public class DialogueSystem : MonoBehaviour
    {
        public static DialogueSystem Instance;

        [Header("UI")]
        [SerializeField] private GameObject dialogueUI;
        [SerializeField] private TMP_Text dialogueText;

        private string[] currentLines;
        private int index;
        private Action onFinish;

        private bool isActive = false;

        private void Awake()
        {
            Instance = this;
            dialogueUI.SetActive(false);
        }

        // >>> Requested property
        public bool DialogueIsOpen => isActive;

        public void StartDialogue(NPCDialogue dialogue, Action onEnd = null)
        {
            if (dialogue == null || dialogue.lines == null || dialogue.lines.Length == 0)
            {
                Debug.LogWarning("Dialogue is empty.");
                return;
            }

            index = 0;
            currentLines = dialogue.lines;
            onFinish = onEnd;
            isActive = true;

            dialogueUI.SetActive(true);
            dialogueText.text = currentLines[index];
        }

        public void NextLine()
        {
            if (!isActive) return;

            index++;

            if (index >= currentLines.Length)
            {
                EndDialogue();
                return;
            }

            dialogueText.text = currentLines[index];
        }

        public void StartSingleLine(string line, Action onEnd = null)
        {
            if (string.IsNullOrEmpty(line))
                return;

            currentLines = new string[] { line };
            index = 0;
            onFinish = onEnd;
            isActive = true;

            dialogueUI.SetActive(true);
            dialogueText.text = line;
        }

        public void EndDialogue()
        {
            dialogueUI.SetActive(false);
            isActive = false;
            onFinish?.Invoke();
        }
    }
}
