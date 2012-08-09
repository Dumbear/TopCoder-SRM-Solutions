using System;

public class RotatingBot {
    private static int[] dx = { 1, 0, -1, 0 };
    private static int[] dy = { 0, 1, 0, -1 };

    public int minArea(int[] moves) {
        if (moves.Length == 1) {
            return moves[0] + 1;
        }
        if (moves.Length == 2) {
            return (moves[0] + 1) * (moves[1] + 1);
        }
        if (moves.Length == 3) {
            return (Math.Max(moves[0], moves[2]) + 1) * (moves[1] + 1);
        }
        int w = Math.Max(moves[0], moves[2]) + 1, h = Math.Max(moves[1], moves[3]) + 1;
        bool[,] isVisited = new bool[w, h];
        int x = Math.Max(0, moves[2] - moves[0]), y = Math.Max(0, moves[3] - moves[1]);
        isVisited[x, y] = true;
        for (int i = 0; i < moves.Length; ++i) {
            for (int j = 0; j < moves[i]; ++j) {
                x += dx[i % 4];
                y += dy[i % 4];
                if (x < 0 || x >= w || y < 0 || y >= h || isVisited[x, y]) {
                    return -1;
                }
                isVisited[x, y] = true;
            }
            int tx = x + dx[i % 4], ty = y + dy[i % 4];
            if (tx >= 0 && tx < w && ty >= 0 && ty < h && !isVisited[tx, ty] && i + 1 != moves.Length) {
                return -1;
            }
        }
        return w * h;
    }
}
