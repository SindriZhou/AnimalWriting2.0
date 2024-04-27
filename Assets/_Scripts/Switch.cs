using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject object1;

    public void isSwitch()
    { object1.SetActive(!object1.activeSelf);
    }
}
