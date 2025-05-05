using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : BaseInteraction
{
    public override void Interact()
    {
        base.Interact();
        SceneManager.LoadScene("MinigameScene");
    }
}
