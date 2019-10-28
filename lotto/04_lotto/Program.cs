using System;
using System.Linq;

namespace _04_lotto {
	class Program {
		private static readonly Random rnd = new Random ();
		static int[] GetLottoRound (int min, int max, int count) {
			int[] result = new int[count];
			for (int i2 = 0; i2 < count; i2++)
			{
				int num;
				do{num = rnd.Next(min, max);} while (result.Contains(num));
				result[i2] = num;
			}
			Array.Sort (result);
			return result;
		}
		static void Main () {
			int[][] rounds = new int[10][];
			for (int i = 0; i < 10; i++) { rounds[i] = GetLottoRound (1, 50, 6); }

			for (int try_no = 0; try_no < 10; try_no++) {
				int good_num = 0;
				Console.WriteLine ("my nums : {0}", string.Join (", ", rounds[try_no]));
				int[] nums = GetLottoRound (1, 50, 6);
				Console.WriteLine ("nums : {0}", string.Join (", ", nums));
				foreach (int num in nums) { if (rounds[try_no].Contains (num)) { good_num++; } }
				Console.WriteLine ("runde: {0} - richtige: {1}\n", try_no, good_num);
			}
		}
	}
}