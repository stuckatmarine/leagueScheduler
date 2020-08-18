import React from 'react'
import { Button, Grid } from 'semantic-ui-react'

const ButtonFloated = (props) => (
  // <Grid>
    <Button.Group>
      <h2>{props.label}</h2>
      <Button>One</Button>
      <Button>Two</Button>
    </Button.Group>
  // </Grid>
)

export default ButtonFloated