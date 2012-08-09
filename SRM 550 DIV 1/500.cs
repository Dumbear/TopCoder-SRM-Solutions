using System;

public class CheckerExpansion {
    public string[] resultAfter(long t, long x0, long y0, int w, int h) {
        string[] result = new string[h];
        for (int i = 0; i < h; ++i) {
            char[] tmp = new char[w];
            for (int j = 0; j < w; ++j) {
                tmp[j] = getChecker(t, x0 + j, y0 + h - i - 1);
            }
            result[i] = new string(tmp);
        }
        return result;
    }

    private char getChecker(long t, long x, long y) {
        if ((x + y) % 2 == 1 || (x + y) / 2 >= t || x - y < 0 || y < 0) {
            return '.';
        }
        if (t == 1) {
            return 'A';
        }
        if (t == 2) {
            return (x == 0 && y == 0 ? 'A' : 'B');
        }
        while ((t & -t) != t) {
            t += t & -t;
        }
        if (y >= t / 2) {
            return getChecker(t / 2, x - t / 2, y - t / 2);
        }
        if (x >= t) {
            return getChecker(t / 2, x - t, y);
        }
        return getChecker(t / 2, x, y);
    }
}
