using System;

namespace kegeln {
	/*
	Es wird gekegelt.
	9 Pins, jeder 3 Würfe
	Sagen wir ... 3 Teilnehmer...
	Also, jeder wirft 3x.
	Gezählt werden die abgeräumten Kegel.
	(Das Ganze per Zufallszahl)
	Haut jemand alle Kegel auf einen Schlag raus, ist er nochmal dran.
	Bis alle Würfe (3) verbraucht sind.
	Nur die abgeräumten Kegel.
	Das Turnier hat 3 Durchgänge.
	Macht mal :-)
	Am Schluss eine Liste mit den 3 Teilnehmern
	Platz 1: Teilnehmer X
	Platz
	*/
	class Program {
		static private readonly Random rnd = new Random ();
		static private int GetRound () {
			int result = 0;
			int pinCount = 0;
			for (int i = 0; i < 3; i++) {
				if (pinCount == 0) { pinCount = 9; }
				int num = rnd.Next (0, 10);
				//Console.WriteLine ("pre_try {0} - num {1} - pins {2}", i, num, pinCount);
				if (num > pinCount) {
					result += pinCount;
					pinCount = 9;
				} else {
					result += num;
					pinCount -= num;
				}
				//Console.WriteLine ("post_try {0} - num {1} - pins {2}", i, num, pinCount);
			}
			return result;
		}
		static void Main () {
			int[] finResult = new int[3];
			for (int idx = 0; idx < 3; idx++) {
				for (int i = 0; i < 3; i++) {
					int round = GetRound ();
					finResult[i] += round;
					Console.WriteLine ("player {0} got {1} Points in round {2}", i + 1, round, idx + 1);
				}
			}
			for (int i = 0; i < finResult.Length; i++) {
				Console.WriteLine ("final Result player {0}: {1}", i + 1, finResult[i]);
			}

		}
	}
}