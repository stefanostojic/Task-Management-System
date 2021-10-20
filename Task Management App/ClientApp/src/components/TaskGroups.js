// import { Button } from 'bootstrap';
import React from 'react';
import { useState, useEffect } from 'react'
import TaskGroupService from '../services/TaskGroupService';
import TaskGroup from './TaskGroup';
import AddNewTaskGroup from './AddNewTaskGroup';
// import { makeStyles } from '@material-ui/core/styles';

// const useStyles = makeStyles({
//   root: {
//     minWidth: 275,
//     maxWidth: 275,
//     padding: 16,
//     margin: 10,
//     oveflowX: 'scroll',
//     display: 'flex',
//     alignItems: 'center',
//     justifyContent: 'center'
//   }
// });

/**
 * Displays all task groups for a given projectId.
 * 
 * Contains: 'TaskGroup'
 * 
 * @param {string} projectId  
 */
const TaskGroups = ({ projectId }) => {
  const [taskGroups, setTaskGroups] = useState([]);
  // const classes = useStyles();

  useEffect(() => {
    fetchTaskGroups();
  }, []);

  const fetchTaskGroups = () => {
    TaskGroupService.getByProjectId(projectId)
      .then(items => {
        setTaskGroups(items);
      });
  };

  return (
    <div style={{ width: '100%', overflowX: 'scroll' }}>
      <div className="d-flex flex-row" style={{ width: 'fit-content' }}>
        {taskGroups && taskGroups.map(taskGroup => (
          <TaskGroup key={taskGroup.id} taskGroup={taskGroup} />
        ))}
        <AddNewTaskGroup onNewTaskCallback={() => fetchTaskGroups()} projectId={projectId} />
      </div>
      {taskGroups && taskGroups.length === 0 && (
        <p>No task groups yet.</p>
      )}
    </div>
  );
}

export default TaskGroups;