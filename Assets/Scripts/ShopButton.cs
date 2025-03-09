using TMPro;
using UnityEngine;

public abstract class ShopButton : MonoBehaviour
{
    [SerializeField] protected ScoreCounter scoreCounter;
    [SerializeField] protected TMP_Text priceText;
    [SerializeField] protected double price;

    public abstract void Buy();
}