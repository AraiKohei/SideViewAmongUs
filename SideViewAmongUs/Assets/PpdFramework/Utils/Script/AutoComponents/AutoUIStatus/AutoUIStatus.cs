using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPD
{
    public class AutoUIStatus : MonoBehaviour
    {
        public bool activateOnAwake = false;
        public UIStatus[] statusList = new UIStatus[] { new UIStatus("Default") };

        private int _currentStatus = -1;

        private void Start()
        {
            if (activateOnAwake)
            {
                ActivateStatus(0);
            }
        }

        public void ActivateStatus(string name)
        {
            for (int id = 0; id < statusList.Length; id++)
            {
                if (statusList[id].StatusName == name)
                {
                    ActivateStatus(id);
                    return;
                }
            }
        }
        public void DeActivateStatus(string name)
        {
            for (int id = 0; id < statusList.Length; id++)
            {
                if (statusList[id].StatusName == name)
                {
                    DeActivateStatus(id);
                    return;
                }
            }
        }

        public void ActivateStatus(int id)
        {
            if (_currentStatus != -1)
            {
                statusList[_currentStatus].Deactivate();
            }
            statusList[id].Activate();
        }

        public void DeActivateStatus(int id)
        {
            if (_currentStatus != -1)
            {
                statusList[_currentStatus].Deactivate();
            }
            statusList[id].Deactivate();
        }
    }
}