using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/TextEffect/List")]
public class TextEffectList : ScriptableObject
{
    public List<TextEffectSO> _effects = new List<TextEffectSO>();
}
