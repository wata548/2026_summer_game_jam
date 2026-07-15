using UnityEngine;
using System.Collections.Generic;
using Data.Skill;
using Extension.Test;

public class KnifeRotate : MonoBehaviour
{

    [Header("Knife")]
    [SerializeField] private Knife knifePrefab;

    [Header("Orbit")]
    [SerializeField] private float radius = 1.0f;
    [SerializeField] private float rotationSpeed = 180f;

    private List<Knife> knifes = new();

    private float currentAngle;

    private void Update()
    {
        if (knifes.Count == 0)
            return;

        currentAngle += rotationSpeed * Time.deltaTime;

        UpdateKnifePosition();
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

            knifes[i].transform.localPosition = offset;

            float rotation = currentAngle + angleStep * i;
            knifes[i].transform.rotation = Quaternion.Euler(0f, 0f, rotation + 90f);
        }
    }
    
    [TestMethod]
    public void Set(int pCount, int pDamage) {
        while (pCount != knifes.Count) {
            if (pCount < knifes.Count)
                knifes.RemoveAt(0);
            else
                knifes.Add(Instantiate(knifePrefab, transform));
        }

        foreach (var knife in knifes) {
            knife.Set(pDamage);
        }
    }
}
