using System;
using System.Numerics;

namespace GeometryTests;

// Simplified Quaternion for testing (copied from OpenTK.Mathematics)
public struct Quaterniond
{
    public double X;
    public double Y;
    public double Z;
    public double W;

    public Quaterniond(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public override string ToString()
    {
        return $"({X:F6}, {Y:F6}, {Z:F6}, {W:F6})";
    }
}

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
    public const double PIOVER180 = Math.PI / 180;

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

    // Quaternion methods from Utils.cs
    public static void BuildQuaternionFromAxis(ref Vector3 vec, double angle, ref Quaterniond res_quat)
    {
        double sinAngle;
        angle = angle * PIOVER180 / 2;

        sinAngle = Math.Sin(angle);

        res_quat.X = vec.X * sinAngle;
        res_quat.Y = vec.Y * sinAngle;
        res_quat.Z = vec.Z * sinAngle;
        res_quat.W = Math.Cos(angle);
    }

    public static void MultiplyQuaternions(Quaterniond quat_a, Quaterniond quat_b, ref Quaterniond res_quat)
    {
        res_quat.X = quat_a.W * quat_b.X + quat_a.X * quat_b.W + quat_a.Y * quat_b.Z - quat_a.Z * quat_b.Y;
        res_quat.Y = quat_a.W * quat_b.Y + quat_a.Y * quat_b.W + quat_a.Z * quat_b.X - quat_a.X * quat_b.Z;
        res_quat.Z = quat_a.W * quat_b.Z + quat_a.Z * quat_b.W + quat_a.X * quat_b.Y - quat_a.Y * quat_b.X;
        res_quat.W = quat_a.W * quat_b.W - quat_a.X * quat_b.X - quat_a.Y * quat_b.Y - quat_a.Z * quat_b.Z;
    }

    public static void BuildMatrixFromQuaternion(Quaterniond quat, ref double[] mat_res)
    {
        double x2, y2, z2;
        double xy, xz, yz;
        double wx, wy, wz;

        x2 = quat.X * quat.X;
        y2 = quat.Y * quat.Y;
        z2 = quat.Z * quat.Z;

        xy = quat.X * quat.Y;
        xz = quat.X * quat.Z;
        yz = quat.Y * quat.Z;

        wx = quat.W * quat.X;
        wy = quat.W * quat.Y;
        wz = quat.W * quat.Z;

        mat_res[0] = 1 - 2 * (y2 + z2);
        mat_res[4] = 2 * (xy - wz);
        mat_res[8] = 2 * (xz + wy);
        mat_res[12] = 0;
        mat_res[1] = 2 * (xy + wz);
        mat_res[5] = 1 - 2 * (x2 + z2);
        mat_res[9] = 2 * (yz - wx);
        mat_res[13] = 0;
        mat_res[2] = 2 * (xz - wy);
        mat_res[6] = 2 * (yz + wx);
        mat_res[10] = 1 - 2 * (x2 + y2);
        mat_res[14] = 0;
        mat_res[3] = 0;
        mat_res[7] = 0;
        mat_res[11] = 0;
        mat_res[15] = 1;
    }

    // DEPRECATED: BuildRotationMatrixWithQuaternions (Y→X→Z) - kept for regression testing
    // This function uses incorrect rotation order and has been removed from main codebase
    // Maintained here for backward compatibility testing only
    // Main code now uses BuildRotationMatrixWithQuaternionsXYZ (X→Y→Z)
    public static void BuildRotationMatrixWithQuaternions(double alpha, double beta, double gamma, ref double[] mat_res)
    {
        Quaterniond quat_x = new Quaterniond();
        Quaterniond quat_y = new Quaterniond();
        Quaterniond quat_z = new Quaterniond();
        Quaterniond quat_xy = new Quaterniond();
        Quaterniond quat_xyz = new Quaterniond();

        Vector3 px = new Vector3(1, 0, 0);
        Vector3 py = new Vector3(0, 1, 0);
        Vector3 pz = new Vector3(0, 0, 1);

        BuildQuaternionFromAxis(ref px, alpha, ref quat_x);
        BuildQuaternionFromAxis(ref py, beta, ref quat_y);
        BuildQuaternionFromAxis(ref pz, gamma, ref quat_z);

        MultiplyQuaternions(quat_y, quat_x, ref quat_xy);
        MultiplyQuaternions(quat_xy, quat_z, ref quat_xyz);

        BuildMatrixFromQuaternion(quat_xyz, ref mat_res);
    }

    // X→Y→Z rotation order (correct order - matches rendering pipeline)
    public static void BuildRotationMatrixWithQuaternionsXYZ(double alpha, double beta, double gamma, ref double[] mat_res)
    {
        Quaterniond quat_x = new Quaterniond();
        Quaterniond quat_y = new Quaterniond();
        Quaterniond quat_z = new Quaterniond();
        Quaterniond quat_xy = new Quaterniond();
        Quaterniond quat_xyz = new Quaterniond();

        Vector3 px = new Vector3(1, 0, 0);
        Vector3 py = new Vector3(0, 1, 0);
        Vector3 pz = new Vector3(0, 0, 1);

        BuildQuaternionFromAxis(ref px, alpha, ref quat_x);
        BuildQuaternionFromAxis(ref py, beta, ref quat_y);
        BuildQuaternionFromAxis(ref pz, gamma, ref quat_z);

        MultiplyQuaternions(quat_x, quat_y, ref quat_xy);
        MultiplyQuaternions(quat_xy, quat_z, ref quat_xyz);

        BuildMatrixFromQuaternion(quat_xyz, ref mat_res);
    }

    public static void MultiplyPoint3DByOGLMatrix(double[] matA, Vector3 p_in, ref Vector3 p_out)
    {
        p_out.X = (float)(p_in.X * matA[0] + p_in.Y * matA[4] + p_in.Z * matA[8] + matA[12]);
        p_out.Y = (float)(p_in.X * matA[1] + p_in.Y * matA[5] + p_in.Z * matA[9] + matA[13]);
        p_out.Z = (float)(p_in.X * matA[2] + p_in.Y * matA[6] + p_in.Z * matA[10] + matA[14]);
    }

    public static void ComputeTransformedBoxBoundingBox(double[] MV_matrix, ref Vector3 p_min, ref Vector3 p_max,
                                                                 ref Vector3 p_min_trans, ref Vector3 p_max_trans)
    {
        Vector3[] box_pointsV = new Vector3[8];
        Vector3 p_aux_trans = new Vector3();
        int iBoxPoints;

        p_max_trans.X = float.NegativeInfinity;
        p_max_trans.Y = float.NegativeInfinity;
        p_max_trans.Z = float.NegativeInfinity;

        p_min_trans.X = float.PositiveInfinity;
        p_min_trans.Y = float.PositiveInfinity;
        p_min_trans.Z = float.PositiveInfinity;

        box_pointsV[0] = p_min;

        box_pointsV[1].X = p_min.X;
        box_pointsV[1].Y = p_min.Y;
        box_pointsV[1].Z = p_max.Z;

        box_pointsV[2].X = p_min.X;
        box_pointsV[2].Y = p_max.Y;
        box_pointsV[2].Z = p_min.Z;

        box_pointsV[3].X = p_min.X;
        box_pointsV[3].Y = p_max.Y;
        box_pointsV[3].Z = p_max.Z;

        box_pointsV[4] = p_max;

        box_pointsV[5].X = p_max.X;
        box_pointsV[5].Y = p_max.Y;
        box_pointsV[5].Z = p_min.Z;

        box_pointsV[6].X = p_max.X;
        box_pointsV[6].Y = p_min.Y;
        box_pointsV[6].Z = p_max.Z;

        box_pointsV[7].X = p_max.X;
        box_pointsV[7].Y = p_min.Y;
        box_pointsV[7].Z = p_min.Z;

        for (iBoxPoints = 0; iBoxPoints < 8; iBoxPoints++)
        {
            MultiplyPoint3DByOGLMatrix(MV_matrix, box_pointsV[iBoxPoints], ref p_aux_trans);

            if (p_max_trans.X < p_aux_trans.X) p_max_trans.X = p_aux_trans.X;
            if (p_max_trans.Y < p_aux_trans.Y) p_max_trans.Y = p_aux_trans.Y;
            if (p_max_trans.Z < p_aux_trans.Z) p_max_trans.Z = p_aux_trans.Z;

            if (p_min_trans.X > p_aux_trans.X) p_min_trans.X = p_aux_trans.X;
            if (p_min_trans.Y > p_aux_trans.Y) p_min_trans.Y = p_aux_trans.Y;
            if (p_min_trans.Z > p_aux_trans.Z) p_min_trans.Z = p_aux_trans.Z;
        }
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
        TestBuildQuaternionFromAxis();
        TestMultiplyQuaternions();
        TestBuildMatrixFromQuaternion();
        TestRotationMatrixYXZ();
        TestRotationMatrixXYZ();
        TestMultiplyPoint3DByOGLMatrix();
        TestComputeTransformedBoxBoundingBox();

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

    static void AssertEqual(double expected, double actual, string testName, double tolerance = 0.0001)
    {
        totalTests++;
        double diff = Math.Abs(expected - actual);

        if (diff <= tolerance)
        {
            passedTests++;
            Console.WriteLine($"✓ {testName} PASSED");
        }
        else
        {
            failedTests++;
            Console.WriteLine($"✗ {testName} FAILED");
            Console.WriteLine($"  Expected: {expected:F10}, Got: {actual:F10}, Diff: {diff:F10}");
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

    static void TestBuildQuaternionFromAxis()
    {
        Console.WriteLine("\n--- Testing BuildQuaternionFromAxis ---");

        // Test 1: Identity rotation (0 degrees) around X axis should give quaternion (0, 0, 0, 1)
        Vector3 axis1 = new Vector3(1, 0, 0);
        Quaterniond result1 = new Quaterniond();
        GeometryUtils.BuildQuaternionFromAxis(ref axis1, 0, ref result1);
        AssertEqual(1.0, result1.W, "BuildQuaternionFromAxis(0 deg around X)", 0.0001);

        // Test 2: 90 degrees around Y axis
        Vector3 axis2 = new Vector3(0, 1, 0);
        Quaterniond result2 = new Quaterniond();
        GeometryUtils.BuildQuaternionFromAxis(ref axis2, 90, ref result2);
        // cos(45°) ≈ 0.707, sin(45°) ≈ 0.707
        AssertEqual(0.7071068, result2.W, "BuildQuaternionFromAxis(90 deg around Y)", 0.01);
    }

    static void TestMultiplyQuaternions()
    {
        Console.WriteLine("\n--- Testing MultiplyQuaternions ---");

        // Test: Multiply identity quaternion (0,0,0,1) with itself should give identity
        Quaterniond q1 = new Quaterniond(0, 0, 0, 1);
        Quaterniond q2 = new Quaterniond(0, 0, 0, 1);
        Quaterniond result = new Quaterniond();
        GeometryUtils.MultiplyQuaternions(q1, q2, ref result);
        AssertEqual(1.0, result.W, "MultiplyQuaternions(identity * identity)", 0.0001);
        AssertEqual(0.0, result.X, "MultiplyQuaternions(identity * identity) X", 0.0001);
    }

    static void TestBuildMatrixFromQuaternion()
    {
        Console.WriteLine("\n--- Testing BuildMatrixFromQuaternion ---");

        // Test: Identity quaternion should give identity matrix
        Quaterniond quat = new Quaterniond(0, 0, 0, 1);
        double[] mat = new double[16];
        GeometryUtils.BuildMatrixFromQuaternion(quat, ref mat);

        // Check diagonal elements are 1, off-diagonal are 0
        AssertEqual(1.0, mat[0], "BuildMatrixFromQuaternion(identity) m00", 0.0001);
        AssertEqual(1.0, mat[5], "BuildMatrixFromQuaternion(identity) m11", 0.0001);
        AssertEqual(1.0, mat[10], "BuildMatrixFromQuaternion(identity) m22", 0.0001);
        AssertEqual(1.0, mat[15], "BuildMatrixFromQuaternion(identity) m33", 0.0001);
    }

    static void TestRotationMatrixYXZ()
    {
        Console.WriteLine("\n--- Testing BuildRotationMatrixWithQuaternions (Y→X→Z) ---");

        // Test: Identity rotation should give identity matrix
        double[] mat = new double[16];
        GeometryUtils.BuildRotationMatrixWithQuaternions(0, 0, 0, ref mat);

        AssertEqual(1.0, mat[0], "RotationMatrix YXZ(identity) m00", 0.0001);
        AssertEqual(1.0, mat[5], "RotationMatrix YXZ(identity) m11", 0.0001);
        AssertEqual(1.0, mat[10], "RotationMatrix YXZ(identity) m22", 0.0001);
        AssertEqual(1.0, mat[15], "RotationMatrix YXZ(identity) m33", 0.0001);
    }

    static void TestRotationMatrixXYZ()
    {
        Console.WriteLine("\n--- Testing BuildRotationMatrixWithQuaternionsXYZ (X→Y→Z) ---");

        // Test: Identity rotation should give identity matrix
        double[] mat = new double[16];
        GeometryUtils.BuildRotationMatrixWithQuaternionsXYZ(0, 0, 0, ref mat);

        AssertEqual(1.0, mat[0], "RotationMatrix XYZ(identity) m00", 0.0001);
        AssertEqual(1.0, mat[5], "RotationMatrix XYZ(identity) m11", 0.0001);
        AssertEqual(1.0, mat[10], "RotationMatrix XYZ(identity) m22", 0.0001);
        AssertEqual(1.0, mat[15], "RotationMatrix XYZ(identity) m33", 0.0001);
    }

    static void TestMultiplyPoint3DByOGLMatrix()
    {
        Console.WriteLine("\n--- Testing MultiplyPoint3DByOGLMatrix ---");

        // Test: Multiply point by identity matrix should give same point
        double[] identityMat = new double[16]
        {
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        };

        Vector3 point = new Vector3(3, 4, 5);
        Vector3 result = new Vector3();
        GeometryUtils.MultiplyPoint3DByOGLMatrix(identityMat, point, ref result);

        AssertEqual(point, result, "MultiplyPoint3DByOGLMatrix(identity * point)");
    }

    static void TestComputeTransformedBoxBoundingBox()
    {
        Console.WriteLine("\n--- Testing ComputeTransformedBoxBoundingBox ---");

        // Test: Identity transform should keep bounding box unchanged
        double[] identityMat = new double[16]
        {
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        };

        Vector3 p_min = new Vector3(-1, -1, -1);
        Vector3 p_max = new Vector3(1, 1, 1);
        Vector3 p_min_trans = new Vector3();
        Vector3 p_max_trans = new Vector3();

        GeometryUtils.ComputeTransformedBoxBoundingBox(identityMat, ref p_min, ref p_max, ref p_min_trans, ref p_max_trans);

        // Check each component separately since tolerance is small
        AssertEqual(p_min.X, p_min_trans.X, "ComputeTransformedBoxBoundingBox(identity) p_min.X", 0.01f);
        AssertEqual(p_min.Y, p_min_trans.Y, "ComputeTransformedBoxBoundingBox(identity) p_min.Y", 0.01f);
        AssertEqual(p_min.Z, p_min_trans.Z, "ComputeTransformedBoxBoundingBox(identity) p_min.Z", 0.01f);
        AssertEqual(p_max.X, p_max_trans.X, "ComputeTransformedBoxBoundingBox(identity) p_max.X", 0.01f);
        AssertEqual(p_max.Y, p_max_trans.Y, "ComputeTransformedBoxBoundingBox(identity) p_max.Y", 0.01f);
        AssertEqual(p_max.Z, p_max_trans.Z, "ComputeTransformedBoxBoundingBox(identity) p_max.Z", 0.01f);
    }
}
