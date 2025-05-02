using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseInteraction : MonoBehaviour
{
    //상호작용 가능한 거리
    protected float interactionDistance = 3f;
    public float InteractionDistance { get { return interactionDistance; } }

    //근처에 있는지 여부 판단
    protected bool isPlayerNear = false;
    public bool IsPlayerNear { get { return isPlayerNear; } }

    //플레이어 할당
    public Transform player;

    protected virtual void Awake()
    {
          
    }

    protected virtual void Update()
    {
        //대상과 플레이어 사이 거리 판단
        float distance = Vector3.Distance(transform.position, player.position);

        //플레이어가 일정 거리 내 들어오면,
        if (distance <= interactionDistance)
        {
            //bool값을 변환하고 상호작용 UI 표시
            if (!isPlayerNear)
            {
                isPlayerNear = true;
                ShowInteractionPrompt();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact(); // 상호작용 실행
            }
        }
        else //거리보다 멀어지면 bool값 변환
        {
            if (isPlayerNear)
            {
                isPlayerNear = false;
                HideInteractionPrompt(); // 상호작용 UI 숨김
            }
        }    
    }

    void ShowInteractionPrompt()
    {
        Debug.Log("Press F to interact.");
    }

    void HideInteractionPrompt()
    {
        Debug.Log("Interaction prompt hidden.");
    }

    void Interact()
    {
        Debug.Log("상호작용 중!");
    }
}
