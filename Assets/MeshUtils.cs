using UnityEngine;

public class MeshUtils
{
    public static Mesh CreateCubeMesh(Vector3 center, Vector3 size)
    {
        // Define the co-ordinates of each Corner of the cube 
        var c = new Vector3[8];

        c[0] = center + new Vector3(-size.x * .5f, -size.y * .5f, size.z * .5f);
        c[1] = center + new Vector3(size.x * .5f, -size.y * .5f, size.z * .5f);
        c[2] = center + new Vector3(size.x * .5f, -size.y * .5f, -size.z * .5f);
        c[3] = center + new Vector3(-size.x * .5f, -size.y * .5f, -size.z * .5f);

        c[4] = center + new Vector3(-size.x * .5f, size.y * .5f, size.z * .5f);
        c[5] = center + new Vector3(size.x * .5f, size.y * .5f, size.z * .5f);
        c[6] = center + new Vector3(size.x * .5f, size.y * .5f, -size.z * .5f);
        c[7] = center + new Vector3(-size.x * .5f, size.y * .5f, -size.z * .5f);


        // Define the vertices that the cube is composed of:
        // I have used 16 vertices (4 vertices per side). 
        // This is because I want the vertices of each side to have separate normals.
        // (so the object renders light/shade correctly) 
        Vector3[] vertices =
        {
            c[0], c[1], c[2], c[3], // Bottom
            c[7], c[4], c[0], c[3], // Left
            c[4], c[5], c[1], c[0], // Front
            c[6], c[7], c[3], c[2], // Back
            c[5], c[6], c[2], c[1], // Right
            c[7], c[6], c[5], c[4] // Top
        };


        // Define each vertex's Normal
        var up = Vector3.up;
        var down = Vector3.down;
        var forward = Vector3.forward;
        var back = Vector3.back;
        var left = Vector3.left;
        var right = Vector3.right;


        Vector3[] normals =
        {
            down, down, down, down, // Bottom
            left, left, left, left, // Left
            forward, forward, forward, forward, // Front
            back, back, back, back, // Back
            right, right, right, right, // Right
            up, up, up, up // Top
        };


        // Define each vertex's UV co-ordinates
        var uv00 = new Vector2(0f, 0f);
        var uv10 = new Vector2(1f, 0f);
        var uv01 = new Vector2(0f, 1f);
        var uv11 = new Vector2(1f, 1f);

        Vector2[] uvs =
        {
            uv11, uv01, uv00, uv10, // Bottom
            uv11, uv01, uv00, uv10, // Left
            uv11, uv01, uv00, uv10, // Front
            uv11, uv01, uv00, uv10, // Back	        
            uv11, uv01, uv00, uv10, // Right 
            uv11, uv01, uv00, uv10 // Top
        };


        // Define the Polygons (triangles) that make up the our Mesh (cube)
        // IMPORTANT: Unity uses a 'Clockwise Winding Order' for determining front-facing polygons.
        // This means that a polygon's vertices must be defined in 
        // a clockwise order (relative to the camera) in order to be rendered/visible.
        int[] triangles =
        {
            3, 1, 0, 3, 2, 1, // Bottom	
            7, 5, 4, 7, 6, 5, // Left
            11, 9, 8, 11, 10, 9, // Front
            15, 13, 12, 15, 14, 13, // Back
            19, 17, 16, 19, 18, 17, // Right
            23, 21, 20, 23, 22, 21, // Top
        };


        // Build the Mesh
        var mesh = new Mesh
        {
            vertices = vertices,
            triangles = triangles,
            normals = normals,
            uv = uvs,
            bounds = new Bounds(center, size)
        };

        return mesh;
    }
}