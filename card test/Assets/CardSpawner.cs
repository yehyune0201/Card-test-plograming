using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab; // 카드 프리팹
    public int cardCount = 5;     // 인스펙터에서 설정

    public float spacing = 2f;

    public CardGame cardGame;

    void Start()
    {
        for (int i = 0; i < cardCount; i++)
        {
            GameObject obj = Instantiate(cardPrefab, transform);

            Card card = obj.GetComponent<Card>();

            card.cardGame = cardGame;

            cardGame.cards.Add(card);
        }

        cardGame.StartGame();
    }

}
