import React from 'react';
import { useState } from 'react'
import { makeStyles } from '@material-ui/core/styles';
import TaskGroupService from '../services/TaskGroupService';

const useStyles = makeStyles({
  root: {
    minWidth: 275,
    maxWidth: 275,
    padding: 16,
    margin: 10,
    oveflowX: 'scroll',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center'
  },
  plusContainer: {
    width: '150px',
    height: '150px',
    fontSize: 100,
    backgroundColor: '#688df6',
    borderRadius: '100px',
    color: 'white',
    cursor: 'pointer'
  }
});

/**
 * A button for adding new projects. Opens a modal dialog form on click.
 */
const AddNewTaskGroup = ({onNewTaskCallback, projectId}) => {
  const classes = useStyles();
  const [showAddNewTaskGroup, setShowAddNewTaskGroup] = useState(false);
  const [newTaskGroupName, setNewTaskGroupName] = useState('');
  const [newTaskGroupDescription, setNewTaskGroupDescription] = useState('');

  const saveNewTaskGroup = () => {
    if (!isValidInput()) {
      alert('Input not valid');
      return;
    }

    TaskGroupService.post({
      name: newTaskGroupName, 
      description: newTaskGroupDescription,
      projectID: projectId
    }).then(newTaskGroup => {
      console.info('New task group added', newTaskGroup);
      onNewTaskCallback();
    });
    cancelNewTaskGroup();
  };
  const cancelNewTaskGroup = () => {
    setShowAddNewTaskGroup(false);
    setNewTaskGroupName('');
    setNewTaskGroupDescription('');
  };

  const isValidInput = () => {
    if ((newTaskGroupName != undefined && newTaskGroupName != null && newTaskGroupName.length > 1 && newTaskGroupName.length < 15) && 
      (newTaskGroupDescription != undefined && newTaskGroupDescription != null && newTaskGroupDescription.length > 1 && newTaskGroupDescription.length < 255)) {
      return true;
    } else {
      return false;
    }
  };

  return (
    <div className={classes.root}>
      <div className={classes.plusContainer} style={{ display: (showAddNewTaskGroup) ? 'none' : 'block' }} onClick={() => setShowAddNewTaskGroup(!showAddNewTaskGroup)}>
        <div className='text-center' style={{ lineHeight: '1.3em' }}>
          +
        </div>
      </div>
      <div style={{ display: (showAddNewTaskGroup) ? 'block' : 'none' }}>
        <div className="form-group mt-5">
          <label>New task group</label>

          <input type="text" className="form-control" placeholder="Name" value={newTaskGroupName} onChange={(e) => setNewTaskGroupName(e.target.value)} />
          <small className="form-text text-muted mb-3">The task group name must be between 1 and 15 letters long.</small>
          
          <input type="text" className="form-control" placeholder="Description" value={newTaskGroupDescription} onChange={(e) => setNewTaskGroupDescription(e.target.value)} />
          <small className="form-text text-muted mb-3">The task group description must be between 1 and 255 letters long.</small>
          
          <button className='btn btn-danger float-left' onClick={() => cancelNewTaskGroup()}>Cancel</button>
          <button className='btn btn-primary float-right' onClick={() => saveNewTaskGroup()}>Add</button>
        </div>
      </div>
    </div>
  );
}

export default AddNewTaskGroup;