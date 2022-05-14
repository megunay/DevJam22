using UnityEngine;

public class JoystickMask : MonoBehaviour
{
    [SerializeField] private RectTransform _outerTransform;
    [SerializeField] private RectTransform _innerTransform;
    [SerializeField] private RectTransform _maskTransform;

    private Vector2 _initialMaskPos;

    private void Awake()
    {
        _initialMaskPos = _maskTransform.anchoredPosition;
    }

    void Update()
    {
        Vector2 outerAnchor = _outerTransform.anchoredPosition;
        Vector2 innerAnchor = _innerTransform.anchoredPosition;
        Vector2 maskAnchor = _maskTransform.anchoredPosition;

        maskAnchor.x = innerAnchor.x;
        maskAnchor.y = innerAnchor.y;

        _maskTransform.anchoredPosition = maskAnchor;

        outerAnchor.x = _initialMaskPos.x - maskAnchor.x;
        outerAnchor.y = _initialMaskPos.y - maskAnchor.y;

        _outerTransform.anchoredPosition = outerAnchor;
    }
}
