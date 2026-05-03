using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab; // 카드 프리팹
    public int cardCount = 5;     // 인스펙터에서 설정

    void Start()
    {
        for (int i = 0; i < cardCount; i++)
        {
            Instantiate(cardPrefab, transform);
        }
    }
}