using UnityEngine;

public class BarilletController : MonoBehaviour
{
    public Transform[] bullets; // Tableau des balles (les GameObjects jaunes)
    private int currentBulletIndex = 0; // Index de la balle actuelle

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clique gauche
        {
            RotateBarillet();
        }
    }

    void RotateBarillet()
    {
        // Passer à la balle suivante
        currentBulletIndex = (currentBulletIndex + 1) % bullets.Length;

        // Calculer l'angle vers la balle suivante
        Vector3 targetPosition = bullets[currentBulletIndex].position;
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Appliquer la rotation
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}