using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float velocidade;                //Velocidade de movimento
    public float alturaPulo;                //Forca do pulo

    public Rigidbody2D playerRigidbody;     //Variavel do tipo Rigidbody2D para conseguirmos usar a fisica e fazer o pulo

    public Transform ground;                //GameObject vazio criado na Unity que sera nosso "sensor" posicinado no "pe"
                                            //do personagem. Usamos ele para verificar se o personagem esta encostando no chao

    public bool grounded;                   //Variavel booleana para sabermos quando o personagem esta na plataformar (TRUE)
                                            //ou quando esta pulando (FALSE)

    public LayerMask groundLayer;           //Na Unity as plataformas estao em um layer chamada Ground. Para o personagem pular,
                                            //precisamos saber quais GameObjects fazem o chao do jogo

    AudioSource audio;                      //AudioSource e necessario quando queremos tocar algum som durante o jogo
    public AudioClip jumpSound;             //Som tocado no pulo do personagem
    public AudioClip coinSound;             //Som tocado quando pegar as coins (pinguins)

    void Start()
    {
        //O personagem possui um componente AudioSource e para conseguirmos tocar sons durante o jogo,
        //com programacao, precisamos pegar esse componente e guardar em uma variavel que sera usada no script
        audio = GetComponent<AudioSource>();
    }

    //A funcao Update() que e repetida a todo momento executa a funcao Movimentar() e Jump()
    //Assim fazemos o personagem andar automaticamente e verificamos quando o jogador apertou a tecla de pulo
    void Update()
    {
        Movimentar();
        Jump();
    }

    void Movimentar()
    {
        //Como nosso personagem anda sozinho para a direita, nao precisamos verificar se o jogador apertou uma tecla
        //Basta colocarmos para se movimentar para a direita em uma certa velocidade
        //Por isso usamos o Vector2.right * velocidade
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    void Jump()
    {
        //O personagem so podera pular se estiver no chao, caso contrario o jogo viraria um FlappyBird

        //O Physics2D.OverlapCircle(ground.position, 0.2f, whatIsGround) cria um circulo invisivel na posicao do "pe"
        //do personagem e verifica se esta colidindo com uma layer especifica, nesse caso, a groundLayer
        //Se estiver, a variavel grounded fica em TRUE, ou seja, o personagem esta no chao
        grounded = Physics2D.OverlapCircle(ground.position, 0.2f, groundLayer);

        //Vefica se o jogador apertou o botao "Jump" E se a variavel grounded esta em TRUE
        //A tecla "Jump" padrao e a barra de espaco, porem, pode ser trocada acessando o menu Edit > Project Settings > Input
        //Se ele apertar, adicionamos forca para cima com o AddForce e o Vector2.up * alturaPulo
        //E tambem tocamos o som de pulo
        if (Input.GetButtonDown("Jump") && grounded == true) {
            playerRigidbody.AddForce(Vector2.up * alturaPulo);
            audio.PlayOneShot(jumpSound, 1.0F);
        }
    }

    //Funcao responsavel pelas colisoes com outros objetos
    //Nos criamos e adicionamos TAGS nos GameOjects para fazer as colisoes
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Se a colisao for com um GameObject com TAG "Spike", iremos reiniciar a tela atual
        if (collision.gameObject.tag == "Spike") {
            SceneManager.LoadScene(Application.loadedLevel);
        }

        //Se a colisao for com um GameObject com TAG "FinishPortal", iremos direto para a tela de Menu
        if (collision.gameObject.tag == "FinishPortal") {
            SceneManager.LoadScene("Menu");
        }
    }

    //Outra funcao responsavel por colisao

    //A diferenca e que quando usamos a OnCollisionEnter2D() a movimentacao do personagem ira perder velocidade
    //Como nao podemos perder velocidade na hora de pegar a coin (pinguim), usamos a funcao OnTriggerEnter2D()

    //A funcao OnTriggerEnter2D() nao funciona igual a colisao de objetos solidos. Ela funciona como uma armadilha
    //Quando algo encostar nela, dispara uma acao sem interferir na movimentacao

    //Para ela funcionar corretamente, preciamos marcar no Inspector das coins (pinguins) a caixinha Is Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Se a TAG do GameObject que o Player colidiu for "Coin"
        //Aumentamos a pontuacao em 1, destruimos a moeda e tocamos o som de moeda
        if (collision.gameObject.tag == "Coin") {
            CoinCounter.coins += 1;
            Destroy(collision.gameObject);
            audio.PlayOneShot(coinSound, 1.0F);
        }
    }
}
