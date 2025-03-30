using System.Collections;
using DG.Tweening;
using UnityEngine;
using YG;

public class WateringCan : MonoBehaviour
{
    private float _startYPosition;
    private float _endYPosition;
    
    private Vector3 _startRotation;
    private Vector3 _endRotation;
    
    private Vector3 _rotationOffset;
    private float _moveOffset;
    private float _showAnimationDuration;
    private float _hideAnimationDuration;

    private void Start()
    {
        _rotationOffset = new Vector3(0.0f, 0.0f, 48.0f);
        _moveOffset = 229.0f;
        _showAnimationDuration = 0.8f;
        _hideAnimationDuration = 0.4f;
        
        _startYPosition = transform.localPosition.y;
        _endYPosition = _startYPosition - _moveOffset;

        _startRotation = transform.rotation.eulerAngles;
        _endRotation = _startRotation + _rotationOffset;
        
        Show();
    }

    private void Show()
    {
        DOTween.Sequence()
            .Append(transform.DOLocalMoveY(_endYPosition, _showAnimationDuration))
            .Join(transform.DOLocalRotate(_endRotation, _showAnimationDuration))
            .Play();
    }

    private void Hide()
    {
        DOTween.Sequence()
            .Append(transform.DOLocalMoveY(_startYPosition, _hideAnimationDuration))
            .Join(transform.DOLocalRotate(_startRotation, _hideAnimationDuration))
            .Play();
    }

    private IEnumerator Cooldown()
    {
        Hide();
        yield return new WaitForSeconds(30.0f);
        Show();
    }

    private void OnDropletFalling()
    {
        StopCoroutine(Cooldown());
        StartCoroutine(Cooldown());
    }
    
    private void OnRewardAdv(string id)
    {
        if (id == "droplet") 
            StartCoroutine(Cooldown());
    }
    
    private void OnEnable()
    {
        YG2.onRewardAdv += OnRewardAdv;
        Droplet.OnDropletFalling += OnDropletFalling;
    }

    private void OnDisable()
    {
        YG2.onRewardAdv -= OnRewardAdv;
        Droplet.OnDropletFalling -= OnDropletFalling;
    }
}
