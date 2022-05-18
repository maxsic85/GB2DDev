using UnityEngine;

public class CurrencyController
{
    private CurrencyView _currencyView;

    public CurrencyController(CurrencyView currencyView, Transform placeUI)
    {
        _currencyView = GameObject.Instantiate(currencyView, placeUI);
    }

    public void CloseWindow()
    {
        GameObject.Destroy(_currencyView.gameObject);
    }
}
