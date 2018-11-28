using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstanceMaterial : MonoBehaviour {


    [System.Serializable]
    public class Material
    {
        public string materialName;
        public float minAmountOfMaterial;
        public float maxAmountOfMaterial;
        [HideInInspector]
        public float amountOfMaterial;
        public GameObject materialPrefab;
    }


    public string ResourceName;
    public float timeToHarvest;
    private Vector3 instancePosition;

    public Material[] material;






    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Destroy()
    {
        for (int i = 0; i <material.Length; i++)
        {
            material[i].amountOfMaterial = Random.Range(material[i].minAmountOfMaterial, material[i].maxAmountOfMaterial);
            for (int j = 0; j < material[i].amountOfMaterial; j++)
            {
                instancePosition = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y, transform.position.z + Random.Range(-2, 2));
                Instantiate(material[i].materialPrefab, instancePosition, Quaternion.identity);
            }

        }

        Destroy(gameObject);
    }
}
