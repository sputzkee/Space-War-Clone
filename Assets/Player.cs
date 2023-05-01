using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject ExplosionEffect; //oyun bittiğinde patlama efektinin belirmesi için ilgili kodu bu kısımda girdik.

    public GameObject PlayerBullet; //oyuncu doğal olarak ateş edeceğinden ötürü mermiyi tanımladık.

    public Image PlayerHealthBar; //oyuncunun sağlık barını girdik.

    public Administrator manage;

    float health = 100.0f; //sağlık değeri. //başlangıç değeri olarak. sabit kalacak.
                            
    float nowHealth = 100.0f; //hâlihazırda sağlık. //başlangıç değeri olacak. //kurşunla her temas sağlandığı vakit bu değerden düşülecek.

    float moveSpeed = 5.0f; //hareket hızı.

    float bulletSpeed = 500.0f; //kurşun hızı.

    

    private void OnTriggerEnter2D(Collider collision)
    {
        if(collision.gameObject.tag == "enemyBullet")
        {
            Destroy(collision.gameObject); //kurşun çarptığı zaman yok olmalı.

            decreaseHealth(10.0f); //can azalt fonksiyonunda parametreyi yolladık. //parametreyi girdik.

        }
    }
    void decreaseHealth(float value) //parametre gönderilebildiğinden bahisle parantez içine değişken ataması yapıldı.
    {
        nowHealth -= value; //elbette ki hâlihazırda candan düşülecek.

        PlayerHealthBar.fillAmount = nowHealth / health;

        if(nowHealth <= 0) //şuanki can 0'a eşit ya da 0'dan küçükse yok ol.
        {
            beLost(); //komutlandı.
        }
    }

    void beLost() //yok ol fonksiyonu tanımlandı. 
    {
        Destroy(gameObject); //ilgili fonksiyon nesneyi yok edecek. //bundan sonraki süreçte daha evvelden oluşturduğumuz oyun bitti/yeniden oyna panelinin devreye sokulması icap ediyor.
        GameObject newExplosion = Instantiate(ExplosionEffect, transform.position, Quaternion.identity); //yok olduktan sonra patlama efekti.
        Destroy(newExplosion, 1.0f); //patlama efektinin mütemadi olarak kalmaması için ilgili kodu girdik.
        manage.showPanel();

    }
    void firing() //ateş etme fonksiyonu, oyuncu kurşununu instantiate edecek yani örneklendirecek.
    {
        GameObject newBullet = Instantiate(PlayerBullet, transform.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);  //kurşun ihdas edince ona güç uygulamak suretiyle hareket ettirmeliyiz. Vector2.up denmesinin sebebi, oyunun 2d olması ve yönün yukarı istikametli olması. en nihayet de bulletSpeed.

        Destroy(newBullet, 2.0f); //kurşun herhangi bir şeye temas etmezse 2 saniye sonra yok olacak.
    }
    
    void Update()
    {
        float keySpecification = Input.GetAxis("Horizontal"); //tuş atandı.

        transform.Translate(keySpecification * Time.deltaTime * moveSpeed, 0, 0); //karakteri translate ile hareket ettiriyoruz.

        if (Input.GetKeyDown(KeyCode.Space)) //ateş etmek için.
        {
            firing(); //yazılmışsa ateş et fonksiyonu aktive olsun.
        }
    }
}
