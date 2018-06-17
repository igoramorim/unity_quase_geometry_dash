using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {

    public static int coins;            //Variavel que ira guardar a quantidade de coins (pinguins) que o jogador pegou
                                        //Ela e do tipo int pois nao temos como pegar meio pinguim ou ter 3.2 pinguins
                                        //O 'static' torna a variavel 'global' e nos podemos acessar ela de outros scripts
                                        //de forma mais pratica

    Text text;                          //Variavel do tipo text (texto) para exibir na tela a quantidade de coins (pinguins)

    
    void Start() {
        //Assim que o jogo iniciar, guardaremos o componente Text que esta no GameObject desse Script na variavel text
        //para conseguir atualizar a pontuacao na tela
        //E também zeramos a quantidade de coins no inicio do jogo
        text = GetComponent<Text>();
        coins = 0;
    }
    
    void Update() {
        //A todo momento iremos atualizar o texto na tela com a pontuacao atual do jogador
        //Exemplo de como ira aparecer: Coins: 3
        //No caso acima "Coins: " e um texto, por isso no codigo fica entre aspas
        //E "coins" minusculo e a variavel que guarda a pontuacao, criada no inicio desse script
        text.text = "Coins: " + coins;
    }


}
