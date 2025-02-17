using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    [SerializeField] private RectTransform mapPanel;
    [SerializeField] private float animationSpeed = 5f;
    [SerializeField] private Button mapButton;
    private bool isMapOpen = false;

    private Vector2 hiddenPos = new Vector2(-415, -600); // Adjust for your UI layout
    private Vector2 visiblePos = new Vector2(-415, 276); // Adjust based on the UI
    private Coroutine currentAnimation;

    void Start()
    {
        mapPanel.anchoredPosition = hiddenPos;

        if (mapButton != null)
            mapButton.onClick.AddListener(ToggleMap);
    }

    void ToggleMap()
    {
        isMapOpen = !isMapOpen;
        Debug.Log("Map Button Press");
        if (currentAnimation != null)
            StopCoroutine(currentAnimation); // Stop any ongoing animation

        currentAnimation = StartCoroutine(AnimateMap(isMapOpen ? visiblePos : hiddenPos));
    }

    // animate movement of map between anchor points
    IEnumerator AnimateMap(Vector2 targetPos)
    {
        float elapsedTime = 0;
        Vector2 startPos = mapPanel.anchoredPosition;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * animationSpeed;
            mapPanel.anchoredPosition = Vector2.Lerp(startPos, targetPos, elapsedTime);
            yield return null;
        }

        mapPanel.anchoredPosition = targetPos; // Ensure it snaps to the final position
    }
}