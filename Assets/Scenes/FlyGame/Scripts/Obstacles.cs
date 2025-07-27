using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    [Header("발판 Y 범위")]
    public float highPosY = 1f;
    public float lowPosY  = -1f;

    [Header("구멍 크기 범위")]
    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    [Header("위/아래 오브젝트 레퍼런스")]
    public Transform topObject;
    public Transform bottomObject;

    [Header("가로 간격 패딩")]
    public float widthPadding = 4f;

    /// <summary>
    /// 외부에서 호출해서 장애물 랜덤 배치하는 메서드
    /// </summary>
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize     = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        topObject.localPosition    = new Vector3(0,  halfHoleSize, 0);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize, 0);

        Vector3 placePosition = lastPosition + Vector3.right * widthPadding;
        placePosition.y = Random.Range(lowPosY, highPosY);
        transform.position = placePosition;
        return placePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player 태그가 붙은 오브젝트만 처리
        if (!collision.CompareTag("Player"))
            return;

        // GameManager.Instance가 있으면 점수 추가
        var gm = GameManager.Instance;
        if (gm != null)
        {
            gm.AddScore(1);
        }
        else
        {
            Debug.LogError("[Obstacle] GameManager.Instance is NULL in OnTriggerEnter2D");
        }

      
    }
}
