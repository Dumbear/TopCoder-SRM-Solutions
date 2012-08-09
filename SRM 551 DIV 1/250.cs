using System;
using System.Collections.Generic;

public class ColorfulChocolates {
    public int maximumSpread(string chocolates, int maxSwaps) {
        int maxCount = 0;
        for (int i = 0; i < chocolates.Length; ++i) {
            List<int> list = new List<int>();
            for (int j = i - 1, k = i - 1; j >= 0; --j) {
                if (chocolates[j] == chocolates[i]) {
                    list.Add(k - j);
                    --k;
                }
            }
            for (int j = i + 1, k = i + 1; j < chocolates.Length; ++j) {
                if (chocolates[j] == chocolates[i]) {
                    list.Add(j - k);
                    ++k;
                }
            }
            list.Sort();
            int count = 1, remain = maxSwaps;
            foreach (int distance in list) {
                if (remain >= distance) {
                    remain -= distance;
                    ++count;
                }
            }
            maxCount = Math.Max(maxCount, count);
        }
        return maxCount;
    }
}
