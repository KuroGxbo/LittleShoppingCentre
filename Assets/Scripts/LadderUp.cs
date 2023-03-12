using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderUp : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Msj;
    [SerializeField]
    private TMP_Text HealthGauge;
    [SerializeField]
    private TMP_Text AmmoCounter;
    [SerializeField]
    private TMP_Text DocsFind;
    private bool Fuse1 = false;
    private bool Fuse2 = false;

    private void Awake()
    {
        var Luz = GameObject.Find("Indicator_1Path005");
        Luz.GetComponent<Light>().enabled = false;
        Luz = GameObject.Find("Indicator_1Path006");
        Luz.GetComponent<Light>().enabled = false;
        Luz = GameObject.Find("Indicator_1Path007");
        Luz.GetComponent<Light>().enabled = false;
        Luz = GameObject.Find("Indicator_1Path008");
        Luz.GetComponent<Light>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name.Contains("Ladder"))
        {
            transform.position += new Vector3(0, 1, 0);
        }
        if (hit.collider.name == "Model_Elevator002" && Fuse1)
        {
            var test = GameObject.Find("Asset_Starting_Point002");
            transform.position = test.transform.position;
            Debug.Log("Elevador");
        }
        else if (hit.collider.name == "Model_Elevator002" && !Fuse1)
        {
            StartCoroutine(ImprimirMsj("Parece Apagado, Necesito Encender El Interruptor"));
            //Msj.text = string.Empty;
        }

        if (hit.collider.name == "Model_Elevator004")
        {
            var test = GameObject.Find("Asset_Starting_Point005");
            transform.position = test.transform.position;
            Debug.Log("Elevador");
        }
        if (hit.collider.name == "Model_Elevator" && Fuse2)
        {
            Light.Destroy(GameObject.Find("Indicator_1Path005"), 1f);
            Light.Destroy(GameObject.Find("Indicator_1Path006"), 1f);
            Light.Destroy(GameObject.Find("Indicator_1Path007"), 1f);
            Light.Destroy(GameObject.Find("Indicator_1Path008"), 1f);

            var test = GameObject.Find("Asset_Starting_Point006");
            transform.position = test.transform.position;
            Debug.Log("Elevador Final");
        }
        else if (hit.collider.name == "Model_Elevator" && !Fuse2)
        {
            StartCoroutine(ImprimirMsj("Parece Apagado, Necesito Encender El Interruptor"));
            //Msj.text = string.Empty;
        }
        if (hit.collider.name == "Prop_FuseBox001")
        {
            Fuse1 = true;
            StartCoroutine(ImprimirMsj("Acabo de Activar uno de los Ascensores"));
            Debug.Log("Activado Elevador 1");
        }
        if (hit.collider.name == "Prop_FuseBox004")
        {
            Fuse2 = true;
            StartCoroutine(ImprimirMsj("Acabo de Activar el otro Ascensor"));
            Light.Destroy(GameObject.Find("Indicator_1Path001"), 1f);
            Light.Destroy(GameObject.Find("Indicator_1Path002"), 1f);
            Light.Destroy(GameObject.Find("Indicator_1Path003"), 1f);
            Light.Destroy(GameObject.Find("Indicator_1Path004"), 1f);
            var Luz = GameObject.Find("Indicator_1Path005");
            Luz.GetComponent<Light>().enabled = true;
            Luz = GameObject.Find("Indicator_1Path006");
            Luz.GetComponent<Light>().enabled = true;
            Luz = GameObject.Find("Indicator_1Path007");
            Luz.GetComponent<Light>().enabled = true;
            Luz = GameObject.Find("Indicator_1Path008");
            Luz.GetComponent<Light>().enabled = true;
            Debug.Log("Activado Elevador 2");
        }
        if (hit.collider.name == "Prop_FuseBox005")
        {
            var final = GameObject.Find("Prop_Electric_Door");
            GameObject.Destroy(final);
            StartCoroutine(ImprimirMsj("Con Este Debería Poder Abandonar Este Lugar"));
            Debug.Log("Finalizando");
        }


        if (hit.collider.name.Contains("Prop_Health"))
        {
            var final = GameObject.Find(hit.collider.name);
            var num = Convert.ToInt64(HealthGauge.text) + 10;
            HealthGauge.text = num.ToString();
            GameObject.Destroy(final);
        }

        if (hit.collider.name.Contains("Prop_Collectable_Data"))
        {
            var final = GameObject.Find(hit.collider.name);
            var num = Convert.ToInt64(DocsFind.text) + 1;
            DocsFind.text = num.ToString();
            GameObject.Destroy(final);
        }

        if (hit.collider.name.Contains("Prop_Ammo"))
        {
            var final = GameObject.Find(hit.collider.name);
            var num = Convert.ToInt64(AmmoCounter.text) + 20;
            AmmoCounter.text = num.ToString();
            GameObject.Destroy(final);
        }

        if (hit.collider.name.Contains("Asset_Ending_Point"))
        {
            SceneManager.LoadScene("Ending");

        }



    }

    IEnumerator ImprimirMsj(string mensaje)
    {

        Msj.text = mensaje;
        yield return new WaitForSeconds(4f);
        Msj.text = string.Empty;
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    collision.transform.position += collision.transform.position + new Vector3(0, 5, 0);
    //}
}
