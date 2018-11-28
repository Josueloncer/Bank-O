using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harvest : MonoBehaviour
{
    public bool isJalando;
    private bool isInside;
    private GameObject resource;
    public Camera camera;
    [SerializeField]
    private LayerMask resourceLayerMask;
    [SerializeField]
    private LayerMask materialLayerMask;
    [SerializeField]
    private LayerMask moveItemLayerMask;
    public GameObject harvestCanvas;
    public Text harvestText;
    public Image loadingHarvest;
    private bool rayIsHiting;
    [SerializeField]
    private float currentTime;
    public Ray ray;

    int takeHash = Animator.StringToHash("take");
    Animator anim;
    private float pickUpTime = .5f;
    private float currentPickUpTime;
    private bool isPickingUp;    

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastPickUp();
    }

    void RaycastPickUp()
    {
        ray = camera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 6, materialLayerMask))
        {
            //harvestCanvas.SetActive(true);
            PickUpMaterial(hitInfo);
            //ShowHarvestCanvas("PickUp");
        }
        

        /*if (Physics.Raycast(ray, out hitInfo, 6, resourceLayerMask))
        {
            rayIsHiting = true;
            harvestCanvas.SetActive(true);
            ShowHarvestCanvas(hitInfo.transform.gameObject.GetComponent<InstanceMaterial>().ResourceName);
            if (Input.GetMouseButton(0))
            {
                if (currentTime >= hitInfo.transform.gameObject.GetComponent<InstanceMaterial>().timeToHarvest)
                {
                    hitInfo.transform.gameObject.GetComponent<InstanceMaterial>().Destroy();
                    currentTime = 0;
                }
                else
                {
                    currentTime += Time.deltaTime;
                }
            }
            else
            {
                currentTime = 0;
            }

            ShowLoading(currentTime, hitInfo.transform.gameObject.GetComponent<InstanceMaterial>().timeToHarvest);
        }
        else
        {
            rayIsHiting = false;
            harvestCanvas.SetActive(false);
        }*/
        DebugRayCast(ray);
    }
    void DebugRayCast(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction * 4, Color.red);
    }
    /*void ShowHarvestCanvas(string text)
    {
        harvestText.text = text;
    }
    void ShowLoading(float currentTime, float timeToHarvest)
    {
        loadingHarvest.fillAmount = currentTime / timeToHarvest;
    }*/
    void PickUpMaterial(RaycastHit hitInfo)
    {
        if(hitInfo.transform.gameObject.tag == "Material")
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("jalo");
                //State.secondBeen = "take";
               // anim.SetTrigger(takeHash);
                //isPickingUp = true;
            }
           /* if(isPickingUp)
            {
                if (currentPickUpTime >= pickUpTime)
                {
                    //Obtener script de reconocimiento de material
                    var pickupObj = hitInfo.transform.gameObject.GetComponent<PickUpObject>();
                    if (pickupObj)
                        inventorySystem.GetInventoryManager().Add(pickupObj.GetId(), pickupObj.GetQuantity());
                    else
                        Debug.LogWarning("El objeto no tiene un script de tipo PickUpObject");
                    Destroy(hitInfo.transform.gameObject);
                    currentPickUpTime = 0;
                    isPickingUp = false;
                }
                else
                {
                    currentPickUpTime += Time.deltaTime;
                }
            }*/
        }
    }

}
