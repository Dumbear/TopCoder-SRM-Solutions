using System;

public class StrIIRec {
    public string recovstr(int n, int minInv, string minStr) {
        minStr = fill(n, minStr, false);
        string result = string.Empty;
        for (int i = 0; i < n; ++i) {
            for (char j = 'a'; j < 'a' + n; ++j) {
                string next = result + j;
                if (result.IndexOf(j) != -1 || string.Compare(next, 0, minStr, 0, next.Length) < 0) {
                    continue;
                }
                if (countInversions(fill(n, next, true)) < minInv) {
                    continue;
                }
                result = next;
                break;
            }
            if (result.Length != i + 1) {
                return string.Empty;
            }
        }
        return result;
    }

    private string fill(int n, string s, bool reversed) {
        bool[] isUsed = new bool[n];
        foreach (char c in s) {
            isUsed[c - 'a'] = true;
        }
        for (int i = (reversed ? n - 1 : 0); (reversed ? i >= 0 : i < n); i += (reversed ? -1 : 1)) {
            if (!isUsed[i]) {
                s += (char)('a' + i);
            }
        }
        return s;
    }

    private int countInversions(string s) {
        int count = 0;
        for (int i = 0; i < s.Length; ++i) {
            for (int j = i + 1; j < s.Length; ++j) {
                if (s[i] > s[j]) {
                    ++count;
                }
            }
        }
        return count;
    }
}
