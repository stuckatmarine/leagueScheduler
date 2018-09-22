
/**
 *   Leauge Schedule Generator
 * 
 *   Generate a schedule based on a teams preference
 *   prefered field, time, or day to optimise favorable games
 * 
 *   By: Mark Duffett, Aug 2018
 */

//using System.Windows.Forms;
//using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;


public class Scheduler
{

	// bitwise preference type representation
	public class PREFTYPE{
		public const int NA		= -1;
		public const int NONE 	= 0;
		public const int DAY 	= 1;
		public const int TIME 	= 2;
		public const int FIELD 	= 4;
	};

	// bitwise day representation
	public class WEEKDAYS {
		public const int NA			= -1;
		public const int MONDAY 	= 1;
		public const int TUESDAY 	= 2;
		public const int WEDNESDAY	= 4;
		public const int THURSDAY	= 8;
		public const int FRIDAY		= 1;
		public const int SATURDAY	= 32;
		public const int SUNDAY		= 64;
	};

	// bitwise timeslot representation
	public class TIMESLOT {
		public const int NA		= -1;
		public const int EARLY	= 1;
		public const int LATE	= 2;
	};

	// bitwise field representation
	public class FIELDNUM {
		public const int NA		= -1;
		public const int ZERO	= 1;
		public const int ONE	= 2;
		public const int TWO	= 4;
		public const int THREE	= 8;
		public const int FOUR	= 16;
		public const int FIVE	= 32;
		public const int SIX	= 64;
		public const int SEVEN  = 128;
	};

	// create a deep clone of an object, not by reference
	// requires [serializable] above class declaration
/*	public static T DeepClone<T> (T obj)
	{
		using (var ms = new MemoryStream ()) {
			var formatter = new BinaryFormatter ();
			formatter.Serialize (ms, obj);
			ms.Position = 0;

			return (T)formatter.Deserialize (ms);
		}
	}
*/
	// Game to be played
	public  class Game
	{
		public int gameNumber;
		public int timeslot = 0;
		public int field = -1;
		public int team1 = -1;
		public int team2 = -1;
		public string time = "";

		public Game (string ti, int ts = 0)
		{
			this.time = ti;
			this.timeslot = ts;
			this.team1 = -1;
			this.team2 = -1;
		}
	};

	/* 
	* Each field/stadium/rink to be played on
 	* numTimes = number of games each day
 	* name = field name
 	* daysAvail = bitwise notation for Monday to Sunday
  	*/
	public class Field
	{
		public int fieldNum = -1;
		public int numGames = -1;
		public int daysAvail = -1;
		public string name;
		public List<Game> games;

		public Field (int numTimes, string field, int days, int fNum)
		{
			this.numGames = numTimes; 
			this.name = field;
			this.daysAvail = days;
			this.fieldNum = fNum;
			games = new List<Game> ();
		}
	};

	// Each team in the league
	public class Team 
	{
		public int teamNumber;
		public int numGamesPlayed = 0;
		public int prefDay;
		public int prefTime;
		public int lastWeekPlayed = -1;
		public int numPreferredGames = 0;
		public int prefType;
		public int prefField;
		public string teamName;
		public List<int> opponents;
		public List<int> opponentsAllSeason;
		public List<Game> gamesAllSeaason;

		public Team (int number, string name, int pref, int day, int time, int field)
		{
			this.teamNumber = number;
			this.teamName = name;
			this.prefType = pref;
			this.prefDay = day;
			this.prefTime = time;
			this.prefField = field;
			opponents = new List<int> ();
			opponentsAllSeason = new List<int> ();
			gamesAllSeaason = new List<Game> ();
		}
	};

	// Each day in a week
	public class Day
	{
		public List<Field> fields;

		public Day ()
		{
			fields = new List<Field> ();
		}
	};

	// --- globals ---
	public Random rand = new Random ();
	public int numTeams = 8;
	public int numWeeks = 10;
	public int numFields = 2;
	public int weeklyGames = 16;
	public int maxGamesPerFieldPerDay = 4;
	public int maxGamesPerWeekPerTeam = 2;
	public int maxGamesPerTeam = 16;
	public int prefsFound;
	public int totalGames;
	public int weeklyTrys = 8;
	public int teamsDone = 0;
	// 1 = pickers Pref, 2 = both prefs
	public bool doubleHeaders = true;

	List<Game> masterGameVec;
	List<int> pickOrder;
	List<int> playedAllready;
	List<int> gotPreferred;
	List<Team> teams;
	List<Field> fields;
	List<Day> days;
	List<List<Day>> weeks;

	// Constructor
	Scheduler ()
	{
		masterGameVec = new List<Game> ();
		pickOrder = new List<int> ();
		playedAllready = new List<int> ();
		gotPreferred = new List<int> ();
		teams = new List<Team> ();
		fields = new List<Field> ();
		days = new List<Day> ();
		weeks = new List<List<Day>> ();
		totalGames = maxGamesPerTeam * numTeams;
	}

	// randomize pick order vector
	void randomizePickOrder ()
	{
		while (pickOrder.Count > 0)
			this.pickOrder.RemoveAt (-1);

		while (pickOrder.Count < numTeams) {
			int randInt = rand.Next () % numTeams;
			bool found = false;
			foreach (int num in pickOrder) {
				if (num == randInt) {
					found = true;
					break;
				}
			}
			if (!found)
				pickOrder.Add (randInt);
		}
	}

	// creat team objects
	public void populateTeams ()
	{
		teams.Add (new Team (0, "Yankes", PREFTYPE.DAY, WEEKDAYS.MONDAY, TIMESLOT.NA, FIELDNUM.NA));
		teams.Add (new Team (1, "Sox", PREFTYPE.DAY, WEEKDAYS.MONDAY + WEEKDAYS.TUESDAY, TIMESLOT.NA, FIELDNUM.NA));
		teams.Add (new Team (2, "Cubs", PREFTYPE.DAY, WEEKDAYS.TUESDAY, -1, -1));
		teams.Add (new Team (3, "Jays", PREFTYPE.DAY, 1, -1, -1));
		teams.Add (new Team (4, "Angels", PREFTYPE.DAY, 1, -1, -1));
		teams.Add (new Team (5, "Nationals", PREFTYPE.DAY, 1, -1, -1));
		teams.Add (new Team (6, "Astros", PREFTYPE.DAY, 1, -1, -1));
		teams.Add (new Team (7, "Cardinals", PREFTYPE.DAY,WEEKDAYS.TUESDAY, -1, -1));
		Debug.Assert (numTeams == pickOrder.Count);
	}

	// create each field's games and time availability
	void populateFields ()
	{
		fields.Add (new Field (4, "Fenway", 3, FIELDNUM.ONE));
		fields [0].games.Add (new Game ("6pm"));
		fields [0].games.Add (new Game ("7:15pm"));
		fields [0].games.Add (new Game ("8:30pm", 1));
		fields [0].games.Add (new Game ("9:45pm", 1));
		fields.Add (new Field (4, "Wrigley", 3, FIELDNUM.TWO));
		fields [1].games.Add (new Game ("6pm"));
		fields [1].games.Add (new Game ("7:15pm"));
		fields [1].games.Add (new Game ("8:30pm", 1));
		fields [1].games.Add (new Game ("9:45pm", 1));

		Debug.Assert (numFields == fields.Count);
		Debug.Assert (fields [0].games [0].team1 == -1);
	}

	// create blank weekly field schedule
	void populateDays ()
	{
		int dayFlag = 1;
		int gameCount = 0; // test
		for (int dayNum = 0; dayNum < 7; dayNum++) {
			Day tempDay = new Day ();
			foreach (Field field in fields) {
				if ((field.daysAvail & dayFlag) > 0) {
					tempDay.fields.Add (field);
					gameCount += field.numGames; 
				}
			}
			days.Add (tempDay);
			dayFlag = dayFlag << 1;
		}
	}

	// check day vs bitwise day value
	bool checkDay (int day, int dayBit)
	{
		int count = 0;
		while (count < 7) {
			if ((dayBit & 0x01) > 0 && count == day) {
				return true;
			}
			count++;
			dayBit = dayBit >> 1;
		}
		return false;
	}

	// find opponent with preference, if none returns last free, if non returns -1
	int findOpponent (int weekNum, int pNum, int day, int time, int field, int numTry = 0)
	{
		Console.WriteLine ("Find Opp: week, day, time, field, pickTeam, : " +
		weekNum + day + time + field + pNum);

		int lastOpp = -1;
		for (int k = 0; k < pickOrder.Count; k++) {
			Console.Write ("Try " + pickOrder [k] + ", lastWeek " + teams [pickOrder [k]].lastWeekPlayed +
			", # games so far " + teams [pickOrder [k]].numGamesPlayed + ",current opp list: ");
			for (int i = 0; i < teams [pickOrder [k]].opponents.Count; i++)
				Console.Write (Convert.ToString (teams [pickOrder [k]].opponents [i]) + " ");
			Console.WriteLine ();
			if (pickOrder [k] != pNum && (teams [pickOrder [k]].lastWeekPlayed - numTry) < weekNum &&
			    teams [pNum].opponents.Find (num => num == pickOrder [k]) == -1 && // checked for logic issue
			    teams [pickOrder [k]].numGamesPlayed < maxGamesPerTeam) {
				Debug.Assert (pickOrder [k] != pNum);
				if (lastOpp < 0)
					lastOpp = pickOrder [k];
				if ((teams [pickOrder [k]].prefDay & day) > 0 || (teams [pickOrder [k]].prefTime & time) > 0 ||
					(teams [pickOrder [k]].prefField & field) > 0) {
					prefsFound = 2;
					return pickOrder [k];
				}
				prefsFound = 1;
			}
		}
		if (lastOpp < 0 && (numTry + (doubleHeaders ? 2 : 1) < maxGamesPerWeekPerTeam)) {
			Console.WriteLine ("#### no opponents who haven't allready played this week, " +
				"trying again within same week");
			lastOpp = findOpponent (weekNum, pNum, day, time, field, numTry + 1);
		}

		return lastOpp;
	}

	// move opponents list contents to seasonOpp
	void moveOpp (int pNum)
	{
		Console.WriteLine ("Team " + pNum + ", shifting opp to season opp");
		while (teams [pNum].opponents.Count > 0) {
			int temp = teams [pNum].opponents [teams [pNum].opponents.Count - 1];
			teams [pNum].opponents.RemoveAt (teams [pNum].opponents.Count - 1);
			teams [pNum].opponentsAllSeason.Add (temp);
		}
	}

	// move index who got their pref to back of order
	void movePickPref (int teamNum)
	{
		Debug.Assert (pickOrder.Find (num => num == teamNum) >= 0);
		gotPreferred.Add (teamNum);
		pickOrder.Remove (teamNum);
	}

	// move index who got played but didnt get their pref to back of order
	void movePickPlayed (int teamNum)
	{
		Debug.Assert (pickOrder.Find (num => num == teamNum) > 0);
		playedAllready.Add (teamNum);
		pickOrder.Remove (teamNum);
	}

	// move all teams to pick order for next week
	void addToPickOrder ()
	{
		Debug.Assert (pickOrder.Count + playedAllready.Count + gotPreferred.Count == numTeams);
		while (playedAllready.Count > 0) {
			pickOrder.Add (playedAllready [playedAllready.Count - 1]);
			playedAllready.RemoveAt (playedAllready.Count - 1);
		}
		while (gotPreferred.Count > 0) {
			pickOrder.Add (gotPreferred [gotPreferred.Count - 1]);
			gotPreferred.RemoveAt (gotPreferred.Count - 1);
		}
	}

	// return true if the gNum is in a preferred pNum game
	bool checkPreferred (int weekNum, int day, int fNum, int gNum, int pNum)
	{
		if (checkDay (day, teams [pNum].prefDay) || (teams [pNum].prefTime &
			weeks [weekNum] [day].fields [fNum].games [gNum].timeslot) > 0 ||
			(teams [pNum].prefField & weeks [weekNum] [day].fields [fNum].fieldNum) > 0)
			return true;
		return false;
	}

	// add both teams to a game, add them as played, update last week played
	void fillInGames (int weekNum, int day, int fNum, int gNum, int oppNum, int pNum)
	{
		Console.WriteLine ("##### Game: week, day, field, game, t1, t2 : " + weekNum + day + fNum + gNum + pNum + oppNum);
		Debug.Assert (pNum >= 0);
		// updated team1/pNum
		weeks [weekNum] [day].fields [fNum].games [gNum].team1 = pNum;
		teams [pNum].opponents.Add (teams [oppNum].teamNumber);
		teams [pNum].lastWeekPlayed = weekNum;
		teams [pNum].numGamesPlayed++;
		if (teams [pNum].numGamesPlayed >= maxGamesPerTeam)
			teamsDone++;

		// check if game is a prefered game for this team
		if (checkPreferred (weekNum, day, fNum, gNum, pNum)) {
			teams [pNum].numPreferredGames++;
		} else
			Console.WriteLine("non pref");

		// move opponents played vec to season vec if all opponents played
		if (teams [pNum].numGamesPlayed % ((numTeams - 1) * (doubleHeaders ? 2 : 1)) == 0) {
			moveOpp (pNum);
		}

		// update team1
		weeks [weekNum] [day].fields [fNum].games [gNum].team2 = teams [oppNum].teamNumber;
		teams [oppNum].opponents.Add (teams [pNum].teamNumber);
		teams [oppNum].lastWeekPlayed = weekNum;
		teams [oppNum].numGamesPlayed++;
		if (teams [oppNum].numGamesPlayed >= maxGamesPerTeam)
			teamsDone++;

		// check if game is a prefered game for this team
		if (checkPreferred (weekNum, day, fNum, gNum, oppNum)) {
			teams [oppNum].numPreferredGames++;
		}

		// move opponents played vec to season vec if all opponents played
		if (teams [oppNum].numGamesPlayed % ((numTeams - 1) * (doubleHeaders ? 2 : 1)) == 0) {
			moveOpp (oppNum);
		}

		// add to individual team's game vector
		weeks [weekNum] [day].fields [fNum].games [gNum].gameNumber = masterGameVec.Count;
		weeks [weekNum] [day].fields [fNum].games [gNum].field = weeks [weekNum] [day].fields [fNum].fieldNum;
		teams [pNum].gamesAllSeaason.Add (weeks [weekNum] [day].fields [fNum].games [gNum]);
		teams [oppNum].gamesAllSeaason.Add (weeks [weekNum] [day].fields [fNum].games [gNum]);

		// add to master game vector
		masterGameVec.Add (weeks [weekNum] [day].fields [fNum].games [gNum]);
	}

	// attempt to find a game for a team with a preferred day
	int gameFinder (int currentWeek, int pNum, int prefType = PREFTYPE.NONE)
	{
		// check each prefday
		int day = 0;
		int prefDayVal = teams [pNum].prefDay;
		int oppFound = -1;
		while (day < 7) {
			if ((prefDayVal & 0x01) > 0 || prefType > 1) {
				// check each field on that day
				for (int i = 0; i < days [day].fields.Count; i++) {
					// check each game time
					for (int j = 0; j < days [day].fields [i].numGames; j++) {
						// if theres a free field
						if ((weeks [currentWeek] [day].fields [i].games [j].team1 == -1) && (prefType == PREFTYPE.DAY) || 
								(prefType == PREFTYPE.TIME && 
								(weeks [currentWeek] [day].fields [i].games [j].timeslot & teams [pNum].prefTime) > 0)||
								(prefType == PREFTYPE.FIELD && 
								(weeks [currentWeek] [day].fields [i].games [j].timeslot & teams [pNum].prefTime) > 0)){
							
							// find opponent, prioritising simaler preferences
							oppFound = findOpponent (currentWeek, pNum, day,
								days [day].fields [i].games [j].timeslot, days [day].fields [i].fieldNum);
							Console.WriteLine ("Result == " + oppFound);
							Debug.Assert (oppFound != pNum);
							Debug.Assert (teams [pNum].opponents.BinarySearch (oppFound) < 0);
						} 
						// exit condition for found game and opponent
						if (oppFound >= 0 ) {
							// fill in games vs opponent
							fillInGames (currentWeek, day, i, j, oppFound, pNum);
							if (doubleHeaders) {
								// fill in twice
								fillInGames (currentWeek, day, i, j + 1, pNum, oppFound);
							}
							return oppFound;
						}
					}
			//		if (oppFound > 0)
			//			return oppFound;
				}
			}
			prefDayVal = prefDayVal >> 1;
			day++;
		}
		return oppFound;
	}

	// attempt to fill in all games for the week up to the weeklyGames limit
	int populateWeek (int currentWeek, int numTry = 0)
	{
		 
		Console.Write ("\n--- Week " + currentWeek + " --- Total Games: " + masterGameVec.Count + " pickOrder ");
		foreach (int num in pickOrder)
			Console.Write (num + " ");
		Console.WriteLine ();

		Debug.Assert (currentWeek < numWeeks);
		int gamesPlanned = 0;
		int pickIndex = 0;

		while (gamesPlanned < weeklyGames && pickOrder.Count > 0 && pickIndex < pickOrder.Count - 1) {
			prefsFound = 0;
			Debug.Assert (pickIndex < pickOrder.Count - 1);
			Console.Write ("Team " + pickOrder [pickIndex] + " prefers " + teams [pickOrder [pickIndex]].prefType +
			"\nopponents thus far: ");

			// print opponents
			for (int i = 0; i < teams [pickOrder [pickIndex]].opponents.Count; i++)
				Console.Write (Convert.ToString (teams [pickOrder [pickIndex]].opponents [i]) + " ");
			Console.WriteLine ();

			int oppFound = -1;
			// check if the picking team has played yet this week
			if (teams [pickOrder [pickIndex]].lastWeekPlayed - numTry < currentWeek) {
				// try and find their preference
				if (teams [pickOrder [pickIndex]].prefType == PREFTYPE.DAY) {
					Console.WriteLine ("Pref Day = " + teams [pickOrder [pickIndex]].prefDay);
					oppFound = gameFinder (currentWeek, pickOrder [pickIndex], PREFTYPE.DAY);
				} else if (teams [pickOrder [pickIndex]].prefType == PREFTYPE.TIME) {
					Console.WriteLine ("Pref Time = " + teams [pickOrder [pickIndex]].prefTime);
					oppFound = gameFinder (currentWeek, pickOrder [pickIndex], PREFTYPE.TIME);
				} else if (teams [pickOrder [pickIndex]].prefType == PREFTYPE.FIELD) {
					Console.WriteLine ("in field case");
					Debug.Assert (1 == 2); // should never get here
				}
			} else
				Console.WriteLine ("    allready played this week");

			if (oppFound >= 0) {
				// inc weekly games count
				gamesPlanned++;
				if (doubleHeaders) {
					gamesPlanned++;
				}

				// move both teams to pref vector
				if (prefsFound == 2) {
					movePickPref (oppFound);
					movePickPref (pickOrder [pickIndex]);
				}
				// move only picking team to pref vector
				else if (prefsFound == 1) {
					movePickPlayed (oppFound);
					Debug.Assert (pickIndex < pickOrder.Count);
					movePickPref (pickOrder [pickIndex]);
				}
			} else if (pickIndex < pickOrder.Count - 1)
				pickIndex++;
			else
				break;
		}
		return gamesPlanned;
	}

	// --- main ---
	static void Main (string[] args)
	{

		Scheduler sched = new Scheduler ();

		// launch gui window
		// Application.Run(new league.LaunchForm());

		sched.randomizePickOrder ();

		sched.populateTeams ();

		// test outs
		Debug.Assert (sched.pickOrder.Count == sched.numTeams);

		// fill vector of weeks creating a blank schedule
		while (sched.weeks.Count - 1 < sched.numWeeks) {
			sched.populateFields ();
			Debug.Assert (sched.fields [0].games [0].team1 == -1);
			sched.populateDays ();
			Debug.Assert (sched.days [0].fields [0].games [0].team1 == -1);
			sched.weeks.Add (sched.days);
			Debug.Assert (sched.weeks [sched.weeks.Count - 1] [0].fields [0].games [0].team1 == -1);
			if (sched.weeks.Count - 1 < sched.numWeeks) {
				sched.fields = new List<Field> ();
				sched.days = new List<Day> ();
			}
		}

		// update games each week based on pick order and preference
		int currentWeek = 0;
		int gamesPlayed = 0;
		int tryNum = 0;
		while (currentWeek < sched.numWeeks) {
			// copy the schedule efore filling week
			Scheduler temp = new Scheduler ();
			temp = ObjectExtensions.Copy (sched);
			gamesPlayed = sched.populateWeek (currentWeek);

			// if week filled correctly
			if (gamesPlayed == sched.weeklyGames || tryNum == sched.weeklyTrys) {
				sched.addToPickOrder ();
				currentWeek++;
				tryNum = 0;
			} else if (sched.masterGameVec.Count >= sched.totalGames || sched.teamsDone == sched.numTeams) {
				Console.WriteLine ("--- All games scheduled --- Week " + currentWeek);
				break;
			} else {
				List<int> tempList = new List<int> ();
				tempList = sched.pickOrder;
				sched = temp;
				foreach (int team in tempList)
					sched.pickOrder.Remove (team);
				foreach (int team in sched.pickOrder)
					tempList.Add (team);
				sched.pickOrder = tempList;
				foreach (int team in sched.pickOrder)
					Console.Write (team + " ");
				Console.WriteLine (" &&& Re-trying week");
				tryNum++;
			}
		}

		Console.WriteLine ("\ncleaning up schedule");
		// put complete opponents list in seasonOpponents for each team
		int leastPreferred = sched.maxGamesPerTeam;
		for (int i = 0; i < sched.numTeams; i++) {
			sched.moveOpp (i);
			if (sched.teams [i].numPreferredGames < leastPreferred)
				leastPreferred = sched.teams [i].numPreferredGames;
		}

		Console.WriteLine ("\nTotals Possible = " + sched.numTeams * sched.maxGamesPerTeam / 2 +
		"\nGames Scheduled= " + sched.masterGameVec.Count);
		Console.WriteLine ("\nTeam with the least prefered has " + leastPreferred + " of " +
		sched.maxGamesPerTeam + " prefered.");

		/*
	cout << "\n ---- Saving schedule to .csv ---- " << endl;
		string path = @"/Users/Julia/Desktop/temp.csv";

		if (File.Exists (path))
			File.Delete (path);

		using (FileStream fs = File.Create (path))
			fs.Write (fields [0].name, 0, fields [0].name.size ());
			
*/

		// Keep the console window open in debug mode.
		//	Console.WriteLine("Press any key to exit.");
		//	Console.ReadKey();

		Console.WriteLine ("Hello World");
	}
}
