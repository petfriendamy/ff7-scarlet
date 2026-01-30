using System;
using System.Numerics;

namespace GeometryTests;

// Simplified Vector3 for testing (copied from OpenTK.Mathematics)
public struct Vector3
{
    public float X;
    public float Y;
    public float Z;

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"({X:F4}, {Y:F4}, {Z:F4})";
    }
}

// Geometry utilities copied from Utils.cs for testing
public static class GeometryUtils
{
    public static float CalculateLength3D(Vector3 v)
    {
        return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
    }

    public static Vector3 AddPoint3D(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector3 SubstractPoint3D(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public static Vector3 DividePoint3D(Vector3 v, float fScalar)
    {
        return new Vector3(v.X / fScalar, v.Y / fScalar, v.Z / fScalar);
    }

    public static Vector3 Normalize(Vector3 v)
    {
        float fLength = CalculateLength3D(v);
        return DividePoint3D(v, fLength);
    }

    public static float CalculateDistance(Vector3 v0, Vector3 v1)
    {
        float fDeltaX = v1.X - v0.X;
        float fDeltaY = v1.Y - v0.Y;
        float fDeltaZ = v1.Z - v0.Z;

        return (float)Math.Sqrt(fDeltaX * fDeltaX + fDeltaY * fDeltaY + fDeltaZ * fDeltaZ);
    }

    public static float ComputeSceneRadius(Vector3 p_min, Vector3 p_max)
    {
        float model_radius, distance_origin;

        Vector3 center_model = new Vector3((p_min.X + p_max.X) / 2.0f,
                                                (p_min.Y + p_max.Y) / 2.0f,
                                                (p_min.Z + p_max.Z) / 2.0f);

        Vector3 origin = new Vector3(0, 0, 0);

        model_radius = CalculateDistance(p_min, p_max) / 2;
        distance_origin = CalculateDistance(center_model, origin);

        return model_radius + distance_origin;
    }
}

// Simple test runner
public class Program
{
    static int totalTests = 0;
    static int passedTests = 0;
    static int failedTests = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("=== Geometry Utilities Tests ===\n");

        TestCalculateDistance();
        TestAddPoint3D();
        TestSubstractPoint3D();
        TestCalculateLength3D();
        TestNormalize();
        TestComputeSceneRadius();

        Console.WriteLine($"\n=== Test Results ===");
        Console.WriteLine($"Total Tests: {totalTests}");
        Console.WriteLine($"Passed: {passedTests}");
        Console.WriteLine($"Failed: {failedTests}");
        Console.WriteLine($"Success Rate: {(passedTests * 100.0 / totalTests):F1}%");

        if (failedTests > 0)
        {
            Environment.Exit(1);
        }
    }

    static void AssertEqual(float expected, float actual, string testName, float tolerance = 0.0001f)
    {
        totalTests++;
        float diff = Math.Abs(expected - actual);

        if (diff <= tolerance)
        {
            passedTests++;
            Console.WriteLine($"✓ {testName} PASSED");
        }
        else
        {
            failedTests++;
            Console.WriteLine($"✗ {testName} FAILED");
            Console.WriteLine($"  Expected: {expected:F6}, Got: {actual:F6}, Diff: {diff:F6}");
        }
    }

    static void AssertEqual(Vector3 expected, Vector3 actual, string testName, float tolerance = 0.0001f)
    {
        totalTests++;
        float dx = actual.X - expected.X;
        float dy = actual.Y - expected.Y;
        float dz = actual.Z - expected.Z;
        float diff = (float)Math.Sqrt(dx*dx + dy*dy + dz*dz);

        if (diff <= tolerance)
        {
            passedTests++;
            Console.WriteLine($"✓ {testName} PASSED");
        }
        else
        {
            failedTests++;
            Console.WriteLine($"✗ {testName} FAILED");
            Console.WriteLine($"  Expected: {expected}, Got: {actual}, Diff: {diff:F6}");
        }
    }

    static void TestCalculateDistance()
    {
        Console.WriteLine("\n--- Testing CalculateDistance ---");

        // Test 1: Distance from origin to (3, 4, 0) should be 5 (3-4-5 triangle)
        Vector3 p1 = new Vector3(0, 0, 0);
        Vector3 p2 = new Vector3(3, 4, 0);
        float expected = 5.0f;
        float actual = GeometryUtils.CalculateDistance(p1, p2);
        AssertEqual(expected, actual, "CalculateDistance(0,0,0 to 3,4,0)");

        // Test 2: Distance between two arbitrary points
        Vector3 p3 = new Vector3(1, 2, 3);
        Vector3 p4 = new Vector3(4, 6, 8);
        float expected2 = (float)Math.Sqrt(3*3 + 4*4 + 5*5); // sqrt(9+16+25) = sqrt(50) ≈ 7.071
        float actual2 = GeometryUtils.CalculateDistance(p3, p4);
        AssertEqual(expected2, actual2, "CalculateDistance(1,2,3 to 4,6,8)");
    }

    static void TestAddPoint3D()
    {
        Console.WriteLine("\n--- Testing AddPoint3D ---");

        Vector3 v1 = new Vector3(1, 2, 3);
        Vector3 v2 = new Vector3(4, 5, 6);
        Vector3 expected = new Vector3(5, 7, 9);
        Vector3 actual = GeometryUtils.AddPoint3D(v1, v2);
        AssertEqual(expected, actual, "AddPoint3D(1,2,3 + 4,5,6)");
    }

    static void TestSubstractPoint3D()
    {
        Console.WriteLine("\n--- Testing SubstractPoint3D ---");

        Vector3 v1 = new Vector3(5, 7, 9);
        Vector3 v2 = new Vector3(4, 5, 6);
        Vector3 expected = new Vector3(1, 2, 3);
        Vector3 actual = GeometryUtils.SubstractPoint3D(v1, v2);
        AssertEqual(expected, actual, "SubstractPoint3D(5,7,9 - 4,5,6)");
    }

    static void TestCalculateLength3D()
    {
        Console.WriteLine("\n--- Testing CalculateLength3D ---");

        // Test 1: Vector (3, 4, 0) length should be 5
        Vector3 v1 = new Vector3(3, 4, 0);
        float expected1 = 5.0f;
        float actual1 = GeometryUtils.CalculateLength3D(v1);
        AssertEqual(expected1, actual1, "CalculateLength3D(3,4,0)");

        // Test 2: Vector (1, 1, 1) length should be sqrt(3) ≈ 1.732
        Vector3 v2 = new Vector3(1, 1, 1);
        float expected2 = (float)Math.Sqrt(3);
        float actual2 = GeometryUtils.CalculateLength3D(v2);
        AssertEqual(expected2, actual2, "CalculateLength3D(1,1,1)");
    }

    static void TestNormalize()
    {
        Console.WriteLine("\n--- Testing Normalize ---");

        // Test 1: Normalize vector (3, 4, 0) should give (0.6, 0.8, 0)
        Vector3 v1 = new Vector3(3, 4, 0);
        Vector3 expected1 = new Vector3(0.6f, 0.8f, 0f);
        Vector3 actual1 = GeometryUtils.Normalize(v1);
        AssertEqual(expected1, actual1, "Normalize(3,4,0)");

        // Test 2: Normalize (1, 1, 1) should give normalized vector
        Vector3 v2 = new Vector3(1, 1, 1);
        float len = (float)Math.Sqrt(3);
        Vector3 expected2 = new Vector3(1/len, 1/len, 1/len);
        Vector3 actual2 = GeometryUtils.Normalize(v2);
        AssertEqual(expected2, actual2, "Normalize(1,1,1)");
    }

    static void TestComputeSceneRadius()
    {
        Console.WriteLine("\n--- Testing ComputeSceneRadius ---");

        // Test 1: Cube centered at origin with size 10
        // Model radius = diagonal of 10x10x10 cube / 2 = sqrt(300)/2 ≈ 8.66
        // Center = (0,0,0), distance from origin = 0
        // Scene radius = 8.66 + 0 ≈ 8.66
        Vector3 p_min1 = new Vector3(-5, -5, -5);
        Vector3 p_max1 = new Vector3(5, 5, 5);
        float expected1 = (float)Math.Sqrt(300) / 2;
        float actual1 = GeometryUtils.ComputeSceneRadius(p_min1, p_max1);
        AssertEqual(expected1, actual1, "ComputeSceneRadius(centered cube size 10)");

        // Test 2: Cube offset from origin
        // Model radius = sqrt(300)/2 ≈ 8.66
        // Center = (10, 10, 10), distance from origin = sqrt(300) ≈ 17.32
        // Scene radius = 8.66 + 17.32 ≈ 25.98
        Vector3 p_min2 = new Vector3(5, 5, 5);
        Vector3 p_max2 = new Vector3(15, 15, 15);
        float expected2 = (float)Math.Sqrt(300) / 2 + (float)Math.Sqrt(300);
        float actual2 = GeometryUtils.ComputeSceneRadius(p_min2, p_max2);
        AssertEqual(expected2, actual2, "ComputeSceneRadius(offset cube)");
    }
}
