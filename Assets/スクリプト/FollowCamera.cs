using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("’Ç]‘ÎÛ")]
    [SerializeField] private Transform target;

    [Header("’Êí‚ÌƒIƒtƒZƒbƒg")]
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -10);

    [Header("’Ç]‚ÌŠŠ‚ç‚©‚³")]
    [SerializeField] private float smoothTime = 0.2f;

    [Header("æ“Ç‚Ý‹——£")]
    [SerializeField] private float lookAheadDistance = 2f;

    [Header("æ“Ç‚Ý‚ÌŠŠ‚ç‚©‚³")]
    [SerializeField] private float lookAheadSmooth = 5f;

    [Header("’Ç]Ý’è")]
    [SerializeField] private bool followX = true;
    [SerializeField] private bool followY = false;

    private Vector3 velocity;
    private Vector3 lastTargetPosition;
    private Vector3 currentLookAhead;

    private void Start()
    {
        if (target != null)
        {
            lastTargetPosition = target.position;
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 moveDelta = target.position - lastTargetPosition;

        Vector3 direction = new Vector3(moveDelta.x, moveDelta.y, 0);

        if (direction.sqrMagnitude > 0.0001f)
            direction.Normalize();

        Vector3 targetLookAhead = direction * lookAheadDistance;

        currentLookAhead = Vector3.Lerp(
            currentLookAhead,
            targetLookAhead,
            lookAheadSmooth * Time.deltaTime);

        Vector3 desiredPosition = target.position + offset + currentLookAhead;

        // X‚ðŒÅ’è‚·‚é‚©
        if (!followX)
            desiredPosition.x = transform.position.x;

        // Y‚ðŒÅ’è‚·‚é‚©
        if (!followY)
            desiredPosition.y = transform.position.y;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            smoothTime);

        lastTargetPosition = target.position;
    }
}