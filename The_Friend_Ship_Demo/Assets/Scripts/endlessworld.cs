//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class endlessworld : MonoBehaviour {

//  //  public Transform Player;

//    public Vector3 playerv3;
//    public Vector3 planev3;

  

//    bool already_spawnedpx;
//    bool already_spawnednx;
//    bool already_spawnedpz;
//    bool already_spawnednz;

//    bool  already_spawnedpxpz;
//    bool already_spawnednxpz;
//    bool already_spawnednxnz;
//    bool already_spawnedpxnz;



//    public bool isfirst;

//    // public GameObject tile;

//    public Transform Islands;


//    int randomnum;
//    int randommissnum;

//    float rotation;
//   public bool onthing;

//    gameman man;
//    // Use this for initialization
    
//    void Start () {

//        man = FindObjectOfType<gameman>();
//        planev3 = transform.position;

        

//        if (man.Platesco.Contains(this.transform.position))
//        {
//            Debug.Log("Already used");
       
//            Destroy(this.gameObject);
//        }
//        else
//        {
            
//            Debug.Log("New");

//            if (transform.position.x == man.max_dir)
//            {
//                GameObject Fog;

//                Fog = Instantiate(man.Fog, transform.position + (transform.right * man.space / 2), transform.rotation);
//            }
//            if (transform.position.x == -man.max_dir)
//            {
//                GameObject Fog;

//                Fog = Instantiate(man.Fog, transform.position + (-transform.right * man.space / 2), transform.rotation);

//            }
//            if (transform.position.z == man.max_dir)
//            {

//                GameObject Fog;

//                Fog = Instantiate(man.Fog, transform.position + (transform.forward * man.space / 2), Quaternion.Euler(0, 90, 0));


//            }
//            if (transform.position.z == -man.max_dir)
//            {

//                GameObject Fog;

//                Fog = Instantiate(man.Fog, transform.position + (-transform.forward * man.space / 2), Quaternion.Euler(0, 90, 0));


//            }

//            man.Platesco.Add(this.transform.position);

//            Randomnumgen();
//    //  Islands = GetComponentInChildren<Transform>();
//       Islands.rotation =  Quaternion.Euler(0, rotation, 0);

//        }
       
//    }

//    // Update is called once per frame
//    void Update () {

//        if (already_spawnednx&&already_spawnedpx&&already_spawnednz&&already_spawnedpz || man.Platesco.Count == 25)
//        {
//            return;            
//        }
//        else
//        {
//            trackplatforms();
//        }
//    }

//    void trackplatforms()
//    {
//      //  playerv3 = man.Player.transform.position;

//        man.distnacex = playerv3.x - planev3.x;
//        man.distancez = playerv3.z - planev3.z;

//        //150 world Sq
//        if (!already_spawnedpx && man.distnacex > man.drawdis && onthing)
//        {
//            already_spawnedpx = true;

//            if (man.Player.position.x < man.max_dir)
//            {
//                Debug.Log("Spawn +x");
//                Randomnumgen();

//                GameObject Tile;

//                man.currentnum = randomnum;
               
//                    Tile = Instantiate(man.Plates[randomnum], transform.position + (transform.right * man.space), transform.rotation);

                
//                Tile.GetComponent<endlessworld>().already_spawnednx = true;
//                //Tile.GetComponent<endlessworld>().already_spawnedpx = false;
//                //Tile.GetComponent<endlessworld>().already_spawnedpz = false;
//                //Tile.GetComponent<endlessworld>().already_spawnednz = false;
//                Tile.GetComponent<endlessworld>().onthing = false;
//             //   Tile.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0,rotation,0);

//            }
       
//        }
//        if (!already_spawnednx && man.distnacex < -man.drawdis && onthing)
//        {
//            already_spawnednx = true;

//            if (man.Player.position.x > -man.max_dir)
//            {
//                Debug.Log("Spawn -x");
//                Randomnumgen();

//                GameObject Tile;
//                man.currentnum = randomnum;
              
//                    man.countndown--;

//                    Tile = Instantiate(man.Plates[randomnum], transform.position + (-transform.right * man.space), transform.rotation);

                
//                Tile.GetComponent<endlessworld>().already_spawnedpx = true;
//                //Tile.GetComponent<endlessworld>().already_spawnednx = false;
//                //Tile.GetComponent<endlessworld>().already_spawnedpz = false;
//                //Tile.GetComponent<endlessworld>().already_spawnednz = false;
//                Tile.GetComponent<endlessworld>().onthing = false;
//              //  Tile.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0, rotation, 0);

//            }
        

//        }
//        if (!already_spawnedpz && man.distancez > man.drawdis && onthing  )
//        {
//            already_spawnedpz = true;

//            if (man.Player.position.z < man.max_dir)
//            {
//                Debug.Log("Spawn +z");
//                Randomnumgen();
//                GameObject Tile;
//                man.currentnum = randomnum;
               
//                    Tile = Instantiate(man.Plates[randomnum], transform.position + (transform.forward * man.space), transform.rotation);

                
//                Tile.GetComponent<endlessworld>().already_spawnednz = true;
//                //Tile.GetComponent<endlessworld>().already_spawnedpz = false;
//                //Tile.GetComponent<endlessworld>().already_spawnednx = false;
//                //Tile.GetComponent<endlessworld>().already_spawnedpx = false;
//                Tile.GetComponent<endlessworld>().onthing = false;
//            //    Tile.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0, rotation, 0);


//            }
           
//        }
//        if (!already_spawnednz && man.distancez < -man.drawdis && onthing)
//        {
//            already_spawnednz = true;

//            if (man.Player.position.z > -man.max_dir)
//            {
//                Debug.Log("Spawn -z");
//                Randomnumgen();

//                GameObject Tile;
//                man.currentnum = randomnum;
             
//                    Tile = Instantiate(man.Plates[randomnum], transform.position + (-transform.forward * man.space), transform.rotation);

                
//                Tile.GetComponent<endlessworld>().already_spawnedpz = true;
//                //Tile.GetComponent<endlessworld>().already_spawnednz = false;
//                //Tile.GetComponent<endlessworld>().already_spawnednx = false;
//                //Tile.GetComponent<endlessworld>().already_spawnedpx = false;
//                Tile.GetComponent<endlessworld>().onthing = false;
//          //      Tile.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0, rotation, 0);

//            }
        
//        }
//        if (!already_spawnedpxpz && man.distnacex > man.drawdis && man.distancez > man.drawdis && onthing)
//        {
//            already_spawnedpxpz = true;

//            if (man.Player.position.x < man.max_dir && man.Player.position.z < man.max_dir)
//            {
//                Randomnumgen();
//                GameObject Tile;
//                man.currentnum = randomnum;
                
//                    man.countndown--;

//                    Tile = Instantiate(man.Plates[randomnum], transform.position + (transform.right * man.space + transform.forward * man.space), transform.rotation);

                
//                Tile.GetComponent<endlessworld>().already_spawnednxnz = true;
//                Tile.GetComponent<endlessworld>().already_spawnednx = true;
//                Tile.GetComponent<endlessworld>().already_spawnednz = true;
//                //Tile.GetComponent<endlessworld>().already_spawnedpx = false;
//                //Tile.GetComponent<endlessworld>().already_spawnedpz = false;
//                //Tile.GetComponent<endlessworld>().already_spawnednz = false;
//                Tile.GetComponent<endlessworld>().onthing = false;
//                //   Tile.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0,rotation,0);

//            }
//        }
//        if (!already_spawnedpxnz && man.distnacex > man.drawdis && man.distancez < -man.drawdis && onthing)
//        {
//            already_spawnedpxnz = true;

//            if (man.Player.position.x < man.max_dir && man.Player.position.z > -man.max_dir)
//            {
//                Randomnumgen();
//                GameObject Tile;
//                man.currentnum = randomnum;
              
//                    man.countndown--;

//                    Tile = Instantiate(man.Plates[randomnum], transform.position + (transform.right * man.space + -transform.forward * man.space), transform.rotation);
            
                
//                Tile.GetComponent<endlessworld>().already_spawnednxpz = true;
//                Tile.GetComponent<endlessworld>().already_spawnednx = true;
//                Tile.GetComponent<endlessworld>().already_spawnedpz = true;
//                //Tile.GetComponent<endlessworld>().already_spawnedpx = false;
//                //Tile.GetComponent<endlessworld>().already_spawnedpz = false;
//                //Tile.GetComponent<endlessworld>().already_spawnednz = false;
//                Tile.GetComponent<endlessworld>().onthing = false;
//                //   Tile.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0,rotation,0);

//            }
//        }
//        if (!already_spawnednxnz && man.distnacex < -man.drawdis && man.distancez < -man.drawdis && onthing)
//        {
//            already_spawnednxnz = true;

//            if (man.Player.position.x > -man.max_dir && man.Player.position.z > -man.max_dir)
//            {
//                Randomnumgen();
//                GameObject Tile;
//                man.currentnum = randomnum;
                
//                    man.countndown--;

//                    Tile = Instantiate(man.Plates[randomnum], transform.position + (-transform.right * man.space + -transform.forward * man.space), transform.rotation);

                
//                Tile.GetComponent<endlessworld>().already_spawnedpxpz = true;
//                Tile.GetComponent<endlessworld>().already_spawnedpz = true;
//                Tile.GetComponent<endlessworld>().already_spawnedpx = true;
//                //Tile.GetComponent<endlessworld>().already_spawnedpx = false;
//                //Tile.GetComponent<endlessworld>().already_spawnedpz = false;
//                //Tile.GetComponent<endlessworld>().already_spawnednz = false;
//                Tile.GetComponent<endlessworld>().onthing = false;
//                //   Tile.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0,rotation,0);

//            }
//        }
//        if (!already_spawnednxpz && man.distnacex < -man.drawdis && man.distancez > man.drawdis && onthing)
//        {
//            already_spawnednxpz = true;

//            if (man.Player.position.x > -man.max_dir && man.Player.position.z < man.max_dir)
//            {
//                Randomnumgen();
//                GameObject Tile;
//                man.currentnum = randomnum;
               

//                    Tile = Instantiate(man.Plates[randomnum], transform.position + (-transform.right * man.space + transform.forward * man.space), transform.rotation);

                
//                Tile.GetComponent<endlessworld>().already_spawnedpxnz = true;
//                Tile.GetComponent<endlessworld>().already_spawnednz = true;
//                Tile.GetComponent<endlessworld>().already_spawnedpx = true;
//                //Tile.GetComponent<endlessworld>().already_spawnedpx = false;
//                //Tile.GetComponent<endlessworld>().already_spawnedpz = false;
//                //Tile.GetComponent<endlessworld>().already_spawnednz = false;
//                Tile.GetComponent<endlessworld>().onthing = false;
//                //   Tile.GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0,rotation,0);

//            }
//        }

       
//    }

//    void Randomnumgen()
//    {
//        randomnum = Random.Range(0, man.platenumbers);
//        rotation = Random.Range(0, 359);
//    }
    
//    private void OnTriggerStay(Collider other)
//    {
//        if (other.GetComponent<movement>())
//        {
//            onthing = true;
//        }
//        playerv3 = other.GetComponent<movement>().transform.position;

//    }
//    private void OnTriggerEnter(Collider other)
//    {
        
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.GetComponent<movement>())
//        {
//            onthing = false;
//        }
//    }

//}
