using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] patrulhaPontos;
    public float speed;
    Transform currentpatrulhaPontos;
    int curretnpatrulhaIndex;


    public Transform target;
    public float chaseRange;
    
    void Start()
    {
        curretnpatrulhaIndex = 0;
        currentpatrulhaPontos = patrulhaPontos[curretnpatrulhaIndex];
    }

    void Update()
    {
        float distanceTarget = Vector3.Distance(transform.position, target.position);
        if (distanceTarget < chaseRange)
        {
            
            Vector3 targetDir = target.position - transform.position;
            // Mathf.Atan2 Valor de retorno é o ângulo entre o eixo x e um vetor 2D começando em zero e terminando em (x, y).
            // Mathf.Rad2Deg Radians-to-degrees conversion constan

            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            // quaternion  são usados para representar rotações.
            //Quaternion.AngleAxis Cria uma rotação que gira os graus do ângulo em torno do eixo.
            //Vector3.forward Atalho para escrever Vector3 (0, 0, 1).
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            //Quaternion.RotateTowards Gira uma rotação em uam direção.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            transform.Translate(Vector3.up * Time.deltaTime * speed);

        }




    }
}

