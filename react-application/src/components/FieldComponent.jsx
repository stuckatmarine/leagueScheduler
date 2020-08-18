import React , { Component } from 'react'
import { Dropdown, Menu, Grid, Button } from 'semantic-ui-react'
import TextForm from './TextForm';

class FieldComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {num : props.number};
  }

  render() {
    return (
        <Grid.Row>
            <Grid.Column>
                <h3># {this.state.num} :</h3><TextForm></TextForm>
            </Grid.Column>
            <Grid.Column>
                <h3>Pref Type:</h3>
                <Button>One</Button>
                <Button>Two</Button>
                <Button>Three</Button>
            </Grid.Column>
            <Grid.Column>
                <h3>col3</h3><TextForm></TextForm>
            </Grid.Column>
        </Grid.Row>
    );
  }
}

export default FieldComponent;
