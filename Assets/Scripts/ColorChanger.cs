using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _targetColor;

    private SpriteRenderer _renderer;
    private Color _startColor;

    public void ChangeToAllert()
    {
        _renderer.color = _targetColor;
    }

    public void ChangeToQuiet()
    {
        _renderer.color = _startColor;
    }

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _startColor = _renderer.color;
    }
}
