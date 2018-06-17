using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    //Esse script e mais avancado e voces nao aprenderam alguns itens necessarios nelee.
    //Entao se vocês nao entenderem completamente, tudo bem. Fiz ele apenas como um bonus

    //Esse script vai, no inicio da fase, pegar as posicoes de todos os spikes e criar uma coin (pinguim) em cima de cada um

    public GameObject[] spikes;     //Essa variavel e uma lista de GameObjects. Quando temos uma variavel em forma de lista
                                    //podemos guardar mais itens dentro dela. Um exemplo seria o inventario de um personagem RPG

    public GameObject coin;         //Coin e o item que iremos criar. Nos adicionamos ela pelo Inspector da Unity
    private Vector3 newPos;         //Posicao no jogo onde iremos criar os pinguins

	// Use this for initialization
	void Start () {
        //Colocamos todos os itens com a TAG "Spike" dentro da nossa lista
        spikes = GameObject.FindGameObjectsWithTag("Spike");

        //Fazemos um for (repeticao) passando em cada item da lista
        //Para cada spike, criamos (instanciamos) uma coin em sua posicao
        //Somente na posicao Y que subimos um pouco, por isso spike.transform.position.y + 3
        //Para o pinguim ficar acima do spike
        foreach (GameObject spike in spikes) {
            newPos.x = spike.transform.position.x;
            newPos.y = spike.transform.position.y + 3;
            newPos.z = spike.transform.position.z;
            Instantiate(coin, newPos, spike.transform.rotation);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
