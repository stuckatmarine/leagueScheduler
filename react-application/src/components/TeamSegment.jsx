import React , { Component } from 'react'
import { Dropdown, Menu, Grid, Segment } from 'semantic-ui-react'
import IntDropdown from './IntDropdown';
import TeamComponent from './TeamComponent';

class TeamSegment extends Component {
  constructor(props) {
    super(props);

    var teams = [];
    for (var i = 1; i <= props.number; i++) {
      teams.push(<TeamComponent number={i} numPrefs={4} key = {i}></TeamComponent>);
    }

    this.state = {teams:teams};
  }

  render() {
    return (
        <Segment>
            <h2>Teams Info</h2>
            <Grid columns={4} >
                <Grid.Row>
                    <Grid.Column width={1}>
                    </Grid.Column>
                    <Grid.Column width={3}>
                        <h3>Team Name</h3>
                    </Grid.Column>
                    <Grid.Column>
                        <h3>Pref Type:</h3>
                    </Grid.Column>
                    <Grid.Column width={5}>
                        <h3>Days:</h3>
                    </Grid.Column>
                    <Grid.Column width={3}>
                        <h3>Timeslot:</h3>
                    </Grid.Column>
                </Grid.Row>

                {this.state.teams}
            </Grid>
        </Segment>
    );
  }
}

export default TeamSegment;
