using System;

public class FlipGame {
    public int minOperations(string[] board) {
        int count = 0;
        while (true) {
            int last = -1;
            for (int i = 0; i < board.Length; ++i) {
                last = Math.Max(last, board[i].LastIndexOf('1'));
                char[] next = board[i].ToCharArray();
                for (int j = 0; j <= last; ++j) {
                    next[j] = (next[j] == '0' ? '1' : '0');
                }
                board[i] = new string(next);
            }
            if (last == -1) {
                break;
            }
            ++count;
        }
        return count;
    }
}
