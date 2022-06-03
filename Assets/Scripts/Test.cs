using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GetJson getJson;

    public Vector3 camPos;
    public Transform camTr;
    public float speed = 2.5f;

    public bool IsZoom = false;

    public FirstPersonLook firstPersonLook;

    public GameObject InfoPanel;

    private FirstPersonMovement firstPersonMovement;
    private Vector3 oldPosition;
    private Vector3 oldTransform;
    private GameObject cristall;
    private GameObject glass;

    private float eps = .1f;

    private const string MineralLayerMask = "Minerals";

    private void Awake()
    {
        firstPersonMovement = GetComponent<FirstPersonMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        camTr = Camera.main.transform;
        camPos = camTr.position;
        InfoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, 3) && hit.collider.tag == "Glass")
        //{
        //    glass = hit.collider.gameObject;
        //    glass.SetActive(false);
        //}
            if (Physics.Raycast(ray, out hit, 5, LayerMask.GetMask(MineralLayerMask)))
        {
            cristall = hit.collider.gameObject;
            //включать выделение объекта по котуру => cristall.GetComponent<>().enabled=false
            print("****************************");
            if (Input.GetMouseButtonDown(0) && !IsZoom)
            {
                //выключить выделение объекта
                //go.GetComponent<>().enabled = false;

                IsZoom = true;
                camPos = camTr.position;

                

                oldPosition = cristall.transform.position;
                oldTransform = cristall.transform.eulerAngles;//new Vector3(cristall.transform.rotation.x, cristall.transform.rotation.y, cristall.transform.rotation.z);
                camPos += 1.2f * camTr.forward; // Zoom

                //cristall.transform.position = camPos;//Vector3.Lerp(go.transform.position, camPos, Time.deltaTime * speed);
                StartCoroutine(ChangePosition(cristall, camPos));

                firstPersonMovement.enabled = false;
                firstPersonLook.enabled = false;

                //включаем скрипт вращения объекта
                
                cristall.GetComponent<Rotation>().enabled = true;

                //включить панель 
                InfoPanel.SetActive(true);
                //text from json

                var minInfo = cristall.GetComponent<MineralInfo>();

                var text = GetText(minInfo.Class + "-" + minInfo.Number);

                var descriptionController = InfoPanel.GetComponent<DescriptionController>();
                if (descriptionController)
                {
                    descriptionController.SetDescription(text);
                }
            }

        }
        else
        {
            //выключаем скрипт выделения
            //if (cristall != null)
                //cristall.GetComponent<>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && IsZoom)
        {
            //выключить панель 
            InfoPanel.SetActive(false);
            //glass.SetActive(true);
            StopAllCoroutines();
            IsZoom = false;
            //вернуть позицию кристаллу
            cristall.transform.position = oldPosition;
            cristall.transform.eulerAngles = oldTransform;//.Set(oldTransform.x, oldTransform.y, oldTransform.z, 0.0f);
            firstPersonMovement.enabled = true;
            firstPersonLook.enabled = true;
            cristall.GetComponent<Rotation>().enabled = false;

            cristall = null;
        }
    }

    private string GetText(string key)
    {
        var item = getJson.Items.Find(x => x.number == key);
        return item != null ? item.description : "";
    }

    private IEnumerator ChangePosition(GameObject gameObject, Vector3 endPos)
    {
        while (Vector3.Distance(gameObject.transform.position, endPos) > eps)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPos, Time.deltaTime * speed);
            print("IEnumerator");
            yield return null;
        }
    }
}
