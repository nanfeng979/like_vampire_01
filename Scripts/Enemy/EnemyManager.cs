using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct WallBorder {
    public Vector2 top;
    public Vector2 bottom;
    public Vector2 left;
    public Vector2 right;
}

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private List<GameObject> EnemyList = new List<GameObject>();

    private float EnemyCreateTime = 1.0f;
    private float EnemyCreateTimer = 0.0f;

    private float ScreenTop;
    private float ScreenBottom;
    private float ScreenLeft;
    private float ScreenRight;
    private WallBorder wallBorder;

    void Start() {
        // ScreenTop 是相机的高度
        ScreenTop = Camera.main.orthographicSize;
        // ScreenBottom 是相机的高度
        Debug.Log(ScreenTop);
    }


    void Update()
    {
        EnemyCreateTimer += Time.deltaTime;
        
        if (EnemyCreateTimer >= EnemyCreateTime)
        {
            CreateEnemy();
            EnemyCreateTimer -= EnemyCreateTime;
        }
        
    }

    private void CreateEnemy()
    {
        GameObject Enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        EnemyList.Add(Enemy);
    }
    
    private void wallBorderRandom() {
        // wallBorder.top = new 

    }
    


}
