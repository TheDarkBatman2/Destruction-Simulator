using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAddJoint : MonoBehaviour
{
   public int breakForceLimit=200;
   bool isConnected =false;
   float frame_num=0;
     void OnCollisionEnter (Collision other) 
     {
        if(!isConnected)
        {
         Physics.IgnoreCollision(this.GetComponent<Collider>(), other.collider, true); 
         FixedJoint fixedJointIns =this.gameObject.AddComponent<FixedJoint>();
         fixedJointIns.connectedBody=other.gameObject.GetComponent<Rigidbody>();

         //fixedJointIns.breakForce=breakForceLimit;
         }
     }

   void FixedUpdate()
   {
      frame_num+=1;
      if(frame_num>10)
      {
         isConnected=true;
      }
      if (GetComponent<FixedJoint>()==null)
      {
         //print(this.gameObject.name);
         //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

      }
   }
}