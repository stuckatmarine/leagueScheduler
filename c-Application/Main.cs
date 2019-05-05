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
            try
            {
                if (File.Exists(curFile))
                    workbook = ExcelFile.Load(curFile);
                else
                {
                    Console.WriteLine("Excel file not found");
                    System.Environment.Exit(1);
                }
            }
            catch
            {
                Console.WriteLine("Error in opting excel file");
            }

            Scheduler sched = new Scheduler();
            Scheduler finalSched = new Scheduler();

            int weeksFilled = generateSched(ref sched, ref finalSched, 20, workbook);
            
            Console.WriteLine("Chosen schedule has least preferred = " + finalSched.leastPreferred);

            // Generate Excel output
            for (int idx = 1; idx < workbook.Worksheets.Count;)
                workbook.Worksheets.Remove(idx);

            workbook.Worksheets.Add("AllTeams");
            var worksheet = workbook.Worksheets["AllTeams"];
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
                    worksheet.Cells[j, i + 1].Value = finalSched.fields[getIndex(game.field)].name;
                    worksheet.Cells[j, i + 2].Value = game.time;
                    worksheet.Cells[j, i + 3].Value = finalSched.teams[game.team1].teamName;
                    worksheet.Cells[j, i + 4].Value = finalSched.teams[game.team2].teamName;
                    j++;
                }
                i += width;
            }
            for (int fieldNum = 0; fieldNum < finalSched.numFields; fieldNum++)
            {
                workbook.Worksheets.Add(finalSched.fields[fieldNum].name);
                worksheet = workbook.Worksheets[finalSched.fields[fieldNum].name];
                i = 0;
                j = 0;
                width = 5;
                int height = finalSched.fields[fieldNum].numGames + 3;

                for (int weekNum = 0; weekNum < weeksFilled; weekNum++)
                {
                    j = weekNum * height;
                    i = 0;
                    var week = finalSched.weeks[weekNum];
                    worksheet.Cells[j, i].Value = "Week #";
                    worksheet.Cells[j, i + 1].Value = (weekNum + 1).ToString();
                    int dayNum = 0;
                    foreach (Day day in week)
                    {
                        j = weekNum * height + 1;
                        worksheet.Cells[j, i].Value = "Day " + dayNum.ToString(); ;
                        worksheet.Cells[j, i + 1].Value = finalSched.fields[fieldNum].name;
                        j++;
                        if (day.fields.Count > 0)
                        {
                            foreach (Game game in day.fields[fieldNum].games)
                            {
                                if (game.team1 != -1)
                                {
                                    worksheet.Cells[j, i].Value = game.time;
                                    worksheet.Cells[j, i + 1].Value = finalSched.teams[game.team1].teamName;
                                    worksheet.Cells[j, i + 2].Value = "vs";
                                    worksheet.Cells[j, i + 3].Value = finalSched.teams[game.team1].teamName;
                                    j++;
                                }
                            }
                            dayNum++;
                        }
                        i += width;
                    }
                }
            }
            try
            {
                workbook.Save(curFile);
            }
            catch
            {
                Console.WriteLine("\nCannot save....Close file\n");
            }
        }

        private static int generateSched(ref Scheduler sched, ref Scheduler finalSched, int numTries, ExcelFile workbook)
        {
            int[] prefArr = new int[numTries];
            int currentWeek = 0;

            for (int i = 0; i < numTries; i++)
            {

                getInputsFromSheet(sched, workbook);
                sched.randomizePickOrder();

                // sched.populateTeams();

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
            return currentWeek;
        }

        static int getIndex(int i)
        {
            if (i == -1)
                return -1;
            else if (i == 1)
                return 0;

            int count = 0;
            while ((i & 0x2) == 0 | (count > 20))
            {
                i = (i >> 1);
                count++;
            }
            return count;
        }

        private static void getInputsFromSheet(Scheduler sched, ExcelFile workbook)
        {

            // Get general inputs from sheet
            var worksheet = workbook.Worksheets["Inputs"];
            sched.numWeeks = int.Parse(worksheet.Cells[2, 2].GetFormattedValue());
            sched.weeklyGames = int.Parse(worksheet.Cells[3, 2].GetFormattedValue());
            sched.maxGamesPerTeam = int.Parse(worksheet.Cells[4, 2].GetFormattedValue());
            sched.maxGamesPerWeekPerTeam = int.Parse(worksheet.Cells[5, 2].GetFormattedValue());
            if (worksheet.Cells[3, 6].GetFormattedValue() == "Yes")
                sched.doubleHeaders = true;
            else
                sched.doubleHeaders = false;

            // Get team inputs
            sched.numTeams = int.Parse(worksheet.Cells["C9"].GetFormattedValue());
            for (int teamNum = 0; teamNum < sched.numTeams; teamNum++)
            {
                int prefType = 0;
                int timePref = 0;
                int dayPref = 0;
                int fieldPref = 0xFF;

                switch (worksheet.Cells[10 + teamNum, 2].GetFormattedValue())
                {
                    case "Time":
                        prefType = PREFTYPE.TIME;
                        if (worksheet.Cells[10 + teamNum, 3].GetFormattedValue() == "Early")
                            timePref = TIMESLOT.EARLY;
                        else
                            timePref = TIMESLOT.LATE;
                        dayPref = 0xFF;
                        break;

                    case "Day":
                        prefType = PREFTYPE.DAY;
                        if (worksheet.Cells[10 + teamNum, 4].GetFormattedValue() == "Yes")
                            dayPref |= WEEKDAYS.MONDAY;
                        if (worksheet.Cells[10 + teamNum, 5].GetFormattedValue() == "Yes")
                            dayPref |= WEEKDAYS.TUESDAY;
                        if (worksheet.Cells[10 + teamNum, 6].GetFormattedValue() == "Yes")
                            dayPref |= WEEKDAYS.WEDNESDAY;
                        if (worksheet.Cells[10 + teamNum, 7].GetFormattedValue() == "Yes")
                            dayPref |= WEEKDAYS.THURSDAY;
                        if (worksheet.Cells[10 + teamNum, 8].GetFormattedValue() == "Yes")
                            dayPref |= WEEKDAYS.FRIDAY;
                        if (worksheet.Cells[10 + teamNum, 9].GetFormattedValue() == "Yes")
                            dayPref |= WEEKDAYS.SATURDAY;
                        if (worksheet.Cells[10 + teamNum, 10].GetFormattedValue() == "Yes")
                            dayPref |= WEEKDAYS.SUNDAY;
                        timePref = 0xFF;
                        break;

                    default:
                        prefType = 0xFF;
                        timePref = 0xFF;
                        dayPref = 0xFF;
                        break;
                }
                sched.teams.Add(new Scheduler.Team(teamNum,
                        worksheet.Cells[11 + teamNum, 1].GetFormattedValue(),
                        prefType, dayPref, timePref, fieldPref));
            }
        }

    }
}
