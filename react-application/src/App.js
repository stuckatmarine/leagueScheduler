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
  DAY: 'day',
  TIME: 'time',
  FIELD: 'field',
  NONE: 'none',
}

const eDAY = {
  MON : "monday",
  TUES : "tuesday",
  WED : "wednesday",
  THUR : "thursday",
  FRI : "friday",
  SAT : "saturday",
  SUN : "sunday",
  NONE : "none"
}

var numTeams = 12;
var numWeeks = 10;
var maxGamesPerTeam = 20;
var numFields = 2;
var weeklyGames = 8;
var numPrefGames = 0;
var totalGames = maxGamesPerTeam * numTeams;

function Field() {
  this.availability = [];
  this.name = "";
  this.games = [];
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
  this.fields = [];
}

function findInArr(arr, day){
  for (var i=0; i < arr.length; i++) {
    if (arr[i].name === day) {
        return true;;
    }
  }
  return false;
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
  availability : [eDAY.MON, eDAY.TUES],
  name : "field 0",
  games : [],
}
fields[0].games.push(new Game());
fields[0].games[0].timeSlot = timeslots[0];
fields[0].games[0].fieldName = fields[0].name;
fields[0].games[0].time = "1pm";
fields[0].games.push(new Game());
fields[0].games[1].timeSlot = timeslots[0];
fields[0].games[1].fieldName = fields[0].name;
fields[0].games[1].time = "2pm";

fields[1] = {
  availability : [eDAY.MON, eDAY.WED],
  name : "field 1",
  games : [],
}
fields[1].games.push(new Game());
fields[1].games[0].timeSlot = timeslots[1];
fields[1].games[0].fieldName =fields[1].name;
fields[1].games[0].time = "5pm";
fields[1].games.push(new Game());
fields[1].games[1].timeSlot = timeslots[1];
fields[1].games[1].fieldName = fields[1].name;
fields[1].games[1].time = "6pm";
console.log("fields len: " + fields.length);

// build the routine weekdays based on field schedules
var week = [];
for (var d in eDAY){
  week.push(new Day());
  console.log(d);
  // for each field
  for (let fi = 0; fi < fields.length; fi++){
    console.log(fields[fi].name);
    console.log(fields[fi].games[0].time);
    console.log(fields[fi].games[1].time);
    if (findInArr(fields[fi].availability, d) && !findInArr(week, d)){
      week.push(new Day());
    }

    // for each game that day
    for (let g = 0; g < fields[fi].games.length; g++){
      week.push(fields[fi].games[g]);
    }
  }
}





// for each week
// for (let weekNum = 0; weekNum < numWeeks; weekNum ++){
//   weekList.push(Week);
  
//   // add each day in the week that has games

// }

function App() {
  return (
    <div className="App">
      <NavBar></NavBar>

      <Dashboard></Dashboard>      
      
    </div>
  );
}

export default App;
