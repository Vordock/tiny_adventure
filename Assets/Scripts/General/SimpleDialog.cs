using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleDialog : MonoBehaviour
{
    [SerializeField]
    GameObject dialogCanvas;

    [SerializeField]
    TMP_Text titleText;

    [SerializeField]
    TMP_Text dialogText;

    [SerializeField]
    Image imageNPC;

    [Space(10), SerializeField]
    string title;

    [TextArea, SerializeField]
    string message;

    void Start()
    {
        dialogCanvas.SetActive(false);

        if (titleText) titleText.text = title;
        if (dialogText) dialogText.text = message;
    }

    public void ActiveDialog()
    {
        Debug.Log($"Dialog triggered with: {gameObject.name}");

        if (!dialogCanvas.activeSelf)
        {
            dialogCanvas.SetActive(true);
            DataManager.playerIsTalking = true;
            GameAction.HoldPlayerMovement?.Invoke(true);
        }

        else
        {
            dialogCanvas.SetActive(false);
            DataManager.playerIsTalking = false;
            GameAction.HoldPlayerMovement?.Invoke(false);
        }
    }
}