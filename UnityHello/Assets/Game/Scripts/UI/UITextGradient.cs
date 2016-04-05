using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public partial class UITextGradient : BaseMeshEffect
{
    private enum Direction
    {
        Vertical,
        Horizontal,
    }

    [SerializeField]
    private Direction mDirection;

    [SerializeField]
    private Gradient mGradient;

    //public Color32 topColor = Color.white;
    //public Color32 bottomColor = Color.black;

    //public override void ModifyMesh(VertexHelper helper)
    //{
    //    if (!this.IsActive() || helper.currentVertCount == 0)
    //        return;

    //    List<UIVertex> vertexs = new List<UIVertex>();
    //    helper.GetUIVertexStream(vertexs);

    //    float bottomY = vertexs[0].position.y;
    //    float topY = vertexs[0].position.y;

    //    for (int i = 1; i < vertexs.Count; i++)
    //    {
    //        float y = vertexs[i].position.y;
    //        if (y > topY)
    //        {
    //            topY = y;
    //        }
    //        else if (y < bottomY)
    //        {
    //            bottomY = y;
    //        }
    //    }

    //    float uiElementHeight = topY - bottomY;

    //    UIVertex v = new UIVertex();

    //    for (int i = 0; i < helper.currentVertCount; i++)
    //    {
    //        helper.PopulateUIVertex(ref v, i);
    //        v.color = Color32.Lerp(bottomColor, topColor, (v.position.y - bottomY) / uiElementHeight);
    //        helper.SetUIVertex(v, i);
    //    }
    //}
    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || mGradient == null)
        {
            return;
        }

        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);

        if (vertexList == null || vertexList.Count == 0)
        {
            return;
        }

        float leftX = vertexList[0].position.x;
        float rightX = vertexList[0].position.x;

        float bottomY = vertexList[0].position.y;
        float topY = vertexList[0].position.y;

        for (int i = 1; i < vertexList.Count; i++)
        {
            float y = vertexList[i].position.y;
            if (y > topY)
            {
                topY = y;
            }
            else if (y < bottomY)
            {
                bottomY = y;
            }

            float x = vertexList[i].position.x;
            if (x > rightX)
            {
                rightX = x;
            }
            else if (x < leftX)
            {
                leftX = x;
            }
        }

        for (int i = 0; i < vertexList.Count; i++)
        {
            UIVertex uiVertex = vertexList[i];
            if (mDirection == Direction.Vertical)
            {
                uiVertex.color = mGradient.Evaluate((uiVertex.position.y - bottomY) / (topY - bottomY));
            }
            else
            {
                uiVertex.color = mGradient.Evaluate((uiVertex.position.x - leftX) / (rightX - leftX));
            }
            vertexList[i] = uiVertex;
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertexList);
    }
}
