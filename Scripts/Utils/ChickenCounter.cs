using Objects.Statue;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Utils;

namespace UI.Counter
{
    /*
     * A progress bar showing the amount of chickens.
     * Note : This code has not been purged of all the Northy Gaminess ;)
     */
    public class ChickenCounter : PUNSingleton<ChickenCounter>, IPunObservable
    {
        public static int currentValue;
        public static int maxValue = 50;

        public Image Barre;
        public TextMeshProUGUI Text;
        
        public void Start()
        {
            Barre = gameObject.GetComponent<Image>();

            if (Barre == null)
            {
                Debug.LogError("Fatal error : Barre is null.");
            }
            
            Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

            if (Text == null)
            {
                Debug.LogError("Fatal error : Text is null.");
            }
        }

        /**
         * A chicken spawns on the map.
         */
        public void Increment()
        {
            currentValue++;
            photonView.RPC("UpdateProgress", RpcTarget.All);
        }

        /**
         * A leprechaun successfully takes a chicken away.
         */
        public void Decrement()
        {
            currentValue--;
            photonView.RPC("UpdateProgress", RpcTarget.All);
        }

        [PunRPC]
        private void UpdateProgress()
        {
            // Update the statue
            StatueEvolve.Instance.ChickenAmountHasUpdated(currentValue);

            Text.text = currentValue + "/" + maxValue;

            if (maxValue == 0)
            {
                Debug.Log("max value oeuf est egal a 0");
                Barre.fillAmount = 1;
                return;
            }

            float value = currentValue * 100 / maxValue;
            Barre.fillAmount = value / 100;
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
        }
    }
}