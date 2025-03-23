using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Image settingsButtonImage;
    [SerializeField] private Transform settingsButtonTransform;
    [SerializeField] private Transform settingsPanelTransform;
    
    private Vector3 _startSettingsButtonPosition;
    private Vector3 _startSettingsPanelPosition;
    private Vector3 _endSettingsButtonPosition;
    private Vector3 _endSettingsPanelPosition;

    private float _moveAnimationDuration;
    private float _fadeAnimationDuration;

    private void Start()
    {
        _startSettingsButtonPosition = settingsButtonTransform.localPosition;
        _startSettingsPanelPosition = settingsPanelTransform.localPosition;
        
        _endSettingsButtonPosition = _startSettingsButtonPosition + new Vector3(0, 100, 0);
        _endSettingsPanelPosition = _startSettingsPanelPosition + new Vector3(250, 0, 0);

        _moveAnimationDuration = 0.5f;
        _fadeAnimationDuration = 0.2f;
    }

    public void OpenAnimation()
    {
        DOTween.Sequence()
            .Append(settingsButtonTransform.DOLocalMove(_endSettingsButtonPosition, _moveAnimationDuration))
            .Join(settingsButtonImage.DOFade(0.0f, _fadeAnimationDuration))
            .Join(settingsPanelTransform.DOLocalMove(_endSettingsPanelPosition, _moveAnimationDuration))
            .Play();
    }
    
    public void CloseAnimation()
    {
        DOTween.Sequence()
            .Append(settingsButtonTransform.DOLocalMove(_startSettingsButtonPosition, _moveAnimationDuration))
            .Join(settingsButtonImage.DOFade(1.0f, _fadeAnimationDuration))
            .Join(settingsPanelTransform.DOLocalMove(_startSettingsPanelPosition, _moveAnimationDuration))
            .Play();
    }
}
