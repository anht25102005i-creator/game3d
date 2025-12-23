using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuLyVaChan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            GameManager.Instance.QuaCheckPoint();
        }
        if(other.gameObject.tag==("WinPoint"))
        {
            GameManager.Instance.QuaWinPoint();
        }
    }
}
