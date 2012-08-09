using System;

public class KleofasTail {
    public long countGoodSequences(long k, long a, long b) {
        long count = 0, weight = 1;
        while (true) {
            while (a <= b && (a % 2 == 1 || a < 1)) {
                count += (isGood(k, a) ? weight : 0);
                ++a;
            }
            if (a <= b && b % 2 == 0) {
                count += (isGood(k, b) ? weight : 0);
                --b;
            }
            if (k >= a && k <= b) {
                count += (k % 2 == 0 ? weight * 2 : weight);
            }
            if (a > b) {
                break;
            }
            weight *= 2;
            a /= 2;
            b /= 2;
        }
        return count;
    }

    private bool isGood(long k, long x) {
        for (; x != 0; x = (x % 2 == 0 ? x / 2 : x - 1)) {
            if (x == k) {
                return true;
            }
        }
        return k == 0;
    }
}
