using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponsManager : MonoBehaviour
{
    public GameObject Gun1;
    public GameObject Gun2;
    public GameObject Gun3;
    public GameObject Gun4;
    public GameObject Gun5;
    [Range(1, 5)]
    public int gunsNum;

    void SetGunAmount(int gunsNum)
    {
        if (gunsNum == 1)
        {
            CenterGunActive(true);
            Left1Right1Active(false);
            Left2Right2Avtive(false);
        } else if (gunsNum == 2)
        {
            CenterGunActive(false);
            Left1Right1Active(true);
            Left2Right2Avtive(false);
        } else if (gunsNum == 3)
        {
            CenterGunActive(true);
            Left1Right1Active(true);
            Left2Right2Avtive(false);
        } else if (gunsNum == 4)
        {
            CenterGunActive(false);
            Left1Right1Active(true);
            Left2Right2Avtive(true);
        } else if (gunsNum == 5)
        {
            CenterGunActive(true);
            Left1Right1Active(true);
            Left2Right2Avtive(true);
        }
    }

    public void AddGun(int upgradeValue)
    {
        gunsNum += upgradeValue;
        SetGunAmount(gunsNum);
    }

    void Start()
    {
        SetGunAmount(gunsNum);
    }

    void CenterGunActive(bool TorF)
    {
        Gun1.SetActive(TorF);
    }

    void Left1Right1Active(bool TorF)
    {
        Gun2.SetActive(TorF);
        Gun3.SetActive(TorF);
    }

    void Left2Right2Avtive(bool TorF)
    {
        Gun4.SetActive(TorF);
        Gun5.SetActive(TorF);
    }


}
