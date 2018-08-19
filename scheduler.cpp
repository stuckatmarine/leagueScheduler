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
using namespace std;

int numTeams = 4;
int numWeeks = 4;
int numFields = 2;
int weeklyGames = 4;
bool doubleHeaders = true;

struct Game{
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
    vector<int> opponents;
    
    Team(int number, string name, string pref, int day, int time, string field)
            :teamNumber(number),teamName(name),prefType(pref),prefDay(day),
            prefTime(time),prefField(field) {}
};

struct Day{
    vector<Field> fields;
};

// --- globals ---
vector<int> pickOrder;
vector<Team> teams;
vector<Field> fields;
vector<Day> days;
vector<vector<Day>> weeks;

// find opponent with preference, if none returnes last free, if non returns -1
int findOpponent(int weekNum, int pNum, int day, int time, string field){
    cout << "Find Opp: week, pickTeam, day, time, field : " << weekNum << pNum << day << time << field << endl;
    int lastOpp = -1;
    for(auto k = numTeams-1; k >= 0; k--){
        if(teams[pickOrder[k]].lastWeekPlayed < weekNum &&
                find(teams[pNum].opponents.begin(),
                teams[pNum].opponents.end(),
                teams[pickOrder[k]].teamNumber) ==
                teams[pNum].opponents.end()){
            if(lastOpp < 0)
                lastOpp = k;
            if(teams[pickOrder[k]].prefDay & day || teams[pickOrder[k]].prefTime == time ||
                    teams[pickOrder[k]].prefField == field){
            return k;
            }
        }
    }
    return lastOpp;
}

// add both teams to a game, add them as played, update last week played
void fillInGames(int weekNum, int day, int fNum, int gNum, int oppNum, int pNum){
    cout << "Game: week, day, field, game, t1, t2 : " << weekNum << day << fNum << gNum << pNum << oppNum << endl;
    weeks[weekNum][day].fields[fNum].games[gNum].team1 = pNum;
    weeks[weekNum][day].fields[fNum].games[gNum].team2 = teams[oppNum].teamNumber;
    teams[pNum].opponents.push_back(teams[oppNum].teamNumber);
    teams[oppNum].opponents.push_back(teams[pNum].teamNumber);
    teams[pNum].lastWeekPlayed = weekNum;
    teams[oppNum].lastWeekPlayed = weekNum;
}

// --- main ---
int main(){
    cout << "\n######################################\n\n";
    srand(time(NULL));
    
    // generate random pick order
    while(pickOrder.size() < numTeams){
        int randInt = rand() % numTeams;
        bool found = false;
        for(auto i = pickOrder.begin(); i != pickOrder.end(); i++){
            if(*i == randInt){
                found = true;
                break;
            }
        }
        if(!found)
            pickOrder.push_back(randInt);
    }
    cout << "pick order: ";
    for(auto i = 0; i < numTeams; i++)
        cout << pickOrder[i] << " ";
    cout << endl;

    // creat team objects
    teams.push_back(Team(0,"Yankes", "Day", 0, 0, "Bannerman"));
    teams.push_back(Team(1,"Sox","Day", 1, 0, "Bannerman"));
    teams.push_back(Team(2,"Cubs","Day", 1, 0, "Bannerman"));
    teams.push_back(Team(3,"Jays","Day", 0, 1, "Bannerman"));
    
    // create each field's games and time availability
    fields.push_back(Field(4,"Vic Park", 3));
    fields[0].games.push_back(Game("6pm"));
    fields[0].games.push_back(Game("7:15pm"));
    fields[0].games.push_back(Game("8:30pm", true));
    fields[0].games.push_back(Game("9:45pm", true));
    fields.push_back(Field(4,"Bannerman", 3));
    fields[1].games.push_back(Game("6pm"));
    fields[1].games.push_back(Game("7:15pm"));
    fields[1].games.push_back(Game("8:30pm", true));
    fields[1].games.push_back(Game("9:45pm", true));
    
    // create blank weekly field schedule
    int dayFlag = 1;
    int gameCount = 0; // test
    for(auto dayNum = 0; dayNum < 7; dayNum ++){
        Day tempDay;
        for(auto i = 0; i < fields.size(); i++){
            if(fields[i].daysAvail & dayFlag){
                tempDay.fields.push_back(fields[i]);
                gameCount += fields[i].numGames; //test
            }
        }
        days.push_back(tempDay);
        dayFlag = dayFlag << 1;
    }
    
    // test outs
    cout << "num days " << days.size() << endl;
    cout << "weekly game count " << gameCount << endl;
    
    // fill vector of weeks
    while(weeks.size() < numWeeks){
        weeks.push_back(days);
    }
    
    // update games each week based on pick order and preference
    int currentWeek = 0;
    while(currentWeek < numWeeks){
        cout << "--- Week " << currentWeek << " ---" << endl;
        int gamesPlanned = 0;
        int pickIndex = 0;
        while(gamesPlanned < weeklyGames){
            cout << "Team " << pickOrder[pickIndex] << ", prefers " << teams[pickOrder[pickIndex]].prefType << endl;
            bool gameFound = false;
            // check if the picking team has played yet this week
            if(teams[pickOrder[pickIndex]].lastWeekPlayed < currentWeek){
                // try and find their preference
                if(teams[pickOrder[pickIndex]].prefType == "Day"){
                    int day = teams[pickOrder[pickIndex]].prefDay;
                    // check feach field on that day
                    for(auto i = 0; i < days[day].fields.size(); i++){
                        // check each game time
                        for(auto j = 0; j < days[day].fields[i].numGames; j++){
                            // if theres a free field
                            if(weeks[currentWeek][day].fields[i].games[j].team1 == -1){
                                // find opponent, prioritising simaler preferences
                                int oppIndex = findOpponent(currentWeek,
                                        pickOrder[pickIndex],
                                        day,days[day].fields[i].games[j].late,
                                        days[day].fields[i].name);
                                cout << "oppIndex == " << oppIndex << endl;
                                // fill in games vs opponent
                                fillInGames(currentWeek, day, i, j, oppIndex,
                                        pickOrder[pickIndex]);
                                gamesPlanned ++;
                                if(doubleHeaders){
                                    fillInGames(currentWeek, day, i, j,
                                            pickOrder[pickIndex], oppIndex);
                                    gamesPlanned ++;
                                }
                                gameFound = true;
                                break;
                            }
                        }
                        if(gameFound)
                            break;
                    }
                } else if(teams[pickOrder[pickIndex]].prefType == "Time"){
                    cout << "in time case" << endl;
                    gamesPlanned ++;
                    gamesPlanned ++;
                } else if(teams[pickOrder[pickIndex]].prefType == "Field"){
                    cout << "in field case" << endl;
                    gamesPlanned ++;
                    gamesPlanned ++;
                }
            }
            if(gameFound){
                int temp = pickOrder[0];
                pickOrder.erase(pickOrder.begin());
                pickOrder.push_back(temp);
            } else
                pickIndex++;
        }
        
        currentWeek ++;
    }
    
    
    std::cout << "hello world" << std::endl;
    
    return 0;
}
