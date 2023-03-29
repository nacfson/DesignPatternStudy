using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{
    public static class Define
    {
        public static Camera MainCam
        {
            get
            {
                if(_mainCam == null)
                {
                    _mainCam = Camera.main;
                }
                return _mainCam;
            }
        }
        public static Camera _mainCam;

    }
}
