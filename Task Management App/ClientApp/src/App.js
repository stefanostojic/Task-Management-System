import React from 'react';
import { useState, useEffect } from 'react'
// import { Route } from 'react-router';
// import Navigation from './components/Navigation';
// import {
//   BrowserRouter as Router,
//   Switch,
//   Route,
//   Link,
//   useRouteMatch,
//   useParams
// } from "react-router-dom";

import './custom.css'
import ProjectService from './services/ProjectService';
import ProjectCard from './components/ProjectCard';
import Container from '@material-ui/core/Container';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';

const useStyles = makeStyles((theme) => ({
  root: {
    marginTop: 36,
    flexGrow: 1
  },
  paper: {
    height: 140,
    width: 100,
  },
  control: {
    padding: theme.spacing(2),
  },
}));

const App = () => {
  const [projects, setProjects] = useState([]);
  const [spacing, setSpacing] = React.useState(5);
  const classes = useStyles();

  useEffect(() => {
    ProjectService.get().then((data) => {
      console.log({ projects });
      setProjects(data.items)
    });
  }, []);

  return (
    <Container>

      <Grid container className={classes.root} spacing={5}>
        <Grid item xs={12}>
          <Grid container justify="center" spacing={spacing}>
            <ProjectCard
              key={123}
              project={{name: 'Dodaj novi', descriptio: 'Kreiranje novog projekta.'}} />
            {projects && projects.map((project) => {
              return <ProjectCard
                key={project.id}
                project={project} />
            })}
          </Grid>
        </Grid>
      </Grid>
    </Container>
  );
}

export default App;
