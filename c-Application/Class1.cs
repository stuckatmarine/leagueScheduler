using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace Schedulerv1
{
    class _Main : Scheduler
    {

        // --- main ---
        static void Main(string[] args)
        {

            Scheduler sched = new Scheduler();

            ///////////////////////// Get values from gui /////////////////////////////////////////
            // launch gui window
            // Application.Run(new league.LaunchForm());


            ///////////////////////// Start generating Sched //////////////////////////////////////
            sched.randomizePickOrder();

            sched.populateTeams();

            // test outs
            Debug.Assert(sched.pickOrder.Count == sched.numTeams);

            // fill vector of weeks creating a blank schedule
            while (sched.weeks.Count - 1 < sched.numWeeks)
            {
                sched.populateFields();
                Debug.Assert(sched.fields[0].games[0].team1 == -1);
                sched.populateDays();
                Debug.Assert(sched.days[0].fields[0].games[0].team1 == -1);
                sched.weeks.Add(sched.days);
                Debug.Assert(sched.weeks[sched.weeks.Count - 1][0].fields[0].games[0].team1 == -1);
                if (sched.weeks.Count - 1 < sched.numWeeks)
                {
                    sched.fields = new List<Field>();
                    sched.days = new List<Day>();
                }
            }

            // update games each week based on pick order and preference
            int currentWeek = 0;
            int gamesPlayed = 0;
            int tryNum = 0;
            while (currentWeek < sched.numWeeks)
            {
                // copy the schedule efore filling week
                Scheduler temp = new Scheduler();
                temp = ObjectExtensions.Copy(sched);
                gamesPlayed = sched.populateWeek(currentWeek);

                // if week filled correctly
                if (sched.masterGameVec.Count >= sched.totalGames || sched.teamsDone >= sched.numTeams)
                {
                    Console.WriteLine("--- All games scheduled --- Week " + currentWeek);
                    break;
                }
                else if (gamesPlayed % (sched.weeklyGames / 2) == 0 ||
                    (gamesPlayed >= sched.numTeams * sched.maxGamesPerWeekPerTeam / 2)
                    || tryNum == sched.weeklyTrys)
                {
                    sched.addToPickOrder();
                    currentWeek++;
                    tryNum = 0;
                }
                else
                {
                    List<int> tempList = new List<int>();
                    tempList = sched.pickOrder;
                    sched = temp;
                    foreach (int team in tempList)
                        sched.pickOrder.Remove(team);
                    foreach (int team in sched.pickOrder)
                        tempList.Add(team);
                    sched.pickOrder = tempList;
                    foreach (int team in sched.pickOrder)
                        Console.Write(team + " ");
                    Console.WriteLine(" &&& Re-trying week");
                    tryNum++;
                }
            }

            Console.WriteLine("\ncleaning up schedule");
            // put complete opponents list in seasonOpponents for each team
            int leastPreferred = sched.maxGamesPerTeam;
            for (int i = 0; i < sched.numTeams; i++)
            {
                sched.moveOpp(i);
                if (sched.teams[i].numPreferredGames < leastPreferred)
                    leastPreferred = sched.teams[i].numPreferredGames;
            }

            Console.WriteLine("\nTotals Possible = " + sched.numTeams * sched.maxGamesPerTeam / 2 +
            "\nGames Scheduled= " + sched.masterGameVec.Count);
            Console.WriteLine("\nTeam with the least prefered has " + leastPreferred + " of " +
            sched.maxGamesPerTeam + " prefered.");

            ////////////////////////////////// Output results to .xls ////////////////////////////////


            Console.WriteLine("Hello World"); // breakpoint line and done confirmaiton
        }
    }
}
