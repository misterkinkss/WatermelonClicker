using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorfulScreen : MonoBehaviour
{
    private readonly Color[] _colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };

    public static event Action OnBonusEnded;
    
    [SerializeField] private Image colorfulScreenImage;
    [SerializeField] private AudioSource audioSource;
    [SerializeField, Range(0, 1)] private float speed;
    [SerializeField, Range(0, 1)] private float alpha;

    private float _timeUntilDroplet;
    private float _timer;
    private float _t;
    private int _lastPos;
    private int _index0;
    private int _index1;
    private bool _isActive;

    private void Update()
    {
        if (!_isActive) return;
        
        _timer += Time.deltaTime;
        _t = _timer / speed;
        Color lerp = Color.Lerp(_colors[_index0], _colors[_index1], _t);
        colorfulScreenImage.color = new Color(lerp.r, lerp.b, lerp.g, alpha);

        if (_t >= 1.0f)
        {
            SelectNextColor();
        }
    }
    
    public IEnumerator ActiveColorfulScreenBonus()
    {
        colorfulScreenImage.gameObject.SetActive(true);
        _isActive = true;
        audioSource.Play();
        yield return new WaitForSeconds(12.5f);
        _isActive = false;
        colorfulScreenImage.gameObject.SetActive(false); 
        
        OnBonusEnded?.Invoke();
    }

    private void SelectNextColor()
    {
        _index0 = _index1;
        _index1 = _index1 < _colors.Length - 1 ? _index1 + 1 : 0;
        _timer = 0f;
    }
 
}