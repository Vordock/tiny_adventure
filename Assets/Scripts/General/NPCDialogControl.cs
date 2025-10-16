using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogControl : MonoBehaviour
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
    [SerializeField]
    string message;

    void Start()
    {
        dialogCanvas.SetActive(false);

        if (titleText) titleText.text = title;
        if (dialogText) dialogText.text = message;
    }

}