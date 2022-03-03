using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isClose : MonoBehaviour
{
    [SerializeField]private float dis;
    [SerializeField] private float distance;
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private GameObject[] savedEnemy;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in Enemy)
        {
            foreach(GameObject SGO in savedEnemy)
            {
                if (go == SGO)
                {

                }
            }
        }
        int i = 0;
        foreach (GameObject go in Enemy)
        {
            dis = Vector3.Distance(transform.position, Enemy[i].transform.position);
            if (dis >= distance)
            {
                Enemy[i].SetActive(false);
            }
            else if (dis <= distance)
            {
                Enemy[i].SetActive(true);
            }
            i++;
        }
    }
}
