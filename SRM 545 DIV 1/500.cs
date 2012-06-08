using System;

public class Spacetsk {
    private const int Modulo = 1000000007;

    public int countsets(int l, int h, int k) {
        long[,] comb = getCombinations(Math.Max(Math.Max(l, h), k) + 1);
        long result = comb[h + 1, k] * (l + 1) % Modulo;
        if (k == 1) {
            return (int)result;
        }
        for (int i = 1; i <= l; ++i) {
            int[] numbers = new int[l + 1];
            int index = 0;
            long current = 0;
            for (int j = 0; j <= l; ++j) {
                numbers[j] = (l - j) / i + 1;
                current = add(current, comb[numbers[j], k]);
            }
            for (int j = 1; j <= h; ++j) {
                if (gcd(i, j) != 1) {
                    continue;
                }
                while (index <= l && numbers[index] > h / j + 1) {
                    current = subtract(current, comb[numbers[index], k]);
                    ++index;
                }
                long tmp = add(current, index * comb[h / j + 1, k] % Modulo);
                result = add(result, tmp);
                result = add(result, tmp);
            }
        }
        return (int)result;
    }

    private long[,] getCombinations(int n) {
        long[,] comb = new long[n + 1, n + 1];
        for (int i = 0; i <= n; ++i) {
            comb[i, 0] = 1;
            for (int j = 1; j <= i; ++j)
                comb[i, j] = (comb[i - 1, j] + comb[i - 1, j - 1]) % Modulo;
        }
        return comb;
    }

    private int gcd(int x, int y) {
        return y == 0 ? x : gcd(y, x % y);
    }

    private long add(long x, long dx) {
        x += dx;
        return x < Modulo ? x : x - Modulo;
    }

    private long subtract(long x, long dx) {
        x -= dx;
        return x < 0 ? x + Modulo : x;
    }
}
