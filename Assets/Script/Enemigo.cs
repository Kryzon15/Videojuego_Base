using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject player;
    public GameObject balaPrefab;
    public float velocidadBala = 10f;
    public float distanciaDisparo = 10f;
    public float tiempoEntreDisparos = 1f;

    private float tiempoUltimoDisparo;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanciaDisparo)
        {
            if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
            {
                tiempoUltimoDisparo = Time.time;
                Disparar();
            }
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        Vector3 direccion = (player.transform.position - transform.position).normalized;
        bala.GetComponent<Rigidbody>().velocity = direccion * velocidadBala;
    }
}
