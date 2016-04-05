using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public partial class UITextGradient : BaseMeshEffect
{
    public Color32 topColor = Color.white;
    public Color32 bottomColor = Color.black;

    public override void ModifyMesh(VertexHelper helper)
    {
        if (!this.IsActive() || helper.currentVertCount == 0)
            return;

        List<UIVertex> vertexs = new List<UIVertex>();
        helper.GetUIVertexStream(vertexs);

        float bottomY = vertexs[0].position.y;
        float topY = vertexs[0].position.y;

        for (int i = 1; i < vertexs.Count; i++)
        {
            float y = vertexs[i].position.y;
            if (y > topY)
            {
                topY = y;
            }
            else if (y < bottomY)
            {
                bottomY = y;
            }
        }

        float uiElementHeight = topY - bottomY;

        UIVertex v = new UIVertex();

        for (int i = 0; i < helper.currentVertCount; i++)
        {
            helper.PopulateUIVertex(ref v, i);
            v.color = Color32.Lerp(bottomColor, topColor, (v.position.y - bottomY) / uiElementHeight);
            helper.SetUIVertex(v, i);
        }
    }
}
