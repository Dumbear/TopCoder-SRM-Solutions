using System;

public class ElectionFraudDiv1 {
    public int MinimumVoters(int[] percentages) {
        for (int i = 1; i <= 1024; ++i) {
            int[] min = new int[101], max = new int[101];
            for (int j = 0; j <= 100; ++j) {
                min[j] = max[j] = -1;
            }
            for (int j = i; j >= 0; --j) {
                min[(int)Math.Round(100.0 * j / i + 1e-8)] = j;
            }
            for (int j = 0; j <= i; ++j) {
                max[(int)Math.Round(100.0 * j / i + 1e-8)] = j;
            }
            int minSum = 0, maxSum = 0;
            foreach (int percentage in percentages) {
                if (min[percentage] == -1 || max[percentage] == -1) {
                    minSum = maxSum = -1;
                    break;
                }
                minSum += min[percentage];
                maxSum += max[percentage];
            }
            if (minSum <= i && maxSum >= i) {
                return i;
            }
        }
        return -1;
    }
}
