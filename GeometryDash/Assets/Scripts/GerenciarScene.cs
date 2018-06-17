using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciarScene : MonoBehaviour {

    public string sceneName;        //Variavel que vai guardar o nome da cena que queremos trocar
                                    //Ela e publica para usarmos pelo editar da Unity
                                    //Ela precisa ser do tipo string pois o nome da cena e um texto e nao numeros

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //A funcao StartGame() ira carregar a cena referente ao botao clicado no Menu
    //O nome da cena e configurado no Inspector do Botao
    public void StartGame(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    //A funcao GoToMenu() troca a cena diretamente para o Menu
    //Ela e usada no botao que fica dentro da Fase 3
    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
