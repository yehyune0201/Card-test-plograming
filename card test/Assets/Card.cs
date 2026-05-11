using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Card : MonoBehaviour
{
    public float rotateY;
    public TextMeshProUGUI text;
    public bool isFront = true;
    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);
    public int number;
    public bool isMatched = false;
    public CardGame cardGame;
   
    public float flipSpeed = 5f;
    public GameObject cardBack;
    public Image frontImage;


    public List<Card> cards = new List <Card>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentY = transform.eulerAngles.y;
        

        if(isFront)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotateY * Time.deltaTime);
            cardBack.SetActive(false);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotateY * Time.deltaTime);
            cardBack.SetActive(true);
        }
        
        
       
    }
    public void ClickCard()
    {
        if(isMatched)
        {
            
        }
        else
        {  
            cardGame.onClickCard(this);
        }
    }

    public void Flip(bool isFront)
    {
        this.isFront = isFront;
    }

    public void SetCardNumber(int newNumber)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        number = newNumber;
        
    }
    public void ChangeColor(Color newColor)
    {
        frontImage.color = newColor;
    }

    public void SetImage(Sprite sprite)
    {
        Debug.Log(sprite.name);

        frontImage.sprite = sprite;
    }
}
