using System;

public struct Point : IComparable {
    public int X;
    public int Y;

    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    public int CompareTo(object obj) {
        Point point = (Point)obj;
        int cx = X.CompareTo(point.X), cy = Y.CompareTo(point.Y);
        return cx == 0 ? cy : cx;
    }
}

public class BinaryIndexedTree {
    private int[] sums;

    public BinaryIndexedTree(int size) {
        sums = new int[size + 1];
    }

    public void Add(int index, int value) {
        for (; index < sums.Length; index += index & -index) {
            sums[index] += value;
        }
    }

    public int Sum(int index) {
        int result = 0;
        for (; index > 0; index ^= index & -index) {
            result += sums[index];
        }
        return result;
    }
}

public class ThreePoints {
    public long countColoring(int n, int xzero, int xmul, int xadd, int xmod, int yzero, int ymul, int yadd, int ymod) {
        int[] xs = new int[n], ys = new int[n];
        Point[] points = new Point[n];
        xs[0] = xzero;
        ys[0] = yzero;
        points[0] = new Point(xs[0], ys[0]);
        for (int i = 1; i < n; ++i) {
            xs[i] = (int)(((long)points[i - 1].X * xmul + xadd) % xmod);
            ys[i] = (int)(((long)points[i - 1].Y * ymul + yadd) % ymod);
            points[i] = new Point(xs[i], ys[i]);
        }
        Array.Sort(xs);
        Array.Sort(ys);
        for (int i = 0; i < n; ++i) {
            points[i].X = Array.BinarySearch(xs, points[i].X) + 1;
            points[i].Y = Array.BinarySearch(ys, points[i].Y) + 1;
        }
        Array.Sort(points);
        long count = 0;
        BinaryIndexedTree tree;
        tree = new BinaryIndexedTree(n);
        int[] countL = new int[n], countR = new int[n];
        for (int i = 0; i < n; ++i) {
            countL[i] = tree.Sum(points[i].Y);
            tree.Add(points[i].Y, 1);
        }
        tree = new BinaryIndexedTree(n);
        for (int i = n - 1; i >= 0; --i) {
            countR[i] = tree.Sum(n) - tree.Sum(points[i].Y);
            count += (long)countR[i] * (countR[i] - 1) / 2;
            count -= (long)countL[i] * countR[i];
            tree.Add(points[i].Y, 1);
        }
        return count;
    }
}
