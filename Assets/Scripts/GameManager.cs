using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float thoiGianChoPhetVeDich = 30f;
    public bool ketThucGame = false;
    public bool winGame=false;
    private static GameManager instance;
    public GameObject gameOverObject;
    public GameObject timeGameobject;
    public GameObject winGameObject;
    [SerializeField]

    private float thoiGianHoiKhiQuaCheckPoint=31;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject gameManagerGameObject = new GameObject("GameManager");
                    instance = gameManagerGameObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Update()
    {
        if (!ketThucGame)
        {
            thoiGianChoPhetVeDich -= Time.deltaTime;
            Debug.Log(thoiGianChoPhetVeDich);

            if (thoiGianChoPhetVeDich <= 0)
            {
                timeGameobject.SetActive(false);
                gameOverObject.SetActive(true);
                KetThucGame();
            }
        }
        if(winGame)
        {
            timeGameobject.SetActive(false);
            winGameObject.SetActive(true);
        }
    }

    public void KetThucGame()
    {
        ketThucGame = true;
    }
    public void QuaCheckPoint()
    {
        if(!ketThucGame)
        {
            thoiGianChoPhetVeDich = thoiGianHoiKhiQuaCheckPoint;
        }
    }
    public void QuaWinPoint()
    {
        if(!ketThucGame)
        {
          winGame = true;
        }
    }
}
