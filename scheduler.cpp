/**
 * Leauge Schedule Generator
 * - Generate a schedule based on a teams preference
 *   prefered field, time, or day to optimise compatability
 */

#include <iostream>
#include <string>
#include <map>
#include <vector>
#include <time.h>
#include <random>
using namespace std;

int numTeams = 4;
int numWeeks = 2;
int numFields = 2;
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
    string teamName;
    string prefType;
    int prefDay;
    string prefField;
    int prefTime;
    int lastWeekPlayed = -1;
    map<int> opponents;
    
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

// find opponent with preference, if none retunes last free, if non returns -1
int findOpponent(int weekNum, int pNum, int day, int time, string field){
    int lastOpp = -1;
    for(auto k = numTeams-1; k >= 0; k--){
        
        if(teams[pickOrder[k]].lastWeekPlayed < weekNum &&
                find(teams[pNum].opponents.begin(),
                teams[pNum].opponents.end(),
                teams[pickOrder[k]].teamNumber) !=
                teams[pNum].opponents.end()){
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
    weeks[weekNum][day].fields[fNum].games[gNum].team1 == pNum;
    weeks[weekNum][day].fields[fNum].games[gNum].team2 == teams[oppNum].teamNumber;
    teams[pNum].opponents.push_back(teams[oppNum].teamNumber);
    teams[oppNum].opponents.push_back(teams[pNum].teamNumber);
    teams[pNum].lastWeekPlayed = weekNum;
    teams[oppNum].lastWeekPlayed = weekNum;
}

// --- main ---
int main(){
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
    teams.push_back(Team(0,"Yankes", "Day", 0, 0, Bannerman));
    teams.push_back(Team(1,"Sox","Day", 1, 0, Bannerman));
    teams.push_back(Team(2,"Cubs","Time", 0, 0, Bannerman));
    teams.push_back(Team(3,"Jays","Time", 0, 1, Bannerman));
    
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
    int gamesPlanned = 0;
    int pickIndex = 0;
    Team tempTeam;
    while(currentWeek < numWeeks){
        cout << "--- Week " << currentWeek << " ---" << endl;
        
        while(gamesPlanned < gameCount){
            cout << "Team " << pickOrder[0] << ", prefers " << teams[pickOrder[0]].prefType << endl;
            // check if the picking team has played yet this week
            if(teams[pickOrder[pickIndex]].lastWeekPlayed < currentWeek){
                switch(teams[pickOrder[pickIndex]].prefType){
                    case("Day"):
                    int day = teams[pickOrder[pickIndex]].prefDay;
                    // check feach field on that day
                    for(auto i = 0; i < days[day].size(); i++){
                        // check each game time
                        for(auto j = 0; j < days[day].fields[i].numGames; j++){
                            // if theres a free field
                            if(weeks[currentWeek][day].fields[i].games[j].team1 == -1){
                                // find opponent
                                int oppIndex = findOpponent(currentWeek, pickOrder[pickIndex], day,
                                        days[day].fields[i].games[j].late, days[day].fields[i].name);
                                // fill in games
                                fillInGames(currentWeek, day, i, j, k);
                                gamesPlanned ++;
                                if(doubleHeaders){
                                    fillInGames(currentWeek, day, i, j, k);
                                    gamesPlanned ++;
                                }
                                
                            }
                        }
                    }
                    
                    break;
                    
                }
            }
            pickOrder ++
        }
        currentWeek ++;
    }
    
    
    std::cout << "hello world" << std::endl;
    
    return 0;
}
