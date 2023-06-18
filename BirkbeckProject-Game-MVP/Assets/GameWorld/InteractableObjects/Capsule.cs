
using UnityEngine;

public class Capsule : MonoBehaviour, IDamagingObject
{
    public bool isDamaging { get; set; }
    public int damageValue { get; set; }

    private void Start()
    {
        {
            isDamaging = true;
            damageValue = 1;
        }
    }
}
