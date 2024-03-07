using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 0.05f;

    private Game game;

    private void Awake()
    {
        game = Game.Instance;
    }
    void Update()
    {
        if (transform.position.x < -6)
        {
            game.AddScore();
            game.DeleteEnemy(this);
        }
        else
            transform.Translate(-speed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        game.DeleteEnemy(this);
        game.Restart();
    }
}
