using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;

    public int cardCount = 10;

    public float xSpacing = 2f;
    public float ySpacing = 3f;

    public int columnCount = 4;

    public CardGame cardGame;

    void Start()
    {
        for (int i = 0; i < cardCount; i++)
        {
            GameObject obj = Instantiate(cardPrefab, transform);

            // 현재 행과 열
            int row = i / columnCount;
            int column = i % columnCount;

            // 현재 줄의 카드 개수 계산
            int currentRowCardCount =
                Mathf.Min(columnCount, cardCount - row * columnCount);

            // 현재 줄 기준 가운데 정렬
            float startX =
                -(currentRowCardCount - 1) * xSpacing / 2f;

            // 위치 계산
            float x = startX + column * xSpacing;
            float y = -row * ySpacing;

            obj.transform.localPosition =
                new Vector3(x, y, 0);

            Card card = obj.GetComponent<Card>();

            card.cardGame = cardGame;

            cardGame.cards.Add(card);
        }

        cardGame.StartGame();
    }
}