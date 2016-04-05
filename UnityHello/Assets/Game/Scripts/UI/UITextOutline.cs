using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UITextOutline : Shadow
{
    [Range(2, 16)]
    [SerializeField]
    private int mDivideAmoumt = 8;

    protected UITextOutline()
    {

    }

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive())
        {
            return;
        }

        List<UIVertex> verts = new List<UIVertex>();
        vh.GetUIVertexStream(verts);

        if (verts == null || verts.Count == 0)
        {
            return;
        }

        int start;
        int end = 0;

        for (float i = 0; i <= Mathf.PI * 2; i += Mathf.PI / (float)mDivideAmoumt)
        {
            start = end;
            end = verts.Count;
            ApplyShadow(verts, effectColor, start, end, effectDistance.x * Mathf.Cos(i), effectDistance.y * Mathf.Sin(i));
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(verts);
    }
}
