import React , { Component } from 'react'
import { Dropdown, Menu } from 'semantic-ui-react'

class IntDropdown extends Component {
  constructor(props) {
    super(props);

    var val = props.rangeLow;
    var options = [];
    for (var i = 1; i <= props.rangeHigh - props.rangeLow; i++) {
      options = options.concat({ key: i, text: String(val), value: val });
      val++;
    }

    this.state = {text_show:props.rangeLow};
    this.state = {values:options};
  }
  myChangeHandler = (event) => {
    this.setState({text_show:event.target.value});
  }

  render() {
    return (
      <Menu compact>
        <Dropdown text={this.state.text_show} options={this.state.values}
                  onChange={this.myChangeHandler} simple item />
      </Menu>
    );
  }
}

// const IntDropdown = () => (
//   <Menu compact>
//     <Dropdown text='Dropdown' options={options} simple item />
//   </Menu>
// )

export default IntDropdown
