/**
 * Leauge Schedule Generator
 * - Generate a schedule based on a teams preference
 *   prefered field, time, or day to optimise compatability
 */
#include <iostream>
#include <string>
#include <vector>
#include <time.h>
#include <random>
#include <utility>
#include <assert.h>
using namespace std;



struct Game{
    int gameNumber;
    bool late = false;
    string time = "";
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
int numWeeks = 6;
int numFields = 2;
int weeklyGames = 8;
int maxGamesPerWeek = 2;
int maxGamesPerTeam = 16;
bool doubleHeaders = true;

vector<Game> masterGameVec;
vector<int> pickOrder;
vector<int> playedAllready;
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
            pickOrder.push_back(randInt);
    }
    cout << "pick order: ";
    for (auto i = 0; i < numTeams; i++)
        cout << pickOrder[i] << " ";
    cout << endl;
}

// creat team objects
void populateTeams() {
    teams.push_back(Team(0, "Yankes", "Day", 2, -1, ""));
    teams.push_back(Team(1, "Sox", "Day", 1, -1, ""));
    teams.push_back(Team(2, "Cubs", "Day", 1, -1, ""));
    teams.push_back(Team(3, "Jays", "Day", 2, -1, ""));
    teams.push_back(Team(4, "Angels", "Day", 2, -1, ""));
    teams.push_back(Team(5, "Nationals", "Day", 1, -1, ""));
    teams.push_back(Team(6, "Astros", "Day", 1, -1, ""));
    teams.push_back(Team(7, "Cardinals", "Day", 2, -1, ""));
    assert(numTeams == teams.size());
}

// create each field's games and time availability
void populateFields() {
    fields.push_back(Field(4, "Fenway", 3));
    fields[0].games.push_back(Game("6pm"));
    fields[0].games.push_back(Game("7:15pm"));
    fields[0].games.push_back(Game("8:30pm", true));
    fields[0].games.push_back(Game("9:45pm", true));
    fields.push_back(Field(4, "Wrigley", 3));
    fields[1].games.push_back(Game("6pm"));
    fields[1].games.push_back(Game("7:15pm"));
    fields[1].games.push_back(Game("8:30pm", true));
    fields[1].games.push_back(Game("9:45pm", true));

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
                tempDay.fields.push_back(fields[i]);
                gameCount += fields[i].numGames; //test
            }
        }
        days.push_back(tempDay);
        dayFlag = dayFlag << 1;
    }
}

// find opponent with preference, if none returns last free, if non returns -1
int findOpponent(int weekNum, int pNum, int day, int time, string field, int numTry = 0){
    cout << "Find Opp: week, pickTeam, day, time, field : " << weekNum << pNum << day << time << field << endl;

    int lastOpp = -1;
    for(auto k = numTeams-1; k >= 0; k--){
        if(pickOrder[k] != pNum && (teams[pickOrder[k]].lastWeekPlayed - numTry) < weekNum &&
                find(teams[pNum].opponents.begin(), teams[pNum].opponents.end(),
                pickOrder[k]) == teams[pNum].opponents.end() &&
                teams[pickOrder[k]].numGamesPlayed < maxGamesPerTeam){
            assert(pickOrder[k] != pNum);
            if(lastOpp < 0)
                lastOpp = pickOrder[k];
            if(teams[pickOrder[k]].prefDay & day || teams[pickOrder[k]].prefTime == time ||
               teams[pickOrder[k]].prefField == field){
                return pickOrder[k];
            }
        }
    }
    if(lastOpp < 0 && (numTry + 1 < maxGamesPerWeek)) {
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
        teams[pNum].opponentsAllSeason.push_back(temp);
    }
}

// add both teams to a game, add them as played, update last week played
void fillInGames(int weekNum, int day, int fNum, int gNum, int oppNum, int pNum){
    cout << "Game: week, day, field, game, t1, t2 : " << weekNum << day << fNum << gNum << pNum << oppNum << endl;
    assert(pNum >= 0 );
    // updated team1
    weeks[weekNum][day].fields[fNum].games[gNum].team1 = pNum;
    teams[pNum].opponents.push_back(teams[oppNum].teamNumber);
    teams[pNum].lastWeekPlayed = weekNum;
    teams[pNum].numGamesPlayed ++;

    // check if game is a prefered game for this team
    if(teams[pNum].prefDay & day || teams[pNum].prefTime ==
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
    teams[oppNum].opponents.push_back(teams[pNum].teamNumber);
    teams[oppNum].lastWeekPlayed = weekNum;
    teams[oppNum].numGamesPlayed ++;

    // check if game is a prefered game for this team
    if(teams[oppNum].prefDay & day || teams[oppNum].prefTime ==
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
    teams[pNum].gamesAllSeaason.push_back(weeks[weekNum][day].fields[fNum].games[gNum]);
    teams[oppNum].gamesAllSeaason.push_back(weeks[weekNum][day].fields[fNum].games[gNum]);

    // add to master game vector
    masterGameVec.push_back(weeks[weekNum][day].fields[fNum].games[gNum]);
}

// attempt to find a game for a team with a preferred day
int preferredDay(int currentWeek, int pNum){
    // convert prefDay to from bitwise to int
    int day = 1;
    int prefDayVal = teams[pNum].prefDay;
    while(prefDayVal & 0x01 == 0){
        prefDayVal >> 1;
        day ++;
    }

    int oppIndex = -1;
    // check each field on that day
    for(auto i = 0; i < days[day].fields.size(); i++){
        // check each game time
        for(auto j = 0; j < days[day].fields[i].numGames; j++){
            // if theres a free field
            if(weeks[currentWeek][day].fields[i].games[j].team1 == -1){
                // find opponent, prioritising simaler preferences
                oppIndex = findOpponent(currentWeek, pNum, day,
                        days[day].fields[i].games[j].late, days[day].fields[i].name);
                cout << "oppIndex == " << oppIndex << endl;
                assert(oppIndex != pNum);
                assert(find(teams[pNum].opponents.begin(),
                            teams[pNum].opponents.end(),
                            oppIndex) == teams[pNum].opponents.end());
                if(oppIndex > 0) {
                    // fill in games vs opponent
                    fillInGames(currentWeek, day, i, j, oppIndex, pNum);
                    if (doubleHeaders) {
                        fillInGames(currentWeek, day, i, j + 1, pNum, oppIndex);
                    }
                    return oppIndex;
                }
            }
        }
        if(oppIndex > 0)
            return oppIndex;
    }
    return oppIndex;
}

int populateWeek(int currentWeek, int numTry = 0){
    cout << "\n--- Week " << currentWeek << " ---" << endl;
    assert(currentWeek < numWeeks);
    int gamesPlanned = 0;
    int pickIndex = 0;
    while(gamesPlanned < weeklyGames) {
        assert(pickIndex < numTeams);
        cout << "Team " << pickOrder[pickIndex] << ", prefers " << teams[pickOrder[pickIndex]].prefType << endl;
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
            gamesPlanned++;
            if (doubleHeaders) {
                gamesPlanned++;
            }
        }

        if(pickIndex < numTeams -1)
            pickIndex++;
        else
            break;
    }

    return -1;
}

// --- main ---
int main(){
    cout << "\n######################################\n\n";
    srand(time(NULL));

    randomizePickOrder();

    populateTeams();
    populateFields();
    populateDays();

    // test outs
    assert(days.size() == 7);
    assert(pickOrder.size() == numTeams);

    // fill vector of weeks creating a blank schedule
    while(weeks.size() < numWeeks){
        weeks.push_back(days);
    }

    // update games each week based on pick order and preference
    int currentWeek = 0;
    while(currentWeek < numWeeks){
        populateWeek(currentWeek);
        currentWeek ++;
    }

    cout << "\ncleaning up schedule" << endl;
    // put complete opponents list in seasonOpponents for each team
    for(auto i = 0; i < numTeams; i++) {
        moveOpp(i);
    }
    printf("\nTotals:\nGames = %lu",masterGameVec.size());

    std::cout << "\nhello world\n";

    return 0;
}
