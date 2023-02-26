
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 1.0f;
    public System.Action killed;


    private SpriteRenderer SpriteRenderer;
    private int animationFrame;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        SpriteRenderer.sprite = animationSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            killed.Invoke();
            gameObject.SetActive(false);
        }
    }
}
