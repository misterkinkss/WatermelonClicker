using TMPro;
using UnityEngine;

public abstract class ShopButton : MonoBehaviour
{
    public Watermelon watermelon;
    public TMP_Text priceText;
    public GameObject decoration;
    public int price;

    public abstract void Buy();
}