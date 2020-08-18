import React, { Component } from "react";
import { Grid } from "semantic-ui-react";

class TextForm extends Component {
    constructor(props) {
      super(props);
      this.state = props.dflt ? { text:props.dflt } : { text: '' };
    }
    myChangeHandler = (event) => {
      this.setState({text: event.target.value});
    }

    render() {
    return (
        <form>
            <input defaultValue={this.state.text}
            type='input text here'
            onChange={this.myChangeHandler}
            />
        </form>
    );
    }
}

export default TextForm;
