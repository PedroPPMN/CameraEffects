using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]

public class CameraControl : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float dollySpeed = 5.0f;
    [SerializeField] private Transform archor;
    [SerializeField] private GameObject model;
    private Animator Anim;

    private bool track = false;
    private bool vertigo = false;
    private bool verticalPanning = false;
    private bool horizontalPanning = false;
    private bool travel = false;
    private bool arch = false;
    private bool dolly = false;

    private Camera playercamera;
    private float inicialFrustumHeight;
    

// Use this for initialization
void Start() {
        VertigoZoom();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        VertigoZoomStart();
        PlayVerticalPanning();
        PlayHorizontalPanning();
        CamTracking();
        CameraArch();
        CameraTravelling();
        DollyCamera();

        if (Input.GetKeyDown("0"))
        {
            SceneManager.LoadScene("MainScene");
        }

        if (Input.GetKeyDown("1"))
        {
            Debug.Log("Vertigo");
            Anim.enabled = false;
            vertigo = true;
        }
        
        if (Input.GetKeyDown("2"))
        {
            Debug.Log("Panning vertical");
            Anim.enabled = true;
            verticalPanning = true;
        }

        if (Input.GetKeyDown("3"))
        {
            Debug.Log("Panning horizontal");
            Anim.enabled = true;
            horizontalPanning = true;
        }

        if (Input.GetKeyDown("4"))
        {
            Debug.Log("Tracking");
            Anim.enabled = true;
            track = true;
        }

        if (Input.GetKeyDown("5"))
        {
            Debug.Log("travelling");
            Anim.enabled = true;
            travel = true;
        }

        if (Input.GetKeyDown("6"))
        {
            Debug.Log("Arco");
            Anim.enabled = true;
            arch = true;
        }
        if (Input.GetKeyDown("7"))
        {
            Debug.Log("Dolly");
            Anim.enabled = true;
            dolly = true;
           

        }

    }

    private void DollyCamera()
    {
        if (dolly == true)
        {
            Debug.Log("7");
            Anim.Play("dolly");
        }
    }

    private void CameraArch()
    {
        if (arch == true)
        {
            Debug.Log("6");
            Anim.Play("Arch");
        }
    }

    private void CameraTravelling()
    {
        if (travel == true)
        {
            Debug.Log("5");
            Anim.Play("Travelling");
        }
    }

    private void CamTracking()
    {
        if (track == true)
        {
            Debug.Log("4");
            Anim.Play("Tracking");
        }
    }

    private void PlayHorizontalPanning()
    {
        if (horizontalPanning == true)
        {
            Debug.Log("3");
            Anim.Play("Tilling");
        }
    }

    private void PlayVerticalPanning()
    {
        if (verticalPanning == true)
        {
            Debug.Log("2");
            Anim.Play("Panning");
        }
    }

    private void VertigoZoomStart()
    {
        if (vertigo == true)
        {
            Debug.Log("1");
            transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * dollySpeed);

            float currentDistance = Vector3.Distance(transform.position, target.position);
            playercamera.fieldOfView = ComputerFOV(inicialFrustumHeight, currentDistance);
        }
    }

    private void VertigoZoom()
    {
        playercamera = GetComponent<Camera>();
        Debug.Assert(playercamera != null);

        float distanceFromTarget = Vector3.Distance(transform.position, target.position);
        inicialFrustumHeight = ComputerFrustumHeight(distanceFromTarget);
    }

    private float ComputerFrustumHeight(float d)
    {
        return (2.0f * d * Mathf.Tan(playercamera.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }

    private float ComputerFOV(float h,float d)
    {
        return (2.0f * Mathf.Atan(h * 0.5f / d) * Mathf.Rad2Deg);
    }
}
