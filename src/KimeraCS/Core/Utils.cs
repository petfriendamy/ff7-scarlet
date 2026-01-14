using OpenTK.Graphics.OpenGL.Compatibility;
using OpenTK.Mathematics;
using KimeraCS.Rendering;

namespace KimeraCS.Core
{
    using static FF7PModel;

    public static class Utils
    {
        public const double PIOVER180 = Math.PI / 180;
        public const double QUAT_NORM_TOLERANCE = 0.00001;

        public const double EulRepYes = 1;
        public const double EulParOdd = 1;
        public const double EulFrmR = 1;
        public const float FLT_EPSILON = 1.192092896e-07f;
        public const float MAX_DELTA_SQUARED = 0.001f * 0.001f;

        public const double PI_180 = Math.PI / 180;

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

        //  Convert Quaternion to Matrix
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

            //  This calculation would be a lot more complicated for non-unit length quaternions
            //  Note: The constructor of Matrix4 expects the Matrix in column-major format like expected by
            //  OpenGL
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

        public static Quaterniond GetQuaternionFromEulerUniversal(double y, double x, double z, int i, int j, int k, int n, int s, int f)
        {
            double[] a = new double[3];
            double ti, tj, th, ci, cj, ch, si, sj, sh, cc, cs, sc, ss;

            double t;

            Quaterniond quat_GetQuaternionFromEulerUniversalResult = new Quaterniond();

            if (f == EulFrmR)
            {
                t = x;
                x = z;
                z = t;
            }

            if (n == EulParOdd) y = -y;

            ti = x * 0.5;
            tj = y * 0.5;
            th = z * 0.5;
            ci = Math.Cos(ti);
            cj = Math.Cos(tj);
            ch = Math.Cos(th);
            si = Math.Sin(ti);
            sj = Math.Sin(tj);
            sh = Math.Sin(th);
            cc = ci * ch;
            cs = ci * sh;
            sc = si * ch;
            ss = si * sh;

            if (s == EulRepYes)
            {
                a[i] = cj * (cs + sc); // Could speed up with trig identities.
                a[j] = sj * (cc + ss);
                a[k] = sj * (cs - sc);
                quat_GetQuaternionFromEulerUniversalResult.W = cj * (cc - ss);
            }
            else
            {
                a[i] = cj * sc - sj * cs; // Could speed up with trig identities.
                a[j] = cj * ss + sj * cc;
                a[k] = cj * cs - sj * sc;
                quat_GetQuaternionFromEulerUniversalResult.W = cj * cc + sj * ss;
            }

            if (n == EulParOdd) a[j] = -a[j];

            quat_GetQuaternionFromEulerUniversalResult.X = a[0];
            quat_GetQuaternionFromEulerUniversalResult.Y = a[1];
            quat_GetQuaternionFromEulerUniversalResult.Z = a[2];

            return quat_GetQuaternionFromEulerUniversalResult;
        }

        public static double QuaternionsDot(ref Quaterniond q1, ref Quaterniond q2)
        {
            return q1.X * q2.X + q1.Y * q2.Y + q1.Z * q2.Z + q1.W * q2.W;
        }

        public static void NormalizeQuaternion(ref Quaterniond quat)
        {
            // Don't normalize if we don't have to
            double mag, mag2;

            mag2 = quat.W * quat.W + quat.X * quat.X + quat.Y * quat.Y + quat.Z * quat.Z;

            mag = Math.Sqrt(mag2);

            quat.W /= mag;
            quat.X /= mag;
            quat.Y /= mag;
            quat.Z /= mag;

            //        NEW UDPATE vertex2995 fix for Hojo/Heidegger animations (by L@Zar0)
            //        If Abs(mag2 - 1#) > QUAT_NORM_TOLERANCE Then
            //            mag = Sqr(mag2)
            //            .W = .W / mag
            //            .X = .X / mag
            //            .Y = .Y / mag
            //            .Z = .Z / mag
            //        End If

            //        If .W > 1# Then
            //            .W = 1
            //        End If
        }

        public static Quaterniond QuaternionLerp(ref Quaterniond q1, ref Quaterniond q2, double t)
        {
            double one_minus_t;
            Quaterniond quat_QuaternionLerpResult = new Quaterniond();

            one_minus_t = 1f - t;

            quat_QuaternionLerpResult.X = q1.X * one_minus_t + q2.X * t;
            quat_QuaternionLerpResult.Y = q1.Y * one_minus_t + q2.Y * t;
            quat_QuaternionLerpResult.Z = q1.Z * one_minus_t + q2.Z * t;
            quat_QuaternionLerpResult.W = q1.W * one_minus_t + q2.W * t;

            NormalizeQuaternion(ref quat_QuaternionLerpResult);

            return quat_QuaternionLerpResult;
        }

        public static Quaterniond QuaternionSlerp2(ref Quaterniond q1, ref Quaterniond q2, double t)
        {
            Quaterniond q3 = new Quaterniond();
            Quaterniond quat_QuaternionSlerp2Result = new Quaterniond();

            double dot, angle, one_minus_t, sin_angle, sin_angle_by_t, sin_angle_by_one_t;

            dot = QuaternionsDot(ref q1, ref q2);
            //    dot = cos(theta)
            //    if (dot < 0), q1 and q2 are more than 90 degrees apart,
            //    so we can invert one to reduce spinning
            if (dot < 0)
            {
                dot = -dot;
                q3.X = -q2.X;
                q3.Y = -q2.Y;
                q3.Z = -q2.Z;
                q3.W = -q2.W;
            }
            else
            {
                q3.X = q2.X;
                q3.Y = q2.Y;
                q3.Z = q2.Z;
                q3.W = q2.W;
            }

            if (dot < 0.95)
            {
                angle = Math.Acos(dot);
                one_minus_t = 1f - t;
                sin_angle = Math.Sin(angle);
                sin_angle_by_t = Math.Sin(angle * t);
                sin_angle_by_one_t = Math.Sin(angle * one_minus_t);

                quat_QuaternionSlerp2Result.X = ((q1.X * sin_angle_by_one_t) + q3.X * sin_angle_by_t) / sin_angle;
                quat_QuaternionSlerp2Result.Y = ((q1.Y * sin_angle_by_one_t) + q3.Y * sin_angle_by_t) / sin_angle;
                quat_QuaternionSlerp2Result.Z = ((q1.Z * sin_angle_by_one_t) + q3.Z * sin_angle_by_t) / sin_angle;
                quat_QuaternionSlerp2Result.W = ((q1.W * sin_angle_by_one_t) + q3.W * sin_angle_by_t) / sin_angle;
            }
            else
            {
                quat_QuaternionSlerp2Result = QuaternionLerp(ref q1, ref q3, t);
            }

            return quat_QuaternionSlerp2Result;
        }

        public static double DegToRad(double x)
        {
            return x * Math.PI / 180f;
        }

        public static double RadToDeg(double x)
        {
            return x * 180f / Math.PI;
        }

        public static Quaterniond GetQuaternionFromEulerYXZr(double x, double y, double z)
        {
            return GetQuaternionFromEulerUniversal(DegToRad(x), DegToRad(y), DegToRad(z), 2, 0, 1, 0, 0, 1);
        }

        public static Vector3 GetEulerFormMatrixUniversal(double[] mat, int i, int j, int k, int n, int s, int f)
        {
            double sy, cy, t;
            Vector3 up3DGetEulerFormMatrixUniversalResult = new Vector3();

            if (s == EulRepYes)
            {
                sy = Math.Sqrt(mat[i + 4 * j] * mat[i + 4 * j] + mat[i + 4 * k] * mat[i + 4 * k]);
                if (sy > 16f * FLT_EPSILON)
                {
                    up3DGetEulerFormMatrixUniversalResult.X = (float)Math.Atan2(mat[i + 4 * j], mat[i + 4 * k]);
                    up3DGetEulerFormMatrixUniversalResult.Y = (float)Math.Atan2(sy, mat[i + 4 * i]);
                    up3DGetEulerFormMatrixUniversalResult.Z = (float)Math.Atan2(mat[j + 4 * i], -mat[k + 4 * i]);
                }
                else
                {
                    up3DGetEulerFormMatrixUniversalResult.X = (float)Math.Atan2(-mat[j + 4 * k], mat[j + 4 * j]);
                    up3DGetEulerFormMatrixUniversalResult.Y = (float)Math.Atan2(sy, mat[i + 4 * i]);
                    up3DGetEulerFormMatrixUniversalResult.Z = 0;
                }
            }
            else
            {
                cy = Math.Sqrt(mat[i + 4 * i] * mat[i + 4 * i] + mat[j + 4 * i] * mat[j + 4 * i]);
                if (cy >16f * FLT_EPSILON)
                {
                    up3DGetEulerFormMatrixUniversalResult.X = (float)Math.Atan2(mat[k + 4 * j], mat[k + 4 * k]);
                    up3DGetEulerFormMatrixUniversalResult.Y = (float)Math.Atan2(-mat[k + 4 * i], cy);
                    up3DGetEulerFormMatrixUniversalResult.Z = (float)Math.Atan2(mat[j + 4 * i], mat[i + 4 * i]);
                }
                else
                {
                    up3DGetEulerFormMatrixUniversalResult.X = (float)Math.Atan2(-mat[j + 4 * k], mat[j + 4 * j]);
                    up3DGetEulerFormMatrixUniversalResult.Y = (float)Math.Atan2(-mat[k + 4 * i], cy);
                    up3DGetEulerFormMatrixUniversalResult.Z = 0;
                }
            }

            if (n == EulParOdd)
            {
                up3DGetEulerFormMatrixUniversalResult.X = -up3DGetEulerFormMatrixUniversalResult.X;
                up3DGetEulerFormMatrixUniversalResult.Y = -up3DGetEulerFormMatrixUniversalResult.Y;
                up3DGetEulerFormMatrixUniversalResult.Z = -up3DGetEulerFormMatrixUniversalResult.Z;
            }

            if (f == EulFrmR)
            {
                t = up3DGetEulerFormMatrixUniversalResult.X;
                up3DGetEulerFormMatrixUniversalResult.X = up3DGetEulerFormMatrixUniversalResult.Z;
                up3DGetEulerFormMatrixUniversalResult.Z = (float)t;
            }

            up3DGetEulerFormMatrixUniversalResult.X = (float)RadToDeg(up3DGetEulerFormMatrixUniversalResult.X);
            up3DGetEulerFormMatrixUniversalResult.Y = (float)RadToDeg(up3DGetEulerFormMatrixUniversalResult.Y);
            up3DGetEulerFormMatrixUniversalResult.Z = (float)RadToDeg(up3DGetEulerFormMatrixUniversalResult.Z);

            return up3DGetEulerFormMatrixUniversalResult;
        }

        public static Vector3 GetEulerYXZrFromMatrix(double[] mat)
        {
            return GetEulerFormMatrixUniversal(mat, 2, 0, 1, 0, 0, 1);
        }

        public static Quaterniond GetQuaternionConjugate(ref Quaterniond quat)
        {
            Quaterniond quat_GetQuaternionConjugateResult =
                new Quaterniond(-quat.X, -quat.Y, -quat.Z, quat.W);

            return quat_GetQuaternionConjugateResult;
        }

        //  Convert from Euler Angles
        public static void BuildQuaternionFromEuler(double alpha, double beta, double gamma, ref Quaterniond res_quat)
        {
            //  Basically we create 3 Quaternions, one for pitch, one for yaw, one for roll
            //  and multiply those together.

            Quaterniond quat_x = new Quaterniond();
            Quaterniond quat_y = new Quaterniond();
            Quaterniond quat_z = new Quaterniond();
            Quaterniond quat_xy = new Quaterniond();

            Vector3 px = new Vector3(1, 0, 0);
            Vector3 py = new Vector3(0, 1, 0);
            Vector3 pz = new Vector3(0, 0, 1);

            BuildQuaternionFromAxis(ref px, alpha, ref quat_x);
            BuildQuaternionFromAxis(ref py, beta, ref quat_y);
            BuildQuaternionFromAxis(ref pz, gamma, ref quat_z);

            MultiplyQuaternions(quat_y, quat_x, ref quat_xy);
            MultiplyQuaternions(quat_xy, quat_z, ref res_quat);

            NormalizeQuaternion(ref res_quat);
        }


        ///////////////////////////////////////////
        // Camera things
        public static void SetCameraModelView(float cX, float cY, float cZ, 
                                              float alpha, float beta, float gamma,
                                              float rszX, float rszY, float rszZ)
        {
            double[] rot_mat = new double[16];

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translated(cX, cY, cZ);

            BuildRotationMatrixWithQuaternionsXYZ(alpha, beta, gamma, ref rot_mat);

            GL.MultMatrixd(rot_mat);

            GL.Scaled(rszX, rszY, rszZ);
        }

        public static void SetCameraModelViewQuat(float cX, float cY, float cZ,
                                                  Quaterniond quat,
                                                  float rszX, float rszY, float rszZ)
        {
            double[] rot_mat = new double[16];

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translated(cX, cY, cZ);

            BuildMatrixFromQuaternion(quat, ref rot_mat);

            GL.MultMatrixd(rot_mat);

            GL.Scaled(rszX, rszY, rszZ);
        }


        public static void SetCameraAroundModel(ref Vector3 p_min, ref Vector3 p_max,
                                                float cX, float cY, float cZ,
                                                float alpha, float beta, float gamma,
                                                float rszX, float rszY, float rszZ)
        {
            float width, height;
            float scene_radius;
            int[] vp = new int[4];

            GL.GetInteger(GetPName.Viewport,vp);
            width = vp[2];
            height = vp[3];

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            scene_radius = ComputeSceneRadius(p_min, p_max);

            gluPerspective(60, (float)width / height, Math.Max(0.1, -cZ - scene_radius), Math.Max(0.1, -cZ + scene_radius));

            SetCameraModelView(cX, cY, cZ, alpha, beta, gamma, rszX, rszY, rszZ);

            // Read matrices directly from OpenGL to ensure picking matches rendering exactly
            float[] projArray = new float[16];
            float[] mvArray = new float[16];
            GL.GetFloat(GetPName.ProjectionMatrix, projArray);
            GL.GetFloat(GetPName.ModelviewMatrix, mvArray);

            GLRenderer.ProjectionMatrix = new Matrix4(
                projArray[0], projArray[1], projArray[2], projArray[3],
                projArray[4], projArray[5], projArray[6], projArray[7],
                projArray[8], projArray[9], projArray[10], projArray[11],
                projArray[12], projArray[13], projArray[14], projArray[15]);

            GLRenderer.ViewMatrix = new Matrix4(
                mvArray[0], mvArray[1], mvArray[2], mvArray[3],
                mvArray[4], mvArray[5], mvArray[6], mvArray[7],
                mvArray[8], mvArray[9], mvArray[10], mvArray[11],
                mvArray[12], mvArray[13], mvArray[14], mvArray[15]);

            GLRenderer.ModelMatrix = Matrix4.Identity;
            GLRenderer.ViewPosition = new OpenTK.Mathematics.Vector3(cX, cY, -cZ);
        }



        ///////////////////////////////////////////
        // Geometric
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

        public static Vector3 CrossProduct3D(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.Y * v2.Z - v1.Z * v2.Y,
                               v1.Z * v2.X - v1.X * v2.Z,
                               v1.X * v2.Y - v1.Y * v2.X);
        }

        public static Vector3 DividePoint3D(Vector3 v, float fScalar)
        {
            return new Vector3(v.X / fScalar, v.Y / fScalar, v.Z / fScalar);
        }

        public static Vector3 Normalize(Vector3 v)
        {
            float fLength;

            fLength = CalculateLength3D(v);

            return DividePoint3D(v, fLength);


            //fLength = CalculateLength3D(v);

            //if (fLength > 0)
            //{
            //    fLength = 1 / fLength;

            //    return new Point3D(v.X / fLength, v.Y / fLength, v.Z / fLength);
            //}

            //else return new Point3D(0.0f, 0.0f, 0.0f);
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

        public static Vector3 CalculateNormal(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            Vector3 v1, v2;

            v1 = SubstractPoint3D(p2, p1);
            v2 = SubstractPoint3D(p3, p1);

            return CrossProduct3D(v1, v2);
        }

        public static bool ComparePoints3D(Vector3 a, Vector3 b)
        {
            return (a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z);
        }

        public static Vector3 CalculateCenteroid(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            return new Vector3((p1.X + p2.X + p3.X) / 3.0f,
                               (p1.Y + p2.Y + p3.Y) / 3.0f,
                               (p1.Z + p2.Z + p3.Z) / 3.0f);
        }

         
        ///////////////////////////////////////////
        // Maths
        public static void GetSubMatrix(double[] mat, int i, int j, ref double[] mat_out)
        {
            int i2, j2, order, pos;

            order = (int)Math.Sqrt(mat.Length);

            mat_out = new double[(int)Math.Pow(order - 1, 2)];

            for (i2 = 0; i2 < order; i2++)
            {
                if (i2 != i)
                {
                    for (j2 = 0; j2 < order; j2++)
                    {
                        if (j2 != j)
                        {
                            pos = i2 + j2 * (order - 1);
                            if (i2 > i) pos--;
                            if (j2 > j) pos = pos - order + 1;
                            mat_out[pos] = mat[i2 + j2 * order];
                        }
                    }
                }
            }
        }

        public static double GetMatrixDeterminant(ref double[] mat)
        {
            double iGetMatrixDeterminantResult = 0;

            int i, order;
            double det_aux;
            double[] mat_aux = Array.Empty<double>();

            order = (int)Math.Sqrt(mat.Length);

            if (order > 2)
            {
                for (i = 0; i < order; i++)
                {
                    if (mat[i] != 0)
                    {
                        GetSubMatrix(mat, i, 0, ref mat_aux);
                        det_aux = GetMatrixDeterminant(ref mat_aux) * Math.Pow(-1, i) * mat[i];
                        iGetMatrixDeterminantResult += det_aux;
                    }
                }
            }
            else
            {
                iGetMatrixDeterminantResult = mat[0] * mat[3] - mat[1] * mat[2];
            }

            return iGetMatrixDeterminantResult;
        }

        //  The value is considered unsigned
        public static int GetBitBlockVUnsigned(byte[] vect, int nBits, ref int FBit)
        {
            int iGetBitBlockVUnsignedResult = 0;
            int baseByte, bi, res, nBytes, unalignedByBits, firstAlignedByte, lastAlignedByte, endBits;
            bool isAligned, cleanEnd;

            if (nBits > 0)
            {
                baseByte = FBit / 8;
                unalignedByBits = FBit % 8;

                if (unalignedByBits + nBits > 8)
                {
                    isAligned = (unalignedByBits == 0);

                    endBits = (FBit + nBits) % 8;
                    cleanEnd = (endBits == 0);

                    nBytes = (nBits - (isAligned ? 0 : 8 - unalignedByBits) - (cleanEnd ? 0 : endBits)) / 8 +
                             (isAligned ? 0 : 1) + (cleanEnd ? 0 : 1);
                    lastAlignedByte = nBytes - (cleanEnd ? 0 : 1) - 1;
                    firstAlignedByte = 0;

                    res = 0;
                    //  Unaligned prefix
                    //  Stored at the begining of the byte
                    if (!isAligned)
                    {
                        res = vect[baseByte];
                        res &= (int)(Math.Pow(2, (8 - unalignedByBits)) - 1);
                        firstAlignedByte = 1;
                    }

                    //  Aligned bytes
                    for (bi = firstAlignedByte; bi <= lastAlignedByte; bi++)
                    {
                        res *= 256;
                        res |= vect[baseByte + bi];
                    }

                    //  Sufix
                    //  Stored at the end of the byte
                    if (!cleanEnd)
                    {
                        res *= (int)Math.Pow(2, endBits);
                        res |= ((vect[baseByte + lastAlignedByte + 1]) / (int)(Math.Pow(2, 8 - endBits)) & (int)(Math.Pow(2, endBits) - 1));
                    }
                }
                else
                {
                    res = vect[baseByte];
                    res /= (int)Math.Pow(2, 8 - (unalignedByBits + nBits));
                    res &= (int)(Math.Pow(2, nBits) - 1);
                }

                iGetBitBlockVUnsignedResult = (short)res;

                FBit += nBits;
            }

            return iGetBitBlockVUnsignedResult;
        }

        public static int ExtendSignInteger(int val, int len)
        {
            int iExtendSignIntegerResult, auxRes;

            //KimeraCS VB6 has this lines but they don't seem to have any effect, right?
            //if (len != 12)
            //{
            //    auxRes = auxRes;
            //}

            if ((val & (int)Math.Pow(2, (len - 1))) != 0)
            {
                auxRes = (int)Math.Pow(2, 16) - 1;
                auxRes ^= (int)(Math.Pow(2, len) - 1);
                auxRes |= val;

                iExtendSignIntegerResult = auxRes;
            }
            else
            {
                iExtendSignIntegerResult = val;
            }

            return iExtendSignIntegerResult;
        }

        public static int GetSignExtendedShort(int src, int valLen)
        {
            int iGetSignExtendedShortResult = 0;

            if (valLen > 0)
            {
                if (valLen < 16)
                {
                    iGetSignExtendedShortResult = ExtendSignInteger(src, valLen);
                }
                else
                {
                    iGetSignExtendedShortResult = src;
                }
            }

            return iGetSignExtendedShortResult;
        }

        public static int GetBitBlockV(byte[] vect, int nBits, ref int FBit)
        {
            int tmpValue;

            tmpValue = GetBitBlockVUnsigned(vect, nBits, ref FBit);

            return GetSignExtendedShort(tmpValue, nBits);
        }

        public static void PutBitBlockV(ref byte[] vect, int nBits, ref int FBit, int iValue)
        {
            int bi, baseByte, nBytes, unalignedByBits;
            int firstAlignedByte, lastAlignedByte, endBits, tmpValue;
            bool isAligned, cleanEnd;

            //  Deal with it as some raw positive value.
            //  Divisions can't be used for bit shifting negative values,
            //  since they round towards 0 instead of minus infinity
            iValue &= (int)(Math.Pow(2, nBits) - 1);

            if (nBits > 0)
            {
                baseByte = FBit / 8;
                unalignedByBits = FBit % 8;

                if (unalignedByBits + nBits > 8)
                {
                    isAligned = (unalignedByBits == 0);

                    endBits = (FBit + nBits) % 8;
                    cleanEnd = (endBits == 0);

                    nBytes = (nBits - (isAligned ? 0 : (8 - unalignedByBits)) - (cleanEnd ? 0 : endBits)) / 8 + 
                             (isAligned ? 0 : 1) + (cleanEnd ? 0 : 1);

                    lastAlignedByte = nBytes - (cleanEnd ? 0 : 1) - 1;
                    firstAlignedByte = 0;

                    Array.Resize(ref vect, baseByte + nBytes);

                    //  Unaligned prefix
                    if (!isAligned)
                    {
                        tmpValue = iValue / (int)(Math.Pow(2, nBits - (8 - unalignedByBits)));
                        tmpValue &= ((int)(Math.Pow(2, (8 - unalignedByBits)) - 1));
                        vect[baseByte] = (byte)(vect[baseByte] | tmpValue);
                        firstAlignedByte = 1;
                    }

                    //  Aligned bytes
                    for (bi = firstAlignedByte; bi <= lastAlignedByte; bi++)
                    {
                        tmpValue = iValue / (int)(Math.Pow(2, ((lastAlignedByte - bi) * 8 + endBits)));
                        vect[baseByte + bi] = (byte)(tmpValue & 0xFF);
                    }

                    // Suffix
                    if (!cleanEnd)
                    {
                        tmpValue = iValue & (int)(Math.Pow(2, endBits) - 1);
                        vect[baseByte + lastAlignedByte + 1] = (byte)(tmpValue * (int)(Math.Pow(2, 8 - endBits)));                            
                    }
                }
                else
                {
                    if (vect.Length - 1 < baseByte)
                    {
                        Array.Resize(ref vect, baseByte + 1);
                        vect[baseByte] = 0;
                    }

                    tmpValue = iValue & (int)Math.Pow(2, nBits) - 1;
                    tmpValue *= (int)Math.Pow(2, 8 - (unalignedByBits + nBits));
                    vect[baseByte] = (byte)(vect[baseByte] | tmpValue);
                }
            }

            FBit += nBits;
        }

        public static float NormalizeAngle180(float fValue)
        {
            float fNormalizeAngle180Result;
            float fDec;

            if (fValue > 0) fDec = 360f;
            else fDec = -360f;

            fNormalizeAngle180Result = fValue;
            while ((fNormalizeAngle180Result > 0 && fValue > 0) || (fNormalizeAngle180Result < 0 && fValue < 0))
                fNormalizeAngle180Result -= fDec;

            if (Math.Abs(fNormalizeAngle180Result) > Math.Abs(fNormalizeAngle180Result + fDec)) fNormalizeAngle180Result += fDec;

            if (fNormalizeAngle180Result >= 180f) fNormalizeAngle180Result -= 360f;

            return fNormalizeAngle180Result;
        }

        public static float GetDegreesFromRaw(int iValue, short key)
        {
            //return (iValue / (float)Math.Pow(2, 12 - key)) * 360;
            float fVal = iValue;
            //fVal = fVal / 4096;
            fVal /= (float)Math.Pow(2, 12 - key);
            fVal *= 360;
            return fVal;
            //return ((float)iValue / 4096) * 360;
        }

        public static int GetRawFromDegrees(float fValue, int key)
        {
            //return (int)((fValue / 360f) * Math.Pow(2, 12 - key));
            float fVal = fValue;
            fVal /= 360;
            //fVal = fVal * 4096;
            fVal *= (float)Math.Pow(2, 12 - key);
            int iVal = (int)Math.Round(fVal);
            return iVal;
            //return (int)(fValue / 360f) * 4096;
        }

        public static int GetBitInteger(int iValue, int iBitIndex)
        {
            return (iValue & (int)Math.Pow(2, iBitIndex)) != 0 ? 1 : 0;
        }

        public static int SetBitInteger(int iValue, int iBitIndex, int iBitValue)
        {
            int iSetBitIntegerResult;

            if (iBitValue == 0) iSetBitIntegerResult = iValue & (~(int)Math.Pow(2, iBitIndex));
            else iSetBitIntegerResult = iValue | ((int)Math.Pow(2, iBitIndex));

            return iSetBitIntegerResult;
        }

        public static int InvertBitInteger(int iValue, int iBitIndex)
        {
            int iInvertBitIntegerResult;

            if (GetBitInteger(iValue, iBitIndex) == 1) iInvertBitIntegerResult = SetBitInteger(iValue, iBitIndex, 0);
            else iInvertBitIntegerResult = SetBitInteger(iValue, iBitIndex, 1);

            return iInvertBitIntegerResult;
        }



        //  -------------------------------------------------------------------------------------------------
        //  ================================= OPENTK MATRIX UTILITIES =======================================
        //  -------------------------------------------------------------------------------------------------

        /// <summary>
        /// Creates a perspective projection matrix (replaces gluPerspective)
        /// </summary>
        /// <param name="fovDegrees">Field of view in degrees</param>
        /// <param name="aspect">Aspect ratio (width/height)</param>
        /// <param name="near">Near clipping plane</param>
        /// <param name="far">Far clipping plane</param>
        public static Matrix4 CreatePerspectiveMatrix(float fovDegrees, float aspect, float near, float far)
        {
            return Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(fovDegrees),
                aspect,
                near,
                far);
        }

        /// <summary>
        /// Creates a model-view matrix from camera parameters (replaces SetCameraModelView pattern)
        /// </summary>
        public static Matrix4 CreateModelViewMatrix(float cX, float cY, float cZ,
                                                     float alpha, float beta, float gamma,
                                                     float scaleX, float scaleY, float scaleZ)
        {
            // Build rotation from quaternions (matching existing BuildRotationMatrixWithQuaternionsXYZ)
            var quatX = Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(alpha));
            var quatY = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(beta));
            var quatZ = Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(gamma));
            var rotation = quatX * quatY * quatZ;

            Matrix4 rotationMatrix = Matrix4.CreateFromQuaternion(rotation);
            Matrix4 translationMatrix = Matrix4.CreateTranslation(cX, cY, cZ);
            Matrix4 scaleMatrix = Matrix4.CreateScale(scaleX, scaleY, scaleZ);

            return translationMatrix * rotationMatrix * scaleMatrix;
        }

        /// <summary>
        /// Converts the double[] matrix (16 elements, column-major) to OpenTK Matrix4
        /// </summary>
        public static Matrix4 ToMatrix4(double[] mat)
        {
            return new Matrix4(
                (float)mat[0], (float)mat[1], (float)mat[2], (float)mat[3],
                (float)mat[4], (float)mat[5], (float)mat[6], (float)mat[7],
                (float)mat[8], (float)mat[9], (float)mat[10], (float)mat[11],
                (float)mat[12], (float)mat[13], (float)mat[14], (float)mat[15]);
        }

        /// <summary>
        /// Alias for ToMatrix4 - converts double[] matrix to OpenTK Matrix4
        /// </summary>
        public static Matrix4 DoubleArrayToMatrix4(double[] mat)
        {
            return ToMatrix4(mat);
        }

        /// <summary>
        /// Set default OpenGL render state
        /// </summary>
        public static void SetDefaultOGLRenderState()
        {
            GL.PolygonMode(TriangleFace.FrontAndBack, PolygonMode.Fill);
            GL.CullFace(TriangleFace.Front);
            GL.Enable(EnableCap.CullFace);

            GL.DepthFunc(DepthFunction.Lequal);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);

            GL.TexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameteri(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        /// <summary>
        /// GLU perspective wrapper - also loads the matrix into the current matrix mode
        /// </summary>
        public static void gluPerspective(double fov, double aspect, double zNear, double zFar)
        {
            Matrix4 perspectiveMatrix = CreatePerspectiveMatrix((float)fov, (float)aspect, (float)zNear, (float)zFar);
            double[] matArray = Matrix4ToDoubleArray(perspectiveMatrix);
            GL.MultMatrixd(matArray);
        }
    }
}
