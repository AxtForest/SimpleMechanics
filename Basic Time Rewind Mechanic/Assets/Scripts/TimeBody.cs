using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;

    List<PointTime> pointsTime;

    Rigidbody rb;

    void Start()
    {
        pointsTime = new List<PointTime>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Return))
          StartRewind();

        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();

       
        

    }
    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Record()
    {
        pointsTime.Insert(0,new PointTime(transform.position,transform.rotation));
    }

    void Rewind()
    {
        if (pointsTime.Count > 0)
        {
            PointTime pointTime = pointsTime[0];

            transform.position = pointTime.position;
            transform.rotation = pointTime.rotation;
            pointsTime.RemoveAt(0);
        }
        else
            StopRewind();
    }


    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
