using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;
using TMPro;
public class ObserverManager : MonoBehaviour, IObserver
{
    [SerializeField] CarData _carData;
    [SerializeField] private TextMeshProUGUI _textMileage;
    [SerializeField] private TextMeshProUGUI _textAmountFuel;

    public void UpdateData(float mileage, float amountFuel)
    {
        _textMileage.text = mileage.ToString();
        _textAmountFuel.text = amountFuel.ToString();
    }

    private void OnEnable()
    {
        _carData.ResisterObserver(this);
    }

    private void OnDisable()
    {
        _carData.RemoveObserver(this);
    }

}
