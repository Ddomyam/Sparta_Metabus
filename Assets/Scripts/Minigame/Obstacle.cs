using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 2f;
    public float holeSizeMax = 4f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    //장애물을 배치하는 함수
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obtaclCount)
    {
        //구멍크기를 랜덤으로 정함
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        //그 구멍의 절반 크기
        float halfHoleSize = holeSize / 2;

        //각 파이프를 구멍의 절반크기만큼 이동시킴.
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        //각 파이프의 간격 설정. 마지막위치에 x값을 간격만큼 더함.
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        //랜덤한 높이를 가지게함.
        placePosition.y = Random.Range(lowPosY, highPosY);

        //전체 장애물 오브젝트 이동
        transform.position = placePosition;

        //다음 장애물의 기준으로 사용
        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
            gameManager.AddScore(1);
    }
}
