using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameInteraction : BaseInteraction
{
    public SpriteRenderer currentSprite;
    public Sprite newSprite;
    public override void Interact()
    {
        currentSprite.sprite = newSprite;
        Invoke("LoadScene", 1f);

    }

    private void LoadScene()
    {
        SceneManager.LoadScene("MinigameScene");

    }
}
