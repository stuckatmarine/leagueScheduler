/**
 * Leauge Schedule Generator
 * - Generate a schedule based on a teams preference
 *   prefered field, time, or day to optimise compatability
 */
#include <iostream>     // couts
#include <string>       // strings
#include <vector>       // vectors
#include <time.h>       // random seed
#include <random>       // rand
#include <utility>      // if pair used///
#include <assert.h>     // assertions
#include <algorithm>    // if move used///
#include <fstream>      // write to .csv
using namespace std;



struct Game{
    int gameNumber;
    bool late = false;
    string time = "";
    string field = "";
    int team1 = -1;
    int team2 = -1;

    Game(string ti, bool lateGame = false) : time(ti), late(lateGame) {}
};

/**
 * numTimes = number of games each day
 * name = field name
 * daysAvail = bitwise notation for Monday to Sunday
 */
struct Field{
    int numGames = -1;
    int daysAvail = -1;
    string name;
    vector<Game> games;

    Field(int numTimes, string field, int days)
            :numGames(numTimes), name(field), daysAvail(days) {}
};

struct Team{
    int teamNumber;
    int numGamesPlayed = 0;
    string teamName;
    string prefType;
    int prefDay;
    string prefField;
    int prefTime;
    int lastWeekPlayed = -1;
    int numPreferredGames = 0;
    vector<int> opponents;
    vector<int> opponentsAllSeason;
    vector<Game> gamesAllSeaason;

    Team(int number, string name, string pref, int day, int time, string field)
            :teamNumber(number),teamName(name),prefType(pref),prefDay(day),
             prefTime(time),prefField(field) {}
};

struct Day{
    vector<Field> fields;
};

// --- globals ---
int numTeams = 8;
int numWeeks = 10;
int numFields = 2;
int weeklyGames = 8;
int maxGamesPerFieldPerDay = 4;
int maxGamesPerWeek = 2;
int maxGamesPerTeam = 16;
int prefsFound; // 1 = pickers Pref, 2 = both prefs
bool doubleHeaders = true;

vector<Game> masterGameVec;
vector<int> pickOrder;
vector<int> playedAllready;
vector<int> gotPreferred;
vector<Team> teams;
vector<Field> fields;
vector<Day> days;
vector<vector<Day>> weeks;

// randomize pick order vector
void randomizePickOrder() {
    while(!pickOrder.empty())
        pickOrder.pop_back();

    while (pickOrder.size() < numTeams) {
        int randInt = rand() % numTeams;
        bool found = false;
        for (auto i = pickOrder.begin(); i != pickOrder.end(); i++) {
            if (*i == randInt) {
                found = true;
                break;
            }
        }
        if (!found)
            pickOrder.emplace_back(randInt);
    }
    cout << "pick order: ";
    for (auto i = 0; i < numTeams; i++)
        cout << pickOrder[i] << " ";
    cout << endl;
}

// creat team objects
void populateTeams() {
    teams.emplace_back(Team(0, "Yankes", "Day", 2, -1, ""));
    teams.emplace_back(Team(1, "Sox", "Day", 1, -1, ""));
    teams.emplace_back(Team(2, "Cubs", "Day", 1, -1, ""));
    teams.emplace_back(Team(3, "Jays", "Day", 2, -1, ""));
    teams.emplace_back(Team(4, "Angels", "Day", 2, -1, ""));
    teams.emplace_back(Team(5, "Nationals", "Day", 1, -1, ""));
    teams.emplace_back(Team(6, "Astros", "Day", 1, -1, ""));
    teams.emplace_back(Team(7, "Cardinals", "Day", 2, -1, ""));
    assert(numTeams == teams.size());
}

// create each field's games and time availability
void populateFields() {
    fields.emplace_back(4, "Fenway", 3);
    fields[0].games.emplace_back("6pm");
    fields[0].games.emplace_back("7:15pm");
    fields[0].games.emplace_back("8:30pm", true);
    fields[0].games.emplace_back("9:45pm", true);
    fields.emplace_back(4, "Wrigley", 3);
    fields[1].games.emplace_back("6pm");
    fields[1].games.emplace_back("7:15pm");
    fields[1].games.emplace_back("8:30pm", true);
    fields[1].games.emplace_back(Game("9:45pm", true));

    assert(numFields == fields.size());
}

// create blank weekly field schedule
void populateDays() {
    int dayFlag = 1;
    int gameCount = 0; // test
    for (auto dayNum = 0; dayNum < 7; dayNum++) {
        Day tempDay;
        for (auto i = 0; i < fields.size(); i++) {
            if (fields[i].daysAvail & dayFlag) {
                tempDay.fields.emplace_back(fields[i]);
                gameCount += fields[i].numGames; //test
            }
        }
        days.emplace_back(tempDay);
        dayFlag = dayFlag << 1;
    }
}

// check day vs bitwise day value
bool checkDay(int day, int dayBit){
    int count = 0;
    while(count < 7){
        if(dayBit & 0x01 && count == day){
            return true;
        }
        count ++;
        dayBit = dayBit >> 1;
    }
    return false;
}

// find opponent with preference, if none returns last free, if non returns -1
int findOpponent(int weekNum, int pNum, int day, int time, string field, int numTry = 0){
    cout << "Find Opp: week, day, time, field, pickTeam, : " << weekNum <<
            day << time << field << pNum<< endl;

    int lastOpp = -1;
    for(auto k = numTeams-1; k >= 0; k--){
        if(pickOrder[k] != pNum && (teams[pickOrder[k]].lastWeekPlayed - numTry) < weekNum &&
                find(teams[pNum].opponents.begin(), teams[pNum].opponents.end(),
                pickOrder[k]) == teams[pNum].opponents.end() &&
                teams[pickOrder[k]].numGamesPlayed < maxGamesPerTeam){
            assert(pickOrder[k] != pNum);
            if(lastOpp < 0)
                lastOpp = pickOrder[k];
            if(teams[pickOrder[k]].prefDay & teams[pNum].prefDay || teams[pickOrder[k]].prefTime == time ||
               teams[pickOrder[k]].prefField == field){
                prefsFound = 2;
                return pickOrder[k];
            }
            prefsFound = 1;
        }
    }
    if(lastOpp < 0 && (numTry + (doubleHeaders?2:1) < maxGamesPerWeek)) {
        cout << "#### no opponents who haven't allready played this week" << endl;
        lastOpp = findOpponent(weekNum, pNum, day, time, field, numTry + 1);
    }

    return lastOpp;
}

// move opponents vector ocntents to seasonOpp
void moveOpp(int pNum) {
    cout << "Team " << pNum << ", shifting opp to season opp" << endl;
    while (!teams[pNum].opponents.empty()) {
        int temp = teams[pNum].opponents.back();
        teams[pNum].opponents.pop_back();
        teams[pNum].opponentsAllSeason.emplace_back(temp);
    }
}

// move index who got their pref to back of order
void movePickPref(int teamNum){
    assert(find(pickOrder.begin(), pickOrder.end(), teamNum) != pickOrder.end());
    gotPreferred.emplace_back(teamNum);
    pickOrder.erase(find(pickOrder.begin(), pickOrder.end(), teamNum));
}

// move index who got their pref to back of order
void movePickPlayed(int teamNum){
    assert(find(pickOrder.begin(), pickOrder.end(), teamNum) != pickOrder.end());
    playedAllready.emplace_back(teamNum);
    pickOrder.erase(find(pickOrder.begin(), pickOrder.end(), teamNum));
}

// move all teams to pick order for next week
void addToPickOrder(){
    assert(pickOrder.size() + playedAllready.size() + gotPreferred.size() == numTeams);
    while(!playedAllready.empty()) {
        pickOrder.emplace_back(playedAllready.back());
        playedAllready.pop_back();
    }
    while(!gotPreferred.empty()){
        pickOrder.emplace_back(gotPreferred.back());
        gotPreferred.pop_back();
    }
}

// move x number cells into ofstream
void indent(ofstream& out, int x){
    while(x > 0){
        out << ",";
        x--;
    }
}

// add both teams to a game, add them as played, update last week played
void fillInGames(int weekNum, int day, int fNum, int gNum, int oppNum, int pNum){
    cout << "Game: week, day, field, game, t1, t2 : " << weekNum << day << fNum << gNum << pNum << oppNum << endl;
    assert(pNum >= 0 );
    // updated team1
    weeks[weekNum][day].fields[fNum].games[gNum].team1 = pNum;
    teams[pNum].opponents.emplace_back(teams[oppNum].teamNumber);
    teams[pNum].lastWeekPlayed = weekNum;
    teams[pNum].numGamesPlayed ++;

    // check if game is a prefered game for this team
    if(checkDay(day, teams[pNum].prefDay) || teams[pNum].prefTime ==
            weeks[weekNum][day].fields[fNum].games[gNum].late ||
            teams[pNum].prefField == weeks[weekNum][day].fields[fNum].name) {
        teams[pNum].numPreferredGames++;
    }

    // move opponents played vec to season vec if all opponents played
    if(teams[pNum].numGamesPlayed % ((numTeams-1) * (doubleHeaders?2:1)) == 0) {
        moveOpp(pNum);
    }

    // update team1
    weeks[weekNum][day].fields[fNum].games[gNum].team2 = teams[oppNum].teamNumber;
    teams[oppNum].opponents.emplace_back(teams[pNum].teamNumber);
    teams[oppNum].lastWeekPlayed = weekNum;
    teams[oppNum].numGamesPlayed ++;

    // check if game is a prefered game for this team
    if(checkDay(day, teams[oppNum].prefDay) || teams[oppNum].prefTime ==
            weeks[weekNum][day].fields[fNum].games[gNum].late ||
            teams[oppNum].prefField == weeks[weekNum][day].fields[fNum].name) {
        teams[oppNum].numPreferredGames++;
    }

    // move opponents played vec to season vec if all opponents played
    if(teams[oppNum].numGamesPlayed % ((numTeams-1) * (doubleHeaders?2:1)) == 0) {
        moveOpp(oppNum);
    }

    // add to individual team's game vector
    weeks[weekNum][day].fields[fNum].games[gNum].gameNumber = masterGameVec.size();
    weeks[weekNum][day].fields[fNum].games[gNum].field = weeks[weekNum][day].fields[fNum].name;
    teams[pNum].gamesAllSeaason.emplace_back(weeks[weekNum][day].fields[fNum].games[gNum]);
    teams[oppNum].gamesAllSeaason.emplace_back(weeks[weekNum][day].fields[fNum].games[gNum]);

    // add to master game vector
    masterGameVec.emplace_back(weeks[weekNum][day].fields[fNum].games[gNum]);
}

// attempt to find a game for a team with a preferred day
int preferredDay(int currentWeek, int pNum){
    // check each prefday
    int day = 0;
    int prefDayVal = teams[pNum].prefDay;
    int oppFound = -1;
    while(day < 7) {
        if(prefDayVal & 0x01) {
            // check each field on that day
            for (auto i = 0; i < days[day].fields.size(); i++) {
                // check each game time
                for (auto j = 0; j < days[day].fields[i].numGames; j++) {
                    // if theres a free field
                    if (weeks[currentWeek][day].fields[i].games[j].team1 == -1) {
                        // find opponent, prioritising simaler preferences
                        oppFound = findOpponent(currentWeek, pNum, day,
                                days[day].fields[i].games[j].late, days[day].fields[i].name);
                        cout << "oppTeam == " << oppFound << endl;
                        assert(oppFound != pNum);
                        assert(find(teams[pNum].opponents.begin(),
                                    teams[pNum].opponents.end(),
                                    oppFound) == teams[pNum].opponents.end());
                        if (oppFound >= 0) {
                            // fill in games vs opponent
                            fillInGames(currentWeek, day, i, j, oppFound, pNum);
                            if (doubleHeaders) {
                                fillInGames(currentWeek, day, i, j + 1, pNum, oppFound);
                            }
                            return oppFound;
                        }
                    }
                }
                if (oppFound > 0)
                    return oppFound;
            }
        }
        prefDayVal = prefDayVal >> 1;
        day++;
    }
    return oppFound;
}

// attempt to fill in all games for the week up to the weeklyGames limit
int populateWeek(int currentWeek, int numTry = 0){
    cout << "\n--- Week " << currentWeek << " ---" << endl;
    assert(currentWeek < numWeeks);
    int gamesPlanned = 0;
    int pickIndex = 0;

    while(gamesPlanned < weeklyGames && !pickOrder.empty()) {
        prefsFound = 0;
        assert(pickIndex < numTeams);
        cout << "Team " << pickOrder[pickIndex] << ", prefers " << teams[pickOrder[pickIndex]].prefType <<
                "\nopponents thus far: " << endl;
        for(auto i = 0; i < teams[pickOrder[pickIndex]].opponents.size(); i++)
            cout << teams[pickOrder[pickIndex]].opponents[i] << " ";
        cout << endl;
        int oppFound = -1;
        // check if the picking team has played yet this week
        if (teams[pickOrder[pickIndex]].lastWeekPlayed - numTry < currentWeek) {
            // try and find their preference
            if (teams[pickOrder[pickIndex]].prefType == "Day") {
                cout << "Pref Day = " << teams[pickOrder[pickIndex]].prefDay << endl;
                oppFound = preferredDay(currentWeek, pickOrder[pickIndex]);
            } else if (teams[pickOrder[pickIndex]].prefType == "Time") {
                cout << "in time case" << endl;
                assert(1 == 2); // should never get here
            } else if (teams[pickOrder[pickIndex]].prefType == "Field") {
                cout << "in field case" << endl;
                assert(1 == 2); // should never get here
            }
        }
        else
            cout << "    allready played this week" << endl;

        if(oppFound) {
            // inc weekly games count
            gamesPlanned++;
            if (doubleHeaders) {
                gamesPlanned++;
            }

            // move both teams to pref vector
            if(prefsFound == 2) {
                movePickPref(oppFound);
                movePickPref(pickOrder[pickIndex]);
            }
            // move only picking team to pref vector
            else if(prefsFound == 1){
                movePickPlayed(oppFound);
                movePickPref(pickOrder[pickIndex]);
            }

        }
        else if(pickIndex < pickOrder.size())
            pickIndex++;
        else
            break;
    }

    return -1;
}

// --- main ---
int main(){
    cout << "\n######################################\n\n";
    srand(time(nullptr));

    randomizePickOrder();

    populateTeams();
    populateFields();
    populateDays();

    // test outs
    assert(days.size() == 7);
    assert(pickOrder.size() == numTeams);

    // fill vector of weeks creating a blank schedule
    while(weeks.size() < numWeeks){
        weeks.emplace_back(days);
    }

    // update games each week based on pick order and preference
    int currentWeek = 0;
    while(currentWeek < numWeeks){
        populateWeek(currentWeek);
        addToPickOrder();
        currentWeek ++;
    }

    cout << "\ncleaning up schedule" << endl;
    // put complete opponents list in seasonOpponents for each team
    int leastPreferred = maxGamesPerTeam;
    for(auto i = 0; i < numTeams; i++) {
        moveOpp(i);
        if(teams[i].numPreferredGames < leastPreferred)
            leastPreferred = teams[i].numPreferredGames;
    }
    printf("\nTotals:\nGames = %lu",masterGameVec.size());
    cout << "\nTeam with the least prefered has " << leastPreferred << " of " <<
            maxGamesPerTeam << " prefered." << endl;


    cout << "\n ---- Saving schedule to .csv ---- " << endl;
    ofstream out ("schedule.csv");
    if(!out.is_open())
        cout << "err opening output file" << endl;

 /*   // print each week
    for(auto i = 0; i < numWeeks; i++){
        out << "Week " << i+1 << ",";

        // print each day
        for(auto j = 0; j < days.size(); j++){
            out << "Day " << j+1 << ",";

            // print each field
            for(auto k = 0; k < days[j].fields.size(); k++){
                out << weeks[i][j].fields[k].name << ",,,,";
            }
        }
        out << "\n";

        indent(out, 1);
        // for each day
        for(auto j = 0; j < days.size(); j++){

            // print each game time
            for(auto k = 0; k < days[j].fields.size(); k++){
                for(auto n = 0; n < maxGamesPerFieldPerDay; n ++) {
                    if(weeks[i][j].fields[k].games.begin() + n != weeks[i][j].fields[k].games.end())
                        out << weeks[i][j].fields[k].games[n].time << ",";

                }
            }

            out << "\n";
        }

        out << "\n\n";
    }
    out.close();
*/
    std::cout << "\nhello world\n";

    return 0;
}
