using UnityEngine;

 public class SkeletonSword : MonoBehaviour
{
    public Enemigo Skeleton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindObjectOfType<PlayerStats>().TakeDamage(Skeleton.damage.GetValue());
            GameObject.FindObjectOfType<Jugador>().playerDamageSound();
        }
    }
}
