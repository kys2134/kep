using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [Header("노트 프리팹들 (Up, Down, Left, Right 순서대로)")]
    public GameObject[] arrowPrefabs;      // 배열로 4개 프리팹을 할당합니다

    [Header("스폰 포인트들 (Up, Down, Left, Right 순서대로)")]
    public Transform[] spawnPoints;        // 배열로 4개 Transform을 할당합니다

    [Header("스폰 간격(초)")]
    public float spawnInterval = 1f;

    private float timer;
    public AudioSource musicSource;

    void Update()
    {
        if (musicSource != null && !musicSource.isPlaying)
            return;
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRandomNote();
            timer = 0f;
        }
    }

    void SpawnRandomNote()
    {
        if (arrowPrefabs.Length != 4 || spawnPoints.Length != 4)
        {
            Debug.LogError("NoteSpawner: arrowPrefabs와 spawnPoints 배열 크기를 모두 4로 맞춰 주세요!");
            return;
        }

        // 0~3 중 랜덤 인덱스 뽑기
        int i = Random.Range(0, 4);

        // 프리팹과 스폰 위치 가져오기
        GameObject prefab = arrowPrefabs[i];
        Transform point = spawnPoints[i];

        // 인스턴스화
        GameObject note = Instantiate(prefab, point.position, Quaternion.identity, transform);
        
        // NoteObject 컴포넌트에 방향값 전달
        var noteObj = note.GetComponent<NoteObject>();
        if (noteObj != null)
            noteObj.noteDirection = GetDirectionByIndex(i);
    }

    string GetDirectionByIndex(int i)
    {
        switch (i)
        {
            case 0: return "Up";
            case 1: return "Down";
            case 2: return "Left";
            case 3: return "Right";
        }
        return "";
    }
}