using UnityEngine;
using System.Collections;

public class BallInteract : MonoBehaviour
{
    [SerializeField]
    private Camera CameraPrimeiraPessoa;//Pega a câmera primeira pessoa do player.
    [SerializeField] private GameObject PivotBola;//Guarda o GameObject do pivot da bola.
    private Ray RaioDeInteracao;//Guarda o raio que vai sair da minha camera.
    [SerializeField]
    private float AlcanceDeInteracao;//Distancia no qual é possível interagir com um GameObject.
    private RaycastHit hit;//Guarda os valores do GameObject atingido pelo raio.
    public bool EstaComBola;//Guarda se o personagem esta com a bola (true) ou não (false).

    GameObject Bola;

    // Use this for initialization
    void Start()
    {
        Bola = GameObject.FindGameObjectWithTag("Bola");
    }

    // Update is called once per frame
    void Update()
    {
        PegarBola();
        EstaComBola = VerificaBola();
    }

    private bool VerificaBola()
    {

        if (Bola.transform.parent != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void PegarBola()
    {
        Vector3 Pivot = PivotBola.transform.position;

        RaioDeInteracao = CameraPrimeiraPessoa.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(RaioDeInteracao, out hit, AlcanceDeInteracao))
        {
            
            if (hit.collider.tag == "Bola" && VerificaBola() == false)
            {
                hit.collider.transform.position = Pivot;
                hit.collider.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.parent = PivotBola.transform;
                //Instantiate(Bola);
                //hit.collider.transform.position(PivotBola.transform.position);
                //Destroy(hit.collider.gameObject);
            }
        }
    }
}
