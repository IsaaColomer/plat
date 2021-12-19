// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Patroller : MonoBehaviour {

//     Camera viewCamera;

//     Transform from;
//     Transform to;

//     public float speed;
//     private float waitTime;
//     public float startWaitTime;
    
//     [SerializeField] Transform[] movesSpots;
//     //
//     private int nextPos;
//     private bool nSpot;
//     public bool goBackOrLoop;

//     //private Vector3 startPos;
//     private Quaternion startRot;

//     GameManager Manager;

//     public bool isShowed;
//     private void Awake()
//     {
//         //startPos = transform.position;
//         startRot = transform.rotation;

//         isShowed = false;
//     }
//     // Use this for initialization
//     void Start () {
//         transform.LookAt(movesSpots[1].position);
//         Manager = GameManager.Instance;
//         isShowed = false;
//         Manager.SetShow(true);
//         //Debug.Log(isShowed);
//     }


//     // Update is called once per frame
//     void Update()
//     {
//         if (isShowed && Manager.GetShow())
//         {
//             isShowed = false;
//         }

//         if (!isShowed && !Manager.GetShow()){
//             isShowed = true;
//             ResetStart();
//         }


//         if (Manager.GetDetected()){
//             ResetStart();
//         }
        
        
//         if (Manager.GetShow() || !Manager.GetRec() && !Manager.GetRestart())
//             MovePosition();
     
//     }
    
//     void MovePosition(){
//         transform.LookAt(movesSpots[nextPos].position);
//         //transform.rotation = Quaternion.Lerp(transform.rotation, movesSpots[nextPos].rotation, Time.time * rtspeed);
//         transform.position = Vector3.MoveTowards(transform.position, movesSpots[nextPos].position, speed * Time.deltaTime);
//         //transform.rotation = Quaternion.LookRotation(movesSpots[nextPos].position);
//         if (Vector3.Distance(transform.position, movesSpots[nextPos].position) < 0.01f){
//             if (waitTime <= 0){
//                 NextPos();
//                 waitTime = startWaitTime;
//             }
//             else
//             {
             
//             //transform.rotation = Quaternion.Lerp(transform.rotation, movesSpots[nextPos].rotation, Time.time * rtspeed);
//             waitTime -= Time.deltaTime;
//         }
//             }
        
//     }
//     void NextPos()
//     {
        
//         if (goBackOrLoop){
//             if (nextPos == movesSpots.Length - 1)
//                 nextPos = 0;
//             else
//                 nextPos++;
//         }else{
//             if (nextPos == movesSpots.Length - 1)
//                 nSpot = false;

//             if (nextPos == 0)
//                 nSpot = true;

//             if (nSpot)
//                 nextPos++;
//             else
//                 nextPos--;
//         }

//     }

//     public void ResetStart()
//     {
//         transform.position = movesSpots[0].transform.position;
//         transform.rotation = startRot;
//         waitTime = startWaitTime;
//         nextPos = 1;
//         nSpot = true;
//     }
// }
