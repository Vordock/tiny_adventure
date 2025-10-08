using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogControl : MonoBehaviour
{
    [SerializeField]
    GameObject dialogCanvas;

    [SerializeField]
    TMP_Text dialogText;

    [SerializeField]
    Image imageNPC;

    [Space(10), SerializeField]
    string title;

    void Start()
    {
        dialogCanvas.SetActive(false);
    }

}