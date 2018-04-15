using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splineGeneration : MonoBehaviour {

    Mesh racetrackMesh;

	// Use this for initialization
	void Start () {
		
	}
    

    Vector3 GetPoint(Vector3[] pts, float t)
    {
        float omt = 1f - t;
        float omt2 = omt * omt;
        float t2 = t * t;
        return pts[0] * (omt2 * omt) +
               pts[1] * (3f * omt2 * t) +
               pts[2] * (3f * omt * t2) +
               pts[3] * (t2 * t);

        //Vector3 a = Vector3.Lerp(pts[0], pts[1], t);
        //Vector3 b = Vector3.Lerp(pts[1], pts[2], t);
        //Vector3 c = Vector3.Lerp(pts[2], pts[3], t);
        //Vector3 d = Vector3.Lerp(a, b, t);
        //Vector3 e = Vector3.Lerp(b, c, t);
        //return Vector3.Lerp(d, e, t);
    }

    Vector3 GetTangent ( Vector3[] pts, float t)
    {
        float omt = 1f - t;
        float omt2 = omt * omt;
        float t2 = t * t;
        Vector3 tangent =
                pts[0] * (-omt2) +
                pts[1] * (3 * omt2 - 2 * omt) +
                pts[2] * (-3 * t2 + 2 * t) +
                pts[3] * (t2);
        return tangent.normalized;

    }

    Vector3 GetNormal3D( Vector3[] pts, float t, Vector3 up)
    {
        Vector3 tng = GetTangent(pts, t);
        Vector3 binormal = Vector3.Cross(up, tng).normalized;
        return Vector3.Cross(tng, binormal);
    }

    Quaternion GetOrientation3D(Vector3[] pts, float t, Vector3 up)
    {
        Vector3 tng = GetTangent(pts, t);
        Vector3 nrm = GetNormal3D(pts, t, up);
        return Quaternion.LookRotation(tng, nrm);
    }

    public class ExtrudeShape
    {
        public Vector2[] verts = new Vector2[4];
        public Vector2[] normals;
        public float[] us;
        public int[] lines = new int[]
        {
        0,1,
        2,3,
        3,4,
        4,5
        };
    }

    //public class ExtrudeShapeLeftStraight
    //{
    //    public Vector2[] verts = new Vector2[4];
    //    public Vector2[] normals;
    //    public float[] us;
    //    public int[] lines = new int[]
    //    {
    //    0,1,
    //    2,3,
    //    3,4,
    //    4,5
    //    };
    //}

    public struct OrientedPoint
    {
        public Vector3 position;
        public Quaternion rotation;
        public float vCoordinate;

        public OrientedPoint(Vector3 position, Quaternion rotation, float vCoordinate = 0)
        {
            this.position = position;
            this.rotation = rotation;
            this.vCoordinate = vCoordinate;
        }

        public Vector3 LocalToWorld(Vector3 point)
        {
            return position + rotation * point;
        }

        public Vector3 WorldToLocal(Vector3 point)
        {
            return Quaternion.Inverse(rotation) * (point - position);
        }

        public Vector3 LocalToWorldDirection(Vector3 dir)
        {
            return rotation * dir;
        }

    }


    //private OrientedPoint[] GetPath()
    //{
    //    /*return new OrientedPoint[] {
    //        new OrientedPoint(
    //            new Vector3(0, 0, 0),
    //            Quaternion.identity),
    //        new OrientedPoint(
    //            new Vector3(0, 1, 1),
    //            Quaternion.identity),
    //        new OrientedPoint(
    //            new Vector3(0, 0, 2),
    //            Quaternion.identity)
    //    };*/

    //    var p = new Vector3[] {
    //            new Vector3(0, 0, 0),
    //            new Vector3(0, 0, 10),
    //            new Vector3(10, 0, 10),
    //            new Vector3(10, 0, 0)
    //        };

    //    var path = new List<OrientedPoint>();

    //    for (float t = 0; t <= 1; t += 0.1f)
    //    {
    //        var point = GetPoint(p, t);
    //        var rotation = GetOrientation3D(p, t, Vector3.up);
    //        path.Add(new OrientedPoint(point, rotation));
    //    }

    //    return path.ToArray();
    //}

    public void Extrude(Mesh mesh, ExtrudeShape shape, OrientedPoint[] path)
    {
        int vertsInShape = shape.verts.Length;
        int segments = path.Length - 1;
        int edgeLoops = path.Length;
        int vertCount = vertsInShape * edgeLoops;
        int triCount = shape.lines.Length * segments;
        int triIndexCount = triCount * 3;

        int[] triangleIndices = new int[triIndexCount];
        Vector3[] vertices = new Vector3[vertCount];
        Vector3[] normals = new Vector3[vertCount];
        Vector2[] uvs = new Vector2[vertCount];

        // Generation code here

        for(int i = 0; i < path.Length; i++)
        {
            int offset = i * vertsInShape;
            for (int j = 0; j < vertsInShape; j++)
            {
                int id = offset + j;
                vertices[id] = path[i].LocalToWorld(shape.verts[j]);
                normals[id] = path[i].LocalToWorldDirection(shape.normals[j]);
                uvs[id] = new Vector2(shape.us[j], path[i].vCoordinate);
            }
        }

        int ti = 0;
        for (int i = 0; i < segments; i++)
        {
            int offset = i * vertsInShape;
            for (int l = 0; l < shape.lines.Length; l += 2)
            {
                int a = offset + shape.lines[l]+ vertsInShape; // remove vertsinshape
                int b = offset + shape.lines[l]; // add + vertsinshape
                int c = offset + shape.lines[l + 1]; // add + vertsinshape
                int d = offset + shape.lines[l + 1] + vertsInShape; // remove vertsinshape
                triangleIndices[ti++] = a;
                triangleIndices[ti++] = b;
                triangleIndices[ti++] = c;
                triangleIndices[ti++] = c;
                triangleIndices[ti++] = d;
                triangleIndices[ti++] = a;
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangleIndices;
        mesh.normals = normals;
        mesh.uv = uvs;

    }

   

    //private void GenerateMesh()
    //{
    //    var mesh = GetMesh();
    //    var shape = GetExtrudeShape();
    //    var path = GetPath();

    //    Extrude(mesh, shape, path);
    //}


   // private ExtrudeShape GetExtrudeShape()
   // {
        //var vert2Ds = new Vertex[] {
        //        new Vertex(
        //            new Vector3(0, 0, 0),
        //            new Vector3(0, 1, 0),
        //            0),
        //        new Vertex(
        //            new Vector3(2, 0, 0),
        //            new Vector3(0, 1, 0),
        //            0.5f),
        //        new Vertex(
        //            new Vector3(2, 0, 0),
        //            new Vector3(0, 1, 0),
        //            0.5f),
        //        new Vertex(
        //            new Vector3(4, 0, 0),
        //            new Vector3(0, 1, 0),
        //            1)
        //    };

        //var lines = new int[] {
        //        0, 1,
        //        1, 2,
        //        2, 3
        //    };

        //return new ExtrudeShape(vert2Ds, lines);
    //}

    //private Mesh GetMesh()
    //{
    //    if (mf.sharedMesh == null)
    //    {
    //        mf.sharedMesh = new Mesh();
    //    }
    //    return mf.sharedMesh;
    //}

    //public static class FloatArrayExtensions
    //{

    //public static float Sample(this float[] fArr, float t)
    //{
    //    int count = fArr.Length;
    //    if (count == 0)
    //    {
    //        Debug.LogError("Unable to sample array - it has no elements.");
    //        return 0;
    //    }

    //    if (count == 1) return fArr[0];

    //    float f = t * (count - 1);
    //    int idLower = Mathf.FloorToInt(f);
    //    int idUpper = Mathf.FloorToInt(f + 1);

    //    if (idUpper >= count) return fArr[count - 1];
    //    if (idLower < 0) return fArr[0];

    //    return Mathf.Lerp(fArr[idLower], fArr[idUpper], f - idLower);
    //}
    //}



    void splineCreation()
    {
        

        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf.sharedMesh == null)
        {
            mf.sharedMesh = new Mesh();
        }
        Mesh mesh = mf.sharedMesh;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3( 1, 0, 1),
            new Vector3( -1, 0, 1),
            new Vector3( 1, 0, -1),
            new Vector3( -1, 0, -1)
        };

        Vector3[] normals = new Vector3[]
        {
            new Vector3( 0, 1, 0),
            new Vector3( 0, 1, 0),
            new Vector3( 0, 1, 0),
            new Vector3( 0, 1, 0)
        };

        Vector2[] uvs = new Vector2[]
        {
            // U coordinates first, V coordinates second
            // Similar to X and Y

            new Vector2 ( 0, 1 ),
            new Vector2 ( 0, 0 ),
            new Vector2 ( 1, 1 ),
            new Vector2 ( 1, 0 )
        };

        int[] triangles = new int[]
        {
            0, 2, 3, // First triangle
            3, 1 ,0 // Second triangle
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;


        

        // Make sure each object has their own unique mesh
        // UniqueMesh class...
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public static class FloatArrayExtensions
{


    public static float Sample(this float[] fArr, float t)
    {
        int count = fArr.Length;
        if (count == 0)
        {
            Debug.LogError("Unable to sample array - it has no elements.");
            return 0;
        }

        if (count == 1) return fArr[0];

        float f = t * (count - 1);
        int idLower = Mathf.FloorToInt(f);
        int idUpper = Mathf.FloorToInt(f + 1);

        if (idUpper >= count) return fArr[count - 1];
        if (idLower < 0) return fArr[0];

        return Mathf.Lerp(fArr[idLower], fArr[idUpper], f - idLower);
    }
}
