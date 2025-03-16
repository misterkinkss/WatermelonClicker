using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SmoothScrollRect : ScrollRect
{
    public override void OnScroll(PointerEventData eventData)
    {
        Vector2 scrollTranslated = -eventData.scrollDelta * scrollSensitivity;
        
        if(velocity.y == 0 || Math.Sign(velocity.y) == Math.Sign(scrollTranslated.y))
        {
            velocity += scrollTranslated;
        }
        else
        {
            velocity = Vector2.zero;
        }
    }
}