using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObserverPattern
{
    public class CarData : MonoBehaviour, ISubject
    {
        private List<IObserver> _observerList = new List<IObserver>();

        private float _mileage;
        private float _fuelAmount;

        public void NotifyObservers()
        {
            _observerList.ForEach(o => o.UpdateData(_mileage,_fuelAmount));
        }

        public void RemoveObserver(IObserver observer)
        {
            _observerList.Add(observer);
        }

        public void ResisterObserver(IObserver observer)
        {
            _observerList.Add(observer);
        }

        
        public void UpdateData(float newMileage,float newFuelAmount)
        {
            _mileage = newMileage;
            _fuelAmount = newFuelAmount;
            NotifyObservers();
        }
    }

}

