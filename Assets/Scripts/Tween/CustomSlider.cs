
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomSlider : Slider
{

    public static string ChangeSliderType => nameof(_animationSliderType);
    public static string CurveEase => nameof(_curveEase);
    public static string Duration => nameof(_duration);
    [SerializeField]
    private AnimationSliderType _animationSliderType = AnimationSliderType.CHANGESCALE;
    [SerializeField]
    private Ease _curveEase = Ease.InBack;
    [SerializeField]
    private float _duration = 3.0f;
    private float _strength = 30.0f;
    private RectTransform _rectTransform;
    protected override void Awake()
    {
        base.Awake();
        _rectTransform = GetComponent<RectTransform>();
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        ActivateAnimation();
    }
    private void ActivateAnimation()
    {
        switch (_animationSliderType)
        {
            case AnimationSliderType.CHANGESCALE:
                _rectTransform.DOScaleX(_strength*0.1f,_duration).SetEase(_curveEase);
                break;
            case AnimationSliderType.CHANGEPOSITION:
                _rectTransform.DOShakeAnchorPos(_duration, Vector2.one *
_strength).SetEase(_curveEase);
        break;
        }
    }
}
