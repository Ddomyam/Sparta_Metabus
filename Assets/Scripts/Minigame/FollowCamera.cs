using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;

        //offset의 거리를 계산. 카메라의 x축과 타겟의 x축 비교
        offsetX = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        //pos에 카메라 위치 할당
        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
