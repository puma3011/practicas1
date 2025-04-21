using UnityEngine;
using UnityEngine.UI;

public class JumpChargeUI : MonoBehaviour
{
    public JumpKingMovement jumpScript; // Script del personaje
    public Image chargeBarFill;         // Referencia al relleno

    void Update()
    {
        if (jumpScript.IsCharging)
        {
            chargeBarFill.fillAmount = jumpScript.ChargePercent;
        }
        else
        {
            chargeBarFill.fillAmount = 0f;
        }
    }
}
