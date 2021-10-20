import React from 'react';
import { useState, useEffect } from 'react'
import {
  Link,
  // BrowserRouter as Router,
  // Switch,
  // Route,
  // Link,
  // useRouteMatch,
  useParams
} from "react-router-dom";
import TaskService from '../services/TaskService';
import TaskCard from './TaskCard';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles({
  root: {
    width: 300,
    height: '70vh',
    margin: 10,
    boxShadow: '2px 3px 7px 2px lightgrey',
    position: 'relative',
    overflowY: 'scroll'
  },
  subRoot1: {

  },
  subRoot2: {
    padding: 12,
    '&:hover $edit2': {
      visibility: 'block',
    }
  },
  label: {
    fontSize: 12,
    color: '#b0b0b0',
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
  },
  addNewTaskButton: {
    padding: 6,
    boxShadow: '2px 3px 7px 2px lightgrey',
    marginTop: 12,
    borderRadius: 4,
    textAlign: 'center',
    color: 'white',
    backgroundColor: '#007bff',
    cursor: 'pointer'
  },
  edit: {
    color: 'darkgray',
    backgroundColor: 'lightgray',
    fontSize: 12,
    borderRadius: 30,
    width: 'fit-content',
    paddingLeft: 12,
    paddingRight: 12,
    cursor: 'pointer',
    visibility: 'none',
    marginTop: 5,
    '&:hover': {
      filter: 'brightness(1.1)'
    },
  }
});

const TaskGroup = ({ taskGroup }) => {
  const classes = useStyles();
  let { projectId } = useParams();
  const [tasks, setTasks] = useState([]);
  const [mouseOver, setMouseOver] = useState(false);

  useEffect(() => {
    TaskService.get({ taskGroupId: taskGroup.id, pageNumber: 1, pageSize: 200 })
      .then(data => {
        setTasks(data.items);
      });
  }, []);

  return (
    <div className={classes.root}>

      <div className={classes.subRoot2} onMouseEnter={() => setMouseOver(true)} onMouseLeave={() => setMouseOver(false)}>
        <p className={classes.title}>{taskGroup.name}</p>
        <p className={classes.description}>{taskGroup.description}</p>

        {mouseOver && (
          <Link to={`/projects/${projectId}/taskGroups/${taskGroup.id}/edit`}>
            <div className={classes.edit}>Edit</div>
          </Link>
        )}
      </div>

      <div className={classes.subRoot2}>
        {tasks && tasks.map(task => (
          <TaskCard key={task.id} task={task} />
        ))}
        {tasks && tasks.length === 0 && (
          <p className={classes.description} style={{ marginTop: '15px' }}>No tasks yet.</p>
        )}
        <Link to={`/projects/${projectId}/taskGroups/${taskGroup.id}/tasks/add`} >
          <div className={classes.addNewTaskButton}>
            Add new task
          </div>
        </Link>
      </div>



    </div>
  );
}

export default TaskGroup;