import React, { Component } from "react";
import { Grid } from "semantic-ui-react";

class IntForm extends Component {
    constructor(props) {
      super(props);
      this.state = props.dflt ? { val:props.dflt } : { val: 0 };
    }
    myChangeHandler = (event) => {
      this.setState({val: event.target.value});
    }

    render() {
    return (
        <form>
            <input defaultValue={this.state.val}
            type='input integer here'
            onChange={this.myChangeHandler}
            />
        </form>
    );
    }
}

export default IntForm;
