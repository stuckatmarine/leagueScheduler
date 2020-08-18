import React , { Component } from 'react'
import { Dropdown, Menu, Grid, Button } from 'semantic-ui-react'
import TextForm from './TextForm';

class TeamComponent extends Component {
  constructor(props) {
    super(props);

    var temp_prefs = [
        {key:1 , value:false, text:'None'},
        {key:2 , value:false, text:'Day'},
        {key:3 , value:false, text:'Time'},
        {key:4 , value:false, text:'Field'}
    ];

    var temp_days = [
        {key:1 , value:false, text:'M'},
        {key:2 , value:false, text:'T'},
        {key:3 , value:false, text:'W'},
        {key:4 , value:false, text:'R'},
        {key:5 , value:false, text:'F'},
        {key:6 , value:false, text:'S'},
        {key:7 , value:false, text:'Su'},
    ];

    var temp_times = [
        {key:1 , value:false, text:'Early'},
        {key:2 , value:false, text:'Late'},
    ];

    var temp_fields = [];
    for (let i = 0; i < props.numFields; i ++)
    {
        temp_fields.push({key:i+1 , value:false, text:String(i)});
    }

    this.state = { num : props.number, prefs : temp_prefs, active:false,
                    numPrefs:props.numPrefs, days: temp_days, times : temp_times,
                    fields:temp_fields};
  }

  prefHandler = (key) => {
    if (key == 1){
        this.state.prefs[1].value = false;
        this.state.prefs[2].value = false;
        this.state.prefs[3].value = false;
    }
    else
        this.state.prefs[0].value = false;
        
    this.state.prefs[key-1].value = !this.state.prefs[key-1].value;
    this.setState(({ active: this.state.prefs[key-1].value }))
    // console.log(this.state.prefs[key-1].value);
  }

  renderPrefButtons = (state) => {
    const buttons = [];

    for( let i = 0; i < state.numPrefs; i++) {
       buttons.push(
        <Button key = {i} toggle size='mini'
                active={state.prefs[i].value}
                onClick={(key) => this.prefHandler(state.prefs[i].key)}>
                {state.prefs[i].text}
        </Button>
      )
    }
    return buttons;
  }

  dayHandler = (key) => {
    this.state.days[key-1].value = !this.state.days[key-1].value;
    this.setState(({ active: this.state.days[key-1].value }))
    // console.log(this.state.prefs[key-1].value);
  }

  renderDayButtons = (state) => {
    const buttons = [];

    for( let i = 0; i < 7; i++) {
       buttons.push(
        <Button key = {i} toggle size='mini'
                active={state.days[i].value}
                onClick={(key) => this.dayHandler(state.days[i].key)}>
                {state.days[i].text}
        </Button>
      )
    }
    return buttons;
  }

  timeHandler = (key) => {
    this.state.times[key-1].value = !this.state.times[key-1].value;
    this.setState(({ active: this.state.times[key-1].value }))
    // console.log(this.state.prefs[key-1].value);
  }

  renderTimeButtons = (state) => {
    const buttons = [];

    for( let i = 0; i < 2; i++) {
       buttons.push(
        <Button key = {i} toggle size='mini'
                active={state.times[i].value}
                onClick={(key) => this.timeHandler(state.times[i].key)}>
                {state.times[i].text}
        </Button>
      )
    }
    return buttons;
  }

  render() {
    return (
        <Grid.Row>
            <Grid.Column width={1}>
                <h3># {this.state.num} :</h3>
            </Grid.Column>
            <Grid.Column width={3}>
                <TextForm></TextForm>
            </Grid.Column>
            <Grid.Column>
                {this.renderPrefButtons(this.state)}
            </Grid.Column>
            <Grid.Column width={5}> 
                {this.renderDayButtons(this.state)}
            </Grid.Column>
            <Grid.Column width={3}> 
                {this.renderTimeButtons(this.state)}
            </Grid.Column>
        </Grid.Row>
    );
  }

  
}

export default TeamComponent;
