using System;

public class PointyWizardHats {
    public int getNumHats(int[] topHeight, int[] topRadius, int[] bottomHeight, int[] bottomRadius) {
        bool[] topUsed = new bool[topHeight.Length];
        bool[] bottomUsed = new bool[bottomHeight.Length];
        int count = 0;
        for (int i = 0; i < topHeight.Length; ++i) {
            int topIndex = -1;
            for (int j = 0; j < topHeight.Length; ++j) {
                if (!topUsed[j] && (topIndex == -1 || topRadius[j] > topRadius[topIndex])) {
                    topIndex = j;
                }
            }
            topUsed[topIndex] = true;
            double topRatio = (double)topHeight[topIndex] / topRadius[topIndex];
            int bottomIndex = -1;
            for (int j = 0; j < bottomHeight.Length; ++j) {
                if (!bottomUsed[j] && topRadius[topIndex] < bottomRadius[j]) {
                    double bottomRatio = (double)bottomHeight[j] / bottomRadius[j];
                    if (bottomRatio < topRatio && (bottomIndex == -1 || bottomRatio > (double)bottomHeight[bottomIndex] / bottomRadius[bottomIndex])) {
                        bottomIndex = j;
                    }
                }
            }
            if (bottomIndex != -1) {
                ++count;
                bottomUsed[bottomIndex] = true;
            }
        }
        return count;
    }
}
