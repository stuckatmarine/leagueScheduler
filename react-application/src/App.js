import React from 'react';
import logo from './logo.svg';
import './App.css';
import Dashboard from './components/Dashboard';
import NavBar from './components/NavBar';

function shuffleArray(array) {
  for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]];
  }
}

const ePREF = {
  DAY: 0,
  TIME: 1,
  FIELD: 2,
  NONE: -1,
}

const eDAY = {
  MON : 0,
  TUES : 1,
  WED : 2,
  THUR : 3,
  FRI : 4,
  SAT : 5,
  SUN : 6,
  NONE : -1
}

var numTeams = 2;
var numWeeks = 10;
var maxGamesPerTeam = 4;
var numFields = 2;
var weeklyGames = 8;
var numPrefGames = 0;
var totalGames = maxGamesPerTeam * numTeams;

function Field() {
  this.name = "";
  this.days = [];
}

function Team() {
  this.name = "";
  this.prefType = [];
  this.prefTime = [];
  this.prefDay  = [];
  this.prefField = [];
  this.games = [];
  this.number = 0;
  this.weeksPlayed = [];
  this.numPrefGames = 0;
  this.opponents = [];
}

function Game() {
  this.number = -1;
  this.day = eDAY.NONE;
  this.timeSlot = -1;
  this.fieldName = "";
  this.time = "";
  this.homeTeam = -1;
  this.awayTeam = -1;
}

function Day() {
  this.name = eDAY.NONE;
  this.games = [];
}

function findInArr(arr, day){
  for (var i=0; i < arr.length; i++) {
    if (arr[i].name === day) {
        return true;;
    }
  }
  return false;
}

function findNextBestGame ( t , w ){
  if (t.prefType === ePREF.DAY){
    console.log("pref day: " + t.prefDay);
    for (let g = 0; g < w[t.prefDay].games.length; g++){
      console.log("checking game: " + w[t.prefDay].games[g]);
      if (w[t.prefDay].games[g].homeTeam === -1) {
        console.log("game found");
        w[t.prefDay].games[g].homeTeam = t.number;
        return w[t.prefDay].games[g];
      }
    }
  } else if (t.prefType === ePREF.TIME){
    console.log("pref time: " + t.prefTime);
    for (let d = 0; d < 7; d++){
      if (w[d].length <= 0)
        continue;
      for (let g = 0; g < w[d].games.length; g++){
        if (w[d].games[g].homeTeam === -1 && w[d].games[g].timeSlot === t.prefTime) {
          // w[d].games[g].homeTeam = t.number;
          return g;
        }
      }
    }
  } else if (t.prefType === ePREF.FIELD){
    console.log("pref field: " + t.prefField);
    for (let d = 0; d < 7; d++){
      if (w[d].length <= 0)
        continue;
      for (let g = 0; g < w[d].games.length; g++){
        if (w[d].games[g].homeTeam === -1 && w[d].games[g].fieldName === t.prefField) {
          // w[d].games[g].homeTeam = t.number;
          return g;
        }
      }
    }
  }
  return null;
}

function findTeamThatPrefsGame ( teamIdx, game){
  for (var n in nextPick){
    if (teamIdx === n)
      continue;

    if (teams[n].prefType === ePREF.DAY && teams[n].prefDay == game.day){
      console.log("team2 pref found: " + teams[n].prefType + ", teamIdx: " + n);
      return n;
    }
    else if (teams[n].prefType === ePREF.TIME && teams[n].prefTime == game.timeSlot){
      console.log("team2 pref found: " + teams[n].prefType + ", teamIdx: " + n);
      return n;
    }
    else if (teams[n].prefType === ePREF.DAY && teams[n].prefDay == game.day){
      console.log("team2 pref found: " + teams[n].prefType + ", teamIdx: " + n);
      return n;
    }
  }
  return null;
}

function fillGame(team1, team2, game){
  game.homeTeam = team1;
  game.awayTeam = team2;
  console.log("Game filled: " + game);
}

// object instantianions
var weekList = [];
var fields =  []; 
var timeslots = [];
var teams = [];
var nextPick = [];
var gamesList = [];

// generate schedule variables
for (var i = 0; i < numTeams; i++) {
  nextPick.push(i);
}
shuffleArray(nextPick);
console.log("nextPick = " + nextPick);

timeslots.push("early");
timeslots.push("late");
console.log(timeslots[0]);
console.log(timeslots[1]);

for (let i = 0; i < numTeams; i++) {
  teams.push(new Team());
  teams[i].name = String(i);
  teams[i].prefType = ePREF.DAY;
  if (i <= 6)
    teams[i].prefDay.push(eDAY.MON);
  else
    teams[i].prefDay.push(eDAY.TUES); 
}

fields[0] = {
  name : "field 0",
  days : [new Day(), new Day(), new Day(), new Day(), new Day(), new Day(), new Day()],
}
fields[0].days[0].games.push(new Game());
fields[0].days[0].games[0].timeSlot = timeslots[0];
fields[0].days[0].games[0].fieldName = fields[0].name;
fields[0].days[0].games[0].time = "1pm";
fields[0].days[0].games.push(new Game());
fields[0].days[0].games[1].timeSlot = timeslots[0];
fields[0].days[0].games[1].fieldName = fields[0].name;
fields[0].days[0].games[1].time = "2pm";

fields[0].days[1].games.push(new Game());
fields[0].days[1].games[0].timeSlot = timeslots[0];
fields[0].days[1].games[0].fieldName = fields[0].name;
fields[0].days[1].games[0].time = "1pm";
fields[0].days[1].games.push(new Game());
fields[0].days[1].games[1].timeSlot = timeslots[0];
fields[0].days[1].games[1].fieldName = fields[0].name;
fields[0].days[1].games[1].time = "2pm";

fields[1] = {
  name : "field 1",
  days : [new Day(), new Day(), new Day(), new Day(), new Day(), new Day(), new Day()],
}
fields[1].days[0].games.push(new Game());
fields[1].days[0].games[0].timeSlot = timeslots[0];
fields[1].days[0].games[0].fieldName = fields[1].name;
fields[1].days[0].games[0].time = "2pm";
fields[1].days[0].games.push(new Game());
fields[1].days[0].games[1].timeSlot = timeslots[1];
fields[1].days[0].games[1].fieldName = fields[1].name;
fields[1].days[0].games[1].time = "3pm";

fields[1].days[2].games.push(new Game());
fields[1].days[2].games[0].timeSlot = timeslots[0];
fields[1].days[2].games[0].fieldName = fields[1].name;
fields[1].days[2].games[0].time = "2pm";
fields[1].days[2].games.push(new Game());
fields[1].days[2].games[1].timeSlot = timeslots[1];
fields[1].days[2].games[1].fieldName = fields[1].name;
fields[1].days[2].games[1].time = "3pm";
console.log("fields len: " + fields.length);

// build the routine weekdays based on field schedules
var week = [];
var numGamesPerWeek = 0;
for (let d = 0; d < 7; d++){
  week.push(new Day());
  week[week.length - 1].name = d;
  console.log("-------- " + d);
  // for each field
  for (let fi = 0; fi < fields.length; fi++){
    if (!fields[fi].days[d].games.length)
      continue;
    console.log("name: " + fields[fi].name);
    console.log("g0 time: " + fields[fi].days[0].games[0].time);
    console.log("g1 time: " + fields[fi].days[0].games[1].time);
    
    for (let g = 0; g < fields[fi].days[0].games.length; g++){
      week[week.length - 1].games.push(fields[fi].days[0].games[g]);
      numGamesPerWeek++;
    }
  }
}
console.log("games each week " + numGamesPerWeek);

// for each week

for (let weekNum = 0; weekNum < numWeeks; weekNum ++){
  var newWeek = JSON.parse(JSON.stringify(week));
  weekList.push(newWeek);
}
console.log("weeks " + weekList.length);
console.log(weekList[0]);

// confirm days are constructed individually
console.assert(weekList[0][0].games[1].time === "2pm");
weekList[0][0].games[1].time = "9pm";
console.assert(weekList[0][0].games[1].time === "9pm");
console.assert(weekList[1][0].games[1].time === "2pm");

// manually add some games
// remove any blackout games/days

// start filling games

// week 1 scheduling
var week1NumGames = 0;
if (week1NumGames < numGamesPerWeek){ // change to while

  // find a game an a team that preferes it
  var game = findNextBestGame(teams[nextPick[0]], weekList[0]);
  console.log("pref game: " + game);
  if (game !== undefined){
    var team1 = nextPick.shift();
    nextPick.push(team1);
    var team2 = findTeamThatPrefsGame(team1, game);

    if (team2){ // two teams that match pref found
      fillGame(team1, team2, game);
    }
    else{ // default to last picking team with availability for team1/gameSlot
      ;

    }
  }
}

function App() {
  return (
    <div className="App">
      <NavBar></NavBar>

      <Dashboard></Dashboard>      
      
    </div>
  );
}

export default App;
