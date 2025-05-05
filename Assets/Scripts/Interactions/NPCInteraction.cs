using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : BaseInteraction
{
    public GameObject dialoguePanel;          // 대화창 패널
    public TextMeshProUGUI dialogueText;      // 대화 텍스트

    private string[] dialogueLines;

    private int currentLineIndex = 0;

    private void Start()
    {
        dialogueLines = new string[]
        {
          "If you pass 7 obstacles in the minigame",
          "I'm gonna give you 1 coin",
          "If you want to try, go right"
        };
    }

    public override void Interact()
    {
        base.Interact();
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                currentLineIndex = 0;
                dialoguePanel.SetActive(true);
                dialogueText.text = dialogueLines[currentLineIndex];
            }
            else
            {
                currentLineIndex++;
                if (currentLineIndex < dialogueLines.Length)
                {
                    dialogueText.text = dialogueLines[currentLineIndex];
                }
                else
                {
                    // 대화 종료
                    dialoguePanel.SetActive(false);
                }
            }
        }

        

        //SceneManager.LoadScene("MinigameScene");
    }

    public override void HideInteractionPrompt()
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(false);
            dialoguePanel.SetActive(false);
            currentLineIndex = 0;
        }
    }
}
