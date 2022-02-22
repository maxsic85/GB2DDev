using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Window _window;
    [SerializeField] private Text _text;

    void Start()
    {
        _button.onClick.AddListener(OpenWindow);
        _window.gameObject.SetActive(false);
    }

    private void OpenWindow()
    {
        //_window.gameObject.SetActive(true);
        //_window.Show();
        _text.DOText("Some powerful hint about yout game", 1);
    }
}