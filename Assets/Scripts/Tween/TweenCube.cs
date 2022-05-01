using UnityEngine;
using DG.Tweening;
public class TweenCube : MonoBehaviour
{
    [SerializeField]
    private float _duration;
    [SerializeField]
    private Vector3 _endValue;
    private void Start()
    {
        transform.DOMove(_endValue, _duration).From();

    }
}