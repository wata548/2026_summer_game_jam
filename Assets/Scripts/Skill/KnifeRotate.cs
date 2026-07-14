using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class KnifeRotate : MonoBehaviour
{

    [Header("Knife")]
    [SerializeField] private GameObject knifePrefab;

    [Header("Orbit")]
    [SerializeField] private float radius = 2.0f;
    [SerializeField] private float rotationSpeed = 180f;

    private List<Transform> knifes = new List<Transform>();

    private float currentAngle;

    private void Start()
    {
        AddKnife(3);
    }

    private void Update()
    {
        if (knifes.Count == 0)
            return;

        currentAngle += rotationSpeed * Time.deltaTime;

        UpdateKnifePosition();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddKnife(1);
        }
    }

    private void UpdateKnifePosition()
    {
        float angleStep = 360f / knifes.Count;

        for (int i = 0; i < knifes.Count; i++)
        {
            float angle = (currentAngle + angleStep * i) * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(
                Mathf.Cos(angle),
                Mathf.Sin(angle),
                0f
            ) * radius;

            knifes[i].localPosition = offset;

            float rotation = currentAngle + angleStep * i;
            knifes[i].rotation = Quaternion.Euler(0f, 0f, rotation + 90f);
        }
    }
    public void AddKnife(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject blade = Instantiate(knifePrefab, transform);
            knifes.Add(blade.transform);
        }
        UpdateKnifePosition();
    }
}
