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


const useStyles = makeStyles({
  root: {
    minWidth: 275,
    maxWidth: 275,
    padding: 16,
    margin: 10,
    oveflowX: 'scroll',
    // boxShadow: '2px 3px 7px 2px lightgrey',
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
const AddTask = (props) => {
  let { projectId, taskGroupId, taskId, action } = useParams();
  const [Name, setName] = useState('');
  const [Description, setDescription] = useState('');
  const [Finished, setFinished] = useState(false);
  const [DueDate, setDueDate] = useState(new Date(Date.now()).toISOString().substring(0, 16));
  const classes = useStyles();

  useEffect(() => {
    // console.log('action', action);
    if (action === 'edit') {
      TaskService.getById(taskId)
        .then(task => {
          console.log(task);
          setName(task.name);
          setDescription(task.description);
          setFinished(task.finished);
          setDueDate(new Date(task.dueDate).toISOString().substring(0, 16));
          console.log('Setting the original date to: ', new Date(task.dueDate).toISOString().substring(0, 16));
        })
        .catch(error => {
          alert('Task was not found');
          props.history.goBack();
        });

    }
  }, []);

  const saveTask = () => {
    if (DueDate === null || DueDate === undefined) {
      alert('Due date must be set.');
    }
    if (DueDate < Date.now()) {
      alert('Due date can\'t be in the past')
    }

    if (action === undefined) {
      console.log('posting a new task')
      TaskService.post({
        name: Name,
        description: Description,
        finished: Finished,
        dueDate: DueDate,
        taskGroupID: taskGroupId
      }).then(Task => {
        console.info('New task added', Task);

        if (Task) {
          props.history.goBack()
        }
      });
    } else if (action === 'edit') {
      console.log('editing a task')
      TaskService.put({
        id: taskId,
        name: Name,
        description: Description,
        finished: Finished,
        dueDate: new Date(Date.parse(DueDate)).toISOString(),
        taskGroupID: taskGroupId
      }).then(Task => {
        console.info('Task edited', Task);

        if (Task) {
          props.history.goBack();
        }
      });
    }
  };

  const cancelTask = () => {
    props.history.goBack();
  };

  const deleteTask = () => {
    TaskService.delete(taskId).then(() => {
      props.history.goBack();
    })
  };

  return (

    <div className='row m-0'>
      <div className='col-12 col-md-4 offset-md-4'>
        <div className="form-group mt-5">
          <label style={{ fontSize: 32 }}>{(action === 'edit') ? 'Edit task' : 'New task'}</label>

          <input type="text" className="form-control" placeholder="Name" value={Name} onChange={(e) => setName(e.target.value)} />
          <small className="form-text text-muted mb-3">The task name must be between 1 and 15 letters long.</small>

          <input type="text" className="form-control" placeholder="Description" value={Description} onChange={(e) => setDescription(e.target.value)} />
          <small className="form-text text-muted mb-3">The task description must be between 1 and 255 letters long.</small>

          <FormControlLabel
            control={
              <Switch
                checked={Finished}
                onChange={(event) => setFinished(event.target.checked)}
                name="checkedB"
                color="primary"
              />
            }
            label="Finished"
          />


          <div className='mb-5'>

            <TextField
              id="datetime-local"
              type="datetime-local"
              className={classes.textField}
              value={DueDate}
              InputLabelProps={{
                shrink: true,
              }}
              onChange={(event) => setDueDate(new Date(Date.parse(event.target.value)).toISOString().substring(0, 16))}
            />
          </div>

          <div>
            {(action !== 'edit') && <Link to={`projects/${projectId}`}>
              <button className='btn btn-danger float-left' onClick={() => cancelTask()}>Cancel</button>
            </Link>}
            {(action === 'edit') && (
              <button className='btn btn-danger float-left' onClick={() => deleteTask()}>Delete</button>
            )}
            <button className='btn btn-primary float-right' onClick={() => saveTask()}>{(action === 'edit') ? 'Save changes' : 'Save new'}</button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default AddTask;