using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShakeType
{
    All,Each
}

[CreateAssetMenu(menuName = "SO/TextEffect/Data")]
public class TextEffectSO : ScriptableObject
{
    [TextArea]
    public string _contentsText;
    public float _textSize;

    public Color _textColor;

    public bool _isShake;
    public ShakeType _shakeType;
    public float _shakePower;

}
