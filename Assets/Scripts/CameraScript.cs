using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public Player player;
    public Vector2 minPosition, maxPosition;
    public Text TxtZone, TxtAction, TxtDialog, TxtQuestion;
    public Image ImgQuestion;
    public GameObject mobileControl, pauseMenu, trueIcon, falseIcon;
    public GameObject[] answers;
    private float width, height;

    /// <summary>
    /// Détéction du matériel
    /// </summary>
    private void Start()
    {      
        Camera camera = GetComponent<Camera>();
        height = 2f * camera.orthographicSize;
        width = height * camera.aspect;
        minPosition = maxPosition = transform.position;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            mobileControl.SetActive(true);
        }
        trueIcon.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        falseIcon.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(
            Mathf.Clamp(player.transform.position.x, minPosition.x + width / 2f, maxPosition.x - width / 2f),
            Mathf.Clamp(player.transform.position.y, minPosition.y + height / 2f, maxPosition.y - height / 2f),
            transform.position.z
        ), 50 * Time.fixedDeltaTime);


        if (SimpleInput.GetButtonDown("Cancel"))
        {
            StaticClass.disableInput = true;
            pauseMenu.SetActive(true);
        }
    }
}
