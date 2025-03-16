using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    private Label _textL1;
    private Label _textL2;

    private void Start()
    {
        VisualElement _document = GetComponent<UIDocument>().rootVisualElement;
        _textL1 = _document.Q<Label>("Speaker");
        _textL2 = _document.Q<Label>("TestTextBox");

        _textL2.text = "test";
    }
}
