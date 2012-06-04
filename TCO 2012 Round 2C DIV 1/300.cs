using System;
using System.Collections.Generic;

public class GreedyTravelingSalesman {
    public int worstDistance(string[] thousands, string[] hundreds, string[] tens, string[] ones) {
        int n = thousands.Length;
        int[,] distance = new int[n, n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                distance[i, j] = getDistance(thousands[i][j], hundreds[i][j], tens[i][j], ones[i][j]);
            }
        }
        int result = 0;
        for (int i = 0; i < n; ++i) {
            List<int> values = new List<int>();
            values.Add(9999);
            for (int j = 0; j < n; ++j) {
                values.Add(Math.Max(1, distance[i, j]));
                values.Add(Math.Max(1, distance[i, j] - 1));
            }
            for (int j = 0; j < n; ++j) {
                if (i != j) {
                    foreach (int value in values) {
                        int tmp = distance[i, j];
                        distance[i, j] = value;
                        result = Math.Max(result, worstDistance(n, distance));
                        distance[i, j] = tmp;
                    }
                }
            }
        }
        return result;
    }

    private int getDistance(char thousand, char hundred, char ten, char one) {
        return 1000 * (thousand - '0') + 100 * (hundred - '0') + 10 * (ten - '0') + 1 * (one - '0');
    }

    private int worstDistance(int n, int[,] distance) {
        int result = 0;
        bool[] isVisited = new bool[n];
        int current = 0;
        isVisited[current] = true;
        for (int i = 1; i < n; ++i) {
            int next = -1;
            for (int j = 0; j < n; ++j) {
                if (current != j && !isVisited[j] && (next == -1 || distance[current, j] < distance[current, next])) {
                    next = j;
                }
            }
            isVisited[next] = true;
            result += distance[current, next];
            current = next;
        }
        return result;
    }
}
