using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObserverPattern
{
    public interface ISubject
    {
        void ResisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();

    }

    public interface IObserver
    {
        void UpdateData(float mileage,float amountFuel);
    }
}

