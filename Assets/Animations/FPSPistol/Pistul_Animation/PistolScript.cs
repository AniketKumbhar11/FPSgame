using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public float fireRate = 0.25f;                                      // Number in seconds which controls how often the player can fire
    public float weaponRange = 20f;

    public bool boolval = true;
    public int bulletsInMagzine = 6;
    public ParticleSystem muzzel;
    public ParticleSystem bullet;
    public Transform StartRayPos;
    public GameObject metalHitEffect;


    public bool Fire=true;
    RaycastHit hit;
    private Animator _Anim;
   
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
      
        _Anim = GetComponent<Animator>();    
    }
   
    // Update is called once per frame
    void Update()
    {
       // Physics.Raycast(StartRayPos.position, transform.forward, out hit, 100f);

       //Debug.DrawRay(StartRayPos.position, transform.forward*100f, Color.red);


        if (Input.GetKeyDown(KeyCode.M))
        {
             if(boolval==true)
            _Anim.SetInteger("OpenGun", 1);
            if (boolval == false)
                _Anim.SetInteger("OpenGun", 2);
            new WaitForSeconds(10f);
            this.gameObject.SetActive(false);
            boolval = !boolval;
        }




        if(Input.GetMouseButtonDown(0) &&Time.time > nextFire&&Fire==true)
        {

      
            {



                nextFire = Time.time + fireRate;
                //muzzel.Play();
                //bullet.Play();
                //_Anim.SetInteger("Fire", 1);

                //Vector3 rayOrigin = StartRayPos.position;
                //RaycastHit hit;
                //if (Physics.Raycast(rayOrigin, StartRayPos.forward, out hit, weaponRange))
                //{
                //    HandleHit(hit);00000000000000000000000000000000000000000000000000000000000000000
                //}



              //  SpawnDecal(hit, metalHitEffect);
                // muzzel.gameObject.SetActive(true);
              //  muzzel.Play();
               // bullet.gameObject.SetActive(true);
                _Anim.SetInteger("Fire", 1);
            }


        }
        if (Input.GetMouseButtonUp(0))
        {
          //  muzzel.gameObject.SetActive(false);
           
            _Anim.SetInteger("Fire", 2);
           

        }





        if (Input.GetKeyDown(KeyCode.R))
        {

            Fire = false;
            _Anim.SetInteger("ReLoad(RB)", 1);

            StartCoroutine("Wait");

        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _Anim.SetInteger("ReLoad(RB)", 2);
           // _Anim.SetInteger("ReLoad(RB)", 2);
            
        }




        if (Input.GetKey(KeyCode.UpArrow))
        {
            _Anim.SetInteger("walktorun", 1);
            if (Input.GetMouseButtonDown(0))
            {
                _Anim.SetInteger("Fire", 3);

            }
            if (Input.GetMouseButtonUp(0))
            {
                _Anim.SetInteger("Fire", 4);

            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                _Anim.SetInteger("walktorun", 3);
            }
            if (Input.GetKeyUp(KeyCode.RightShift))
            {
                Debug.Log("right");
                _Anim.SetInteger("walktorun", 4);
            }
        }













        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _Anim.SetInteger("walktorun", 2);
        }



   



    }


    IEnumerator Wait()
    {

        yield return new WaitForSeconds(1.5f);
        Fire = true;
    }




    //void SpawnDecal(RaycastHit hit, GameObject prefab)
    //{
    //    GameObject spawnedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
    //    spawnedDecal.transform.SetParent(hit.collider.transform);
    //    Destroy(spawnedDecal, 1f);
    //}


    //void HandleHit(RaycastHit hit)
    //{
    //    if (hit.collider.sharedMaterial != null)
    //    {
    //        string materialName = hit.collider.sharedMaterial.name;

    //        switch (materialName)
    //        {
    //            case "Metal":
    //                SpawnDecal(hit, metalHitEffect);
    //                break;
    //            case "Sand":
    //                SpawnDecal(hit, sandHitEffect);
    //                break;
    //            case "Stone":
    //                SpawnDecal(hit, stoneHitEffect);
    //                break;
    //            case "WaterFilled":
    //                SpawnDecal(hit, waterLeakEffect);
    //                SpawnDecal(hit, metalHitEffect);
    //                break;
    //            case "Wood":
    //                SpawnDecal(hit, woodHitEffect);
    //                break;
    //            case "Meat":
    //                SpawnDecal(hit, fleshHitEffects[Random.Range(0, fleshHitEffects.Length)]);
    //                break;
    //            case "Character":
    //                SpawnDecal(hit, fleshHitEffects[Random.Range(0, fleshHitEffects.Length)]);
    //                break;
    //            case "WaterFilledExtinguish":
    //                SpawnDecal(hit, waterLeakExtinguishEffect);
    //                SpawnDecal(hit, metalHitEffect);
    //                break;
    //        }
    //    }
    //}
}
