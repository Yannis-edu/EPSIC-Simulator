using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public Player player;
    public Vector2 minPosition, maxPosition;
    public Text TxtZone, TxtAction, TxtDialog, TxtQuestion;
    public Image ImgQuestion;
    public GameObject mobileControl, pauseMenu;
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
    }

    /*private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[i].position), Vector2.zero);
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                hit.collider.gameObject.GetComponent<MobileButton>().Down();
            }
            if (Input.touches[i].phase == TouchPhase.Ended)
            {
                hit.collider.gameObject.GetComponent<MobileButton>().Up();
            }
        }
    }*/

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
