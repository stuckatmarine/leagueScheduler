using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using GemBox.Spreadsheet;
using System.IO;


namespace Schedulerv1
{
    class _Main : Scheduler
    {
        // --- main ---
        static void Main(string[] args)
        {
            // Open inputs spreadsheet, exit if dne
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            string curFile = "SchedulerFile.xlsx";
            ExcelFile workbook = new ExcelFile();
            if (File.Exists(curFile))
                workbook = ExcelFile.Load(curFile);
            else
            {
                Console.WriteLine("Excel file not found");
                System.Environment.Exit(1);
            }

            /*
            worksheet.Cells[0, 0].Value = "English:";
            worksheet.Cells[0, 1].Value = "Hello";

            worksheet.Cells[1, 0].Value = "Russian:";
            // Using UNICODE string.
            worksheet.Cells[1, 1].Value = new string(new char[] { '\u0417', '\u0434', '\u0440', '\u0430', '\u0432', '\u0441', '\u0442', '\u0432', '\u0443', '\u0439', '\u0442', '\u0435' });

            worksheet.Cells[2, 0].Value = "Chinese:";
            // Using UNICODE string.
            worksheet.Cells[2, 1].Value = new string(new char[] { '\u4f60', '\u597d' });

            worksheet.Cells[4, 0].Value = "In order to see Russian and Chinese characters you need to have appropriate fonts on your PC.";
            worksheet.Cells.GetSubrangeAbsolute(4, 0, 4, 7).Merged = true;

            */


            Scheduler sched = new Scheduler();
            Scheduler finalSched = new Scheduler();

            //league.LaunchForm launchForm = new league.LaunchForm();

            generateSched(ref sched, ref finalSched, 20);
            
            Console.WriteLine("Chosen schedule has least preferred = " + finalSched.leastPreferred);

            var worksheet = workbook.Worksheets[0];
            int i = 0;
            int j = 0;
            int width = 6;
            foreach (Scheduler.Team team in finalSched.teams){
                j = 0;
                worksheet.Cells[0, i].Value = "Week #";
                worksheet.Cells[0, i + 1].Value = team.teamName;
                j++;
                foreach (Scheduler.Game game in team.gamesAllSeaason)
                {
                    worksheet.Cells[j, i].Value = (j).ToString();
                    worksheet.Cells[j, i + 1].Value = finalSched.fields[game.field].name;
                    worksheet.Cells[j, i + 2].Value = finalSched.fields[game.field].games[game.timeslot].time;
                    worksheet.Cells[j, i + 3].Value = finalSched.teams[game.team1].teamName;
                    worksheet.Cells[j, i + 4].Value = finalSched.teams[game.team2].teamName;
                    j++;
                }
                i += width;

            }

            workbook.Save(curFile);

            //while (true) Thread.Sleep(1000);
        }

        static void generateSched(ref Scheduler sched, ref Scheduler finalSched, int numTries)
        {
            int[] prefArr = new int[numTries];

            ///////////////////////// Get values from gui /////////////////////////////////////////
            // launch gui window
            // Application.Run(new league.LaunchForm());

            ///////////////////////// Start generating Sched //////////////////////////////////////
            for (int i = 0; i < numTries; i++)
            {
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
                    // copy the schedule before filling week
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

                sched.calcLeastPreferred();
                prefArr[i] = sched.leastPreferred;
                if (sched.leastPreferred > finalSched.leastPreferred)
                {
                    finalSched = ObjectExtensions.Copy(sched);
                }

                if (finalSched.leastPreferred == sched.maxGamesPerTeam)
                    break;
                else
                    sched = new Scheduler();
            }
        }
    }
}
