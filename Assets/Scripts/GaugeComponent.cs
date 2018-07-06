using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeComponent : MonoBehaviour {

    protected bool _stopFlag;

    public void ResetFlag()
    {
        _stopFlag = false;
    }
}
