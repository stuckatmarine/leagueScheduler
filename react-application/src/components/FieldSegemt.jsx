import React , { Component } from 'react'
import { Dropdown, Menu, Grid, Segment } from 'semantic-ui-react'
import IntDropdown from './IntDropdown';
import FieldComponent from './FieldComponent';

class FieldSegment extends Component {
  constructor(props) {
    super(props);

    var fields = [];
    for (var i = 1; i <= props.number; i++) {
      fields.push(<FieldComponent number={i} key = {i}></FieldComponent>);
    }

    this.state = {fields:fields};
  }

  render() {
    return (
        <Segment>
            <h2>Field Info</h2>
            <Grid columns={3} >
                {this.state.fields}
            </Grid>
        </Segment>
    );
  }
}

export default FieldSegment;
