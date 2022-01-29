using UnityEngine;

public class AvatarInputConverter : MonoBehaviour
{

    [Header("Avatar Prefab Transforms")]
    public Transform avatarPrefab;
    public Transform avatarHead;
    public Transform avatarBody;
    public Transform avatarHandLeft;
    public Transform avatarHandRight;
    
    [Header("XR Origin Transforms")]
    public Transform xrMainCamera;
    public Transform xrHandLeft;
    public Transform xrHandRight;

    [Header("Off-Sets")]
    public Vector3 headPositionOffset;
    public Vector3 handRotationOffset;

    

    // Update is called once per frame
    void Update()
    {
        //Head and Body synch
        avatarPrefab.position = Vector3.Lerp(avatarPrefab.position, xrMainCamera.position + headPositionOffset, 0.5f);
        avatarHead.rotation = Quaternion.Lerp(avatarHead.rotation, xrMainCamera.rotation, 0.5f);
        avatarBody.rotation = Quaternion.Lerp(avatarBody.rotation, Quaternion.Euler(new Vector3(0, avatarHead.rotation.eulerAngles.y, 0)), 0.05f);

        //Hands synch
        avatarHandRight.position = Vector3.Lerp(avatarHandRight.position,xrHandRight.position,0.5f);
        avatarHandRight.rotation = Quaternion.Lerp(avatarHandRight.rotation,xrHandRight.rotation,0.5f)*Quaternion.Euler(handRotationOffset);

        avatarHandLeft.position = Vector3.Lerp(avatarHandLeft.position,xrHandLeft.position,0.5f);
        avatarHandLeft.rotation = Quaternion.Lerp(avatarHandLeft.rotation,xrHandLeft.rotation,0.5f)*Quaternion.Euler(handRotationOffset);
    }
}