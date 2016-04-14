using UnityEngine;
using System.Collections;
using System;

namespace DTPathFind
{
    public class DetourCommon
    {
        public static void dtSwap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public static float dtSqr(float a)
        {
            return a * a;
        }

        public static int dtSqr(int a)
        {
            return a * a;
        }

        public static uint dtSqr(uint a)
        {
            return a * a;
        }

        public static byte dtSqr(byte a)
        {
            return (byte)(a * a);
        }

        public static int dtClamp(int v, int mn, int mx)
        {
            return v < mn ? mn : (v > mx ? mx : v);
        }
        public static uint dtClamp(uint v, uint mn, uint mx)
        {
            return v < mn ? mn : (v > mx ? mx : v);
        }
        public static byte dtClamp(byte v, byte mn, byte mx)
        {
            return v < mn ? mn : (v > mx ? mx : v);
        }
        public static ushort dtClamp(ushort v, ushort mn, ushort mx)
        {
            return v < mn ? mn : (v > mx ? mx : v);
        }
        public static float dtClamp(float v, float mn, float mx)
        {
            return v < mn ? mn : (v > mx ? mx : v);
        }

        public static void dtVcross(float[] dest, float[] v1, float[] v2)
        {
            dest[0] = v1[1] * v2[2] - v1[2] * v2[1];
            dest[1] = v1[2] * v2[0] - v1[0] * v2[2];
            dest[2] = v1[0] * v2[1] - v1[1] * v2[0];
        }

        public static float dtVdot(float[] v1, float[] v2)
        {
            return v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];
        }

        public static float dtVdot(float[] v1, int v1Start, float[] v2, int v2Start)
        {
            return v1[v1Start + 0] * v2[v2Start + 0] + v1[v1Start + 1] * v2[v2Start + 1] + v1[v1Start + 2] * v2[v2Start + 2];
        }

        public static void dtVmad(float[] dest, float[] v1, float[] v2, float s)
        {
            dest[0] = v1[0] + v2[0] * s;
            dest[1] = v1[1] + v2[1] * s;
            dest[2] = v1[2] + v2[2] * s;
        }
        public static void dtVlerp(float[] dest, float[] v1, float[] v2, float t)
        {
            dest[0] = v1[0] + (v2[0] - v1[0]) * t;
            dest[1] = v1[1] + (v2[1] - v1[1]) * t;
            dest[2] = v1[2] + (v2[2] - v1[2]) * t;
        }
        public static void dtVlerp(float[] dest, int destStart, float[] v1, int v1Start, float[] v2, int v2Start, float t)
        {
            dest[destStart + 0] = v1[v1Start + 0] + (v2[v2Start + 0] - v1[v1Start + 0]) * t;
            dest[destStart + 1] = v1[v1Start + 1] + (v2[v2Start + 1] - v1[v1Start + 1]) * t;
            dest[destStart + 2] = v1[v1Start + 2] + (v2[v2Start + 2] - v1[v1Start + 2]) * t;
        }

        public static void dtVadd(float[] dest, float[] v1, float[] v2)
        {
            dest[0] = v1[0] + v2[0];
            dest[1] = v1[1] + v2[1];
            dest[2] = v1[2] + v2[2];
        }
        public static void dtVadd(float[] dest, int destStart, float[] v1, int v1Start, float[] v2, int v2Start)
        {
            dest[destStart + 0] = v1[v1Start + 0] + v2[v2Start + 0];
            dest[destStart + 1] = v1[v1Start + 1] + v2[v2Start + 1];
            dest[destStart + 2] = v1[v1Start + 2] + v2[v2Start + 2];
        }
        public static void dtVsub(float[] dest, float[] v1, float[] v2)
        {
            dest[0] = v1[0] - v2[0];
            dest[1] = v1[1] - v2[1];
            dest[2] = v1[2] - v2[2];
        }
        public static void dtVsub(float[] dest, int destStart, float[] v1, int v1Start, float[] v2, int v2Start)
        {
            dest[destStart + 0] = v1[v1Start + 0] - v2[v2Start + 0];
            dest[destStart + 1] = v1[v1Start + 1] - v2[v2Start + 1];
            dest[destStart + 2] = v1[v1Start + 2] - v2[v2Start + 2];
        }
        public static void dtVscale(float[] dest, float[] v, float t)
        {
            dest[0] = v[0] * t;
            dest[1] = v[1] * t;
            dest[2] = v[2] * t;
        }
        public static void dtVscale(float[] dest, int destStart, float[] v, int vStart, float t)
        {
            dest[destStart + 0] = v[vStart + 0] * t;
            dest[destStart + 1] = v[vStart + 1] * t;
            dest[destStart + 2] = v[vStart + 2] * t;
        }
        public static void dtVmin(float[] mn, float[] v)
        {
            mn[0] = Math.Min(mn[0], v[0]);
            mn[1] = Math.Min(mn[1], v[1]);
            mn[2] = Math.Min(mn[2], v[2]);
        }
        public static void dtVmin(float[] mn, int mnStart, float[] v, int vStart)
        {
            mn[mnStart + 0] = Math.Min(mn[mnStart + 0], v[vStart + 0]);
            mn[mnStart + 1] = Math.Min(mn[mnStart + 1], v[vStart + 1]);
            mn[mnStart + 2] = Math.Min(mn[mnStart + 2], v[vStart + 2]);
        }
        public static void dtVmax(float[] mx, float[] v)
        {
            mx[0] = Math.Max(mx[0], v[0]);
            mx[1] = Math.Max(mx[1], v[1]);
            mx[2] = Math.Max(mx[2], v[2]);
        }
        public static void dtVmax(float[] mx, int mxStart, float[] v, int vStart)
        {
            mx[mxStart + 0] = Math.Max(mx[mxStart + 0], v[vStart + 0]);
            mx[mxStart + 1] = Math.Max(mx[mxStart + 1], v[vStart + 1]);
            mx[mxStart + 2] = Math.Max(mx[mxStart + 2], v[vStart + 2]);
        }

        public static void dtVset(float[] dest, float x, float y, float z)
        {
            dest[0] = x; dest[1] = y; dest[2] = z;
        }
        public static void dtVset(float[] dest, int destStart, float x, float y, float z)
        {
            dest[destStart + 0] = x; dest[destStart + 1] = y; dest[destStart + 2] = z;
        }
        public static void dtVcopy(float[] dest, float[] a)
        {
            dest[0] = a[0];
            dest[1] = a[1];
            dest[2] = a[2];
        }
        public static void dtVcopy(float[] dest, int destStart, float[] a, int aStart)
        {
            dest[destStart + 0] = a[aStart + 0];
            dest[destStart + 1] = a[aStart + 1];
            dest[destStart + 2] = a[aStart + 2];
        }

        public static float dtVlen(float[] v)
        {
            return (float)Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);
        }
        public static float dtVlen(float[] v, int vStart)
        {
            return (float)Math.Sqrt(v[0 + vStart] * v[0 + vStart] + v[1 + vStart] * v[1 + vStart] + v[2 + vStart] * v[2 + vStart]);
        }

        public static float dtVlenSqr(float[] v)
        {
            return v[0] * v[0] + v[1] * v[1] + v[2] * v[2];
        }
        public static float dtVlenSqr(float[] v, int vStart)
        {
            return v[0 + vStart] * v[0 + vStart] + v[1 + vStart] * v[1 + vStart] + v[2 + vStart] * v[2 + vStart];
        }

        public static float dtVdist(float[] v1, float[] v2)
        {
            float dx = v2[0] - v1[0];
            float dy = v2[1] - v1[1];
            float dz = v2[2] - v1[2];
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
        public static float dtVdist(float[] v1, int v1Start, float[] v2, int v2Start)
        {
            float dx = v2[v2Start + 0] - v1[v1Start + 0];
            float dy = v2[v2Start + 1] - v1[v1Start + 1];
            float dz = v2[v2Start + 2] - v1[v1Start + 2];
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static float dtVdistSqr(float[] v1, float[] v2)
        {
            float dx = v2[0] - v1[0];
            float dy = v2[1] - v1[1];
            float dz = v2[2] - v1[2];
            return dx * dx + dy * dy + dz * dz;
        }

        public static float dtVdistSqr(float[] v1, int v1Start, float[] v2, int v2Start)
        {
            float dx = v2[v2Start + 0] - v1[v1Start + 0];
            float dy = v2[v2Start + 1] - v1[v1Start + 1];
            float dz = v2[v2Start + 2] - v1[v1Start + 2];
            return dx * dx + dy * dy + dz * dz;
        }

        public static float dtVdist2D(float[] v1, float[] v2)
        {
            float dx = v2[0] - v1[0];
            float dz = v2[2] - v1[2];
            return (float)Math.Sqrt(dx * dx + dz * dz);
        }

        public static float dtVdist2D(float[] v1, int v1Start, float[] v2, int v2Start)
        {
            float dx = v2[v2Start + 0] - v1[v1Start + 0];
            float dz = v2[v2Start + 2] - v1[v1Start + 2];
            return (float)Math.Sqrt(dx * dx + dz * dz);
        }

        public static float dtVdist2DSqr(float[] v1, float[] v2)
        {
            float dx = v2[0] - v1[0];
            float dz = v2[2] - v1[2];
            return dx * dx + dz * dz;
        }

        public static float dtVdist2DSqr(float[] v1, int v1Start, float[] v2, int v2Start)
        {
            float dx = v2[v2Start + 0] - v1[v1Start + 0];
            float dz = v2[v2Start + 2] - v1[v1Start + 2];
            return dx * dx + dz * dz;
        }

        public static void dtVnormalize(float[] v)
        {
            float d = 1.0f / (float)Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);
            v[0] *= d;
            v[1] *= d;
            v[2] *= d;
        }
        public static void dtVnormalize(float[] v, int vStart)
        {
            float d = 1.0f / (float)Math.Sqrt(v[vStart + 0] * v[vStart + 0] + v[vStart + 1] * v[vStart + 1] + v[vStart + 2] * v[vStart + 2]);
            v[vStart + 0] *= d;
            v[vStart + 1] *= d;
            v[vStart + 2] *= d;
        }

        public static bool dtVequal(float[] p0, float[] p1)
        {
            float thrSqrt = (1.0f / 16384.0f);
            float thr = thrSqrt * thrSqrt;
            float d = dtVdistSqr(p0, p1);
            return d < thr;
        }
        public static bool dtVequal(float[] p0, int p0Start, float[] p1, int p1Start)
        {
            float thrSqrt = (1.0f / 16384.0f);
            float thr = thrSqrt * thrSqrt;
            float d = dtVdistSqr(p0, p0Start, p1, p1Start);
            return d < thr;
        }

        public static float dtVdot2D(float[] u, float[] v)
        {
            return u[0] * v[0] + u[2] * v[2];
        }
        public static float dtVdot2D(float[] u, int uStart, float[] v, int vStart)
        {
            return u[uStart + 0] * v[vStart + 0] + u[uStart + 2] * v[vStart + 2];
        }

        public static float dtVperp2D(float[] u, float[] v)
        {
            return u[2] * v[0] - u[0] * v[2];
        }
        public static float dtVperp2D(float[] u, int uStart, float[] v, int vStart)
        {
            return u[uStart + 2] * v[vStart + 0] - u[uStart + 0] * v[vStart + 2];
        }

        public static float dtTriArea2D(float[] a, float[] b, float[] c)
        {
            float abx = b[0] - a[0];
            float abz = b[2] - a[2];
            float acx = c[0] - a[0];
            float acz = c[2] - a[2];
            return acx * abz - abx * acz;
        }
        public static float dtTriArea2D(float[] a, int aStart, float[] b, int bStart, float[] c, int cStart)
        {
            float abx = b[bStart + 0] - a[aStart + 0];
            float abz = b[bStart + 2] - a[aStart + 2];
            float acx = c[cStart + 0] - a[aStart + 0];
            float acz = c[cStart + 2] - a[aStart + 2];
            return acx * abz - abx * acz;
        }

        public static bool dtOverlapQuantBounds(ushort[] amin, ushort[] amax,
                                 ushort[] bmin, ushort[] bmax)
        {
            bool overlap = true;
            overlap = (amin[0] > bmax[0] || amax[0] < bmin[0]) ? false : overlap;
            overlap = (amin[1] > bmax[1] || amax[1] < bmin[1]) ? false : overlap;
            overlap = (amin[2] > bmax[2] || amax[2] < bmin[2]) ? false : overlap;
            return overlap;
        }

        public static bool dtOverlapBounds(float[] amin, float[] amax,
                            float[] bmin, float[] bmax)
        {
            bool overlap = true;
            overlap = (amin[0] > bmax[0] || amax[0] < bmin[0]) ? false : overlap;
            overlap = (amin[1] > bmax[1] || amax[1] < bmin[1]) ? false : overlap;
            overlap = (amin[2] > bmax[2] || amax[2] < bmin[2]) ? false : overlap;
            return overlap;
        }

        public static void dtClosestPtPointTriangle(float[] closest, float[] p,
                              float[] a, float[] b, float[] c)
        {
            float[] ab = new float[3];
            float[] ac = new float[3];
            float[] ap = new float[3];

            dtVsub(ab, b, a);
            dtVsub(ac, c, a);
            dtVsub(ap, p, a);

            float d1 = dtVdot(ab, ap);
            float d2 = dtVdot(ac, ap);

            if (d1 <= 0.0f && d2 <= 0.0f)
            {
                dtVcopy(closest, a);
                return;
            }

            float[] bp = new float[3];
            dtVsub(bp, p, b);
            float d3 = dtVdot(ab, bp);
            float d4 = dtVdot(ac, bp);
            if (d3 >= 0.0f && d4 <= d3)
            {
                dtVcopy(closest, b);
                return;
            }

            float vc = d1 * d4 - d3 * d2;
            if (vc <= 0.0f && d1 >= 0.0f && d3 <= 0.0f)
            {
                // barycentric coordinates (1-v,v,0)
                float _v = d1 / (d1 - d3);
                closest[0] = a[0] + _v * ab[0];
                closest[1] = a[1] + _v * ab[1];
                closest[2] = a[2] + _v * ab[2];
                return;
            }

            float[] cp = new float[3];
            dtVsub(cp, p, c);
            float d5 = dtVdot(ab, cp);
            float d6 = dtVdot(ac, cp);
            if (d6 >= 0.0f && d5 <= d6)
            {
                dtVcopy(closest, c);
                return;
            }

            float vb = d5 * d2 - d1 * d6;
            if (vb <= 0.0f && d2 >= 0.0f && d6 <= 0.0f)
            {
                float _w = d2 / (d2 - d6);
                closest[0] = a[0] + _w * ac[0];
                closest[1] = a[1] + _w * ac[1];
                closest[2] = a[2] + _w * ac[2];
                return;
            }

            float va = d3 * d6 - d5 * d4;
            if (va <= 0.0f && (d4 - d3) >= 0.0f && (d5 - d6) >= 0.0f)
            {
                float _w = (d4 - d3) / ((d4 - d3) + (d5 - d6));
                closest[0] = b[0] + _w * (c[0] - b[0]);
                closest[1] = b[1] + _w * (c[1] - b[1]);
                closest[2] = b[2] + _w * (c[2] - b[2]);
                return;
            }

            float denom = 1.0f / (va + vb + vc);
            float v = vb * denom;
            float w = vc * denom;
            closest[0] = a[0] + ab[0] * v + ac[0] * w;
            closest[1] = a[1] + ab[1] * v + ac[1] * w;
            closest[2] = a[2] + ab[2] * v + ac[2] * w;
        }

        public static bool dtClosestHeightPointTriangle(float[] p, int pStart, float[] a, int aStart, float[] b, int bStart, float[] c, int cStart, ref float h)
        {
            float[] v0 = new float[3];
            float[] v1 = new float[3];
            float[] v2 = new float[3];
            dtVsub(v0, 0, c, cStart, a, aStart);
            dtVsub(v1, 0, b, bStart, a, aStart);
            dtVsub(v2, 0, p, pStart, a, aStart);

            float dot00 = dtVdot2D(v0, v0);
            float dot01 = dtVdot2D(v0, v1);
            float dot02 = dtVdot2D(v0, v2);
            float dot11 = dtVdot2D(v1, v1);
            float dot12 = dtVdot2D(v1, v2);

            float invDenom = 1.0f / (dot00 * dot11 - dot01 * dot01);
            float u = (dot11 * dot02 - dot01 * dot12) * invDenom;
            float v = (dot00 * dot12 - dot01 * dot02) * invDenom;

            float EPS = 1e-4f;

            if (u >= -EPS && v >= -EPS && (u + v) <= 1 + EPS)
            {
                h = a[aStart + 1] + v0[1] * u + v1[1] * v;
                return true;
            }

            return false;
        }

        public static bool dtIntersectSegmentPoly2D(float[] p0, float[] p1,
                                  float[] verts, int nverts,
                                  ref float tmin, ref float tmax,
                                  ref int segMin, ref int segMax)
        {
            float EPS = 0.00000001f;

            tmin = 0;
            tmax = 1;
            segMin = -1;
            segMax = -1;

            float[] dir = new float[3];
            dtVsub(dir, p1, p0);

            for (int i = 0, j = nverts - 1; i < nverts; j = i++)
            {
                float[] edge = new float[3];
                float[] diff = new float[3];
                dtVsub(edge, 0, verts, i * 3, verts, j * 3);
                dtVsub(diff, 0, p0, 0, verts, j * 3);
                float n = dtVperp2D(edge, diff);
                float d = dtVperp2D(dir, edge);
                if (Math.Abs(d) < EPS)
                {
                    if (n < 0)
                        return false;
                    else
                        continue;
                }
                float t = n / d;
                if (d < 0)
                {
                    if (t > tmin)
                    {
                        tmin = t;
                        segMin = j;
                        if (tmin > tmax)
                            return false;
                    }
                }
                else
                {
                    if (t < tmax)
                    {
                        tmax = t;
                        segMax = j;
                        if (tmax < tmin)
                            return false;
                    }
                }
            }

            return true;
        }

        public static float vperpXZ(float[] a, float[] b)
        {
            return a[0] * b[2] - a[2] * b[0];
        }

        public static bool dtIntersectSegSeg2D(float[] ap, float[] aq,
                         float[] bp, float[] bq,
                         ref float s, ref float t)
        {
            float[] u = new float[3];
            float[] v = new float[3];
            float[] w = new float[3];
            dtVsub(u, aq, ap);
            dtVsub(v, bq, bp);
            dtVsub(w, ap, bp);
            float d = vperpXZ(u, v);
            if (Math.Abs(d) < 1e-6f) return false;
            s = vperpXZ(v, w) / d;
            t = vperpXZ(u, w) / d;
            return true;
        }

        public static bool dtIntersectSegSeg2D(float[] ap, int apStart, float[] aq, int aqStart,
                         float[] bp, int bpStart, float[] bq, int bqStart,
                         ref float s, ref float t)
        {
            float[] u = new float[3];
            float[] v = new float[3];
            float[] w = new float[3];
            dtVsub(u, 0, aq, aqStart, ap, apStart);
            dtVsub(v, 0, bq, bqStart, bp, bpStart);
            dtVsub(w, 0, ap, apStart, bp, bpStart);
            float d = vperpXZ(u, v);
            if (Math.Abs(d) < 1e-6f) return false;
            s = vperpXZ(v, w) / d;
            t = vperpXZ(u, w) / d;
            return true;
        }

        public static bool dtPointInPolygon(float[] pt, float[] verts, int nverts)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = nverts - 1; i < nverts; j = i++)
            {
                int viIndex = i * 3;
                int vjIndex = j * 3;
                if (((verts[viIndex + 2] > pt[2]) != (verts[vjIndex + 2] > pt[2])) &&
                    (pt[0] < (verts[vjIndex + 0] - verts[viIndex + 0]) * (pt[2] - verts[viIndex + 2]) / (verts[vjIndex + 2] - verts[viIndex + 2]) + verts[viIndex + 0]))
                    c = !c;
            }
            return c;
        }

        public static float dtDistancePtSegSqr2D(float[] pt, int ptStart, float[] p, int pStart, float[] q, int qStart, ref float t)
        {
            float pqx = q[qStart + 0] - p[pStart + 0];
            float pqz = q[qStart + 2] - p[pStart + 2];
            float dx = pt[ptStart + 0] - p[pStart + 0];
            float dz = pt[ptStart + 2] - p[pStart + 2];
            float d = pqx * pqx + pqz * pqz;
            t = pqx * dx + pqz * dz;
            if (d > 0) t /= d;
            if (t < 0) t = 0;
            else if (t > 1) t = 1;
            dx = p[pStart + 0] + t * pqx - pt[ptStart + 0];
            dz = p[pStart + 2] + t * pqz - pt[ptStart + 2];
            return dx * dx + dz * dz;
        }

        public static bool dtDistancePtPolyEdgesSqr(float[] pt, int ptStart, float[] v, int nverts,
                              float[] ed, float[] et)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = nverts - 1; i < nverts; j = i++)
            {
                int vi = i * 3;
                int vj = j * 3;
                if (((v[vi + 2] > pt[ptStart + 2]) != (v[vj + 2] > pt[ptStart + 2])) &&
                    (pt[ptStart + 0] < (v[vj + 0] - v[vi + 0]) * (pt[ptStart + 2] - v[vi + 2]) / (v[vj + 2] - v[vi + 2]) + v[vi + 0]))
                    c = !c;
                ed[j] = dtDistancePtSegSqr2D(pt, ptStart, v, vj, v, vi, ref et[j]);
            }
            return c;
        }

        public static void dtCalcPolyCenter(float[] tc, ushort[] idx, int nidx, float[] verts)
        {
            tc[0] = 0.0f;
            tc[1] = 0.0f;
            tc[2] = 0.0f;
            for (int j = 0; j < nidx; ++j)
            {
                int vIndex = idx[j] * 3;
                tc[0] += verts[vIndex + 0];
                tc[1] += verts[vIndex + 1];
                tc[2] += verts[vIndex + 2];
            }
            float s = 1.0f / nidx;
            tc[0] *= s;
            tc[1] *= s;
            tc[2] *= s;
        }

        public static void projectPoly(float[] axis, float[] poly, int npoly,
                        ref float rmin, ref float rmax)
        {
            rmin = rmax = dtVdot2D(axis, poly);
            for (int i = 1; i < npoly; ++i)
            {
                float d = dtVdot2D(axis, 0, poly, i * 3);
                rmin = Math.Min(rmin, d);
                rmax = Math.Max(rmax, d);
            }
        }

        public static bool overlapRange(float amin, float amax,
                                 float bmin, float bmax,
                                 float eps)
        {
            return ((amin + eps) > bmax || (amax - eps) < bmin) ? false : true;
        }

        public static bool dtOverlapPolyPoly2D(float[] polya, int npolya,
                             float[] polyb, int npolyb)
        {
            float eps = 1e-4f;

            for (int i = 0, j = npolya - 1; i < npolya; j = i++)
            {
                int vaStart = j * 3;
                int vbStart = i * 3;
                float[] n = new float[] { polya[vbStart + 2] - polya[vaStart + 2], 0, -(polya[vbStart + 0] - polya[vaStart + 0]) };
                float amin = 0.0f, amax = 0.0f, bmin = 0.0f, bmax = 0.0f;
                projectPoly(n, polya, npolya, ref amin, ref amax);
                projectPoly(n, polyb, npolyb, ref bmin, ref bmax);
                if (!overlapRange(amin, amax, bmin, bmax, eps))
                {
                    return false;
                }
            }
            for (int i = 0, j = npolyb - 1; i < npolyb; j = i++)
            {
                int vaStart = j * 3;
                int vbStart = i * 3;
                float[] n = new float[] { polyb[vbStart + 2] - polyb[vaStart + 2], 0, -(polyb[vbStart + 0] - polyb[vaStart + 0]) };
                float amin = 0.0f, amax = 0.0f, bmin = 0.0f, bmax = 0.0f;
                projectPoly(n, polya, npolya, ref amin, ref amax);
                projectPoly(n, polyb, npolyb, ref bmin, ref bmax);
                if (!overlapRange(amin, amax, bmin, bmax, eps))
                {
                    return false;
                }
            }
            return true;
        }

        public static uint dtNextPow2(uint v)
        {
            v--;
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            v |= v >> 8;
            v |= v >> 16;
            v++;
            return v;
        }

        public static int dtIlog2(uint v)
        {
            int r;
            int shift;
            r = ((v > 0xffff) ? 1 : 0) << 4; v >>= r;
            shift = ((v > 0xff) ? 1 : 0) << 3; v >>= shift; r |= shift;
            shift = ((v > 0xf) ? 1 : 0) << 2; v >>= shift; r |= shift;
            shift = ((v > 0x3) ? 1 : 0) << 1; v >>= shift; r |= shift;
            r |= ((int)v >> 1);
            return r;
        }

        public static int dtAlign4(int x)
        {
            return (x + 3) & ~3;
        }

        public static int dtOppositeTile(int side)
        {
            return (side + 4) & 0x7;
        }

        public static void dtSwapEndian(ref ushort v)
        {
            byte[] bytes = BitConverter.GetBytes(v);
            System.Array.Reverse(bytes);
            v = BitConverter.ToUInt16(bytes, 0);
        }

        public static void dtSwapEndian(ref short v)
        {
            byte[] bytes = BitConverter.GetBytes(v);
            System.Array.Reverse(bytes);
            v = BitConverter.ToInt16(bytes, 0);
        }

        public static void dtSwapEndian(ref uint v)
        {
            byte[] bytes = BitConverter.GetBytes(v);
            System.Array.Reverse(bytes);
            v = BitConverter.ToUInt32(bytes, 0);
        }

        public static void dtSwapEndian(ref int v)
        {
            byte[] bytes = BitConverter.GetBytes(v);
            System.Array.Reverse(bytes);
            v = BitConverter.ToInt32(bytes, 0);
        }

        public static void dtSwapEndian(ref float v)
        {
            byte[] bytes = BitConverter.GetBytes(v);
            System.Array.Reverse(bytes);
            v = BitConverter.ToSingle(bytes, 0);
        }

        public static void dtRandomPointInConvexPoly(float[] pts, int npts, float[] areas,
                                   float s, float t, float[] _out)
        {
            float areasum = 0.0f;
            for (int i = 2; i < npts; i++)
            {
                areas[i] = dtTriArea2D(pts, 0, pts, (i - 1) * 3, pts, i * 3);
                areasum += Math.Max(0.001f, areas[i]);
            }
            float thr = s * areasum;
            float acc = 0.0f;
            float u = 0.0f;
            int tri = 0;
            for (int i = 2; i < npts; i++)
            {
                float dacc = areas[i];
                if (thr >= acc && thr < (acc + dacc))
                {
                    u = (thr - acc) / dacc;
                    tri = i;
                    break;
                }
                acc += dacc;
            }

            float v = (float)Math.Sqrt(t);

            float a = 1 - v;
            float b = (1 - u) * v;
            float c = u * v;
            int paStart = 0;
            int pbStart = (tri - 1) * 3;
            int pcStart = tri * 3;

            _out[0] = a * pts[paStart + 0] + b * pts[pbStart + 0] + c * pts[pcStart + 0];
            _out[1] = a * pts[paStart + 1] + b * pts[pbStart + 1] + c * pts[pcStart + 1];
            _out[2] = a * pts[paStart + 2] + b * pts[pbStart + 2] + c * pts[pcStart + 2];
        }

        public static void dtcsArrayItemsCreate<T>(T[] array) where T : class, new()
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = new T();
            }
        }
    }
}