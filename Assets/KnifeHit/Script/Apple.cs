/**
 * Apple.cs
 * Created by: #FreeBird#
 * Created on: #CREATIONDATE# (dd/mm/yy)
 */

using System.Collections;
using System.Collections.Generic;
using UniPay;
using UnityEngine;

public class Apple : MonoBehaviour {

	public ParticleSystem splatApple;
	public SpriteRenderer Sprite;
	public AudioClip appleHitSfx;

	// Use this for initialization
	public Rigidbody2D rb;
	void Start () {
		rb = GetComponentInChildren<Rigidbody2D> ();    
		rb.isKinematic = true;
	}
	void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Knife"))
        {
            // Lấy tất cả BoxCollider2D trên Knife
            BoxCollider2D[] knifeColliders = other.GetComponents<BoxCollider2D>();

            // Chỉ xử lý nếu collider va chạm là cái đầu tiên
            if (other == knifeColliders[0])
            {
                SoundManager.instance.PlaySingle(appleHitSfx);

                GameManager.Apple++;
                transform.parent = null;
                GetComponent<CircleCollider2D>().enabled = false;
                Sprite.enabled = false;
                splatApple.Play();
                Destroy(gameObject, 3f);
            }
        }
    }
}


