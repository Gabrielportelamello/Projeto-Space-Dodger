using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class LootLocker_Sistema : MonoBehaviour
{
    public TMP_InputField Nome;
    public TextMeshProUGUI Placar;
    public int ID;

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
         {
             if (response.success)
                 Debug.Log("Conectado");
             else
                 Debug.Log("Erro na conexão");
         });
    }

    public void EnviarPlacar()
    {
        LootLockerSDKManager.SubmitScore(Nome.text,int.Parse(Placar.text), ID, (response) =>
        {
            if (response.success)
                Debug.Log("Enviado");
            else
                Debug.Log("Erro no envio");
        });
    }
}

