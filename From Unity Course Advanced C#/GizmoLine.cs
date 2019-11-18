//---------------------------------------------------
using UnityEngine;
using System.Collections;
//---------------------------------------------------
public class GizmoLine : MonoBehaviour
{
	//---------------------------------------------------
	public Transform LineStart = null;
	public Transform LineEnd = null;
	//---------------------------------------------------
	void OnDrawGizmos()
	{
        DrawMyLine();
	}
    /// <summary>
    /// Draws a green line in the viewport given that none of the lines end or startpoints are null.
    /// </summary>
   private void DrawMyLine()
    {
        if (LineStart == null || LineEnd == null)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(LineStart.position, LineEnd.position);
    }
    //---------------------------------------------------
}
//---------------------------------------------------