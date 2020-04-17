import React, { Component, Fragment } from "react";
import { Menu, Container, Button } from "semantic-ui-react";

class NavBar extends Component {
  render() {

    return (
      <Menu inverted fixed="top">
        <Container>
          <h2> Nave bar</h2>
        </Container>
      </Menu>
    );
  }
}

export default NavBar;
