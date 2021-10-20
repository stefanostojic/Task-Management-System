import React from 'react';
import { useState, useEffect } from 'react'
import {
  // BrowserRouter as Router,
  // Switch,
  // Route,
  // Link,
  // useRouteMatch,
  useParams
} from "react-router-dom";
import ProjectService from '../services/ProjectService';
// import TaskGroupService from '../services/TaskGroupService';
import TaskGroups from './TaskGroups';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles({
  root: {
    minWidth: 275,
    padding: 16,
    margin: 10,
    boxShadow: '2px 3px 7px 2px lightgrey'
  },
  label: {
    fontSize: 12,
    color: 'gray',
    margin: 0
  },
  title: {
    fontSize: 32,
    margin: 0
  },
  description: {
    fontSize: 14,
    color: 'darkgray',
    margin: 0
  }
});

const Project = (props) => {
  const classes = useStyles();
  let { projectId } = useParams();
  const [project, setProject] = useState();

  useEffect(() => {
    ProjectService.getById(projectId)
      .then(project => {
        setProject(project);
      });
  }, []);

  return (
    <div className={classes.root}>
      {project && <div>
        <p className={classes.label}>Project name:</p>
        <p className={classes.title}>{project.name}</p>
        <p className={classes.label}>Description:</p>
        <p className={classes.description}>{project.description}</p>

        <TaskGroups projectId={projectId} />
      </div>}
    </div>
  );
}

export default Project;