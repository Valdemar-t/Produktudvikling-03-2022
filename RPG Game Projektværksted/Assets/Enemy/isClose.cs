using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isClose : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private float dis;
    [SerializeField] private float distance;
    [SerializeField] private Component desSetter;
    // Start is called before the first frame update
    void Start()
    {
        dis = Vector3.Distance(transform.position, Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (dis >= distance)
        {
        }
    }
}
