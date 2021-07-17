using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class movement : Agent
{
    public Rigidbody rb;
    public float f_force = 500;
    public float moveSpeed = 100f;
    public GameObject ball;
    public override void CollectObservations(VectorSensor sensor)
    {

        sensor.AddObservation(gameObject.transform.localPosition);
        sensor.AddObservation(ball.transform.localPosition);

    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        float MoveX = actionBuffers.ContinuousActions[0];
        float MoveZ = actionBuffers.ContinuousActions[1];
        //Debug.Log(MoveX + "," + MoveZ);
        gameObject.transform.localPosition += new Vector3(MoveX,0f,MoveZ) * Time.deltaTime * moveSpeed;
  
        //Debug.Log(gameObject.transform.localPosition);
    }

    public override void OnEpisodeBegin()
    {
     
        gameObject.transform.localPosition = new Vector3(Random.Range(-0.2f,0.28f),1.47f, Random.Range(-0.265f,0.265f));
        
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
        Debug.Log(continuousActionsOut[0] + "," + continuousActionsOut[1]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            SetReward(-1f);
            EndEpisode();
            //Debug.Log("HIT WALL");
        }
        if (other.gameObject.tag == "goal")
        {
            SetReward(1f);
            Debug.Log("GOAL");
            EndEpisode();
        }
    }

}
