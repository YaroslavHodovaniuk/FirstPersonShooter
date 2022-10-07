using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberKills : MonoBehaviour
{
    private int _kills;

    public void PlusOneDead()
    {
        _kills++;
    }

    public int GetNumberKills()
    {
        return _kills;
    }
}
