import React from 'react';
import { useState, useEffect } from 'react'
import {
  BrowserRouter as Router,
  // Switch,
  Route,
  Link,
  useRouteMatch,
  useParams
} from "react-router-dom";
import TaskService from '../services/TaskService';
import { makeStyles } from '@material-ui/core/styles';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Switch from '@material-ui/core/Switch';
import TextField from '@material-ui/core/TextField';
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
  },
  plus: {

  }
});

/**
 * A screen for creating and editing tasks.
 */
const EditTaskGroup = (props) => {
  let { projectId, taskGroupId, action } = useParams();
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const classes = useStyles();

  useEffect(() => {
    console.log('action', action);

    TaskGroupService.getById(taskGroupId)
      .then(taskGroup => {
        setName(taskGroup.name);
        setDescription(taskGroup.description);
      }).catch(error => {
        alert('Can\'t find the requested task group');
        props.history.goBack();
      });

  }, []);

  const save = () => {
    TaskGroupService.put({
      id: taskGroupId,
      name,
      description,
      projectID: projectId
    }).then(taskGroup => {
      console.info('Task group updated', taskGroup);

      if (taskGroup) {
        props.history.goBack();
      }
    }).catch(error => {
      console.error(error);
    });
  };

  const deleteHandler = () => {
    TaskGroupService.delete(taskGroupId)
      .then(() => {
        console.log(`Task group ${name} deleted.`);
        props.history.goBack();
      });
  }

  const cancel = () => {
    props.history.goBack();
  };

  return (

    <div className='row m-0'>
      <div className='col-12 col-md-4 offset-md-4'>
        <div className="form-group mt-5">
          <label style={{ fontSize: 32 }}>Edit task group</label>

          <input type="text" className="form-control" placeholder="Name" value={name} onChange={(e) => setName(e.target.value)} />
          <small className="form-text text-muted mb-3">The task name must be between 1 and 15 letters long.</small>

          <input type="text" className="form-control" placeholder="Description" value={description} onChange={(e) => setDescription(e.target.value)} />
          <small className="form-text text-muted mb-3">The task description must be between 1 and 255 letters long.</small>

          <div>
            <Link to={`/projects/${projectId}`}>
              <button className='btn btn-danger float-left' onClick={() => deleteHandler()}>Delete</button>
            </Link>
            <button className='btn btn-primary float-right' onClick={() => save()}>Save</button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default EditTaskGroup;