
using UnityEngine;

public class Paddlenoise : MonoBehaviour
{
    public void Paddlein() {
        Audiomana.Audioinstance.Play("Paddlein");

    }

    public void Paddleoout() {
        Audiomana.Audioinstance.Play("Paddleout");

    }
}
