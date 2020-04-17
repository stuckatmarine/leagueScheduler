import React, { Component } from "react";
import { Grid } from "semantic-ui-react";

class Dashboard extends Component {
  render() {
    const { events, loading } = this.props;
    return (
      <Grid>
        <h1>Dashbaord</h1>
      </Grid>
    );
  }
}

export default Dashboard;
