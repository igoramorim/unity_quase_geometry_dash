using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {

    //A programacao desse script esta na apostila
    //O objetivo dele e fazer um GameObject ficar se movimentando para a esquerda e para a direita
    //Usamos ele para fazer algumas plataformas com movimento e deixar a fase mais interessante

    private bool isLeft;            //Variavel que vai indicar se o GameObject esta andando para a esquerda ou nao
                                    //Esse tipo bool significa booleana. Esse tipo de variavel pode guardar somente
                                    //dois valores: TRUE ou FALSE

    public float tempoMovimento;    //Tempo que o GameObject ira andar em uma direcao

    // Use this for initialization
    void Start() {
        //A funcao InvokeRepeating() executa outra funcao repetidamente de tempos em tempos
        //A funcao que sera executada e a TrocarLado() e o tempo e a variavel tempoMovimento, configurada no Inspector da Unity
        InvokeRepeating("TrocarLado", tempoMovimento, tempoMovimento);
    }

    // Update is called once per frame
    void Update() {
        //Executa a funcao Movimentar() a todo momento, pois esta dentro do Update()
        //Assim faremos nossa plataformar se movimentar durante todo o jogo
        Movimentar();
    }

    void Movimentar() {
        //Antes da plataforma se movimentar, precisamos saber se ele vai andar para a esquerda ou direita
        //Para isso, verificamos se a variavel booleana isLeft esta ativada (TRUE)
        //Se estiver, a plataformar anda para a esquerda (Vector2.left)

        //Senao (else) significa que ela esta desligada (FALSE) e a plataforma deve andar para a direita (Vector2.right)

        if (isLeft) {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
    }

    //A funcao TrocarLado() troca inverte o valor da variavel booleana isLeft
    //O simbolo de exclamacao ( ! ) significa negacao, em programacao
    //Se ela estiver TRUE vai para FALSE, se estiver FALSE vai para TRUE
    void TrocarLado() {
        isLeft = !isLeft;
    }
}
