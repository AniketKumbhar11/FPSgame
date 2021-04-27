using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject CAmera;
    public AudioClip reloadAudio;
    public AudioClip FireThenreload;
    public AudioClip FireAudio;
    public static Sniper Sniperobj;
    public GameObject ZoomObj;
    public GameObject OriginalPos;
    public GameObject RaycastStartPoint;
    public float ShotingRange = 100f;
    public float fireRate = 0.25f;
    public bool FireFlag = true;
    public float nextFire;
    //  public GameObject OrginalPos;
    public KeyCode fire = KeyCode.Mouse0;
    public KeyCode aim = KeyCode.Mouse1;
    public KeyCode drowGun = KeyCode.E;
    public KeyCode run = KeyCode.LeftShift;
    public KeyCode reload = KeyCode.R;

  
    public bool DrowFlag;
    public bool ReloadFlag;
    AudioSource Sounds;
    Vector3 raycastDircion=new Vector3();



    Animator anim;





    // Start is called before the first frame update
    private void Awake()
    {
       Sniperobj = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        DrowFlag = true;
        Vector3 OrginalPos = this.gameObject.transform.position;
        Sounds = GetComponent<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Fire();
        Put();
        Run();
        Reload();
        raycastDircion = RaycastStartPoint.transform.forward*ShotingRange;/*TransformDirection(Vector3.forward);*/
       // Debug.DrawLine(RaycastStartPoint.transform.position, raycastDircion, Color.red, ShotingRange);




    }
    void Reload()
    {

        if (Input.GetKeyDown(reload))
        {
           // Sounds.PlayOneShot(reloadAudio);
            anim.SetBool("Reload", true);
        }
        // 




        if (Input.GetKeyUp(reload))

            anim.SetBool("Reload", false);



    }

    void Run()
    {
        if (Input.GetKey(run))
            anim.SetBool("Run", true);
        if (Input.GetKeyUp(run))
            anim.SetBool("Run", false);


    }

    void Put()
    {


        if (Input.GetKeyUp(drowGun))
        {
            if (DrowFlag)
            {
                anim.SetBool("PutGun", true);
                DrowFlag = false;
            }
            else
            {
                anim.SetBool("PutGun", false);
                DrowFlag = true;
            }
        }


    }


    void Aim()
    {
        if (Input.GetKeyDown(aim))
        {
            this.transform.position = ZoomObj.transform.position;
             //CAmera.transform.position = ZoomObj.transform.position;
            //  this.transform.localRotation = ZoomObj.transform.localRotation;
            // this.transform.localScale= ZoomObj.transform.localScale;
            anim.SetBool("Aim", true);
            // anim.SetBool("Fire", false);
        }


        if (Input.GetKeyUp(aim))
        {
            this.transform.position = OriginalPos.transform.position;
              this.transform.localRotation = OriginalPos.transform.localRotation;
             this.transform.localScale= OriginalPos.transform.localScale;
            // CAmera.transform.position = OriginalPos.transform.position;
            //  anim.SetBool("Fire", false);
            anim.SetBool("Aim", false);
        }





    }
    void Fire()
    {
        if (Input.GetKeyDown(fire) && Time.time > nextFire && FireFlag == true)
        {
            RaycastHit hit;
            Physics.Raycast(RaycastStartPoint.transform.position, raycastDircion, out hit, ShotingRange);
            //if(hit.collider.gameObject.tag== "Enemy")
            //{
            //    Destroy(hit.collider.gameObject);
            //}




            Debug.DrawRay(RaycastStartPoint.transform.position, raycastDircion, Color.red, ShotingRange);
           
            //  Sounds.PlayOneShot(FireAudio);
            nextFire = Time.time + fireRate;

            anim.SetBool("Fire", true);
            //  anim.SetBool("Aim", true);

            Debug.Log("ENter");
          
            
                
            

        }

        if (Input.GetKeyUp(fire))
        {
            anim.SetBool("Fire", false);
            //FireFlag = false;
            //anim.SetBool("Aim", false);
        }

         




    }
    public void FireSound(int i)
    {
                if(i==1)
        
            Sounds.PlayOneShot(FireAudio);
        
                if(i==2)
        
            Sounds.PlayOneShot(FireThenreload);
        if (i == 3)
            Sounds.PlayOneShot(reloadAudio);

    }
    
   
         
}
