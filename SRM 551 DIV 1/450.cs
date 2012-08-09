using System;

public class ColorfulWolves {
    public int getmin(string[] colormap) {
        int n = colormap.Length;
        int[,] distances = new int[n, n];
        for (int i = 0; i < n; ++i) {
            int count = 0;
            for (int j = 0; j < n; ++j) {
                distances[i, j] = short.MaxValue;
                if (colormap[i][j] == 'Y') {
                    distances[i, j] = count++;
                }
            }
        }
        for (int k = 0; k < n; ++k) {
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < n; ++j) {
                    distances[i, j] = Math.Min(distances[i, j], distances[i, k] + distances[k, j]);
                }
            }
        }
        return distances[0, n - 1] == short.MaxValue ? -1 : distances[0, n - 1];
    }
}
