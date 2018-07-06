using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Circle_fillGauge_BackgroundControl : MonoBehaviour {

    GameObject child;

    private void Start()
    {
        var children = GetComponentsInChildren<Transform>().Where(t => t.gameObject.tag == "Child");
        child = children.First().gameObject;
    }

    public void ResetFlag()
    {
        child.SendMessage("ResetFlag");
    }
}
