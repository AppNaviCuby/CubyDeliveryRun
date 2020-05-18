using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmoriInfor : MonoBehaviour
{

    Dictionary<GameObject, int> ObstacleWeightList = new Dictionary<GameObject, int>();

    GameObject TargetManager;

    TargetManager Targetscript;

    public int FirstOmoriMass;
    public int OmoriMass;


    int unitychanObstacleWeight = 0;
    bool OmoriOnFloorFlag = false;

    FallDownFloor DownFloorOmori;
    // Start is called before the first frame update
    void Start()
    {
        TargetManager = GameObject.Find("TargetManager");
        Targetscript = TargetManager.GetComponent<TargetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        unitychanObstacleWeight = Targetscript.weight;
    }

    /*public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FallDownFloor")
        {
            DownFloorOmori = other.gameObject.GetComponent<FallDownFloor>();
            OmoriOnFloorFlag = true;
        }
        if (other.gameObject.tag == "Character")
        {
            ObstacleWeightList.Add(other.gameObject, unitychanObstacleWeight);
            Debug.Log("Character on");
        }
        if (other.gameObject.tag == "Obstacle")
        {
            ObstacleWeightList.Add(other.gameObject, unitychanObstacleWeight);
        }*/


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FallDownFloor")
        {
            DownFloorOmori = other.gameObject.GetComponent<FallDownFloor>();
            OmoriOnFloorFlag = true;
        }
        if (other.gameObject.tag == "Character")
        {
            ObstacleWeightList.Add(other.gameObject, unitychanObstacleWeight);
            Debug.Log("Character on");
        }
        if (other.gameObject.tag == "Obstacle")
        {
            ObstacleWeightList.Add(other.gameObject, unitychanObstacleWeight);
        }


        /* if (other.gameObject.tag == "Obstacle")
         {

             Debug.Log("お守りに触れた");
             int OmoriWeight = other.gameObject.GetComponent<OmoriInfor>().OmoriMass;
             ObstacleWeightList.Add(other.gameObject, OmoriWeight);
         }*/

        TotalObstacleWeightCalc();

        if (OmoriOnFloorFlag)
        {
            DownFloorOmori.GetOmoriMassUpdate(this.gameObject, OmoriMass);
        }
    }

    /* public void OnTriggerExit2D(Collider2D other)
     {
         ObstacleWeightList.Remove(other.gameObject);
         Debug.Log("Character off");
         TotalObstacleWeightCalc();
         if (OmoriOnFloorFlag)
         {
             DownFloorOmori.GetOmoriMassUpdate(this.gameObject, OmoriMass);
         }
     }*/

    public void OnCollisionExit2D(Collision2D other)
    {
        ObstacleWeightList.Remove(other.gameObject);
        Debug.Log("Character off");
        TotalObstacleWeightCalc();
        if (OmoriOnFloorFlag)
        {
            DownFloorOmori.GetOmoriMassUpdate(this.gameObject, OmoriMass);
        }
    }

    void TotalObstacleWeightCalc()
    {
        int ObjectObstacleWeight = 0;
        foreach (int Value in ObstacleWeightList.Values)
        {
            ObjectObstacleWeight += Value;
        }
        OmoriMass = ObjectObstacleWeight + FirstOmoriMass;
    }


}
